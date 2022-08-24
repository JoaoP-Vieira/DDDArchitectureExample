using DDDArchitectureExample.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace DDDArchitectureExample.Infra.Data.Context
{
	public class ApplicationDbContext : DbContext
	{
		public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
		{ }

		public DbSet<Hero> Heroes { get; set; }

		protected override void OnModelCreating(ModelBuilder modelBuilder)
		{
			base.OnModelCreating(modelBuilder);
			modelBuilder.ApplyConfigurationsFromAssembly(typeof(ApplicationDbContext).Assembly);
		}
	}
}
