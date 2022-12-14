using AutoMapper;
using DDDArchitectureExample.Application.DTOs;
using DDDArchitectureExample.Application.DTOs.Validations;
using DDDArchitectureExample.Application.Services.Interfaces;
using DDDArchitectureExample.Domain.Entities;
using DDDArchitectureExample.Domain.Repositories;

namespace DDDArchitectureExample.Application.Services
{
	public class HeroService : IHeroService
	{
		private readonly IHeroRepository _heroRepository;
		private readonly IMapper _mapper;

		public HeroService(IHeroRepository heroRepository, IMapper mapper)
		{
			_heroRepository = heroRepository;
			_mapper = mapper;
		}

		public async Task<ResultService<HeroDTO>> CreateAsync(HeroDTO heroDTO, string password)
		{
			try
			{
				if (heroDTO == null && string.IsNullOrEmpty(password))
					throw new ArgumentNullException("Missing informations");

				if (heroDTO != null)
				{
					var validation = new HeroDTOValidation().Validate(heroDTO);
					if (!validation.IsValid)
						return ResultService.RequestError<HeroDTO>("Bad informations!", validation);
				}

				var data = _mapper.Map<Hero>(heroDTO);
				data.Password = password;
				var result = await _heroRepository.CreateAsync(data);

				return ResultService.Ok(
					"Hero added successfully!",
					_mapper.Map<HeroDTO>(result));
			}
			catch (Exception ex)
			{
				return ResultService.Fail<HeroDTO>(ex.Message);
			}
		}

		public async Task<ResultService> DeleteAsync(string email)
		{
			try
			{
				if (string.IsNullOrEmpty(email))
					throw new ArgumentNullException("Missing informations");

				await _heroRepository.DeleteAsync(email);

				return ResultService.Ok("Hero deleted successfully!");
			}
			catch (Exception ex)
			{
				return ResultService.Fail(ex.Message);
			}
		}

		public async Task<ResultService<List<HeroDTO>>> GetAsync()
		{
			try
			{
				var result = await _heroRepository.GetAsync();
				return ResultService.Ok(
					"Search complete!",
					_mapper.Map<List<HeroDTO>>(result));
			}
			catch (Exception ex)
			{
				return ResultService.Fail<List<HeroDTO>>(ex.Message);
			}
		}

		public async Task<ResultService<HeroDTO>> GetByEmailAsync(string email)
		{
			try
			{
				if (string.IsNullOrEmpty(email))
					throw new ArgumentNullException("Missing informations");

				var result = await _heroRepository.GetByEmailAsync(email);
				return ResultService.Ok(
					"Search complete!",
					_mapper.Map<HeroDTO>(result));
			}
			catch (Exception ex)
			{
				return ResultService.Fail<HeroDTO>(ex.Message);
			}
		}

		public async Task<ResultService<HeroDTO>> GetByIdAsync(int id)
		{
			try
			{
				if (id <= 0)
					throw new ArgumentNullException("Bad informations");

				var result = await _heroRepository.GetByIdAsync(id);
				return ResultService.Ok(
					"Search complete!",
					_mapper.Map<HeroDTO>(result));
			}
			catch (Exception ex)
			{
				return ResultService.Fail<HeroDTO>(ex.Message);
			}
		}

		public async Task<ResultService> UpdateAsync(HeroDTO heroDTO, string password)
		{
			try
			{
				if (heroDTO == null && string.IsNullOrEmpty(password))
					throw new ArgumentNullException("Missing informations");

				if (heroDTO != null)
				{
					var validation = new HeroDTOValidation().Validate(heroDTO);
					if (!validation.IsValid)
						return ResultService.RequestError("Bad informations!", validation);
				}

				var data = _mapper.Map<Hero>(heroDTO);
				data.Password = password;
				await _heroRepository.UpdateAsync(data);

				return ResultService.Ok("Hero updated successfully!");
			}
			catch (Exception ex)
			{
				return ResultService.Fail(ex.Message);
			}
		}
	}
}
