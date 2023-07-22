using cesapp.Models;
using Microsoft.EntityFrameworkCore;

namespace cesapp.Context.Seeding
{
	public class DbContextInitializer
	{
		private readonly ModelBuilder _modelBuilder;
        public DbContextInitializer(ModelBuilder modelBuilder)
        {
            _modelBuilder = modelBuilder;
        }
        public void Seed()
        {
            _modelBuilder.Entity<Role>().HasData(
                new Role()
                {
                    RoleId = 1,
                    RoleName="Admin"
                },
                new Role()
                {
                    RoleId = 2,
                    RoleName = "Simple"
                }
                );
            _modelBuilder.Entity<User>().HasData(
                new User()
                {
                    UserId = 1,
                    FirstName = "Anouar",
                    LastName = "Oumaacha",
                    Email = "oumaachaanouar@gmail.com",
                    PasswordHash = "0613395473",
                    RoleId = 1,
                },
                new User()
                {
					UserId = 2,
					FirstName = "Kawtar",
					LastName = "Naim",
					Email = "naimkawtar@gmail.com",
					PasswordHash = "0613395473",
					RoleId = 2,
				}
			);
        }
    }
}
