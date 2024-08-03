using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MiminalApi.Dominio.Entidades;
using MiminalApi.Dominio.Interfaces;
using MiminalApi.Dominio.Servicos;
using MiminalApi.DTOs;
using MiminalApi.Infraestrutura.Db;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddScoped<IAdministradorServico, AdministradorServico>();

builder.Services.AddDbContext<DbContexto>(options => {
    options.UseMySql(
        builder.Configuration.GetConnectionString("mysql"),
        ServerVersion.AutoDetect(builder.Configuration.GetConnectionString("mysql"))
    );
});

var app = builder.Build();


app.MapGet("/", () => "Olá pessoal!");

app.MapPost("/login", ([FromBody] LoginDTO loginDTO, IAdministradorServico administradorServico) => {
    if(administradorServico.Login(loginDTO) != null){
        return Results.Ok("Logincom sucesso");
    } else {
        return Results.Unauthorized();
    }
});


app.Run();

