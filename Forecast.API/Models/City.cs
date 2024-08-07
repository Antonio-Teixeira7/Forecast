using System.Text.Json.Serialization;

namespace Forecast.API.Models;

public class City
{
	[JsonPropertyName("nome")]
	public string? Nome { get; set; }

	[JsonPropertyName("estado")]
	public string? Estado { get; set; }

	[JsonPropertyName("id")]
	public int? Id { get; set; }
}
