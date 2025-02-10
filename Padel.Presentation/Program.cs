
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

        var connectionString = builder.Configuration.GetConnectionString("PadelDb");
       
        builder.Services.AddDbContext<PadelContext>(options =>
            options.UseMySql(connectionString, ServerVersion.AutoDetect(connectionString))
        );
        
        var app = builder.Build();

        app.UseRouting();
        app.MapControllers();

        app.Run();
    }

}