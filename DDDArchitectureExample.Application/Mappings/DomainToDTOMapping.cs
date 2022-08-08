using AutoMapper;
using DDDArchitectureExample.Application.DTOs;
using DDDArchitectureExample.Domain.Entities;

namespace DDDArchitectureExample.Application.Mappings
{
	public class DomainToDTOMapping : Profile
	{
		public DomainToDTOMapping()
		{
			CreateMap<Hero, HeroDTO>();
		}
	}
}
