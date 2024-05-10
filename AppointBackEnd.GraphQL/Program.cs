
using AppointBackEnd.Core;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

builder.Services
    .AddGraphQLServer()
    .RegisterDbContext<AppointDbContext>()
    .AddQueryType<DbLoggerCategory.Query>();

var app = builder.Build();

app.MapGraphQL();

// app.UseCors();

app.Run();