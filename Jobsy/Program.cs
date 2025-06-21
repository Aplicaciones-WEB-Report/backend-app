// --- USINGS NECESARIOS ---
using Jobsy.Shared.Infrastructure.Persistencia.Configuration;
using Jobsy.Shared.Domain.Repositories;
using Jobsy.Shared.Infrastructure.Persistencia.Repositories;
using Jobsy.Postulant.CandidateAuthentication.Domain.Repositories;
using Jobsy.Postulant.CandidateAuthentication.Domain.Services;
using Jobsy.Postulant.CandidateAuthentication.Infrastructure.Repositories;
using Jobsy.Postulant.CandidateAuthentication.Application.Internal.CommandServices;
using Jobsy.Postulant.CandidateAuthentication.Application.Internal.QueryServices;
using Jobsy.Recruiter.Domain.Repository;
using Jobsy.Recruiter.Infrastructure.Repositories;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System.Text.Json.Serialization;
// NO se necesita el using de Npgsql.EntityFrameworkCore.PostgreSQL

// --- INICIO DE LA CONFIGURACIÓN ---
var builder = WebApplication.CreateBuilder(args);

// --- SERVICIOS BASE ---
builder.Services.AddControllers()
    .AddJsonOptions(options =>
    {
        options.JsonSerializerOptions.Converters.Add(new JsonStringEnumConverter());
    });
    
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

// --- CONFIGURACIÓN DE MEDIATR (CQRS) ---
builder.Services.AddMediatR(typeof(Program).Assembly);

// --- CONFIGURACIÓN DE LA BASE DE DATOS (MYSQL) ---
var connectionString = builder.Configuration.GetConnectionString("DefaultConnection");
builder.Services.AddDbContext<AppDbContext>(options =>
{
    // CAMBIO 1: Usamos UseMySQL en lugar de UseNpgsql
    options.UseMySQL(connectionString);
});

// --- INYECCIÓN DE DEPENDENCIAS (REPOSITORIOS Y SERVICIOS) ---

// Shared
builder.Services.AddScoped<IUnitOfWork, UnitOfWork>();

// Postulant Context
builder.Services.AddScoped<ICandidateProfileRepository, CandidateProfileRepository>();
builder.Services.AddScoped<ICandidateProfileCommandService, CandidateProfileCommandService>();
builder.Services.AddScoped<ICandidateProfileQueryService, CandidateProfileQueryService>();

// Recruiter Context
builder.Services.AddScoped<IEmployerProfileRepository, EmployerProfileRepository>();

// --- CONSTRUCCIÓN DE LA APLICACIÓN ---
var app = builder.Build();

using (var scope = app.Services.CreateScope())
{
    var services = scope.ServiceProvider;
    var context = services.GetRequiredService<AppDbContext>();
    context.Database.EnsureCreated();
}

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();
app.MapControllers();

app.Run();
