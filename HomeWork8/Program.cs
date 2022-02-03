using HomeWork8;
using Autofac;

DependencyInjection dependencyInjection = new DependencyInjection();
var container = dependencyInjection.SetDI();
var starter = container.Resolve<Starter>();

starter.Run();