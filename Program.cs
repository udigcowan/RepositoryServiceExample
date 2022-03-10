using Microsoft.EntityFrameworkCore;
using ToDo.Data;
using ToDo.Repositories;
using ToDo.Services;
using System.Collections.Generic;


var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();


//services to build postgres database
builder.Services.AddDbContext<ToDoContext>(
    o=>o.UseNpgsql(builder.Configuration.GetConnectionString("ToDoDB"))
);
builder.Services.AddGraphQLServer().AddQueryType<GraphQLQuery>().AddFiltering().AddSorting().AddProjections();


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

app.MapGraphQL("/graphql");

app.Run();
