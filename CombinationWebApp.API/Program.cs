using CombinationWebApp.API.Configuration;
using CombinationWebApp.Presentation.Grpc_Controllers;

namespace CombinationWebApp.API
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);


            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();

            builder.Services.RegisterDbContext(builder.Configuration);

            builder.Services.RegisterControllers();

            builder.Services.RegisterRepositories();
            builder.Services.RegisterServices();

            builder.Services.RegisterGrpc();

            builder.Services.AddGrpcReflection();

            var app = builder.Build();

            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();
                app.MapGrpcReflectionService();
            }

            app.UseHttpsRedirection();

            app.UseAuthorization();

            app.MapControllers();
            app.MapGrpcService<AccountGrpcController>();
            app.MapGrpcService<CategoryGrpcController>();
            app.MapGrpcService<TransactionGrpcController>();
            app.MapGrpcService<UserGrpcController>();

            app.Run();
        }
    }
}