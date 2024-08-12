using CombinationWebApp.API.Configuration;
using CombinationWebApp.Application.Event_Bus;
using CombinationWebApp.Application.Event_Bus.Base;
using CombinationWebApp.Application.Event_Handlers;
using CombinationWebApp.Application.Event_Handlers.Base;
using CombinationWebApp.Core.Events.Users;
using CombinationWebApp.Presentation.Grpc_Controllers;
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
                //serverOptions.Limits.MaxConcurrentConnections = 5000;
                //serverOptions.Limits.MaxConcurrentUpgradedConnections = 5000;

                //ThreadPool.SetMinThreads(200, 200);

                serverOptions.ConfigureEndpointDefaults(lo => lo.Protocols = HttpProtocols.Http1AndHttp2);

                serverOptions.Listen(IPAddress.Loopback, 7030, listenOptions =>
                {
                    listenOptions.UseHttps();
                });

            });

            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();

            builder.Services.RegisterDbContext(builder.Configuration);

            builder.Services.RegisterControllers();

            builder.Services.RegisterRepositories();
            builder.Services.RegisterServices();

            builder.Services.AddScoped<IEventBus, EventBus>();
            builder.Services.AddScoped<IEventHandler<GetAllUsersEvent>, GetAllUsersEventHandler>();

            builder.Services.RegisterGrpc();

            builder.Services.AddGrpcReflection();

            var app = builder.Build();

            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();
            }
            app.MapGrpcReflectionService();

            app.UseHttpsRedirection();

            app.UseHsts();

            app.UseAuthorization();

            app.MapControllers();
            app.MapGrpcService<AccountGrpcController>();
            app.MapGrpcService<CategoryGrpcController>();
            app.MapGrpcService<TransactionGrpcController>();
            app.MapGrpcService<UserGrpcController>();

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