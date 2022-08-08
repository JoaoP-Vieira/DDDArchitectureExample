using DDDArchitectureExample.Domain.Entities;
using DDDArchitectureExample.Domain.Repositories;
using DDDArchitectureExample.Infra.Data.Context;
using Microsoft.EntityFrameworkCore;

namespace DDDArchitectureExample.Infra.Data.Repositories
{
	public class HeroRepository : IHeroRepository
	{
		private readonly ApplicationDbContext _db;

		public HeroRepository(ApplicationDbContext db)
		{
			_db = db;
		}

		public async Task<Hero> CreateAsync(Hero hero)
		{
			try
			{
				_db.Add(hero);
				await _db.SaveChangesAsync();
				return hero;
			}
			catch (Exception ex)
			{
				if (ex is DbUpdateException)
					throw new DbUpdateException("Couldn't add the Hero");

				throw;
			}
		}

		public async Task DeleteAsync(string email)
		{
			try
			{
				var hero = await _db.Heroes.SingleOrDefaultAsync(x => x.Email == email);

				if (hero == null)
					throw new Exception("Hero doesn't exist!");

				_db.Remove(hero);
				await _db.SaveChangesAsync();
			}
			catch (Exception ex)
			{
				if (ex is DbUpdateException)
					throw new DbUpdateException("Couldn't remove the Hero");

				throw;
			}
		}

		public Task<List<Hero>> GetAsync()
		{
			var heroes = _db.Heroes.ToListAsync();

			return heroes;
		}

		public async Task<Hero> GetByEmailAsync(string email)
		{
			try
			{
				var hero = await _db.Heroes.SingleOrDefaultAsync(x => x.Email == email);

				if (hero == null)
					throw new Exception("Hero doesn't exist!");

				return hero;
			}
			catch (Exception)
			{
				throw;
			}
		}

		public async Task<Hero> GetByIdAsync(int id)
		{
			try
			{
				var hero = await _db.Heroes.SingleOrDefaultAsync(x => x.Id == id);

				if (hero == null)
					throw new Exception("Hero doesn't exist!");

				return hero;
			}
			catch (Exception)
			{
				throw;
			}
		}

		public async Task UpdateAsync(Hero hero)
		{
			try
			{
				var currentHero = await _db.Heroes.SingleOrDefaultAsync(x => x.Id == hero.Id);

				if (currentHero == null)
					throw new Exception("Hero doesn't exist!");

				currentHero.Name = hero.Name;
				currentHero.Email = hero.Email;
				currentHero.Password = hero.Password;

				await _db.SaveChangesAsync();
			}
			catch (Exception ex)
			{
				if (ex is DbUpdateException)
					throw new DbUpdateException("Couldn't update the Hero's informations");

				throw;
			}
		}
	}
}
