using DDDArchitectureExample.Application.DTOs;

namespace DDDArchitectureExample.Application.Services.Interfaces
{
	public interface IHeroService
	{
		Task<ResultService<List<HeroDTO>>> GetAsync();
		Task<ResultService<HeroDTO>> GetByEmailAsync(string email);
		Task<ResultService<HeroDTO>> GetByIdAsync(int id);
		Task<ResultService<HeroDTO>> CreateAsync(HeroDTO heroDTO, string password);
		Task<ResultService> UpdateAsync(HeroDTO heroDTO, string password);
		Task<ResultService> DeleteAsync(string email);
	}
}
