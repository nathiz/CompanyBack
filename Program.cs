using CompanyBack;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Configuração do DbContext para PostgreSQL
builder.Services.AddDbContext<ApplicationDbContext>(options =>
    options.UseNpgsql(builder.Configuration.GetConnectionString("DefaultConnection")));

// Registra os serviços (injeção de dependência)
builder.Services.AddScoped<AreaService>();
builder.Services.AddScoped<ProcessoService>();
builder.Services.AddScoped<SubProcessService>();
builder.Services.AddScoped<DetalhamentoProcessosService>();
builder.Services.AddScoped<DocumentosService>();
builder.Services.AddScoped<FerramentaService>();
builder.Services.AddScoped<ResponsavelService>();

// Configuração dos Controllers e prevenção de ciclos de referência
builder.Services.AddControllers().AddJsonOptions(options =>
{
    options.JsonSerializerOptions.ReferenceHandler = System.Text.Json.Serialization.ReferenceHandler.IgnoreCycles;
    options.JsonSerializerOptions.WriteIndented = true;
});

// Configuração do Swagger para documentação da API
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

// Configuração do CORS para permitir múltiplas origens
builder.Services.AddCors(options =>
{
    options.AddPolicy("CorsPolicy", policy =>
        policy.WithOrigins("http://localhost:3000", "http://localhost:5173") // Adicione outras origens se necessário
            .AllowAnyHeader()
            .AllowAnyMethod()
            .AllowCredentials());
});

var app = builder.Build();

// Aplica migrations automaticamente no início
using (var scope = app.Services.CreateScope())
{
    var services = scope.ServiceProvider;
    try
    {
        var context = services.GetRequiredService<ApplicationDbContext>();
        context.Database.Migrate(); // Aplica as migrations

        var exampleData = new ExampleData(context);
        await exampleData.SeedDataAsync(); // Popula o banco com dados iniciais (se necessário)
    }
    catch (Exception ex)
    {
        var logger = services.GetRequiredService<ILogger<Program>>();
        logger.LogError(ex, "Um erro ocorreu ao aplicar as migrations.");
    }
}

//Configuração do pipeline da API
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseCors("CorsPolicy"); // Ativa o CORS configurado
app.UseAuthorization(); // Garante autenticação/autorização
app.MapControllers(); // Mapeia os controllers da API

//Executa a aplicação
app.Run();