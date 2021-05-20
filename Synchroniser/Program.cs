using System;
using System.Threading.Tasks;
using Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Mapping;
using Interfaces.Services;
using Services;

namespace Synchroniser
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Starting synchroniser");

            using IHost host = CreateHostBuilder(args).Build();
            var context = host.Services.GetService<DataContext>();

            try
            {
                context.Database.EnsureCreated();
                context.Database.Migrate();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
            }

            host.Run();
        }


        static IHostBuilder CreateHostBuilder(string[] args)
        {
            var connectionString = @"Server=db;Database=master;User=sa;Password=Your_password123;";

            var host = Host.CreateDefaultBuilder(args);

            host.ConfigureServices((_, services) =>
                      services.AddHttpClient()
                      .AddHostedService<Synchroniser>()
                      .AddDbContext<DataContext>(opt => opt.UseSqlServer(connectionString))
                      .AddAutoMapper(typeof(Mapping.MapBase).Assembly)
                      .AddScoped<ICharacterService, CharacterService>()
                      );
            
            host.ConfigureLogging(logging =>
            {
                logging.ClearProviders();
                logging.AddConsole();
            });

            return host;
        }

    }
}
