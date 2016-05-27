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

           


        }
    }
}
