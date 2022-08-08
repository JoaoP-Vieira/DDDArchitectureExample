using FluentValidation;

namespace DDDArchitectureExample.Application.DTOs.Validations
{
	public class HeroDTOValidation : AbstractValidator<HeroDTO>
	{
		public HeroDTOValidation()
		{
			RuleFor(x => x.Name)
				.NotNull()
				.NotEmpty()
				.WithMessage("Heroes need a name!");

			RuleFor(x => x.Email)
				.NotNull()
				.NotEmpty()
				.WithMessage("Heroes need a email!");
		}
	}
}
