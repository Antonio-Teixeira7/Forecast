using Forecast.API.Models;
using Forecast.API.Models.Results;
using Forecast.API.Rest.Interfaces;
using Forecast.API.Services.Interfaces;
using System.Net;

namespace Forecast.API.Services;

public class CityService : ICityService
{
	private readonly IBrasilApiRest _brasilApiRest;

	public CityService(IBrasilApiRest brasilApiRest)
	{
		_brasilApiRest = brasilApiRest;
	}

	public async Task<ResultModel<List<City>>> GetAll()
	{
		return await _brasilApiRest.GetAllCities();
	}

	public async Task<ResultModel> GetByName(string name)
	{
		return await _brasilApiRest.GetCitiesByName(name);
	}
}
