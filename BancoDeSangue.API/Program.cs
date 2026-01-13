using BancoDeSangue.API.ExceptionHandler;
using Scalar.AspNetCore;
using BancoDeSangue.Infrastructure;
using BancoDeSangue.Application;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring OpenAPI at https://aka.ms/aspnet/openapi
builder.Services.AddOpenApi();
builder.Services.AddExceptionHandler<ApiExceptionHandler>();

builder.Services
    .AddApplication()
    .AddInfrastructure(builder.Configuration);

var app = builder.Build();



// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.MapOpenApi();
    app.MapScalarApiReference(options =>
    {
        options
        .WithTitle("GerenciadorLivro API")
        .WithTheme(ScalarTheme.Moon);
    }
);
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
