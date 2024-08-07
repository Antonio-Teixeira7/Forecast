using Forecast.API.Models;
using Forecast.API.Models.Results;
using Forecast.API.Rest.Interfaces;
using System.Text.Json;

namespace Forecast.API.Rest;

public class BrasilApiRest : IBrasilApiRest
{
	private readonly HttpClient _httpClient;

	public BrasilApiRest(HttpClient client)
	{
		_httpClient = client;
	}

	public async Task<ResultModel<List<City>>> GetAllCities()
	{
		var responseBrasilApi = await _httpClient.GetAsync("cidade");
		var contentResponse = await responseBrasilApi.Content.ReadAsStringAsync();
		var cities = JsonSerializer.Deserialize<List<City>>(contentResponse);

		return ResultModel<List<City>>.SuccessResult(cities!);
	}

	public async Task<ResultModel<List<City>>> GetCitiesByName(string name)
	{
		var responseApiBrasil = await _httpClient.GetAsync($"cidade/{name}");
		var contentResponse = await responseApiBrasil.Content.ReadAsStringAsync();

		if (!responseApiBrasil.IsSuccessStatusCode)
		{
			return ResultModel<List<City>>.ErrorResult(responseApiBrasil.StatusCode, contentResponse);
		}

		var result = JsonSerializer.Deserialize<List<City>>(contentResponse);

		return ResultModel<List<City>>.SuccessResult(result!);
	}
}
