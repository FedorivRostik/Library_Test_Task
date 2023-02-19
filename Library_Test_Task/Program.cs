using Application;
using Application.CustomMappers;
using DataAccess;
using Library_Test_Task.Middleware;
using Library_Test_Task.Providers;
using Microsoft.AspNetCore.Mvc.ApplicationModels;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection.Extensions;
using System.Text.Json.Serialization;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers(options =>
{
    options.SuppressAsyncSuffixInActionNames = false;
}).AddJsonOptions(jsonOptions =>
                jsonOptions.JsonSerializerOptions.ReferenceHandler = ReferenceHandler.IgnoreCycles);

builder.Services.AddApplicationServices();
builder.Services.AddDataAccessServicesConfiguration();
builder.Services.AddApplicationMappers();


// for use service in attributes
builder.Services.TryAddEnumerable(ServiceDescriptor.Transient
 <IApplicationModelProvider, ConfigurationModelProvider>());

// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddDbContext<LibraryContext>(o => o.UseInMemoryDatabase("Librarydb"));
var app = builder.Build();

// Configure the HTTP request pipeline.
app.AddApplicationMiddleware();

if (app.Environment.IsDevelopment())
{  
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
