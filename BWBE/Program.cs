using System.Reflection.Metadata.Ecma335;
using BWBE;
using Microsoft.EntityFrameworkCore;
using Pomelo.EntityFrameworkCore;
using Newtonsoft.Json;
using static BCrypt.Net.BCrypt;
using System.Xml.Linq;
using System.Data.Entity;

var builder = WebApplication.CreateBuilder(args);

var connection = String.Empty;
var serverVersion = new MySqlServerVersion(new Version(8, 0, 39));
connection = builder.Configuration["ConnectionString:DefaultConnection"];
builder.Services.AddDbContext<BakeryContext>(options => options.UseMySql(connection, serverVersion));
builder.Services.AddDatabaseDeveloperPageExceptionFilter();
var app = builder.Build();

app.MapGet("/", () =>
{
    Console.WriteLine("HIIIIIIIIIIIIIIIIIIIIIIIIIII");
});

app.MapGet("/users", async (BakeryContext db) =>
    await db.TblUsers.ToListAsync());

app.MapGet("/users/EmployeeID:{EmployeeID}", async (string EmployeeID, BakeryContext db) =>
    await db.TblUsers.Where(s => s.EmployeeId == EmployeeID).ToListAsync()
        is { } todo
        ? Results.Ok(todo)
        : Results.NotFound("Sorry, user not found"));

app.MapGet("/users/Name:{Name}", async (string Name, BakeryContext db) =>
    await db.TblUsers.Where(s => s.FirstName + " " + s.LastName == Name).ToListAsync()
        is { } todo
        ? Results.Ok(todo)
        : Results.NotFound("Sorry, user not found"));

/* the format for the input should look like this: https:SERVER/users/{PAYLOAD}
 {PAYLOAD} =
 {
    "FirstName": "Pluto",
    "LastName": "Mouse",
    "Password": "TEST",
    "Username": "Pluto2024"
}
 */
app.MapPost("/users",
    async (TblUser user, BakeryContext db) => {
        var exist = db.TblUsers.Any(e => e.Username == user.Username);

        if (!exist) {
            Guid id = Guid.NewGuid();
            user.EmployeeId = id.ToString();
            string passHash = HashPassword(user.Password);
            user.Password = passHash;

            await db.TblUsers.AddAsync(user);
            await db.SaveChangesAsync();

            return Results.Created($"/users/{user.EmployeeId}", user);
        }

        return Results.BadRequest("User already exists");
    });

app.MapGet("/emails", async (BakeryContext db) =>
    await db.TblEmails.ToListAsync());

app.MapGet("/emailtypes", async (BakeryContext db) =>
    await db.TblEmailTypes.ToListAsync());

app.MapGet("/phone", async (BakeryContext db) =>
    await db.TblPhoneNumbers.ToListAsync());

app.MapGet("/phonetypes", async (BakeryContext db) =>
    await db.TblPhoneTypes.ToListAsync());

app.MapGet("/vendors", async (BakeryContext db) =>
    await db.TblVendors.ToListAsync());

/*
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


app.MapGet("/recipes", async (TodoDb db) =>
    await db.Todos.ToListAsync());

app.MapGet("/recipes/{name}", async (string name, TodoDb db) =>
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