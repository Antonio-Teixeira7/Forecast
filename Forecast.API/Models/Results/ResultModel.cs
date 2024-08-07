using System.Net;

namespace Forecast.API.Models.Results;

public class ResultModel
{
	public HttpStatusCode Status { get; protected set; }
	public bool Success { get; protected set; }
	public string ErrorMessage { get; protected set; }

	protected ResultModel()
	{
		Status = HttpStatusCode.OK;
		Success = true;
	}

	protected ResultModel(HttpStatusCode status, string errorMessage)
	{
		Status = status;
		ErrorMessage = errorMessage;
		Success = false;
	}

	public static ResultModel SuccessResult()
	{
		return new ResultModel();
	}

	public static ResultModel ErrorResult(HttpStatusCode status, string errorMessage)
	{
		return new ResultModel(status, errorMessage);
	}
}

public class ResultModel<T> : ResultModel
{
	public T? Data { get; private set; }

	private ResultModel(T data) : base()
	{
		Data = data;
	}

	public ResultModel(HttpStatusCode status, T? data)
	{
		Status = status;
		Data = data;
	}

	private ResultModel(HttpStatusCode status, string errorMessage) : base(status, errorMessage)
	{
	}

	public static ResultModel<T> SuccessResult(T data)
	{
		return new ResultModel<T>(data);
	}

	public static ResultModel<T> ErrorResult(HttpStatusCode status, string errorMessage)
	{
		return new ResultModel<T>(status, errorMessage);
	}

	public static implicit operator ResultModel<T>(T data)
	{
		return ResultModel<T>.SuccessResult(data);
	}
}
