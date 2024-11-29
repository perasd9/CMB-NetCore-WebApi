using Carter;
using CombinationWebApp.API.Configuration;
using Microsoft.AspNetCore.Server.Kestrel.Core;
using System.Net;

namespace CombinationWebApp.API
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            builder.WebHost.ConfigureKestrel(serverOptions =>
            {
                serverOptions.ConfigureEndpointDefaults(lo => lo.Protocols = HttpProtocols.Http1AndHttp2);

                serverOptions.Listen(IPAddress.Loopback, 7030, listenOptions =>
                {
                    listenOptions.UseHttps();
                });

            });

            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();

            builder.Services.RegisterDbContext(builder.Configuration);

            builder.Services.RegisterRepositories();
            builder.Services.RegisterServices();

            builder.Services.AddCarter();

            var app = builder.Build();

            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();
            }

            app.UseHttpsRedirection();

            app.UseHsts();

            app.MapCarter();

            app.UseMiddleware<ProtocolLoggingMiddleware>();
            app.Run();
        }
    }

    public class ProtocolLoggingMiddleware
    {
        private readonly RequestDelegate _next;
        private readonly ILogger<ProtocolLoggingMiddleware> _logger;

        public ProtocolLoggingMiddleware(RequestDelegate next, ILogger<ProtocolLoggingMiddleware> logger)
        {
            _next = next;
            _logger = logger;
        }

        public async Task Invoke(HttpContext context)
        {
            _logger.LogWarning($"Protocol: {context.Request.Protocol}");

            await _next(context);
        }
    }
}