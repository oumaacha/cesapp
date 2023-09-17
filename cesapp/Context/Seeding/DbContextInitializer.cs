using cesapp.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Xml.Linq;

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
            _modelBuilder.Entity<Localisation>().HasData(
                new Localisation() { 
                    LocalisationId = 1,
                    PrefectureId = 2,
                    X = 24,
                    Y = 45
                }
                );
            _modelBuilder.Entity<Client>().HasData(
                new Client()
                {
                    ClientId = 1,
                    ClientName = "Client A"
                }
                );
            _modelBuilder.Entity<Responsable>().HasData(
                new Responsable()
                {
                    ResponsableId = 1,
                    ResponsableFName = "Najib",
                    ResponsableLName = "Elgoumi",
                    CodeTelephone = "1457",
                    Mail = "elgoumi@lpee.ma",
                    Matricule = "0451",
                    NumeroTelephone = "0614571579"
                }
                );
            _modelBuilder.Entity<Dossier>().HasData(
                new Dossier()
                {
                    DossierId = 1,
                    DossierNum = "1455-1457-2486-3479",
                    DateOuv = DateTime.UtcNow.AddDays(2),
					Objet = "Objet Object Objet",
					ResponsableId = 1,
					ClientId = 1
				}
                );
			_modelBuilder.Entity<Chantier>().HasData(
				new Chantier()
				{
					ChantierId = 1,
					Budget = 40000,
					ChantierName = "Chantier AR472",
					DateDebut = DateTime.UtcNow,
					DateFin = DateTime.UtcNow.AddDays(10),
					Description = "The curious cat quickly jumped over the tall fence and explored the mysterious garden, chasing butterflies and enjoying the sunshine.",
					LocalisationId = 1,
					Progres = 55,
                    DossierId = 1
				},
				new Chantier()
				{
					ChantierId = 2,
					Budget = 60000,
					ChantierName = "Chantier XOP98",
					DateDebut = DateTime.UtcNow,
					DateFin = DateTime.UtcNow.AddDays(20),
					Description = "The curious cat quickly jumped over the tall fence and explored the mysterious garden, chasing butterflies and enjoying the sunshine.",
					LocalisationId = 1,
					Progres = 0,
					DossierId = 1
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
                    OperateurId = 1
                },
                new Machine()
                {
                    MachineId = 2,
                    Designation = "Machine B",
                    Nfacteur = "15484",
                    DateAcquisition = DateTime.UtcNow,
                    FournisseurId = 2,
                    MachineTypeId = 1,
                    OperateurId = 2
                },
                new Machine()
                {
                    MachineId = 3,
                    Designation = "Machine C",
                    Nfacteur = "45789",
                    DateAcquisition = DateTime.UtcNow.AddDays(-20),
                    FournisseurId = 1,
                    MachineTypeId = 1,
                    OperateurId = 1
                }
                );
            _modelBuilder.Entity<ChefLieu>().HasData(
                new ChefLieu()
                {
                    LieuId = 1,
                    LieuName = "Tanger-Assilah"
                },
                new ChefLieu()
                {
                    LieuId = 2,
                    LieuName = "Oujda-Angad"
                },
                new ChefLieu()
                {
                    LieuId = 3,
                    LieuName = "Fès"
                },
                new ChefLieu()
                {
                    LieuId = 4,
                    LieuName = "Rabat"
                },
                new ChefLieu()
                {
                    LieuId = 5,
                    LieuName = "Beni Mellal"
                },
                new ChefLieu()
                {
                    LieuId = 6,
                    LieuName = "Casablanca"
                },
                new ChefLieu()
                {
                    LieuId = 7,
                    LieuName = "Marrakech"
                },
                new ChefLieu()
                {
                    LieuId = 8,
                    LieuName = "Errachidia"
                },
                new ChefLieu()
                {
                    LieuId = 9,
                    LieuName = "Agadir Ida-Outanane"
                },
                new ChefLieu()
                {
                    LieuId = 10,
                    LieuName = "Guelmim"
                },
                new ChefLieu()
                {
                    LieuId = 11,
                    LieuName = "Laâyoune"
                },
                new ChefLieu()
                {
                    LieuId = 12,
                    LieuName = "Dakhla-Oued-Eddahab"
                }
                );
            _modelBuilder.Entity<Prefecture>().HasData(
                new Prefecture()
                {
                    PrefectureId = 1,
                    PrefectureName = "Tanger-Assilah",
                    ChefLieuId = 1
                },
                new Prefecture()
                {
                    PrefectureId = 2,
                    PrefectureName = "Tétouan",
                    ChefLieuId = 1
                },
                new Prefecture()
                {
                    PrefectureId = 3,
                    PrefectureName = "Larache",
                    ChefLieuId = 1
                },
                new Prefecture()
                {
                    PrefectureId = 4,
                    PrefectureName = "Chefchaouen", /**/
                    ChefLieuId = 1
                },
                new Prefecture()
                {
                    PrefectureId = 5,
                    PrefectureName = "Oujda-Angad",
                    ChefLieuId = 2
                },
                new Prefecture()
                {
                    PrefectureId = 6,
                    PrefectureName = "Driouech",
                    ChefLieuId = 2
                },
                new Prefecture()
                {
                    PrefectureId = 7,
                    PrefectureName = "Berkane",
                    ChefLieuId = 2
                },
                new Prefecture()
                {
                    PrefectureId = 8,
                    PrefectureName = "Guercif", /**/
                    ChefLieuId = 2
                },
                new Prefecture()
                {
                    PrefectureId = 9,
                    PrefectureName = "Fès",
                    ChefLieuId = 3
                },
                new Prefecture()
                {
                    PrefectureId = 10,
                    PrefectureName = "Hajeb",
                    ChefLieuId = 3
                },
                new Prefecture()
                {
                    PrefectureId = 11,
                    PrefectureName = "Moulay Yacoub",
                    ChefLieuId = 3
                },
                new Prefecture()
                {
                    PrefectureId = 12,
                    PrefectureName = "Boulemane",
                    ChefLieuId = 3
                },
                new Prefecture()
                {
                    PrefectureId = 13,
                    PrefectureName = "Taza", /**/
                    ChefLieuId = 3
                }
                );
            _modelBuilder.Entity<ConsommationType>().HasData(
                new ConsommationType()
                {
                    ConsommationTypeId = 1,
                    Type = "Carburant"
                },
                new ConsommationType()
                {
                    ConsommationTypeId = 2,
                    Type = "Vidange"
                },
                new ConsommationType()
                {
                    ConsommationTypeId = 3,
                    Type = "Achat d'accessoire"
                }
                );
        }
    }
}
