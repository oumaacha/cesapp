using System.ComponentModel.DataAnnotations;

namespace cesapp.Models
{
	public class UserLogin
	{
		[Required(ErrorMessage = "Email de passe requis")]
		public string Email { get; set; }
		[Required(ErrorMessage = "Mot de passe requis")]
		public string PasswordHash { get; set; }
	}
}
