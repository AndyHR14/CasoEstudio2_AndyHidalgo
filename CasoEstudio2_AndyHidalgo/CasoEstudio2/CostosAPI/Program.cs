using CostosAPI.Services;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddScoped<ICostoService, CostoService>();

var app = builder.Build();

app.MapGet("/calcularCosto", (double peso, double distancia, bool esUrgente,
    ICostoService costoService) =>
{
    try
    {
        var costo = costoService.CalcularCosto(peso, distancia, esUrgente);
        return Results.Ok(new { CostoTotal = costo });
    }
    catch (ArgumentException ex)
    {
        return Results.BadRequest(ex.Message);
    }
});

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
