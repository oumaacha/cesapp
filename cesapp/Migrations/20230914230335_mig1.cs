using System;
using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace cesapp.Migrations
{
    /// <inheritdoc />
    public partial class mig1 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "ChefLieux",
                columns: table => new
                {
                    LieuId = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    LieuName = table.Column<string>(type: "text", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ChefLieux", x => x.LieuId);
                });

            migrationBuilder.CreateTable(
                name: "Clients",
                columns: table => new
                {
                    ClientId = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    ClientName = table.Column<string>(type: "text", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Clients", x => x.ClientId);
                });

            migrationBuilder.CreateTable(
                name: "ConsommationsType",
                columns: table => new
                {
                    ConsommationTypeId = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Type = table.Column<string>(type: "text", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ConsommationsType", x => x.ConsommationTypeId);
                });

            migrationBuilder.CreateTable(
                name: "Fournisseurs",
                columns: table => new
                {
                    FournisseurId = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    FournisseurName = table.Column<string>(type: "text", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Fournisseurs", x => x.FournisseurId);
                });

            migrationBuilder.CreateTable(
                name: "MachineTypes",
                columns: table => new
                {
                    MachineTypeId = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    MachineTypeName = table.Column<string>(type: "character varying(200)", maxLength: 200, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MachineTypes", x => x.MachineTypeId);
                });

            migrationBuilder.CreateTable(
                name: "Operateurs",
                columns: table => new
                {
                    OperateurId = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    OperateurName = table.Column<string>(type: "text", nullable: false),
                    OperateurPhone = table.Column<string>(type: "text", nullable: true),
                    isAvailable = table.Column<bool>(type: "boolean", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Operateurs", x => x.OperateurId);
                });

            migrationBuilder.CreateTable(
                name: "Responsables",
                columns: table => new
                {
                    ResponsableId = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    ResponsableFName = table.Column<string>(type: "text", nullable: false),
                    ResponsableLName = table.Column<string>(type: "text", nullable: false),
                    Matricule = table.Column<string>(type: "text", nullable: false),
                    CodeTelephone = table.Column<string>(type: "text", nullable: true),
                    NumeroTelephone = table.Column<string>(type: "text", nullable: true),
                    Mail = table.Column<string>(type: "text", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Responsables", x => x.ResponsableId);
                });

            migrationBuilder.CreateTable(
                name: "Roles",
                columns: table => new
                {
                    RoleId = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    RoleName = table.Column<string>(type: "text", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Roles", x => x.RoleId);
                });

            migrationBuilder.CreateTable(
                name: "Prefectures",
                columns: table => new
                {
                    PrefectureId = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    PrefectureName = table.Column<string>(type: "text", nullable: false),
                    ChefLieuId = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Prefectures", x => x.PrefectureId);
                    table.ForeignKey(
                        name: "FK_Prefectures_ChefLieux_ChefLieuId",
                        column: x => x.ChefLieuId,
                        principalTable: "ChefLieux",
                        principalColumn: "LieuId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Workers",
                columns: table => new
                {
                    WorkerId = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    WorkerName = table.Column<string>(type: "text", nullable: false),
                    PhoneNumber = table.Column<string>(type: "text", nullable: true),
                    Type = table.Column<string>(type: "text", nullable: false),
                    OperateurId = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Workers", x => x.WorkerId);
                    table.ForeignKey(
                        name: "FK_Workers_Operateurs_OperateurId",
                        column: x => x.OperateurId,
                        principalTable: "Operateurs",
                        principalColumn: "OperateurId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Dossiers",
                columns: table => new
                {
                    DossierId = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    DossierNum = table.Column<string>(type: "text", nullable: false),
                    DateOuv = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    Objet = table.Column<string>(type: "text", nullable: false),
                    ResponsableId = table.Column<int>(type: "integer", nullable: false),
                    ClientId = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Dossiers", x => x.DossierId);
                    table.ForeignKey(
                        name: "FK_Dossiers_Clients_ClientId",
                        column: x => x.ClientId,
                        principalTable: "Clients",
                        principalColumn: "ClientId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Dossiers_Responsables_ResponsableId",
                        column: x => x.ResponsableId,
                        principalTable: "Responsables",
                        principalColumn: "ResponsableId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Users",
                columns: table => new
                {
                    UserId = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    FirstName = table.Column<string>(type: "character varying(100)", maxLength: 100, nullable: false),
                    LastName = table.Column<string>(type: "character varying(100)", maxLength: 100, nullable: false),
                    Email = table.Column<string>(type: "character varying(100)", maxLength: 100, nullable: false),
                    PasswordHash = table.Column<string>(type: "text", nullable: false),
                    IsEmailConfirmed = table.Column<bool>(type: "boolean", nullable: false),
                    Created = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    LastConnection = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    RoleId = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Users", x => x.UserId);
                    table.ForeignKey(
                        name: "FK_Users_Roles_RoleId",
                        column: x => x.RoleId,
                        principalTable: "Roles",
                        principalColumn: "RoleId");
                });

            migrationBuilder.CreateTable(
                name: "Localisations",
                columns: table => new
                {
                    LocalisationId = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    X = table.Column<double>(type: "double precision", nullable: false),
                    Y = table.Column<double>(type: "double precision", nullable: false),
                    PrefectureId = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Localisations", x => x.LocalisationId);
                    table.ForeignKey(
                        name: "FK_Localisations_Prefectures_PrefectureId",
                        column: x => x.PrefectureId,
                        principalTable: "Prefectures",
                        principalColumn: "PrefectureId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Chantiers",
                columns: table => new
                {
                    ChantierId = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    ChantierName = table.Column<string>(type: "text", nullable: false),
                    Description = table.Column<string>(type: "text", nullable: true),
                    DateDebut = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    DateFin = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    Budget = table.Column<double>(type: "double precision", nullable: false),
                    Progres = table.Column<int>(type: "integer", nullable: false),
                    LocalisationId = table.Column<int>(type: "integer", nullable: false),
                    DossierId = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Chantiers", x => x.ChantierId);
                    table.ForeignKey(
                        name: "FK_Chantiers_Dossiers_DossierId",
                        column: x => x.DossierId,
                        principalTable: "Dossiers",
                        principalColumn: "DossierId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Chantiers_Localisations_LocalisationId",
                        column: x => x.LocalisationId,
                        principalTable: "Localisations",
                        principalColumn: "LocalisationId");
                });

            migrationBuilder.CreateTable(
                name: "Machines",
                columns: table => new
                {
                    MachineId = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Designation = table.Column<string>(type: "text", nullable: false),
                    Nfacteur = table.Column<string>(type: "text", nullable: false),
                    DateAcquisition = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    isAvailable = table.Column<bool>(type: "boolean", nullable: false),
                    situation = table.Column<int>(type: "integer", nullable: false),
                    FournisseurId = table.Column<int>(type: "integer", nullable: false),
                    MachineTypeId = table.Column<int>(type: "integer", nullable: false),
                    OperateurId = table.Column<int>(type: "integer", nullable: false),
                    ChantierId = table.Column<int>(type: "integer", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Machines", x => x.MachineId);
                    table.ForeignKey(
                        name: "FK_Machines_Chantiers_ChantierId",
                        column: x => x.ChantierId,
                        principalTable: "Chantiers",
                        principalColumn: "ChantierId",
                        onDelete: ReferentialAction.SetNull);
                    table.ForeignKey(
                        name: "FK_Machines_Fournisseurs_FournisseurId",
                        column: x => x.FournisseurId,
                        principalTable: "Fournisseurs",
                        principalColumn: "FournisseurId");
                    table.ForeignKey(
                        name: "FK_Machines_MachineTypes_MachineTypeId",
                        column: x => x.MachineTypeId,
                        principalTable: "MachineTypes",
                        principalColumn: "MachineTypeId");
                    table.ForeignKey(
                        name: "FK_Machines_Operateurs_OperateurId",
                        column: x => x.OperateurId,
                        principalTable: "Operateurs",
                        principalColumn: "OperateurId");
                });

            migrationBuilder.CreateTable(
                name: "Consommations",
                columns: table => new
                {
                    ConsommationId = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    MontantEnDh = table.Column<decimal>(type: "numeric", nullable: false),
                    Date = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    OperateurId = table.Column<int>(type: "integer", nullable: false),
                    ConsommationTypeId = table.Column<int>(type: "integer", nullable: false),
                    MachineId = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Consommations", x => x.ConsommationId);
                    table.ForeignKey(
                        name: "FK_Consommations_ConsommationsType_ConsommationTypeId",
                        column: x => x.ConsommationTypeId,
                        principalTable: "ConsommationsType",
                        principalColumn: "ConsommationTypeId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Consommations_Machines_MachineId",
                        column: x => x.MachineId,
                        principalTable: "Machines",
                        principalColumn: "MachineId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Consommations_Operateurs_OperateurId",
                        column: x => x.OperateurId,
                        principalTable: "Operateurs",
                        principalColumn: "OperateurId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Rondements",
                columns: table => new
                {
                    RondmentId = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Date = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    SC_En_Metre = table.Column<decimal>(type: "numeric", nullable: false),
                    SD_En_Metre = table.Column<decimal>(type: "numeric", nullable: false),
                    EssaiPressiometrique = table.Column<int>(type: "integer", nullable: false),
                    SPT = table.Column<int>(type: "integer", nullable: false),
                    CPT_En_MetreLineaire = table.Column<decimal>(type: "numeric", nullable: false),
                    MachineId = table.Column<int>(type: "integer", nullable: false),
                    ChantierId = table.Column<int>(type: "integer", nullable: true),
                    OperateurId = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Rondements", x => x.RondmentId);
                    table.ForeignKey(
                        name: "FK_Rondements_Chantiers_ChantierId",
                        column: x => x.ChantierId,
                        principalTable: "Chantiers",
                        principalColumn: "ChantierId");
                    table.ForeignKey(
                        name: "FK_Rondements_Machines_MachineId",
                        column: x => x.MachineId,
                        principalTable: "Machines",
                        principalColumn: "MachineId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Rondements_Operateurs_OperateurId",
                        column: x => x.OperateurId,
                        principalTable: "Operateurs",
                        principalColumn: "OperateurId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "ChefLieux",
                columns: new[] { "LieuId", "LieuName" },
                values: new object[,]
                {
                    { 1, "Tanger-Assilah" },
                    { 2, "Oujda-Angad" },
                    { 3, "Fès" },
                    { 4, "Rabat" },
                    { 5, "Beni Mellal" },
                    { 6, "Casablanca" },
                    { 7, "Marrakech" },
                    { 8, "Errachidia" },
                    { 9, "Agadir Ida-Outanane" },
                    { 10, "Guelmim" },
                    { 11, "Laâyoune" },
                    { 12, "Dakhla-Oued-Eddahab" }
                });

            migrationBuilder.InsertData(
                table: "Clients",
                columns: new[] { "ClientId", "ClientName" },
                values: new object[] { 1, "Client A" });

            migrationBuilder.InsertData(
                table: "ConsommationsType",
                columns: new[] { "ConsommationTypeId", "Type" },
                values: new object[,]
                {
                    { 1, "Carburant" },
                    { 2, "Vidange" },
                    { 3, "Achat d'accessoire" }
                });

            migrationBuilder.InsertData(
                table: "Fournisseurs",
                columns: new[] { "FournisseurId", "FournisseurName" },
                values: new object[,]
                {
                    { 1, "EMCI" },
                    { 2, "TEC SYSTME" }
                });

            migrationBuilder.InsertData(
                table: "MachineTypes",
                columns: new[] { "MachineTypeId", "MachineTypeName" },
                values: new object[,]
                {
                    { 1, "Sondeuse" },
                    { 2, "Inclinomètre" },
                    { 3, "Contrôleur Pression Volume (CPV)" },
                    { 4, "Enregistreur de paramètres de forage" }
                });

            migrationBuilder.InsertData(
                table: "Operateurs",
                columns: new[] { "OperateurId", "OperateurName", "OperateurPhone", "isAvailable" },
                values: new object[,]
                {
                    { 1, "Operateur A", "0613354716", true },
                    { 2, "Operateur B", "0613354716", true },
                    { 3, "Operateur C", "0613354716", true }
                });

            migrationBuilder.InsertData(
                table: "Responsables",
                columns: new[] { "ResponsableId", "CodeTelephone", "Mail", "Matricule", "NumeroTelephone", "ResponsableFName", "ResponsableLName" },
                values: new object[] { 1, "1457", "elgoumi@lpee.ma", "0451", "0614571579", "Najib", "Elgoumi" });

            migrationBuilder.InsertData(
                table: "Roles",
                columns: new[] { "RoleId", "RoleName" },
                values: new object[,]
                {
                    { 1, "Admin" },
                    { 2, "Simple" }
                });

            migrationBuilder.InsertData(
                table: "Dossiers",
                columns: new[] { "DossierId", "ClientId", "DateOuv", "DossierNum", "Objet", "ResponsableId" },
                values: new object[] { 1, 1, new DateTime(2023, 9, 16, 23, 3, 35, 517, DateTimeKind.Utc).AddTicks(3059), "1455-1457-2486-3479", "Objet Object Objet", 1 });

            migrationBuilder.InsertData(
                table: "Machines",
                columns: new[] { "MachineId", "ChantierId", "DateAcquisition", "Designation", "FournisseurId", "MachineTypeId", "Nfacteur", "OperateurId", "isAvailable", "situation" },
                values: new object[,]
                {
                    { 1, null, new DateTime(2023, 9, 14, 23, 3, 35, 517, DateTimeKind.Utc).AddTicks(3107), "Machine A", 1, 1, "15484", 1, true, 1 },
                    { 2, null, new DateTime(2023, 9, 14, 23, 3, 35, 517, DateTimeKind.Utc).AddTicks(3109), "Machine B", 2, 1, "15484", 2, true, 1 },
                    { 3, null, new DateTime(2023, 8, 25, 23, 3, 35, 517, DateTimeKind.Utc).AddTicks(3111), "Machine C", 1, 1, "45789", 1, true, 1 }
                });

            migrationBuilder.InsertData(
                table: "Prefectures",
                columns: new[] { "PrefectureId", "ChefLieuId", "PrefectureName" },
                values: new object[,]
                {
                    { 1, 1, "Tanger-Assilah" },
                    { 2, 1, "Tétouan" },
                    { 3, 1, "Larache" },
                    { 4, 1, "Chefchaouen" },
                    { 5, 2, "Oujda-Angad" },
                    { 6, 2, "Driouech" },
                    { 7, 2, "Berkane" },
                    { 8, 2, "Guercif" },
                    { 9, 3, "Fès" },
                    { 10, 3, "Hajeb" },
                    { 11, 3, "Moulay Yacoub" },
                    { 12, 3, "Boulemane" },
                    { 13, 3, "Taza" }
                });

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "UserId", "Created", "Email", "FirstName", "IsEmailConfirmed", "LastConnection", "LastName", "PasswordHash", "RoleId" },
                values: new object[,]
                {
                    { 1, new DateTime(2023, 9, 14, 23, 3, 35, 517, DateTimeKind.Utc).AddTicks(2815), "oumaachaanouar@gmail.com", "Anouar", false, null, "Oumaacha", "0613395473", 1 },
                    { 2, new DateTime(2023, 9, 14, 23, 3, 35, 517, DateTimeKind.Utc).AddTicks(2820), "naimkawtar@gmail.com", "Kawtar", false, null, "Naim", "0613395473", 2 }
                });

            migrationBuilder.InsertData(
                table: "Workers",
                columns: new[] { "WorkerId", "OperateurId", "PhoneNumber", "Type", "WorkerName" },
                values: new object[,]
                {
                    { 1, 1, "0613395473", "OUVRIER", "Worker A" },
                    { 2, 1, "0613395473", "OUVRIER", "Worker B" },
                    { 4, 2, "0613395473", "OUVRIER", "Worker C" },
                    { 5, 1, "0613395473", "AID_SONDEUR", "Worker D" },
                    { 6, 2, "0613395473", "AID_SONDEUR", "Worker E" }
                });

            migrationBuilder.InsertData(
                table: "Localisations",
                columns: new[] { "LocalisationId", "PrefectureId", "X", "Y" },
                values: new object[] { 1, 2, 24.0, 45.0 });

            migrationBuilder.InsertData(
                table: "Chantiers",
                columns: new[] { "ChantierId", "Budget", "ChantierName", "DateDebut", "DateFin", "Description", "DossierId", "LocalisationId", "Progres" },
                values: new object[,]
                {
                    { 1, 40000.0, "Chantier AR472", new DateTime(2023, 9, 14, 23, 3, 35, 517, DateTimeKind.Utc).AddTicks(3083), new DateTime(2023, 9, 24, 23, 3, 35, 517, DateTimeKind.Utc).AddTicks(3085), "The curious cat quickly jumped over the tall fence and explored the mysterious garden, chasing butterflies and enjoying the sunshine.", 1, 1, 55 },
                    { 2, 60000.0, "Chantier XOP98", new DateTime(2023, 9, 14, 23, 3, 35, 517, DateTimeKind.Utc).AddTicks(3089), new DateTime(2023, 10, 4, 23, 3, 35, 517, DateTimeKind.Utc).AddTicks(3089), "The curious cat quickly jumped over the tall fence and explored the mysterious garden, chasing butterflies and enjoying the sunshine.", 1, 1, 0 }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Chantiers_DossierId",
                table: "Chantiers",
                column: "DossierId");

            migrationBuilder.CreateIndex(
                name: "IX_Chantiers_LocalisationId",
                table: "Chantiers",
                column: "LocalisationId");

            migrationBuilder.CreateIndex(
                name: "IX_Consommations_ConsommationTypeId",
                table: "Consommations",
                column: "ConsommationTypeId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Consommations_MachineId",
                table: "Consommations",
                column: "MachineId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Consommations_OperateurId",
                table: "Consommations",
                column: "OperateurId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Dossiers_ClientId",
                table: "Dossiers",
                column: "ClientId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Dossiers_ResponsableId",
                table: "Dossiers",
                column: "ResponsableId");

            migrationBuilder.CreateIndex(
                name: "IX_Localisations_PrefectureId",
                table: "Localisations",
                column: "PrefectureId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Machines_ChantierId",
                table: "Machines",
                column: "ChantierId");

            migrationBuilder.CreateIndex(
                name: "IX_Machines_FournisseurId",
                table: "Machines",
                column: "FournisseurId");

            migrationBuilder.CreateIndex(
                name: "IX_Machines_MachineTypeId",
                table: "Machines",
                column: "MachineTypeId");

            migrationBuilder.CreateIndex(
                name: "IX_Machines_OperateurId",
                table: "Machines",
                column: "OperateurId");

            migrationBuilder.CreateIndex(
                name: "IX_Prefectures_ChefLieuId",
                table: "Prefectures",
                column: "ChefLieuId");

            migrationBuilder.CreateIndex(
                name: "IX_Rondements_ChantierId",
                table: "Rondements",
                column: "ChantierId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Rondements_MachineId",
                table: "Rondements",
                column: "MachineId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Rondements_OperateurId",
                table: "Rondements",
                column: "OperateurId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Users_RoleId",
                table: "Users",
                column: "RoleId");

            migrationBuilder.CreateIndex(
                name: "IX_Workers_OperateurId",
                table: "Workers",
                column: "OperateurId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Consommations");

            migrationBuilder.DropTable(
                name: "Rondements");

            migrationBuilder.DropTable(
                name: "Users");

            migrationBuilder.DropTable(
                name: "Workers");

            migrationBuilder.DropTable(
                name: "ConsommationsType");

            migrationBuilder.DropTable(
                name: "Machines");

            migrationBuilder.DropTable(
                name: "Roles");

            migrationBuilder.DropTable(
                name: "Chantiers");

            migrationBuilder.DropTable(
                name: "Fournisseurs");

            migrationBuilder.DropTable(
                name: "MachineTypes");

            migrationBuilder.DropTable(
                name: "Operateurs");

            migrationBuilder.DropTable(
                name: "Dossiers");

            migrationBuilder.DropTable(
                name: "Localisations");

            migrationBuilder.DropTable(
                name: "Clients");

            migrationBuilder.DropTable(
                name: "Responsables");

            migrationBuilder.DropTable(
                name: "Prefectures");

            migrationBuilder.DropTable(
                name: "ChefLieux");
        }
    }
}
