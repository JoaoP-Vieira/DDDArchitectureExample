using DDDArchitectureExample.Application.DTOs;
using DDDArchitectureExample.Application.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace DDDArchitectureExample.API.Controllers
{
	[Route("v1/hero")]
	[ApiController]
	public class HeroController : ControllerBase
	{
		private readonly IHeroService _heroService;

		public HeroController(IHeroService heroService)
		{
			_heroService = heroService;
		}

		[HttpGet]
		public async Task<ActionResult<List<HeroDTO>>> Get()
		{
			var result = await _heroService.GetAsync();

			if (result.Sucess)
				return Ok(result);

			return BadRequest(result);
		}
	}
}
