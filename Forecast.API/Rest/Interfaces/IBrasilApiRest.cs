using Forecast.API.Models;
using Forecast.API.Models.Results;

namespace Forecast.API.Rest.Interfaces
{
	public interface IBrasilApiRest
	{
		Task<ResultModel<List<City>>> GetAllCities();
		Task<ResultModel<List<City>>> GetCitiesByName(string name);

	}
}