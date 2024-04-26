using Dominio.Interfaces;
using Dominio.Modelos;
using Dominio.Validacoes;
using FluentValidation;
using Infra.Dados;
using Infra.Servicos;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddScoped<IUsuario, ServicoUsuario>();
builder.Services.AddScoped<ITarefa, ServicoTarefa>();
builder.Services.AddScoped<IValidator<Usuario>, ValidacaoUsuario>();
builder.Services.AddScoped<IValidator<Tarefas>, ValidacaoTarefa>();

builder.Services.AddDbContext<AppDbContext>(options =>
{
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection"));
});

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
