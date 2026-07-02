using Autofac;
namespace University.Data.Modules
{
    public class CourseRepositoryModule : Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            builder.RegisterAssemblyTypes(typeof(CourseRepositoryModule).Assembly)
                  .Where(t => t.Name.EndsWith("CourseRepository"))
                  .AsImplementedInterfaces()
                  .PropertiesAutowired();
        }
    }
}
