using Microsoft.EntityFrameworkCore;
using MovieDatabase.API.Models.Database;
using MovieDatabase.API.Services.Interfaces;
using MovieDatabase.API.Services.Repositories;
using Newtonsoft.Json.Serialization;

var builder = WebApplication.CreateBuilder(new WebApplicationOptions
{
    ApplicationName = typeof(Program).Assembly.FullName,
    ContentRootPath = Directory.GetCurrentDirectory(),
    EnvironmentName = Environments.Production
});

Console.WriteLine($"Application name: {builder.Environment.ApplicationName}");
Console.WriteLine($"Environment name: {builder.Environment.EnvironmentName}");
Console.WriteLine($"Content root path: {builder.Environment.ContentRootPath}");

// Add services to the container.
builder.Services
    .AddDbContext<MovieDatabaseContext>(options => options.UseInMemoryDatabase("MovieDatabase"))
    .AddTransient<IMovieRepository, MovieRepository>()
    .AddTransient<IDirectorRepository, DirectorRepository>();

builder.Services
    .AddControllers(options => options.ReturnHttpNotAcceptable = true)
    .AddNewtonsoftJson(options => options.SerializerSettings.ContractResolver = new DefaultContractResolver());

var app = builder.Build();

// Initialize DB
using var scope = app.Services.CreateScope();
scope.ServiceProvider.GetRequiredService<MovieDatabaseContext>();
await DbInitializer.InitializeAsync(scope.ServiceProvider);

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
    app.UseExceptionHandler(appBuilder => appBuilder.Run(async context =>
    {
        context.Response.StatusCode = 500;
        await context.Response.WriteAsync("An error occured. Please try again later.");
    }));
else
    app.UseDeveloperExceptionPage();

app.UseHttpsRedirection();

app.UseRouting();

app.UseAuthorization();

app.MapControllers();

app.Run();

public partial class Program
{
}