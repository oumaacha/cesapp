﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;
using cesapp.Context;

#nullable disable

namespace cesapp.Migrations
{
    [DbContext(typeof(ApplicationDbContext))]
    partial class ApplicationDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.9")
                .HasAnnotation("Relational:MaxIdentifierLength", 63);

            NpgsqlModelBuilderExtensions.UseIdentityByDefaultColumns(modelBuilder);

            modelBuilder.Entity("cesapp.Models.Chantier", b =>
                {
                    b.Property<int>("ChantierId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("ChantierId"));

                    b.Property<double>("Budget")
                        .HasColumnType("double precision");

                    b.Property<string>("ChantierName")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<DateTime>("DateDebut")
                        .HasColumnType("timestamp with time zone");

                    b.Property<DateTime>("DateFin")
                        .HasColumnType("timestamp with time zone");

                    b.Property<string>("Description")
                        .HasColumnType("text");

                    b.Property<int>("LocalisationId")
                        .HasColumnType("integer");

                    b.Property<int>("Progres")
                        .HasColumnType("integer");

                    b.HasKey("ChantierId");

                    b.HasIndex("LocalisationId")
                        .IsUnique();

                    b.ToTable("Chantiers");
                });

            modelBuilder.Entity("cesapp.Models.ChefLieu", b =>
                {
                    b.Property<int>("LieuId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("LieuId"));

                    b.Property<string>("LieuName")
                        .IsRequired()
                        .HasColumnType("text");

                    b.HasKey("LieuId");

                    b.ToTable("ChefLieux");

                    b.HasData(
                        new
                        {
                            LieuId = 1,
                            LieuName = "Tanger-Assilah"
                        },
                        new
                        {
                            LieuId = 2,
                            LieuName = "Oujda-Angad"
                        },
                        new
                        {
                            LieuId = 3,
                            LieuName = "Fès"
                        },
                        new
                        {
                            LieuId = 4,
                            LieuName = "Rabat"
                        },
                        new
                        {
                            LieuId = 5,
                            LieuName = "Beni Mellal"
                        },
                        new
                        {
                            LieuId = 6,
                            LieuName = "Casablanca"
                        },
                        new
                        {
                            LieuId = 7,
                            LieuName = "Marrakech"
                        },
                        new
                        {
                            LieuId = 8,
                            LieuName = "Errachidia"
                        },
                        new
                        {
                            LieuId = 9,
                            LieuName = "Agadir Ida-Outanane"
                        },
                        new
                        {
                            LieuId = 10,
                            LieuName = "Guelmim"
                        },
                        new
                        {
                            LieuId = 11,
                            LieuName = "Laâyoune"
                        },
                        new
                        {
                            LieuId = 12,
                            LieuName = "Dakhla-Oued-Eddahab"
                        });
                });

            modelBuilder.Entity("cesapp.Models.Fournisseur", b =>
                {
                    b.Property<int>("FournisseurId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("FournisseurId"));

                    b.Property<string>("FournisseurName")
                        .IsRequired()
                        .HasColumnType("text");

                    b.HasKey("FournisseurId");

                    b.ToTable("Fournisseurs");

                    b.HasData(
                        new
                        {
                            FournisseurId = 1,
                            FournisseurName = "EMCI"
                        },
                        new
                        {
                            FournisseurId = 2,
                            FournisseurName = "TEC SYSTME"
                        });
                });

            modelBuilder.Entity("cesapp.Models.Localisation", b =>
                {
                    b.Property<int>("LocalisationId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("LocalisationId"));

                    b.Property<int>("PrefectureId")
                        .HasColumnType("integer");

                    b.Property<double>("X")
                        .HasColumnType("double precision");

                    b.Property<double>("Y")
                        .HasColumnType("double precision");

                    b.HasKey("LocalisationId");

                    b.HasIndex("PrefectureId")
                        .IsUnique();

                    b.ToTable("Localisations");
                });

            modelBuilder.Entity("cesapp.Models.Machine", b =>
                {
                    b.Property<int>("MachineId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("MachineId"));

                    b.Property<int?>("ChantierId")
                        .HasColumnType("integer");

                    b.Property<DateTime>("DateAcquisition")
                        .HasColumnType("timestamp with time zone");

                    b.Property<string>("Designation")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<int>("FournisseurId")
                        .HasColumnType("integer");

                    b.Property<int>("MachineTypeId")
                        .HasColumnType("integer");

                    b.Property<string>("Nfacteur")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<int>("OperateurId")
                        .HasColumnType("integer");

                    b.Property<bool>("isAvailable")
                        .HasColumnType("boolean");

                    b.HasKey("MachineId");

                    b.HasIndex("ChantierId");

                    b.HasIndex("FournisseurId")
                        .IsUnique();

                    b.HasIndex("MachineTypeId");

                    b.HasIndex("OperateurId")
                        .IsUnique();

                    b.ToTable("Machines");

                    b.HasData(
                        new
                        {
                            MachineId = 1,
                            DateAcquisition = new DateTime(2023, 8, 1, 15, 22, 46, 12, DateTimeKind.Utc).AddTicks(8862),
                            Designation = "Machine A",
                            FournisseurId = 1,
                            MachineTypeId = 1,
                            Nfacteur = "15484",
                            OperateurId = 1,
                            isAvailable = true
                        },
                        new
                        {
                            MachineId = 2,
                            DateAcquisition = new DateTime(2023, 8, 1, 15, 22, 46, 12, DateTimeKind.Utc).AddTicks(8865),
                            Designation = "Machine B",
                            FournisseurId = 2,
                            MachineTypeId = 1,
                            Nfacteur = "15484",
                            OperateurId = 2,
                            isAvailable = true
                        });
                });

            modelBuilder.Entity("cesapp.Models.MachineType", b =>
                {
                    b.Property<int>("MachineTypeId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("MachineTypeId"));

                    b.Property<string>("MachineTypeName")
                        .IsRequired()
                        .HasMaxLength(200)
                        .HasColumnType("character varying(200)");

                    b.HasKey("MachineTypeId");

                    b.ToTable("MachineTypes");

                    b.HasData(
                        new
                        {
                            MachineTypeId = 1,
                            MachineTypeName = "Sondeuse"
                        },
                        new
                        {
                            MachineTypeId = 2,
                            MachineTypeName = "Inclinomètre"
                        },
                        new
                        {
                            MachineTypeId = 3,
                            MachineTypeName = "Contrôleur Pression Volume (CPV)"
                        },
                        new
                        {
                            MachineTypeId = 4,
                            MachineTypeName = "Enregistreur de paramètres de forage"
                        });
                });

            modelBuilder.Entity("cesapp.Models.Operateur", b =>
                {
                    b.Property<int>("OperateurId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("OperateurId"));

                    b.Property<string>("OperateurName")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("OperateurPhone")
                        .HasColumnType("text");

                    b.Property<bool>("isAvailable")
                        .HasColumnType("boolean");

                    b.HasKey("OperateurId");

                    b.ToTable("Operateurs");

                    b.HasData(
                        new
                        {
                            OperateurId = 1,
                            OperateurName = "Operateur A",
                            OperateurPhone = "0613354716",
                            isAvailable = true
                        },
                        new
                        {
                            OperateurId = 2,
                            OperateurName = "Operateur B",
                            OperateurPhone = "0613354716",
                            isAvailable = true
                        },
                        new
                        {
                            OperateurId = 3,
                            OperateurName = "Operateur C",
                            OperateurPhone = "0613354716",
                            isAvailable = true
                        });
                });

            modelBuilder.Entity("cesapp.Models.Prefecture", b =>
                {
                    b.Property<int>("PrefectureId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("PrefectureId"));

                    b.Property<int>("ChefLieuId")
                        .HasColumnType("integer");

                    b.Property<string>("PrefectureName")
                        .IsRequired()
                        .HasColumnType("text");

                    b.HasKey("PrefectureId");

                    b.HasIndex("ChefLieuId");

                    b.ToTable("Prefectures");

                    b.HasData(
                        new
                        {
                            PrefectureId = 1,
                            ChefLieuId = 1,
                            PrefectureName = "Tanger-Assilah"
                        },
                        new
                        {
                            PrefectureId = 2,
                            ChefLieuId = 1,
                            PrefectureName = "Tétouan"
                        },
                        new
                        {
                            PrefectureId = 3,
                            ChefLieuId = 1,
                            PrefectureName = "Larache"
                        },
                        new
                        {
                            PrefectureId = 4,
                            ChefLieuId = 1,
                            PrefectureName = "Chefchaouen"
                        },
                        new
                        {
                            PrefectureId = 5,
                            ChefLieuId = 2,
                            PrefectureName = "Oujda-Angad"
                        },
                        new
                        {
                            PrefectureId = 6,
                            ChefLieuId = 2,
                            PrefectureName = "Driouech"
                        },
                        new
                        {
                            PrefectureId = 7,
                            ChefLieuId = 2,
                            PrefectureName = "Berkane"
                        },
                        new
                        {
                            PrefectureId = 8,
                            ChefLieuId = 2,
                            PrefectureName = "Guercif"
                        },
                        new
                        {
                            PrefectureId = 9,
                            ChefLieuId = 3,
                            PrefectureName = "Fès"
                        },
                        new
                        {
                            PrefectureId = 10,
                            ChefLieuId = 3,
                            PrefectureName = "Hajeb"
                        },
                        new
                        {
                            PrefectureId = 11,
                            ChefLieuId = 3,
                            PrefectureName = "Moulay Yacoub"
                        },
                        new
                        {
                            PrefectureId = 12,
                            ChefLieuId = 3,
                            PrefectureName = "Boulemane"
                        },
                        new
                        {
                            PrefectureId = 13,
                            ChefLieuId = 3,
                            PrefectureName = "Taza"
                        });
                });

            modelBuilder.Entity("cesapp.Models.Role", b =>
                {
                    b.Property<int>("RoleId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("RoleId"));

                    b.Property<string>("RoleName")
                        .HasColumnType("text");

                    b.HasKey("RoleId");

                    b.ToTable("Roles");

                    b.HasData(
                        new
                        {
                            RoleId = 1,
                            RoleName = "Admin"
                        },
                        new
                        {
                            RoleId = 2,
                            RoleName = "Simple"
                        });
                });

            modelBuilder.Entity("cesapp.Models.User", b =>
                {
                    b.Property<int>("UserId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("UserId"));

                    b.Property<DateTime>("Created")
                        .HasColumnType("timestamp with time zone");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("character varying(100)");

                    b.Property<string>("FirstName")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("character varying(100)");

                    b.Property<bool>("IsEmailConfirmed")
                        .HasColumnType("boolean");

                    b.Property<DateTime?>("LastConnection")
                        .HasColumnType("timestamp with time zone");

                    b.Property<string>("LastName")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("character varying(100)");

                    b.Property<string>("PasswordHash")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<int>("RoleId")
                        .HasColumnType("integer");

                    b.HasKey("UserId");

                    b.HasIndex("RoleId");

                    b.ToTable("Users");

                    b.HasData(
                        new
                        {
                            UserId = 1,
                            Created = new DateTime(2023, 8, 1, 15, 22, 46, 12, DateTimeKind.Utc).AddTicks(8693),
                            Email = "oumaachaanouar@gmail.com",
                            FirstName = "Anouar",
                            IsEmailConfirmed = false,
                            LastName = "Oumaacha",
                            PasswordHash = "0613395473",
                            RoleId = 1
                        },
                        new
                        {
                            UserId = 2,
                            Created = new DateTime(2023, 8, 1, 15, 22, 46, 12, DateTimeKind.Utc).AddTicks(8699),
                            Email = "naimkawtar@gmail.com",
                            FirstName = "Kawtar",
                            IsEmailConfirmed = false,
                            LastName = "Naim",
                            PasswordHash = "0613395473",
                            RoleId = 2
                        });
                });

            modelBuilder.Entity("cesapp.Models.Worker", b =>
                {
                    b.Property<int>("WorkerId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("WorkerId"));

                    b.Property<int>("OperateurId")
                        .HasColumnType("integer");

                    b.Property<string>("PhoneNumber")
                        .HasColumnType("text");

                    b.Property<string>("Type")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("WorkerName")
                        .IsRequired()
                        .HasColumnType("text");

                    b.HasKey("WorkerId");

                    b.HasIndex("OperateurId");

                    b.ToTable("Workers");

                    b.HasData(
                        new
                        {
                            WorkerId = 1,
                            OperateurId = 1,
                            PhoneNumber = "0613395473",
                            Type = "OUVRIER",
                            WorkerName = "Worker A"
                        },
                        new
                        {
                            WorkerId = 2,
                            OperateurId = 1,
                            PhoneNumber = "0613395473",
                            Type = "OUVRIER",
                            WorkerName = "Worker B"
                        },
                        new
                        {
                            WorkerId = 4,
                            OperateurId = 2,
                            PhoneNumber = "0613395473",
                            Type = "OUVRIER",
                            WorkerName = "Worker C"
                        },
                        new
                        {
                            WorkerId = 5,
                            OperateurId = 1,
                            PhoneNumber = "0613395473",
                            Type = "AID_SONDEUR",
                            WorkerName = "Worker D"
                        },
                        new
                        {
                            WorkerId = 6,
                            OperateurId = 2,
                            PhoneNumber = "0613395473",
                            Type = "AID_SONDEUR",
                            WorkerName = "Worker E"
                        });
                });

            modelBuilder.Entity("cesapp.Models.Chantier", b =>
                {
                    b.HasOne("cesapp.Models.Localisation", "Localisation")
                        .WithOne()
                        .HasForeignKey("cesapp.Models.Chantier", "LocalisationId");

                    b.Navigation("Localisation");
                });

            modelBuilder.Entity("cesapp.Models.Localisation", b =>
                {
                    b.HasOne("cesapp.Models.Prefecture", "Prefecture")
                        .WithOne()
                        .HasForeignKey("cesapp.Models.Localisation", "PrefectureId");

                    b.Navigation("Prefecture");
                });

            modelBuilder.Entity("cesapp.Models.Machine", b =>
                {
                    b.HasOne("cesapp.Models.Chantier", null)
                        .WithMany("Machines")
                        .HasForeignKey("ChantierId");

                    b.HasOne("cesapp.Models.Fournisseur", "Fournisseur")
                        .WithOne()
                        .HasForeignKey("cesapp.Models.Machine", "FournisseurId");

                    b.HasOne("cesapp.Models.MachineType", "MachineType")
                        .WithMany("Machines")
                        .HasForeignKey("MachineTypeId");

                    b.HasOne("cesapp.Models.Operateur", "Operateur")
                        .WithOne()
                        .HasForeignKey("cesapp.Models.Machine", "OperateurId");

                    b.Navigation("Fournisseur");

                    b.Navigation("MachineType");

                    b.Navigation("Operateur");
                });

            modelBuilder.Entity("cesapp.Models.Prefecture", b =>
                {
                    b.HasOne("cesapp.Models.ChefLieu", "ChefLieu")
                        .WithMany("Prefectures")
                        .HasForeignKey("ChefLieuId");

                    b.Navigation("ChefLieu");
                });

            modelBuilder.Entity("cesapp.Models.User", b =>
                {
                    b.HasOne("cesapp.Models.Role", "Role")
                        .WithMany("Users")
                        .HasForeignKey("RoleId");

                    b.Navigation("Role");
                });

            modelBuilder.Entity("cesapp.Models.Worker", b =>
                {
                    b.HasOne("cesapp.Models.Operateur", "Operateur")
                        .WithMany("Workers")
                        .HasForeignKey("OperateurId");

                    b.Navigation("Operateur");
                });

            modelBuilder.Entity("cesapp.Models.Chantier", b =>
                {
                    b.Navigation("Machines");
                });

            modelBuilder.Entity("cesapp.Models.ChefLieu", b =>
                {
                    b.Navigation("Prefectures");
                });

            modelBuilder.Entity("cesapp.Models.MachineType", b =>
                {
                    b.Navigation("Machines");
                });

            modelBuilder.Entity("cesapp.Models.Operateur", b =>
                {
                    b.Navigation("Workers");
                });

            modelBuilder.Entity("cesapp.Models.Role", b =>
                {
                    b.Navigation("Users");
                });
#pragma warning restore 612, 618
        }
    }
}
