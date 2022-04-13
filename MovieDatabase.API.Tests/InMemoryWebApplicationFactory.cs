using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc.Testing;
using Microsoft.AspNetCore.TestHost;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using MovieDatabase.API.Models.Database;

namespace MovieDatabase.API.Tests;

public class InMemoryWebApplicationFactory<T> : WebApplicationFactory<T> where T : class
{
    protected override void ConfigureWebHost(IWebHostBuilder builder)
    {
        builder.ConfigureTestServices(services =>
        {
            services.AddScoped(provider => new DbContextOptionsBuilder<MovieDatabaseContext>()
                .UseInMemoryDatabase("MovieDatabase")
                .UseApplicationServiceProvider(provider));
        });
        
        base.ConfigureWebHost(builder);
    }
}