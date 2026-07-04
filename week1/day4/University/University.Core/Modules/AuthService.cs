using Autofac;
using University.Core.Services;

public class AuthServiceModule : Module
{
    protected override void Load(ContainerBuilder builder)
    {
        builder.RegisterType<AuthService>()
            .As<IAuthService>()
            .InstancePerLifetimeScope();
    }
}