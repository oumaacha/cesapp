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
				.WithMany()
				.HasForeignKey(x => x.OperateurId) /**/
				.IsRequired(false);
			modelBuilder.Entity<Machine>()
				.HasOne(x => x.Fournisseur)
				.WithMany()
				.HasForeignKey(x => x.FournisseurId)
				.IsRequired(false);
			modelBuilder.Entity<Machine>()
				.HasOne(x => x.MachineType)
				.WithMany(x => x.Machines)
				.HasForeignKey(x => x.MachineTypeId)
				.IsRequired(false);
			modelBuilder.Entity<Chantier>()
				.HasOne(x => x.Localisation)
				.WithMany()
				.HasForeignKey(x => x.LocalisationId)
				.IsRequired(false);
			modelBuilder.Entity<Machine>()
				.HasOne(x => x.Chantier)
				.WithMany(x => x.Machines)
				.HasForeignKey(x => x.ChantierId);
			modelBuilder.Entity<Machine>()
				.HasOne(x => x.Chantier)
				.WithMany(x => x.Machines)
				.HasForeignKey(x => x.ChantierId)
				.OnDelete(DeleteBehavior.SetNull);
			modelBuilder.Entity<Worker>()
				.HasOne(x => x.Operateur)
				.WithMany(x => x.Workers)
				.HasForeignKey(x => x.OperateurId);
			modelBuilder.Entity<Worker>()
				.Property(x => x.Type)
				.HasConversion<string>();
			modelBuilder.Entity<Prefecture>()
				.HasOne(x => x.ChefLieu)
				.WithMany(x => x.Prefectures)
				.HasForeignKey(x => x.ChefLieuId);
			modelBuilder.Entity<Localisation>()
				.HasOne(x => x.Prefecture)
				.WithOne()
				.HasForeignKey<Localisation>(x => x.PrefectureId);
			modelBuilder.Entity<Consommation>()
				.HasOne(x => x.consommationType)
				.WithOne()
				.HasForeignKey<Consommation>(x => x.ConsommationTypeId);
			modelBuilder.Entity<Consommation>()
				.HasOne(x => x.Operateur)
				.WithOne()
				.HasForeignKey<Consommation>(x => x.OperateurId);
			modelBuilder.Entity<Consommation>()
				.HasOne(x => x.Machine)
				.WithOne()
				.HasForeignKey<Consommation>(x => x.MachineId);

			modelBuilder.Entity<Dossier>()
				.HasOne(x => x.Client)
				.WithOne()
				.HasForeignKey<Dossier>(x => x.ClientId);

			modelBuilder.Entity<Responsable>()
				.HasMany(x => x.Dossiers)
				.WithOne(x => x.Responsable)
				.HasForeignKey(x => x.ResponsableId);

			modelBuilder.Entity<Dossier>()
				.HasMany(x => x.Chantiers)
				.WithOne(x => x.Dossier)
				.HasForeignKey(x => x.DossierId);

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
		public DbSet<Consommation> Consommations { get; set; }
		public DbSet<ConsommationType> ConsommationsType { get; set; }
		public DbSet<Dossier> Dossiers { get; set; }
		public DbSet<Responsable> Responsables { get; set; }
		public DbSet<Client> Clients { get; set; }
	}
}
