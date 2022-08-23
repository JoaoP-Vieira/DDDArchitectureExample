using DDDArchitectureExample.Application.Mappings;
using DDDArchitectureExample.Domain.Repositories;
using DDDArchitectureExample.Infra.Data.Context;
using DDDArchitectureExample.Infra.Data.Repositories;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace DDDArchitectureExample.Infra.IoC
{
	public static class DependencyInjection
	{
		public static IServiceCollection AddInfrastructure(
			this IServiceCollection services,
			IConfiguration configuration)
		{
			services.AddDbContext<ApplicationDbContext>(
			opt => opt.UseSqlServer(configuration.GetConnectionString("")));

			services.AddScoped<IHeroRepository, HeroRepository>();
			
			return services;
		}

		public static IServiceCollection AddServices(
			this IServiceCollection services,
			IConfiguration configuration)
		{
			services.AddAutoMapper(typeof(DomainToDTOMapping));

			return services;
		}
	}
}
