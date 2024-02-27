using FIAP_PersistenciaDadosBff.Interfaces;
using FIAP_PersistenciaDadosBff.Repositoty;
using FIAP_PersistenciaDadosBff.Services;
using Npgsql;
using System.Data;

var builder = WebApplication.CreateBuilder(args);

var configuration = new ConfigurationBuilder()
    .AddJsonFile("appsettings.json")
    .Build();

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddScoped<IProdutoRepository, ProdutoRepository>();
builder.Services.AddScoped<IProdutoService, ProdutoService>();

//Realização a injeção de dependência do nosso BD
var connectionString = configuration.GetValue<string>("ConnectionStringPostgres");
builder.Services.AddScoped<IDbConnection>((connection) => new NpgsqlConnection(connectionString));

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
