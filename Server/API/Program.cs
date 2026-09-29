using Infrastructure;
using Infrastructure.Database;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();
builder.Services.AddCors();
builder.Services.AddDbContext<ApplicationDbContext>(options =>
{
    var connection =
        builder.Configuration.GetConnectionString("DefaultConnection")
        ?? throw new ApplicationException(
            "No valid connection string for the database was provided!"
        );

    options.UseSqlite(connection);
});

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    try
    {
        await app.ApplyDatabaseMigrations();
        await app.SeedDatabase();
    }
    catch (Exception ex)
    {
        app.Logger.LogError(
            ex,
            "An error occurred while applying migrations or seeding the database."
        );
    }
}

app.UseCors(options =>
    options
        .AllowAnyHeader()
        .AllowAnyMethod()
        .WithOrigins("https://localhost:3000", "http://localhost:3000")
);
app.MapControllers();

app.Run();
