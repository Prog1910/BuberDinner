﻿using BuberDinner.Api.Common.Http;
using ErrorOr;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using System.Net;

namespace BuberDinner.Api.Controllers;

[ApiController]
public class ApiController : ControllerBase
{
	protected IActionResult Problem(List<Error> errors)
	{
		if (errors.Count is 0)
			return Problem();

		if (errors.All(e => e.Type == ErrorType.Validation))
			return ValidationProblem(errors);

		HttpContext.Items[HttpContextItemKeys.Errors] = errors;

		var firstError = errors[0];

		return Problem(firstError);
	}

	private IActionResult Problem(Error error)
	{
		var statusCode = error.Type switch
		{
			ErrorType.Conflict => (int)HttpStatusCode.Conflict,
			ErrorType.Validation => (int)HttpStatusCode.BadRequest,
			ErrorType.NotFound => (int)HttpStatusCode.NotFound,
			_ => (int)HttpStatusCode.InternalServerError
		};

		return Problem(statusCode: statusCode, title: error.Description);
	}

	private IActionResult ValidationProblem(List<Error> errors)
	{
		var modelStateDictionary = new ModelStateDictionary();

		foreach (var error in errors)
		{
			modelStateDictionary.AddModelError(
				error.Code,
				error.Description);
		}

		return ValidationProblem(modelStateDictionary);
	}
}