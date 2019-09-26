using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.EntityFrameworkCore;
using Server.Data;
using Server.Repositories;

namespace Server
{
    public class Startup
    {
        private IConfiguration _configuration;

        public Startup(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        public void ConfigureServices(IServiceCollection services)
        {
            services.AddTransient<ITextRepository,TextRepository>();

            services.AddDbContext<TextContext>(options =>
                  options.UseSqlite("Data Source=SimpleDatabase.db"));

            services.AddMvc();
        }

        public void Configure(IApplicationBuilder app,IHostingEnvironment env, TextContext context)
        {
            context.Database.EnsureDeleted();
            context.Database.EnsureCreated();

            if(env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseMvc();
        }
    }
}
