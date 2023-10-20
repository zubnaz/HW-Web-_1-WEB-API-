using DataProject.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory.Database;

string path;
var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
path = builder.Configuration.GetConnectionString("Connect")!;
builder.Services.AddControllers();

// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddDbContext<AutoDbContext>(opts => opts.UseSqlServer(path));
var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}
//builder.Services.AddControllersWithViews();


app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
