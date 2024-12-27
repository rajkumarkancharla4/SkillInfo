using Microsoft.EntityFrameworkCore;
using SkillInfoAdo.net.DBContextDataDetails;
using SkillInfoAdo.net.Interfaceses;
using SkillInfoAdo.net.Repositories;
using SkillInfoAdo.net.Serviceses;
using System;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddDbContext<DbDataDetail>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));

builder.Services.AddScoped<ICourseInfoRepository, CourseInfoRepository>();
builder.Services.AddScoped<ICourseInfoService, CourseInfoService>();
builder.Services.AddScoped<ICourseInfoStoreprocedure, CourseinfoStroreproceService>();
builder.Services.AddScoped<ICourseInfoStoreprocedureRepository, CourseInfoSeStoreprocedureRepository>();
builder.Services.AddScoped<ISkillInfoAddRepository, SkillInfoRepository>();
builder.Services.AddScoped<ISkillInfoAddService, SkillInfoService>();



var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}


app.UseAuthorization();

app.MapControllers();

app.Run();
