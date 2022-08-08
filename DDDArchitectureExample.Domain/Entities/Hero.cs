using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;

namespace DDDArchitectureExample.Domain.Entities
{
	[Index(nameof(Email), IsUnique = true)]
	public sealed class Hero
	{
		[Key]
		public int Id { get; set; }

		[Required]
		[StringLength(42)]
		public string Name { get; set; } = string.Empty;

		[Required]
		[StringLength(42)]
		public string Email { get; set; } = string.Empty;

		[Required]
		[StringLength(16)]
		public string Password { get; set; } = string.Empty;

		public Hero() { }

		public Hero(string name, string email, string password)
		{
			Validate(name, email, password);
		}

		public void Validate(string name, string email, string password)
		{
			if(string.IsNullOrEmpty(name))
				throw new ArgumentNullException(nameof(name), "The Hero need a name!");

			if(name.Length > 42)
				throw new ArgumentException("The Hero's name is too long!", nameof(name));

			if (string.IsNullOrEmpty(email))
				throw new ArgumentNullException(nameof(email), "The Hero need a email!");

			if (email.Length > 42)
				throw new ArgumentException("The Hero's email is too long!", nameof(email));

			if (string.IsNullOrEmpty(password))
				throw new ArgumentNullException(nameof(password), "The Hero need a password!");

			if (password.Length > 16)
				throw new ArgumentException("The Hero's password is too long!", nameof(password));
		
			Name = name;
			Email = email;
			Password = password;
		}
	}
}
