using System.ComponentModel.DataAnnotations;

namespace cesapp.Models
{
	public class User
	{
		[Key]
		public int UserId { get; set; }

		[Required(ErrorMessage = "Ce champe est requis")]
        [MaxLength(100,ErrorMessage = "Le nombre de caractères ne doit pas dépasser 100")]
		public string FirstName { get; set; }

        [Required(ErrorMessage = "Ce champe est requis")]
        [MaxLength(100, ErrorMessage = "Le nombre de caractères ne doit pas dépasser 100")]
        public string LastName { get; set; }

        [Required(ErrorMessage = "Ce champe est requis")]
        [MaxLength(100, ErrorMessage = "Le nombre de caractères ne doit pas dépasser 100")]
        public string Email { get; set; }

        [Required(ErrorMessage = "Ce champe est requis")]
        public string PasswordHash { get; set; }

		public bool IsEmailConfirmed { get; set; } = false;
		public DateTime Created { get; set; }
		public DateTime? LastConnection { get; set; } = null;
        [Required(ErrorMessage = "Ce champe est requis")]
        public int RoleId { get; set; }
		public Role Role { get; set; }
        public User()
        {
            Created = DateTime.UtcNow;
        }
    }
}
