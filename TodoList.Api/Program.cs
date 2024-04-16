using FluentValidation;
using Microsoft.AspNetCore.Http.Json;
using Microsoft.EntityFrameworkCore;
using System;
using System.Text.Json.Serialization;
using TodoList.Domain.ToDoContext.Commands.ToDo.Handler;
using TodoList.Domain.ToDoContext.Entities;
using TodoList.Domain.ToDoContext.Repositories;
using TodoList.Domain.ToDoContext.Validations;
using TodoList.Infra.DataContext;
using TodoList.Infra.Repository;
using TodoList.Shared.ToDoContext.DbConfig;

var SpecificOrigins = "_specificOrigins";
var builder = WebApplication.CreateBuilder(args);



builder.Services.AddCors(options =>
{
    options.AddPolicy(SpecificOrigins,
        policy =>
        {
            policy.WithOrigins("http://localhost:4200/")
                                .AllowAnyOrigin()
                                .AllowAnyHeader()
                                .AllowAnyMethod();
        });
    });

// Add services to the container.
builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.Configure<JsonOptions>(options => options.SerializerOptions.ReferenceHandler = ReferenceHandler.IgnoreCycles);

builder.Services.AddDbContext<TodoListDbContext>(options => options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));


builder.Services.AddScoped<IUserRepository, UserRespository>();
builder.Services.AddScoped<ITodoRepository, TodoRepository>();

builder.Services.AddTransient<TodoHandler, TodoHandler>();

builder.Services.AddTransient<IValidator<Todo>, TodoValidation>();
builder.Services.AddTransient<IValidator<User>, UserValidation>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseCors(SpecificOrigins);

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
