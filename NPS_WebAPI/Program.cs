
using Persistence;
using Application;
using Microsoft.Extensions.Configuration;
using NPS_WebAPI.Middleware;
using Serilog.Events;
using Serilog;
using Serilog.AspNetCore;
using Serilog.Formatting.Json;

namespace NPS_WebAPI
{
    public class Program
    {
        public static void Main(string[] args)
        {

            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.
            builder.Services.AddControllers();
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();
            builder.Services.AddApplication();
            builder.Services.AddPersistence(builder.Configuration);
            builder.Services.AddScoped<DbIntializer>();


            var app = builder.Build();
            // Initialize database
            app.UseCustomExceptionHandler();
      
            using (var scope = app.Services.CreateScope())
            {
                var services = scope.ServiceProvider;
                var dbContext = services.GetRequiredService<Apps_DbContext>();
                DbIntializer.Initialize(dbContext);
            }

            // Configure the HTTP request pipeline.
            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();
            }
            app.UseHttpsRedirection();
            app.UseAuthorization();
            app.MapControllers();
            app.Run();
        }
    }
}