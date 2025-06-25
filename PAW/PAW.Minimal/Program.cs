using Microsoft.EntityFrameworkCore;
using PAW.Business;
using PAW.Repositories;

var builder = WebApplication.CreateBuilder(args);


builder.Services.AddControllers();

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddScoped<IBusinessCatalog, BusinessCatalog>();
builder.Services.AddScoped<IRepositoryCatalog, RepositoryCatalog>();

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.MapGet("/catalog", async (IBusinessCatalog business) =>
    await business.GetAllCatalogsAsync());

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
