using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Threading.Tasks;
using CloudMovies.Context.Databases;
using CloudMovies.Database.Repositories;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;

namespace CloudMovies.Service
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddMvc();

            var configurationSection = Configuration.GetSection("ConnectionStrings:MovieDatabase");
            services.AddDbContext<CloudMoviesContext>(options => 
                options.UseSqlServer(
                    configurationSection.Value,
                    a => a.MigrationsAssembly(this.GetType().GetTypeInfo().Assembly.FullName)));

            services.AddTransient<IActorRepository, ActorRepository>();
            services.AddTransient<IMovieRepository, MovieRepository>();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseMvc();
        }
    }
}
