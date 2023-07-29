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
            _modelBuilder.Entity<Fournisseur>().HasData(
                new Fournisseur()
                {
                    FournisseurId = 1,
                    FournisseurName = "EMCI"
                },
                new Fournisseur()
                {
                    FournisseurId = 2,
                    FournisseurName = "TEC SYSTME"
                }
                );
            _modelBuilder.Entity<Operateur>().HasData(
                new Operateur()
                {
                    OperateurId = 1,
                    OperateurName = "Operateur A",
                    OperateurPhone = "0613354716"
                },
                new Operateur()
                {
                    OperateurId = 2,
                    OperateurName = "Operateur B",
                    OperateurPhone = "0613354716"
                },
                new Operateur()
                {
                    OperateurId = 3,
                    OperateurName = "Operateur C",
                    OperateurPhone = "0613354716"
                }
                );
            _modelBuilder.Entity<MachineType>().HasData(
                new MachineType()
                {
                    MachineTypeId = 1,
                    MachineTypeName = "Sondeuse"
                },
                new MachineType()
                {
                    MachineTypeId = 2,
                    MachineTypeName = "Inclinomètre"
                },
                new MachineType()
                {
                    MachineTypeId = 3,
                    MachineTypeName = "Contrôleur Pression Volume (CPV)"
                },
                new MachineType()
                {
                    MachineTypeId = 4,
                    MachineTypeName = "Enregistreur de paramètres de forage"
                }
                );
            _modelBuilder.Entity<Emplacement>().HasData(
                new Emplacement()
                {
                    EmplacementId = 1,
                    EmplacementName = "Emplacement A",
                },
                new Emplacement()
                {
                    EmplacementId = 2,
                    EmplacementName = "Emplacement B",
                },
                new Emplacement()
                {
                    EmplacementId = 3,
                    EmplacementName = "Emplacement C",
                }
                );
            _modelBuilder.Entity<Worker>().HasData(
                new Worker()
                {
                    WorkerId = 1,
                    WorkerName = "Worker A",
                    PhoneNumber = "0613395473",
                    Type = TypeWorker.OUVRIER,
                    OperateurId = 1,
                },
                new Worker()
                {
                    WorkerId = 2,
                    WorkerName = "Worker B",
                    PhoneNumber = "0613395473",
                    Type = TypeWorker.OUVRIER,
                    OperateurId = 1,
                },
                new Worker()
                {
                    WorkerId = 4,
                    WorkerName = "Worker C",
                    PhoneNumber = "0613395473",
                    Type = TypeWorker.OUVRIER,
                    OperateurId = 2
                },
                new Worker()
                {
                    WorkerId = 5,
                    WorkerName = "Worker D",
                    PhoneNumber = "0613395473",
                    Type = TypeWorker.AID_SONDEUR,
                    OperateurId = 1,
                },
                new Worker()
                {
                    WorkerId = 6,
                    WorkerName = "Worker E",
                    PhoneNumber = "0613395473",
                    Type = TypeWorker.AID_SONDEUR,
                    OperateurId = 2
                }
                );
            _modelBuilder.Entity<Machine>().HasData(
                new Machine()
                {
                    MachineId = 1,
                    Designation = "Machine A",
                    Nfacteur = "15484",
                    DateAcquisition = DateTime.UtcNow,
                    FournisseurId = 1,
                    MachineTypeId = 1,
                    OperateurId = 1,
                },
                new Machine()
                {
                    MachineId = 2,
                    Designation = "Machine B",
                    Nfacteur = "15484",
                    DateAcquisition = DateTime.UtcNow,
                    FournisseurId = 2,
                    MachineTypeId = 1,
                    OperateurId = 2,
                }
                );
        }
    }
}
