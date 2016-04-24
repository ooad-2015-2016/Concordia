using System;
using Microsoft.Data.Entity;
using Microsoft.Data.Entity.Metadata;
using Microsoft.Data.Entity.Migrations.Infrastructure;
using Poliklinika.PoliklinikaBAZA.Models;

namespace PoliklinikaMigrations
{
    [ContextType(typeof(PoliklinikaDbContext))]
    partial class InitialMigration
    {
        public override string Id
        {
            get { return "20160424111932_InitialMigration"; }
        }

        public override string ProductVersion
        {
            get { return "7.0.0-beta6-13815"; }
        }

        public override void BuildTargetModel(ModelBuilder builder)
        {
            builder
                .Annotation("ProductVersion", "7.0.0-beta6-13815");

            builder.Entity("Poliklinika.PoliklinikaBAZA.Models.Osoblje", b =>
                {
                    b.Property<int>("OsobljeId")
                        .ValueGeneratedOnAdd();

                    b.Property<DateTime>("DatumRodjenja");

                    b.Property<DateTime>("DatumZaposlenja");

                    b.Property<string>("Ime");

                    b.Property<string>("Password");

                    b.Property<float>("Plata");

                    b.Property<string>("Prezime");

                    b.Property<string>("Username");

                    b.Key("OsobljeId");
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
        }
    }
}
