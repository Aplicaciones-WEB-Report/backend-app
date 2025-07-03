using Jobsy.JobsyAi.Application.Handlers;
using Jobsy.JobsyAi.Domain.Services;
using Jobsy.JobsyAi.Infrastructure.ExternalServices;
using Jobsy.Shared.Infrastructure.Persistencia.Configuration;
using Jobsy.UserAuthentication.Application.CommandServices;
using MediatR;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
//------------------
//-----IA----
builder.Services.AddHttpClient<IChatService, OpenRouterService>();
builder.Services.AddMediatR(typeof(SendMessageHandler).Assembly);
//---document--
builder.Services.AddScoped<IDocumentAnalyzer, DocumentProcessingService>();
//------------------
//---
builder.Services.AddMediatR(typeof(RegisterUserService).Assembly);
builder.Services.AddScoped<RegisterUserService>();
//----
var connectionString = builder.Configuration.GetConnectionString("DefaultConnection");

builder.Services.AddDbContext<AppDbContext>(options =>
{
    options.UseMySQL(connectionString); // MYSQL
});

var app = builder.Build();

using (var scope = app.Services.CreateScope())
{
    var services = scope.ServiceProvider;
    var context = services.GetRequiredService<AppDbContext>();
    context.Database.EnsureCreated();
}


// Configure the HTTP request pipeline.

app.UseSwagger();
app.UseSwaggerUI();
app.MapControllers();


app.UseHttpsRedirection();

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

app.Run();

record WeatherForecast(DateOnly Date, int TemperatureC, string? Summary)
{
    public int TemperatureF => 32 + (int)(TemperatureC / 0.5556);
}