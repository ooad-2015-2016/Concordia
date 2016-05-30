using System.Collections.Generic;
using Microsoft.Data.Entity.Migrations;
using Microsoft.Data.Entity.Migrations.Builders;
using Microsoft.Data.Entity.Migrations.Operations;

namespace PoliklinikaMigrations
{
    public partial class InitialMigration : Migration
    {
        public override void Up(MigrationBuilder migration)
        {
            migration.CreateTable(
                name: "OstaloOsoblje",
                columns: table => new
                {
                   
                    OstaloOsobljeId = table.Column(type: "INTEGER", nullable: false),
                       // .Annotation("Sqlite:Autoincrement", true),
                    DatumRodjenja = table.Column(type: "TEXT", nullable: false),
                    DatumZaposlenja = table.Column(type: "TEXT", nullable: false),
                    Ime = table.Column(type: "TEXT", nullable: true),
                    Password = table.Column(type: "TEXT", nullable: true),
                    Plata = table.Column(type: "REAL", nullable: false),
                    Prezime = table.Column(type: "TEXT", nullable: true),
                    Username = table.Column(type: "TEXT", nullable: true),
                    tip=table.Column(type: "TEXT", nullable:true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Osoblje", x => x.OstaloOsobljeId);
                });

            migration.CreateTable(
               name: "Doktor",
               columns: table => new
               {
                   DoktorId = table.Column(type: "INTEGER", nullable: false),
                    // .Annotation("Sqlite:Autoincrement", true),
                   DatumRodjenja = table.Column(type: "TEXT", nullable: false),
                   DatumZaposlenja = table.Column(type: "TEXT", nullable: false),
                   Ime = table.Column(type: "TEXT", nullable: true),
                   Password = table.Column(type: "TEXT", nullable: true),
                   Plata = table.Column(type: "REAL", nullable: false),
                   Prezime = table.Column(type: "TEXT", nullable: true),
                   Username = table.Column(type: "TEXT", nullable: true),
                   OdjelId=table.Column(type: "INTEGER", nullable:false)
               },
               constraints: table =>
               {
                   table.PrimaryKey("PK_Doktor", x => x.DoktorId);
               });

            migration.CreateTable(
               name: "Odjel",
               columns: table => new
               {
                   OdjelId = table.Column(type: "INTEGER", nullable: false),
                    // .Annotation("Sqlite:Autoincrement", true),
                   naziv = table.Column(type: "TEXT", nullable: false)
               },
               constraints: table =>
               {
                   table.PrimaryKey("PK_Odjel", x => x.OdjelId);
               });

            migration.CreateTable(
                name: "Pacijent",
                columns: table => new
                {
                    PacijentId = table.Column(type: "INTEGER", nullable: false),
                    ime = table.Column(type: "TEXT", nullable: true),
                    prezime = table.Column(type: "TEXT", nullable: true),
                    datumRodjenja = table.Column(type: "TEXT", nullable: true),
                    JMBG=table.Column(type:"TEXT", nullable:true),


                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Pacijent", x => x.PacijentId);
                });

            migration.CreateTable(
                name: "RegistrovaniPacijent",
                columns: table => new
                {
                    RegistrovaniPacijentId = table.Column(type: "INTEGER", nullable: false),
                    ime = table.Column(type: "TEXT", nullable: true),
                    prezime = table.Column(type: "TEXT", nullable: true),
                    datumRodjenja = table.Column(type: "TEXT", nullable: true),
                    datumRegistracije = table.Column(type: "TEXT", nullable: true),
                    JMBG = table.Column(type: "TEXT", nullable: true),
                    username = table.Column(type: "TEXT", nullable: true),
                    password = table.Column(type: "TEXT", nullable: true)

                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RegistrovaniPacijent", x => x.RegistrovaniPacijentId);
                });

            migration.CreateTable(
                name: "ZdravstveniKarton",
                columns: table => new
                {
                    ZdravstveniKartonId = table.Column(type: "INTEGER", nullable: false),
                       // .Annotation("Sqlite:Autoincrement", true),
                    KrvnaGrupa = table.Column(type: "TEXT", nullable: true),
                    Slika = table.Column(type: "image", nullable: true),
                    fourSqaureId = table.Column(type: "TEXT", nullable: true),
                    imePacijenta = table.Column(type: "TEXT", nullable: true),
                    prezimePacijenta = table.Column(type: "TEXT", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ZdravstveniKarton", x => x.ZdravstveniKartonId);
                });

            migration.CreateTable(
                name: "Pregled",
                columns: table => new
                {
                    PregledId = table.Column(type: "INTEGER", nullable: false),
                    termin=table.Column(type:"TEXT", nullable:true),
                    status = table.Column(type: "TEXT", nullable: true),
                    pacijentId= table.Column(type: "INTEGER", nullable: true),
                    zdKartonId = table.Column(type: "INTEGER", nullable: true),
                    odjelId = table.Column(type: "INTEGER", nullable: true)


                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Pregled", x => x.PregledId);
                });

            migration.CreateTable(
               name: "Pretraga",
               columns: table => new
               {
                   PretragaId = table.Column(type: "INTEGER", nullable: false),
                   naziv = table.Column(type: "TEXT", nullable: true),
                   cijena = table.Column(type: "REAL", nullable: true),
                   pregledId = table.Column(type: "INTEGER", nullable: true)
               },
               constraints: table =>
               {
                   table.PrimaryKey("PK_Pretraga", x => x.PretragaId);
               });

            migration.CreateTable(
              name: "Racun",
              columns: table => new
              {
                  RacunId = table.Column(type: "INTEGER", nullable: false),
                  cijena = table.Column(type: "REAL", nullable: true),
                  status= table.Column(type: "TEXT", nullable: true),
                  pregledId = table.Column(type: "INTEGER", nullable: true)

              },
              constraints: table =>
              {
                  table.PrimaryKey("PK_Racun", x => x.RacunId);
              });
        }

        public override void Down(MigrationBuilder migration)
        {
            migration.DropTable("OstaloOsoblje");
            migration.DropTable("ZdravstveniKarton");
            migration.DropTable("Doktor");
            migration.DropTable("Pacijent");
            migration.DropTable("RegistrovaniPacijent");
            migration.DropTable("Pregled");
            migration.DropTable("Odjel");
            migration.DropTable("Pretraga");
            migration.DropTable("Racun");
        }
    }
}
