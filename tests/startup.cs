
using API;
using dataaccess;
using Microsoft.Data.Sqlite;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.DependencyInjection.Extensions;

namespace tests;

public class startup
{
    public void ConfigureServices(IServiceCollection services)
    {
        Program.ConfigurationServices(services);
        services.RemoveAll(typeof(MyDbContext));
        services.AddScoped<MyDbContext>(provider =>
        {
            var connection = new SqliteConnection("DataSource=:memory:");
            connection.Open();
            var options = new DbContextOptionsBuilder<MyDbContext>()
                .UseSqlite(connection)
                .Options;
            var context = new MyDbContext(options);
            context.Database.EnsureCreated();
            return context;
        });
    }
}