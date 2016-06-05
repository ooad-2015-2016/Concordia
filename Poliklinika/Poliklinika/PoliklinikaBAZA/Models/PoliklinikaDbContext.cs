using Microsoft.Data.Entity;
using Poliklinika.PoliklinikaMVVM.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.Storage;

namespace Poliklinika.PoliklinikaBAZA.Models
{
    class PoliklinikaDbContext : DbContext
    {
      
        public DbSet<ZdravstveniKarton> ZdravstveniKartoni { get; set; }
        public DbSet<Pacijent> Pacijenti { get; set; }
        public DbSet<RegistrovaniPacijent> RegistrovaniPacijenti { get; set; }
        public DbSet<OstaloOsoblje> Zaposlenici { get; set; }
        public DbSet<Doktor> Doktori { get; set; }
        public DbSet<Pregled> Pregledi { get; set; }
        public DbSet<Pretraga> Pretrage { get; set; }
        public DbSet<Odjel> Odjeli { get; set; }
        public DbSet<Racun> Racuni { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            string databaseFilePath = "Concordia-DataBaseVIDEO.db";
            try
            {
               databaseFilePath = Path.Combine(ApplicationData.Current.LocalFolder.Path,
               databaseFilePath);
            }
            catch (InvalidOperationException) { }
            //Sqlite baza
            optionsBuilder.UseSqlite($"Data source={databaseFilePath}");
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            //jedno od polja je image da se zna šta je zapravo predstavlja byte[]
            modelBuilder.Entity<ZdravstveniKarton>().Property(p => p.Slika).HasColumnType("image");
        }
    }
}
