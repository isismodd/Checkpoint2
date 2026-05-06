using Checkpoint2.Data;
using Microsoft.EntityFrameworkCore;
using Oracle.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// 1. Configuração do Oracle
// Busca a string de conexão definida no appsettings.json
var connectionString = builder.Configuration.GetConnectionString("OracleDbConnection");

// 2. Registro do Contexto do Banco de Dados
builder.Services.AddDbContext<ApplicationContext>(options =>
    options.UseOracle(connectionString));

// Add services to the container.
builder.Services.AddControllers();

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