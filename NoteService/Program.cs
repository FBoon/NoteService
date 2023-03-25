using AutoMapper;
using Microsoft.AspNetCore;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Note.DataLayer;
using Note.DataLayer.UnitOfWork;
using Note.LogicLayer.Handlers;
using Note.LogicLayer.Handlers.Interfaces;
using Note.LogicLayer.Mapper;
using Note.LogicLayer.Models;

var builder = WebApplication.CreateBuilder(args);

// Config file for Connection strings, keys, secrets (things to keep out of git)
builder.Configuration.AddJsonFile("secrets.json", false);

// Add services to the container.
builder.Services.AddAutoMapper(typeof(MapperConfig));
builder.Services.AddDbContext<NoteContext>(
    options => options.UseSqlServer(
        builder.Configuration.GetConnectionString("NoteDatabase"),
        b => b.MigrationsAssembly(typeof(NoteContext).Assembly.FullName)
    ));

builder.Services.AddTransient<IUnitOfWork, UnitOfWork>();

builder.Services.AddTransient<INotationHandler, NotationHandler>();

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
