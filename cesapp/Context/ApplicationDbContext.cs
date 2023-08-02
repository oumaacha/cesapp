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
			modelBuilder.Entity<Machine>()
				.HasOne(x => x.Operateur)
				.WithOne()
				.HasForeignKey<Machine>(x => x.OperateurId)
				.IsRequired(false);
			modelBuilder.Entity<Machine>()
				.HasOne(x => x.Fournisseur)
				.WithOne()
				.HasForeignKey<Machine>(x => x.FournisseurId)
				.IsRequired(false);
			modelBuilder.Entity<Machine>()
				.HasOne(x => x.MachineType)
				.WithMany(x => x.Machines)
				.HasForeignKey(x => x.MachineTypeId)
				.IsRequired(false);
			modelBuilder.Entity<Chantier>()
				.HasOne(x => x.Localisation)
				.WithOne()
				.IsRequired(false);
			modelBuilder.Entity<Chantier>()
				.HasMany(x => x.Machines);
			modelBuilder.Entity<Operateur>()
				.HasMany(x => x.Workers)
				.WithOne(x => x.Operateur)
				.HasForeignKey(x => x.OperateurId)
				.IsRequired(false);
			modelBuilder.Entity<Worker>()
				.Property(x => x.Type)
				.HasConversion<string>();
			modelBuilder.Entity<ChefLieu>()
				.HasMany(x => x.Prefectures)
				.WithOne(x => x.ChefLieu)
				.IsRequired(false);
			modelBuilder.Entity<Localisation>()
				.HasOne(x => x.Prefecture)
				.WithOne()
				.IsRequired(false);
			new DbContextInitializer(modelBuilder).Seed();
		}

		public DbSet<User> Users { get; set; }
        public DbSet<Role> Roles { get; set; }
		public DbSet<Machine> Machines { get; set; }
		public DbSet<Operateur> Operateurs { get; set; }
		public DbSet<Fournisseur> Fournisseurs { get; set; }
		public DbSet<Chantier> Chantiers { get; set; }
		public DbSet<MachineType> MachineTypes { get; set; }
		public DbSet<Worker> Workers { get; set; }
		public DbSet<ChefLieu> ChefLieux { get; set; }
		public DbSet<Prefecture> Prefectures { get; set; }
		public DbSet<Localisation> Localisations { get; set; }
    }
}
