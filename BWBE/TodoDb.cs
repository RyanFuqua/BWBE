using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;

namespace BWBE;

public class TodoDb : DbContext
{
    public TodoDb(DbContextOptions<TodoDb> options)
        : base(options) { }

    public DbSet<Todo> Todos => Set<Todo>();
}