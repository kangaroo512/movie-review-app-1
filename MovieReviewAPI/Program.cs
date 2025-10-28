using FluentValidation;
using Microsoft.EntityFrameworkCore;
using Movie_Review_API.AutoMappers;
using Movie_Review_API.Data;
using Movie_Review_API.DTOs.Movies;
using Movie_Review_API.Models;
using Movie_Review_API.Repositories;
using Movie_Review_API.Services.Movies;
using Movie_Review_API.Validators.Movies;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddScoped<IMovieService, MovieServiceImpl>();


//Database
builder.Services.AddDbContext<AppDbContext>(options =>
{
    options.UseNpgsql(builder.Configuration.GetConnectionString("StoreConnection"));
});

//Repository
builder.Services.AddScoped<IMovieRepository<Movie>, MovieRepositoryImpl>();

//Validators
builder.Services.AddScoped<IValidator<MovieInsertDTO>, MovieInsertValidator>();
builder.Services.AddScoped<IValidator<MovieUpdateDTO>, MovieUpdateValidator>();

//Mappers
builder.Services.AddAutoMapper(typeof(MappingProfile));

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
