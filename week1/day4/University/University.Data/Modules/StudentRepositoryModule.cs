using Autofac;
namespace University.Data.Modules
{
    public class StudentRepositoryModule : Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            builder.RegisterAssemblyTypes(typeof(StudentRepositoryModule).Assembly)
                   .Where(t => t.Name.EndsWith("StudentRepository"))
                   .AsImplementedInterfaces()
                   .PropertiesAutowired();
        }
    }
}