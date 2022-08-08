using AutoMapper;
using DDDArchitectureExample.Application.DTOs;
using DDDArchitectureExample.Domain.Entities;

namespace DDDArchitectureExample.Application.Mappings
{
	public class DTOToDomainMapping : Profile
	{
		public DTOToDomainMapping()
		{
			CreateMap<HeroDTO, Hero>();
		}
	}
}
