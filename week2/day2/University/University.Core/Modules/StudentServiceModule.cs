using Autofac;

namespace University.Core.Modules
{
    public class StudentServiceModule : Module
    {

        protected override void Load(ContainerBuilder builder)
        {
            builder.RegisterAssemblyTypes(typeof(StudentServiceModule).Assembly)
            .Where(t => t.Name.EndsWith("StudentService"))
            .AsImplementedInterfaces()
            .PropertiesAutowired();
        }
    }
}
