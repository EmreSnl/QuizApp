using Microsoft.EntityFrameworkCore;
using QuizApp.Business.Managers;
using QuizApp.Business.Services;
using QuizApp.Data.Context;
using QuizApp.Data.Repositories;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
//builder.Services.AddDbContext<QuizAppContext>(options => options.UseInMemoryDatabase("QuizAppDb"));

var connectionString = builder.Configuration.GetConnectionString("DefaultConnection");

builder.Services.AddDbContext<QuizAppContext>(options => options.UseSqlServer(connectionString));

builder.Services.AddScoped<IQuizService, QuizManager>();
builder.Services.AddScoped<IQuestionService, QuestionManager>();
builder.Services.AddScoped(typeof(IGenericRepository<>), typeof(GenericRepository<>));


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
