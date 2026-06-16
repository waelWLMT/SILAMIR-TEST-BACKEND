using Application.Services;
using Application.Validators;
using Domain.Iterfaces;
using FluentValidation;
using FluentValidation.AspNetCore;
using Presentation.Middlewares;

var builder = WebApplication.CreateBuilder(args);

var allowedOrigins = builder.Configuration
    .GetSection("Cors:AllowedOrigins")
    .Get<string[]>();

// Add services to the container.
builder.Services.AddScoped<IFizzBuzzService, FizzBuzzService>();
builder.Services.AddScoped<IIntegerToStringConverter, IntegerToStringConverter>();

builder.Services.AddFluentValidationAutoValidation();
builder.Services.AddValidatorsFromAssemblyContaining<FizzBuzzRequestValidator>();






builder.Services.AddControllers();



// Health checks
builder.Services.AddHealthChecks();

// Swagger
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

// Cors configuration
builder.Services.AddCors(options =>
{
    options.AddPolicy("CorsPolicy", policy =>
    {
        policy
            .WithOrigins(allowedOrigins!)
            .AllowAnyHeader()
            .AllowAnyMethod();
    });
});

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

if (!app.Environment.IsDevelopment())
{
    app.UseHttpsRedirection();
}

app.UseCors("CorsPolicy");

app.UseAuthorization();

app.UseMiddleware<RequestLoggingMiddleware>();
app.MapControllers();
app.MapHealthChecks("/health");

app.Run();

public partial class Program { }
