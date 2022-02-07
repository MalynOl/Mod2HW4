using Autofac;

namespace HomeWork8
{
    public class DependencyInjection
    {
        public IContainer SetDI()
        {
            var builder = new ContainerBuilder();
            builder.RegisterType<Action>().As<IAction>();
            builder.RegisterType<ConfigService>().As<IConfigService>();
            builder.RegisterType<FileService>().As<IFileService>();
            builder.RegisterType<NotificationService>().As<INotificationService>();
            builder.RegisterType<Logger>().As<ILogger>();
            builder.RegisterType<Starter>();

            var container = builder.Build();

            return container;
        }
    }
}
