using EntityLayer.Concrete;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OgrenciBilgiSistemi
{
    public class Program
    {
        public static async Task Main(string[] args)
        {
            var host = CreateHostBuilder(args).Build();

            
            using (var scope = host.Services.CreateScope())
            {
                var serviceProvider = scope.ServiceProvider;
                var userManager = serviceProvider.GetRequiredService<UserManager<Kullanicilar>>();
                var roleManager = serviceProvider.GetRequiredService<RoleManager<Rol>>();

                //Default Role
                if (!roleManager.Roles.Any())
                {
                    roleManager.CreateAsync(new Rol()
                    {
                        Name = "Admin",
                    }).Wait();
                    roleManager.CreateAsync(new Rol()
                    {
                        Name = "Öğrenci",
                    }).Wait();

                }

              //Default Admin
                if (!userManager.Users.Any())
                {

                    userManager.CreateAsync(new Kullanicilar
                    {
                        UserName = "Admin",
                        Email = "admin@gmail.com",
                        Kimlik = new OBSEntityLayer.NewConcrete.Kimlik()
                        {
                            Iletisim = new OBSEntityLayer.NewConcrete.Iletisim()
                        }
                    }, "12345aA*").Wait();

                    Kullanicilar admin = await userManager.FindByNameAsync("Admin");
                    userManager.AddToRoleAsync(admin, "Admin").Wait();
                }
            }

            host.Run();
        }

        public static IHostBuilder CreateHostBuilder(string[] args) =>
            Host.CreateDefaultBuilder(args)
                .ConfigureWebHostDefaults(webBuilder =>
                {
                    webBuilder.UseStartup<Startup>();
                });
    }
}
