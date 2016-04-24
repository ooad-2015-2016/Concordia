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
                name: "Osoblje",
                columns: table => new
                {
                    OsobljeId = table.Column(type: "INTEGER", nullable: false),
                       // .Annotation("Sqlite:Autoincrement", true),
                    DatumRodjenja = table.Column(type: "TEXT", nullable: false),
                    DatumZaposlenja = table.Column(type: "TEXT", nullable: false),
                    Ime = table.Column(type: "TEXT", nullable: true),
                    Password = table.Column(type: "TEXT", nullable: true),
                    Plata = table.Column(type: "REAL", nullable: false),
                    Prezime = table.Column(type: "TEXT", nullable: true),
                    Username = table.Column(type: "TEXT", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Osoblje", x => x.OsobljeId);
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
        }

        public override void Down(MigrationBuilder migration)
        {
            migration.DropTable("Osoblje");
            migration.DropTable("ZdravstveniKarton");
        }
    }
}
