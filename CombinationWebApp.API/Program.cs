
using CombinationWebApp.API.Configuration;
using CombinationWebApp.Application.GrpcServices;

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

            var app = builder.Build();

            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();
            }

            app.UseHttpsRedirection();

            app.UseAuthorization();

            app.MapControllers();
            app.MapGrpcService<UserServiceGrpc>();

            app.Run();
        }
    }
}