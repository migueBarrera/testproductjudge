using ProductJudgeAPI.Entities;
using ProductJudgeAPI.Extensions;
using ProductJudgeAPI.Features.Barcode;
using ProductJudgeAPI.Features.Category;
using ProductJudgeAPI.Features.Judge;
using ProductJudgeAPI.Features.Product;
using ProductJudgeAPI.Features.User;
using Scalar.AspNetCore;
using System.Reflection;

namespace ProductJudgeAPI;

public class Program
{
    public static void Main(string[] args)
    {
        var builder = WebApplication.CreateBuilder(args);

        builder.Services.Configure<StoreDatabaseSettings>(
            builder.Configuration.GetSection("BookStoreDatabase"));
        builder.Services.AddSingleton<BarcodeService>();
        builder.Services.AddTransient<UserService>();
        builder.Services.AddTransient<ProductService>();
        builder.Services.AddTransient<CategoryService>();
        builder.Services.AddTransient<JudgeService>();
        // Add services to the container.

        builder.Services.AddControllers();
        // Learn more about configuring OpenAPI at https://aka.ms/aspnet/openapi
        builder.Services.AddOpenApi();
        builder.Services.AddTokenAuthentication(builder.Configuration);
        builder.Services.AddMediatR(cfg => cfg.RegisterServicesFromAssembly(Assembly.GetExecutingAssembly()));

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
