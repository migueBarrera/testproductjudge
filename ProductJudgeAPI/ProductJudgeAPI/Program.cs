using ProductJudgeAPI.Entities;
using ProductJudgeAPI.Extensions;
using ProductJudgeAPI.Features.Barcode;
using ProductJudgeAPI.Features.Category;
using ProductJudgeAPI.Features.Judge;
using ProductJudgeAPI.Features.Product;
using ProductJudgeAPI.Features.User;
using Scalar.AspNetCore;
using System.Reflection;
using Hellang.Middleware.ProblemDetails;
using Microsoft.AspNetCore.Mvc;
using ProductJudgeAPI.Exceptions;
using MediatR;
using ProductJudgeAPI.Infrastructure;
using FluentValidation;
using ProductJudgeAPI.Features.User.Register;
using ProductJudgeAPI.Features.User.Login;
using Azure.Monitor.OpenTelemetry.AspNetCore;
using ProductJudgeAPI.Features.Product.CreateProduct;

namespace ProductJudgeAPI;

public class Program
{
    public static void Main(string[] args)
    {
        var builder = WebApplication.CreateBuilder(args);

        builder.Services.AddOpenTelemetry().UseAzureMonitor();

        builder.Services.Configure<StoreDatabaseSettings>(
            builder.Configuration.GetSection("BookStoreDatabase"));
        builder.Services.AddSingleton<BarcodeService>();
        builder.Services.AddTransient<UserService>();
        builder.Services.AddTransient<ProductService>();
        builder.Services.AddTransient<CategoryService>();
        builder.Services.AddTransient<JudgeService>();
        builder.Services.AddProblemDetails(configure =>
        {
            configure.Map<ValidationException>(ConfigureExceptionProblemDetails);
            configure.Map<ProductJudgeException>(ConfigureExceptionProblemDetails);
        })
        .Configure<ApiBehaviorOptions>(options =>
                {
                    options.InvalidModelStateResponseFactory = context =>
                    {
                        var problemDetails = new ValidationProblemDetails(context.ModelState)
                        {
                            Instance = context.HttpContext.Request.Path,
                            Status = StatusCodes.Status400BadRequest,
                            Type = "https://httpstatuses.com/400",
                            Detail = "https://httpstatuses.com/400"
                        };
                        return new BadRequestObjectResult(problemDetails)
                        {
                            ContentTypes =
                            {
                                "application/problem+json",
                                "application/problem+xml"
                            }
                        };
                    };
                });
        // Add services to the container.

        builder.Services.AddControllers();
        // Learn more about configuring OpenAPI at https://aka.ms/aspnet/openapi
        builder.Services.AddOpenApi();
        builder.Services.AddTokenAuthentication(builder.Configuration);
        builder.Services.AddMediatR(cfg => cfg.RegisterServicesFromAssembly(Assembly.GetExecutingAssembly()));
        builder.Services.AddTransient(typeof(IPipelineBehavior<,>), typeof(ValidationBehavior<,>));
        builder.Services.AddScoped<IValidator<RegisterRequest>, RegisterValidator>();
        builder.Services.AddScoped<IValidator<LoginRequest>, LoginRequestValidator>();
        builder.Services.AddScoped<IValidator<CreateProductRequest>, CreateProductRequestValidator>();
        var app = builder.Build();

        app.UseProblemDetails();
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

            private static ProblemDetails? ConfigureExceptionProblemDetails(Exception exception)
        {
            return new ProblemDetails()
            {
                Status = StatusCodes.Status400BadRequest,
                Type =  "https://httpstatuses.com/400",
                Detail = exception.Message
            };
        }
}
