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
            builder.RegisterType<Starter>();
            builder.RegisterType<Logger>();

            var container = builder.Build();

            return container;
        }
    }
}
