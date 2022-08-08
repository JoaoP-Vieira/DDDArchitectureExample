using DDDArchitectureExample.Domain.Entities;

namespace DDDArchitectureExample.Domain.Repositories
{
	public interface IHeroRepository
	{
		Task<List<Hero>> GetAsync();
		Task<Hero> GetByEmailAsync(string email);
		Task<Hero> GetByIdAsync(int id);
		Task<Hero> CreateAsync(Hero hero);
		Task UpdateAsync(Hero hero);
		Task DeleteAsync(string email);
	}
}
