using Poliklinika.PoliklinikaMVVM.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Poliklinika.PoliklinikaBAZA.Models
{
    class DefaultPodaci
    {
        public static void Initialize(PoliklinikaDbContext context)
        {
            

            if (!context.ZdravstveniKartoni.Any())
            {
                context.ZdravstveniKartoni.AddRange(
                new ZdravstveniKarton()
                {
                    imePacijenta="PacijentIme",
                    prezimePacijenta="PacijentPrezime",
                    KrvnaGrupa="A+"
                }
                );
                context.SaveChanges();
            }

            if (!context.Odjeli.Any())
            {
                context.Odjeli.AddRange(
                new Odjel()
                { naziv = "dermatologija"},
                new Odjel()
                { naziv = "porodicna medicina"},
                new Odjel()
                { naziv = "ginekologija"},
                new Odjel()
                {naziv = "gastroenterologija"},
                new Odjel()
                {naziv = "interna medicina"}

                );
                context.SaveChanges();
            }


            if (!context.Zaposlenici.Any())
            {
                context.Zaposlenici.AddRange(
                new OstaloOsoblje()
                {
                    Ime = "Admin",
                    Prezime = "Admin",
                    Username = "admin",
                    Password = "1234",
                    tip="administrator"

                },
                new OstaloOsoblje()
                {
                    Ime = "Recepcionist",
                    Prezime = "Recepcionist",
                    Username = "recepcionist",
                    Password = "1234",
                    tip = "recepcionist"

                },
                new OstaloOsoblje()
                {
                    Ime = "Blagajnik",
                    Prezime = "Blagajnik",
                    Username = "blagajnik",
                    Password = "1234",
                    tip = "blagajnik"

                }
                );
                context.SaveChanges();
            }

            if (!context.Doktori.Any())
            {
                context.Doktori.AddRange(
                new Doktor()
                {
                    Ime = "Doktor",
                    Prezime = "Doktor",
                    Username = "doktor",
                    Password = "1234"

                }
                );
                    context.SaveChanges();
               
            }




        }
    }
}
