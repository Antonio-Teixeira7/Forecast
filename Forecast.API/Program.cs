using Forecast.API.Rest;
using Forecast.API.Rest.Interfaces;
using Forecast.API.Services;
using Forecast.API.Services.Interfaces;
using static System.Net.WebRequestMethods;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddHttpClient<IBrasilApiRest, BrasilApiRest>(client =>
{
	client.BaseAddress = new Uri("https://brasilapi.com.br/api/cptec/v1");
});
builder.Services.AddSingleton <ICityService, CityService>();

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
