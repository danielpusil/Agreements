using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Domain;
using Infrastructure;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;

namespace WebApiAgreement
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var hostserver = CreateHostBuilder(args).Build();
            //Se realiza la migración hacia la base de datos
            using(var environment = hostserver.Services.CreateScope()){
                var services = environment.ServiceProvider;
                try{
                    var userManager = services.GetRequiredService<UserManager<User>>();
                    var context = services.GetRequiredService<AgreementContext>();
                    context.Database.Migrate();
                    DataTest.InsertData(context, userManager).Wait();
                }catch(Exception e){
                    var logging = services.GetRequiredService<ILogger<Program>>();
                    logging.LogError(e, "Ocurrio un error en la migración");
                }
                
            }
            hostserver.Run();

        }

        public static IHostBuilder CreateHostBuilder(string[] args) =>
            Host.CreateDefaultBuilder(args)
                .ConfigureWebHostDefaults(webBuilder =>
                {
                    webBuilder.UseStartup<Startup>();
                });
    }
}
