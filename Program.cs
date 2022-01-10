using AnimeList.Data;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers(); // Suporte a uso de controllers.
builder.Services.AddDbContext<AppDbContext>(); // Serviço de conexão com DB.

var app = builder.Build();

app.MapControllers(); // Mapeia os controllers.

app.Run();
