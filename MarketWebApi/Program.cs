using MarketWebApi.Data;
using MarketWebApi.Interfaces;
using MarketWebApi.Repository;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

//Inicio del área de servicio

builder.Services.AddControllers();
builder.Services.AddScoped<ICategoriaRepository, CategoriaRepository>();

builder.Services.AddEndpointsApiExplorer();

builder.Services.AddDbContext<DB_MiniMarketContext>(options =>
{
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection"));
});

builder.Services.AddSwaggerGen();

var app = builder.Build();

//Inicio del área de los middlewares

app.UseSwagger();
app.UseSwaggerUI();

app.MapControllers();

app.Run();
