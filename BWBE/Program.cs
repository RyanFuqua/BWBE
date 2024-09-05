using System.Reflection.Metadata.Ecma335;
using BWBE;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddDbContext<TodoDb>(opt => opt.UseInMemoryDatabase("TodoList"));
builder.Services.AddDatabaseDeveloperPageExceptionFilter();
var app = builder.Build();

app.MapGet("/", () =>
{
    Ingredients flour = new Ingredients();
    flour.Id = 1;
    flour.Name = "Flour";
    flour.Description = "Milled wheat grain";

    string output = JsonConvert.SerializeObject(flour);

    return output;
});

app.MapGet("/inventory", async (TodoDb db) =>
    await db.Todos.ToListAsync());

app.MapGet("/inventory/{name}", async (string name, TodoDb db) =>
    await db.Todos.Where(s => s.Name == name).ToListAsync()
        is { } todo
        ? Results.Ok(todo)
        : Results.NotFound("Sorry, ingredient not found"));

app.MapGet("/inventory/{id:int}", async (int id, TodoDb db) =>
    await db.Todos.FindAsync(id)
        is { } todo
        ? Results.Ok(todo)
        : Results.NotFound("Sorry, ingredient not found"));

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
    await db.Todos.Where(s => s.Name == name).ToListAsync()
        is { } todo
        ? Results.Ok(todo)
        : Results.NotFound("Sorry, recipe not found"));

app.MapGet("/recipes/{id:int}", async (int id, TodoDb db) =>
    await db.Todos.FindAsync(id)
        is { } todo
        ? Results.Ok(todo)
        : Results.NotFound("Sorry, recipe not found"));

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