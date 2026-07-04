using Autofac;
using Autofac.Extensions.DependencyInjection;
using Microsoft.EntityFrameworkCore;
using University.API;
using University.Core.Modules;
using University.Data;
using University.Data.Modules;
using AutoWrapper;
using University.Data.Entities;
using Microsoft.AspNetCore.Identity;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers(options =>
{
    options.Filters.Add<ApiExceptionFilter>();
});

builder.Services.AddDbContext<UniversityDbContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));

builder.Services.AddIdentity<ApplicationUser, IdentityRole>()
    .AddEntityFrameworkStores<UniversityDbContext>()
    .AddDefaultTokenProviders();

builder.Host.UseServiceProviderFactory(new AutofacServiceProviderFactory());

builder.Host.ConfigureContainer<ContainerBuilder>(container =>
{
    container.RegisterModule(new CourseRepositoryModule());
    container.RegisterModule(new StudentRepositoryModule());
    container.RegisterModule(new CourseServiceModule());
    container.RegisterModule(new StudentServiceModule());
    container.RegisterModule(new AuthServiceModule());
});
var app = builder.Build();
if (app.Environment.IsDevelopment())
{
    app.MapOpenApi();
}

app.UseApiResponseAndExceptionWrapper();
app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
