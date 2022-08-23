using FluentValidation.Results;

namespace DDDArchitectureExample.Application.Services
{
	public class ResultService
	{
		public bool Sucess { get; set; }
		public string Message { get; set; } = String.Empty;
		public List<ErrorValidation>? Errors { get; set; }

		public static ResultService RequestError(string message, ValidationResult validationResult)
		{
			return new ResultService
			{
				Sucess = false,
				Message = message,
				Errors = validationResult.Errors.Select(
					x => new ErrorValidation()
					{
						Field = x.PropertyName,
						Message = x.ErrorMessage
					}).ToList()
			};
		}

		public static ResultService<T> RequestError<T>(string message, ValidationResult validationResult)
		{
			return new ResultService<T>
			{
				Sucess = false,
				Message = message,
				Errors = validationResult.Errors.Select(
					x => new ErrorValidation()
					{
						Field = x.PropertyName,
						Message = x.ErrorMessage
					}).ToList()
			};
		}

		public static ResultService Fail(string message)
		{
			return new ResultService
			{
				Sucess = false,
				Message = message,
			};
		}

		public static ResultService<T> Fail<T>(string message)
		{
			return new ResultService<T>
			{
				Sucess = false,
				Message = message,
			};
		}

		public static ResultService Ok(string message)
		{
			return new ResultService
			{
				Sucess = true,
				Message = message,
			};
		}

		public static ResultService<T> Ok<T>(string message, T result)
		{
			return new ResultService<T>
			{
				Sucess = true,
				Message = message,
				Result = result,
			};
		}
	};

	public class ResultService<T>
	{
		public bool Sucess { get; set; }
		public string Message { get; set; } = String.Empty;
		public T? Result { get; set; }
		public List<ErrorValidation>? Errors { get; set; }
	}
}
