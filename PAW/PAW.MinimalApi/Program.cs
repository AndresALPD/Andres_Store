using PAW.MinimalApi.Factory;
using PAW.Models;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

// Registramos el Factory en el contenedor de dependencias
builder.Services.AddScoped<ICatalogFactory, CatalogFactory>();

var app = builder.Build();


// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

// Endpoint de prueba para crear entity
app.MapGet("/create-entity", (ICatalogFactory factory) =>
{
    var entity = factory.CreateEntity<Catalog>("AndresCatalog");
    return Results.Ok(entity);
});

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
