using System;
using Microsoft.Data.Entity;
using Microsoft.Data.Entity.Metadata;
using Microsoft.Data.Entity.Migrations.Infrastructure;
using Poliklinika.PoliklinikaBAZA.Models;

namespace PoliklinikaMigrations
{
    [ContextType(typeof(PoliklinikaDbContext))]
    partial class PoliklinikaDbContextModelSnapshot : ModelSnapshot
    {
        public override void BuildModel(ModelBuilder builder)
        {
            builder
                .Annotation("ProductVersion", "7.0.0-beta6-13815");

            builder.Entity("Poliklinika.PoliklinikaBAZA.Models.OstaloOsoblje", b =>
                {
                   

                    b.Property<int>("OstaloOsobljeId")
                        .ValueGeneratedOnAdd();

                    b.Property<DateTime>("DatumRodjenja");

                    b.Property<DateTime>("DatumZaposlenja");

                    b.Property<string>("Ime");

                    b.Property<string>("Password");

                    b.Property<double>("Plata");

                    b.Property<string>("Prezime");

                    b.Property<string>("Username");
                    b.Property<string>("tip");

                    b.Key("OstaloOsobljeId");
                });

            builder.Entity("Poliklinika.PoliklinikaMVVM.Models.Doktor", b =>
            {
               

                b.Property<int>("DoktorId")
                    .ValueGeneratedOnAdd();

                b.Property<DateTime>("DatumRodjenja");

                b.Property<DateTime>("DatumZaposlenja");

                b.Property<string>("Ime");

                b.Property<string>("Password");

                b.Property<double>("Plata");

                b.Property<string>("Prezime");

                b.Property<string>("Username");

                b.Property<int>("odjelId");


                b.Key("DoktorId");
            });

            builder.Entity("Poliklinika.PoliklinikaBAZA.Models.ZdravstveniKarton", b =>
                {
                    b.Property<int>("ZdravstveniKartonId")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("KrvnaGrupa");

                    b.Property<byte[]>("Slika")
                        .Annotation("Relational:ColumnType", "image");

                    b.Property<string>("fourSqaureId");

                    b.Property<string>("imePacijenta");

                    b.Property<string>("prezimePacijenta");

                    b.Key("ZdravstveniKartonId");
                });

            builder.Entity("Poliklinika.PoliklinikaMVVM.Models.Pacijent", b =>
            {
                b.Property<int>("PacijentId")
                    .ValueGeneratedOnAdd();
                b.Property<string>("ime");

                b.Property<string>("prezime");

                b.Property<DateTime>("datumRodjenja");

                b.Property<string>("JMBG");

                b.Key("PacijentId");
            });

            builder.Entity("Poliklinika.PoliklinikaMVVM.Models.RegistrovaniPacijent", b =>
            {
                b.Property<int>("RegPacijentId")
                    .ValueGeneratedOnAdd();
                b.Property<string>("ime");

                b.Property<string>("prezime");

                b.Property<DateTime>("datumRodjenja");

                b.Property<string>("JMBG");
                b.Property<string>("username");
                b.Property<string>("password");

                b.Key("RegPacijentId");
            });

            builder.Entity("Poliklinika.PoliklinikaMVVM.Models.Odjel", b =>
            {
                b.Property<int>("OdjelId")
                    .ValueGeneratedOnAdd();
                b.Property<string>("naziv");

              

                b.Key("OdjelId");
            });

            builder.Entity("Poliklinika.PoliklinikaMVVM.Models.Pregled", b =>
            {
                b.Property<int>("PregledId")
                    .ValueGeneratedOnAdd();
                b.Property<DateTime>("termin");
                b.Property<string>("odjel");
                b.Property<string>("status");
                b.Property<int>("pacijentId");
                b.Property<int>("zdKartonId");
                b.Property<int>("odjelId");

                b.Key("PregledId");
            });

            builder.Entity("Poliklinika.PoliklinikaMVVM.Models.Pretraga", b =>
            {
                b.Property<int>("PretragaId")
                    .ValueGeneratedOnAdd();
               
                b.Property<string>("naziv");
                b.Property<float>("cijena");
                b.Property<int>("pregledId");

                b.Key("PretragaId");
            });

            builder.Entity("Poliklinika.PoliklinikaMVVM.Models.Racun", b =>
            {
                b.Property<int>("RacunId")
                    .ValueGeneratedOnAdd();

                b.Property<string>("naziv");
                b.Property<string>("status");
                b.Property<int>("pregledId");
                b.Key("RacunId");
            });
        }
    }
}
