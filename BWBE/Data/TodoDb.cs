using BWBE.Models;
using Microsoft.EntityFrameworkCore;

namespace BWBE.Data;

public class TodoDb : DbContext
{
    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        var server = Environment.GetEnvironmentVariable("SERVER_IP");
        var username = Environment.GetEnvironmentVariable("USERNAME");
        var password = Environment.GetEnvironmentVariable("PASSWORD");

        var connection = $"server={server}; database=test; user={username}; password={password}";
        Console.WriteLine($"{connection}");

        optionsBuilder.UseMySql(connection, ServerVersion.AutoDetect(connection));
    }
    
    public DbSet<Todo> Todos => Set<Todo>();
}