
using Microsoft.EntityFrameworkCore;
using SuperHeroes.Data;
using SuperHeroes.ExceptionMiddleware;
using SuperHeroes.Interfaces;
using SuperHeroes.Repositories;
using SuperHeroes.Services;

namespace SuperHeroes
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.

            builder.Services.AddControllers();
            builder.Services.AddScoped<IHeroiRepository, HeroiRepository>();
            builder.Services.AddScoped<IHeroiService, HeroiService>();
            // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();
            builder.Services.AddCors(options => options.AddPolicy(name: "HeroiOrigins",
                policy =>
                {
                    policy.WithOrigins("http://localhost:4200")
                        .AllowAnyMethod()
                        .AllowAnyHeader();
                }));

            builder.Services.AddDbContext<AppDbContext>(options => options.UseInMemoryDatabase("SuperHeroesDatabase"));

            var app = builder.Build();

            using (var scope = app.Services.CreateScope())
            {
                var context = scope.ServiceProvider.GetRequiredService<AppDbContext>();
                DbInitializer.Seed(context);
            }

            app.UseMiddleware<GlobalExceptionMiddleware>();

            // Configure the HTTP request pipeline.
            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();
            }

            app.UseCors("HeroiOrigins");

            app.UseAuthorization();


            app.MapControllers();

            app.Run();
        }
    }
}
