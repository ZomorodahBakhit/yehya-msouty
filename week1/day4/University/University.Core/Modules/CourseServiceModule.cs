using Autofac;

namespace University.Core.Modules
{
    public class CourseServiceModule : Module
    {

        protected override void Load(ContainerBuilder builder)
        {
            builder.RegisterAssemblyTypes(typeof(CourseServiceModule).Assembly)
            .Where(t => t.Name.EndsWith("CourseService"))
            .AsImplementedInterfaces()
            .PropertiesAutowired();
        }
    }
}
