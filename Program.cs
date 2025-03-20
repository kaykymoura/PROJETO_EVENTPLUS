using System.Reflection;
using Projeto_EventPlus.Contexts;
using Microsoft.EntityFrameworkCore;
using projeto_event_plus.Interfaces;
using EventPlus_.Repositories;
using Projeto_EventPlus.Repositories;

var builder = WebApplication.CreateBuilder(args);
builder.Services 
    .AddControllers() 
    .AddJsonOptions(options => 
    {
        // Configuração para ignorar propriedades nulas ao serializar objetos em JSON
        options.JsonSerializerOptions.DefaultIgnoreCondition = System.Text.Json.Serialization.JsonIgnoreCondition.WhenWritingNull;

        // Configuração para evitar referência circular ao serializar objetos que possuem relacionamentos recursivos
        options.JsonSerializerOptions.ReferenceHandler = System.Text.Json.Serialization.ReferenceHandler.IgnoreCycles;
    });


builder.Services.AddDbContext<Event_Context>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));


builder.Services.AddScoped<ITiposEventosRepository, TipoEventoRepository>();
builder.Services.AddScoped<ITiposUsuariosRepository, TiposUsuariosRepository>();


builder.Services.AddControllers();

var app = builder.Build();

//adicionar o mapeamento dos controllers
app.MapControllers();
app.Run();