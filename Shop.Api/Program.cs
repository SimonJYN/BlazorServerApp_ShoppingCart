using Microsoft.EntityFrameworkCore;
using Shop.DataModels.Models;
using Shop.Logic.Services;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddDbContext<ShoppingCartDBContext>(options =>
	options.UseSqlite("Data Source=../DB/ShoppingCartDB.db"));
builder.Services.AddControllers();
builder.Services.AddScoped<IAdminService, AdminService>();

var app = builder.Build();

// Configure the HTTP request pipeline.

app.UseAuthorization();

app.MapControllers();

app.Run();
