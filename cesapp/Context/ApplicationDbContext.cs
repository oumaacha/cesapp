using cesapp.Context.Seeding;
using cesapp.Models;
using Microsoft.EntityFrameworkCore;

namespace cesapp.Context
{
	public class ApplicationDbContext : DbContext
	{
        public ApplicationDbContext(DbContextOptions options) : base(options)
        {
            
        }

		protected override void OnModelCreating(ModelBuilder modelBuilder)
		{
			base.OnModelCreating(modelBuilder);
			modelBuilder.Entity<User>()
				.HasOne(x => x.Role)
				.WithMany(x => x.Users)
				.HasForeignKey(x => x.RoleId)
				.IsRequired(false);
			new DbContextInitializer(modelBuilder).Seed();
		}

		public DbSet<User> Users { get; set; }
        public DbSet<Role> Roles { get; set; }
    }
}
