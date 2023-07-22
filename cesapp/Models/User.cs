using System.ComponentModel.DataAnnotations;

namespace cesapp.Models
{
	public class User
	{
		[Key]
		public int UserId { get; set; }
		public string FirstName { get; set; }
		public string LastName { get; set; }
		public string Email { get; set; }
		public string PasswordHash { get; set; }
		public bool IsEmailConfirmed { get; set; } = false;
		public DateTime Created { get; set; }
		public DateTime? LastConnection { get; set; } = null;
		public int RoleId { get; set; }
		public Role Role { get; set; }
        public User()
        {
            Created = DateTime.UtcNow;
        }
    }
}
