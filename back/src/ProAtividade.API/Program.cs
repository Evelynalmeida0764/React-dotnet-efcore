using System.Text.Json.Serialization;
using Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers()
    .AddJsonOptions(
        options =>{
            options.JsonSerializerOptions.Converters.Add(new JsonStringEnumConverter()); 
        }
    ) ;

builder.Services.AddDbContext<DataContext>(
    options => options.UseSqlite(builder.Configuration.GetConnectionString("Default"))
);

builder.Services.AddCors();

// Add services to the container.
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddCors();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseCors(option => option.AllowAnyHeader()
                            .AllowAnyMethod()
                            .AllowAnyOrigin());

app.MapControllers();

app.Run();
