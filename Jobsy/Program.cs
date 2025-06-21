using Jobsy.Shared.Infrastructure.Persistencia.Configuration;
using Jobsy.Shared.Domain.Repositories;
using Jobsy.Shared.Infrastructure.Persistencia.Repositories;
using Jobsy.UserAuthentication.Application.CommandServices;
using Jobsy.Postulant.CandidateAuthentication.Application.Internal.CommandServices;
using Jobsy.Postulant.CandidateAuthentication.Application.Internal.QueryServices;
using Jobsy.Postulant.CandidateAuthentication.Domain.Repositories;
using Jobsy.Postulant.CandidateAuthentication.Domain.Services;
using Jobsy.Postulant.CandidateAuthentication.Infrastructure.Repositories;
using MediatR;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

// MediatR (solo si estás usando patrones tipo CQRS)
builder.Services.AddMediatR(typeof(RegisterUserService).Assembly);
builder.Services.AddScoped<RegisterUserService>();

// Connection string & EF Core
var connectionString = builder.Configuration.GetConnectionString("DefaultConnection");
builder.Services.AddDbContext<AppDbContext>(options =>
{
    options.UseMySQL(connectionString);
});

// Repositories & UnitOfWork
builder.Services.AddScoped<IUnitOfWork, UnitOfWork>();
builder.Services.AddScoped<ICandidateProfileRepository, CandidateProfileRepository>();

// Services
builder.Services.AddScoped<ICandidateProfileCommandService, CandidateProfileCommandService>();
builder.Services.AddScoped<ICandidateProfileQueryService, CandidateProfileQueryService>();

var app = builder.Build();

// Ensure database creation
using (var scope = app.Services.CreateScope())
{
    var services = scope.ServiceProvider;
    var context = services.GetRequiredService<AppDbContext>();
    context.Database.EnsureCreated();
}

// Swagger UI
app.UseSwagger();
app.UseSwaggerUI();

// Routing & Controllers
app.UseHttpsRedirection();
app.MapControllers();

app.Run();


// ————————————————————————
// ❌ Comentado: WeatherForecast demo
/*
var summaries = new[]
{
    "Freezing", "Bracing", "Chilly", "Cool", "Mild", "Warm", "Balmy", "Hot", "Sweltering", "Scorching"
};

app.MapGet("/weatherforecast", () =>
{
    var forecast = Enumerable.Range(1, 5).Select(index =>
            new WeatherForecast
            (
                DateOnly.FromDateTime(DateTime.Now.AddDays(index)),
                Random.Shared.Next(-20, 55),
                summaries[Random.Shared.Next(summaries.Length)]
            ))
        .ToArray();
    return forecast;
})
.WithName("GetWeatherForecast");

record WeatherForecast(DateOnly Date, int TemperatureC, string? Summary)
{
    public int TemperatureF => 32 + (int)(TemperatureC / 0.5556);
}
*/