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

            // Установка конфигурации Serilog
            Log.Logger = new LoggerConfiguration()
                .MinimumLevel.Override("Microsoft", LogEventLevel.Information)
              //  .WriteTo.File("C:\\dan\\IntelectSoft\\NotesWebAppLog.txt", rollingInterval: RollingInterval.Month)
                .WriteTo.Console(restrictedToMinimumLevel: LogEventLevel.Warning) 
                .CreateLogger();

            // Регистрация службы Serilog в качестве посредника логирования запросов
            builder.Host.UseSerilog((hostingContext, loggerConfiguration) => loggerConfiguration
                .ReadFrom.Configuration(hostingContext.Configuration)
                .WriteTo.Console());

            // Добавление служб в контейнер
            builder.Services.AddControllers();
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();
            builder.Services.AddApplication();
            builder.Services.AddPersistence(builder.Configuration);
            builder.Services.AddScoped<DbIntializer>();

            var app = builder.Build();

            // Инициализация базы данных
            app.UseCustomExceptionHandler();

            // Использование Swagger в режиме разработки
            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();
            }

            // Настройка конвейера обработки HTTP запросов
            app.UseHttpsRedirection();
            app.UseAuthorization();
           // app.UseSerilogRequestLogging(); 
            app.MapControllers();
            app.Run();
        }
    }
}