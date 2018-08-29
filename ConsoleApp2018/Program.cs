using Microsoft.Extensions.DependencyInjection;
using VideoApp.Core.ApplicationService;
using VideoApp.Core.ApplicationService.Implementation;
using VideoApp.Core.DomainService;
using VideoApp.Infrastructure.Static.Data.Repositories;

namespace ConsoleApp2018
{
    class Program
    {
        static void Main()
        {
            var serviceCollection = new ServiceCollection();
            serviceCollection.AddScoped<IVideoRepository, VideoRepository>();
            serviceCollection.AddScoped<IVideoService, VideoService>();
            serviceCollection.AddScoped<IConsolePrinter, ConsolePrinter>();

            var serviceProvider = serviceCollection.BuildServiceProvider();
            var printer = serviceProvider.GetRequiredService<IConsolePrinter>();

            printer.ChooseMenuItem();
        }
    }
}