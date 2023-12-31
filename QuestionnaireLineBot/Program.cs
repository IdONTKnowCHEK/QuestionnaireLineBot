using Microsoft.EntityFrameworkCore;
using QuestionnaireLineBot.Models;
using QuestionnaireLineBot.Services;
using System.Text.Json.Serialization;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.



builder.Services.AddScoped<IQuestionsService, QuestionsService>();
builder.Services.AddScoped<IAccountService, AccountService>();
builder.Services.AddScoped<LineBotService>();
builder.Services.AddHttpClient();

builder.Services.AddDbContext<LineBotQuestionnaireDbContext>(
    option =>
    {
        option.UseSqlServer("Name=ConnectionString:DefaultConnection");
    });

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
