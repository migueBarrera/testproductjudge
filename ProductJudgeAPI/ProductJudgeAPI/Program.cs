
using Microsoft.EntityFrameworkCore;
using ProductJudgeAPI.Context;
using ProductJudgeAPI.Extensions;
using Scalar.AspNetCore;
using System.Reflection;

namespace ProductJudgeAPI;

public class Program
{
    public static void Main(string[] args)
    {
        var builder = WebApplication.CreateBuilder(args);

        // Add services to the container.

        builder.Services.AddControllers();
        // Learn more about configuring OpenAPI at https://aka.ms/aspnet/openapi
        builder.Services.AddOpenApi();
        builder.Services.AddTokenAuthentication(builder.Configuration);
        builder.Services.AddMediatR(cfg => cfg.RegisterServicesFromAssembly(Assembly.GetExecutingAssembly()));
        //var connectionString = builder.Configuration.GetConnectionString("DefaultConnection");
        //builder.Services.AddDbContext<AppDbContext>(options =>
        //{
        //    options.UseSqlServer(connectionString);
        //});
        builder.Services.AddDbContext<AppDbContext>(options =>
        {
            options.UseInMemoryDatabase("ImMemoryDb");
        });
        var app = builder.Build();

        // Configure the HTTP request pipeline.
        //if (app.Environment.IsDevelopment())
        //{
            app.MapOpenApi();
            app.MapScalarApiReference();
        //}

        app.UseHttpsRedirection();

        app.UseAuthorization();


        app.MapControllers();

        app.Run();
    }
}
