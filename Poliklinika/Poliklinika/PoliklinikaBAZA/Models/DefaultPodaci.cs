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
            if (!context.Zaposlenici.Any())
            {
                context.Zaposlenici.AddRange(
                new Osoblje()
                {
                    Ime = "ZaposlenikIme",
                    Prezime = "ZaposlenikPrezime",
                    DatumRodjenja = new DateTime(1986, 10, 1),
                    DatumZaposlenja = new DateTime(2014, 10, 1),
                    Plata=1000,
                    Username="zaposlenik1",
                    Password="zaposlenikPass"
                }
                );
                context.SaveChanges();
            }

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


        }
    }
}
