using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;

namespace BWBE;

public class TodoDb : DbContext
{
    public TodoDb(DbContextOptions<TodoDb> options)
        : base(options) { }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        base.OnConfiguring(optionsBuilder);
        //optionsBuilder.UseSqlServer("Server=.\\SQLExpress;Database=tododb;Trusted_Connection=true;TrustServerCertificate=true;");
    }

    public DbSet<Todo> Todos => Set<Todo>();
}