using Microsoft.EntityFrameworkCore;
using Microsoft.OpenApi.Models;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
var connectionString = builder.Configuration.GetConnectionString("DefaultConnection");
builder.Services.AddDbContext<CarContext>(options =>
    options.UseMySql(connectionString, ServerVersion.AutoDetect(connectionString)));

// Add Swagger services
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(c =>
{
    c.SwaggerDoc("v1", new OpenApiInfo { Title = "Car API", Version = "v1" });
});

var app = builder.Build();

// Configure Swagger middleware
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "Car API v1"));
}

// Apply database migrations
using (var scope = app.Services.CreateScope())
{
    var dbContext = scope.ServiceProvider.GetRequiredService<CarContext>();
    dbContext.Database.Migrate();
}

// Minimal API Endpoints
app.MapGet("/cars", async (CarContext db) => await db.Cars.ToListAsync());

app.MapGet("/cars/{id:int}", async (int id, CarContext db) =>
    await db.Cars.FindAsync(id) is Car car ? Results.Ok(car) : Results.NotFound());

app.MapPost("/cars", async (Car car, CarContext db) =>
{
    db.Cars.Add(car);
    await db.SaveChangesAsync();
    return Results.Created($"/cars/{car.Id}", car);
});

app.MapPut("/cars/{id:int}", async (int id, Car inputCar, CarContext db) =>
{
    var car = await db.Cars.FindAsync(id);

    if (car is null) return Results.NotFound();

    car.Cost = inputCar.Cost;
    car.Brand = inputCar.Brand;
    car.Color = inputCar.Color;
    car.Number = inputCar.Number;

    await db.SaveChangesAsync();

    return Results.NoContent();
});

app.MapDelete("/cars/{id:int}", async (int id, CarContext db) =>
{
    var car = await db.Cars.FindAsync(id);

    if (car is null) return Results.NotFound();

    db.Cars.Remove(car);
    await db.SaveChangesAsync();

    return Results.Ok(car);
});

app.Run();

public class CarContext : DbContext
{
    public CarContext(DbContextOptions<CarContext> options) : base(options) { }

    public DbSet<Car> Cars { get; set; }
}

public class Car
{
    public int Id { get; set; }
    public decimal Cost { get; set; }
    public string Brand { get; set; }
    public string Color { get; set; }
    public string Number { get; set; } // Assuming "Number" is the license plate in Ukrainian format
}
