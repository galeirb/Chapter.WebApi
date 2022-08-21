using Chapter.WebApi.Contexts;
using Chapter.WebApi.Repositories;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Chapter.WebApi
{
    public class Startup
    {
        // Chamado pelo host antes do método Configure para configurar os serviços do aplicativo
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddScoped<ChapterContext, ChapterContext>();
            services.AddControllers();
            services.AddTransient<LivroRepository,LivroRepository> ();
        }

        // O método Configure é usado para especificar como o aplicativo responde às solicitações HTTP.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseRouting();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
