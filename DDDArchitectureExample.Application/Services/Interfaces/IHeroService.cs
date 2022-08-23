using DDDArchitectureExample.Application.DTOs;

namespace DDDArchitectureExample.Application.Services.Interfaces
{
	public interface IHeroService
	{
		ResultService<List<HeroDTO>> GetAsync();
		ResultService<HeroDTO> GetByEmailAsync(string email);
		ResultService<HeroDTO> GetByIdAsync(int id);
		ResultService<HeroDTO> CreateAsync(HeroDTO heroDTO, string password);
		ResultService UpdateAsync(HeroDTO heroDTO, string password);
		ResultService DeleteAsync(string email);
	}
}
