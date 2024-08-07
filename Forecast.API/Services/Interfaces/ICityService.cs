using Forecast.API.Models;
using Forecast.API.Models.Results;

namespace Forecast.API.Services.Interfaces
{
    public interface ICityService
    {
        Task<ResultModel<List<City>>> GetAll();
        Task<ResultModel> GetByName(string name);

	}
}