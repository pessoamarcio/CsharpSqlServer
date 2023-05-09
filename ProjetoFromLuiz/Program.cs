using ProjetoFromLuiz.Data;
using Microsoft.EntityFrameworkCore;
using ProjetoFromLuiz.Repository.Interfaces;
using ProjetoFromLuiz.Repository;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Hosting;

namespace ProjetoFromLuiz
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var host = Host.CreateDefaultBuilder(args)
                .ConfigureWebHostDefaults(webBuilder =>
                {
                    webBuilder.UseStartup<Startup>();
                })
                .Build();

            host.Run();
        }
    }
}
