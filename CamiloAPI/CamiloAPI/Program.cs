using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using CamiloAPI.Data;
var builder = WebApplication.CreateBuilder(args);
builder.Services.AddDbContext<CamiloAPIContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("CamiloAPIContext") ?? throw new InvalidOperationException("Connection string 'CamiloAPIContext' not found.")));

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddScoped<AlimentarBD>();

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

using (var scope = app.Services.CreateScope())
{
    var services = scope.ServiceProvider;
    var seedDb = services.GetRequiredService<AlimentarBD>();
    await seedDb.SeedAsync();
}

