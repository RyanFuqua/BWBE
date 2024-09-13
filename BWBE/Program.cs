using BWBE.Data;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddDbContext<BakeryCtx>();
builder.Services.AddDatabaseDeveloperPageExceptionFilter();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();
app.UseSwagger();
app.UseSwaggerUI();

app.MapGet("/users", async (BakeryCtx ctx) => await ctx.User.ToListAsync());

// app.MapPost("/users", async (BakeryCtx ctx) =>
// {
//     
// });

app.Run();