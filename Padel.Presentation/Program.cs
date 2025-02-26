
using Microsoft.EntityFrameworkCore;
using Padel.Application.Interfaces;
using Padel.Application.Services;
using Padel.Domain.Interfaces;
using Padel.Infrastructure.Database;
using Padel.Infrastructure.Repositories;

public class Program
{

    public static void Main(string[] args)
    {
        var builder = WebApplication.CreateBuilder(args);
        builder.Services.AddControllers();
        builder.Services.AddScoped<IUserService, UserService>();
        builder.Services.AddScoped<IUserRepository, UserRepository>();
        builder.Services.AddScoped<IProductoService, ProductoService>();
        builder.Services.AddScoped<IProductoRepository, ProductoRepository>();
        //Comandos para ejecutar el swagger
        builder.Services.AddEndpointsApiExplorer();
        builder.Services.AddSwaggerGen();

        var connectionString = builder.Configuration.GetConnectionString("PadelDb");
        builder.Services.AddDbContext<PadelContext>(options =>
            options.UseMySql(connectionString, ServerVersion.AutoDetect(connectionString))
        );
        
        var app = builder.Build();
        app.UseRouting();
        app.MapControllers();
        if (app.Environment.IsDevelopment())
        {
            app.UseSwagger();
            app.UseSwaggerUI();
        }
        app.Run();
    }
}