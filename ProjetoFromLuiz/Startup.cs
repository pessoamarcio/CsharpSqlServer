using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using System;
using ProjetoFromLuiz.Data;
using ProjetoFromLuiz.Repository;
using ProjetoFromLuiz.Repository.Interfaces;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProjetoFromLuiz
{
    public class Startup
    {
        private readonly IConfiguration _configuration;

        public Startup(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        public void ConfigureServices(IServiceCollection services)
        {
            services.AddDbContext<SistemaPessoasDBContext>(options =>
                options.UseSqlServer(_configuration.GetConnectionString("DataBase")));

            services.AddScoped<IPessoaRepository, PessoaRepository>();
            services.AddControllers().AddNewtonsoftJson();

        }

        public void Configure(IApplicationBuilder app, SistemaPessoasDBContext dbContext)
        {

            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseAuthentication();

          
            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });

            dbContext.Database.EnsureCreated();
        }
    }
}
