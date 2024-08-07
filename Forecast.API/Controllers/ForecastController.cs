using Forecast.API.Models;
using Forecast.API.Models.Results;
using Forecast.API.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace Forecast.API.Controllers;

[Route("[controller]")]
[ApiController]
public class ForecastController : ControllerBase
{
	private readonly ICityService _service;

	public ForecastController(ICityService service)
	{
		_service = service;
	}

	[HttpGet]
	public async Task<ResultModel<List<City>>> GetAllCity()
	{
		return await _service.GetAll();
	}

	[HttpGet("{name}")]
	public async Task<ResultModel> GetByName([FromRoute] string name)
	{
		return await _service.GetByName(name);
	}
}
