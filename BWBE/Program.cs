using BWBE;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddDbContext<TodoDb>(opt => opt.UseInMemoryDatabase("TodoList"));
builder.Services.AddDatabaseDeveloperPageExceptionFilter();
var app = builder.Build();

app.MapGet("/inventory", async (TodoDb db) =>
    await db.Todos.ToListAsync());

app.MapGet("/inventory/{Name}", async (string Name, TodoDb db) =>
    await db.Todos.FindAsync(Name)
        is { } todo
        ? Results.Ok(todo)
        : Results.NotFound());

app.MapGet("/inventory/{id:int}", async (int id, TodoDb db) =>
    await db.Todos.FindAsync(id)
        is { } todo
        ? Results.Ok(todo)
        : Results.NotFound());

/*
app.MapPost("/inventory", async (Todo todo, TodoDb db) =>
{
    db.Todos.Add(todo);
    await db.SaveChangesAsync();

    return Results.Created($"/todoitems/{todo.Id}", todo);
});

app.MapPut("/inventory/{id:int}", async (int id, Todo inputTodo, TodoDb db) =>
{
    var todo = await db.Todos.FindAsync(id);

    if (todo is null) return Results.NotFound();

    todo.Name = inputTodo.Name;
    todo.IsComplete = inputTodo.IsComplete;

    await db.SaveChangesAsync();

    return Results.NoContent();
});

app.MapDelete("/inventory/{id:int}", async (int id, TodoDb db) =>
{
    if (await db.Todos.FindAsync(id) is not { } todo) return Results.NotFound();
    
    db.Todos.Remove(todo);
    await db.SaveChangesAsync();
    return Results.NoContent();
});
*/

app.MapGet("/recipes", async (TodoDb db) =>
    await db.Todos.ToListAsync());

app.MapGet("/recipes/{Name}", async (string Name, TodoDb db) =>
    await db.Todos.FindAsync(Name)
        is { } todo
        ? Results.Ok(todo)
        : Results.NotFound());

app.MapGet("/recipes/{id:int}", async (int id, TodoDb db) =>
    await db.Todos.FindAsync(id)
        is { } todo
        ? Results.Ok(todo)
        : Results.NotFound());

/*
app.MapPost("/recipes", async (Todo todo, TodoDb db) =>
{
    db.Todos.Add(todo);
    await db.SaveChangesAsync();

    return Results.Created($"/todoitems/{todo.Id}", todo);
});



app.MapPut("/recipes/{id:int}", async (int id, Todo inputTodo, TodoDb db) =>
{
    var todo = await db.Todos.FindAsync(id);

    if (todo is null) return Results.NotFound();

    todo.Name = inputTodo.Name;
    todo.IsComplete = inputTodo.IsComplete;

    await db.SaveChangesAsync();

    return Results.NoContent();
});

app.MapDelete("/recipes/{id:int}", async (int id, TodoDb db) =>
{
    if (await db.Todos.FindAsync(id) is not { } todo) return Results.NotFound();

    db.Todos.Remove(todo);
    await db.SaveChangesAsync();
    return Results.NoContent();
});
*/

app.Run();