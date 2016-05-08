using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Poliklinika.PoliklinikaBAZA.Models
{
    class ZdravstveniKarton
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int ZdravstveniKartonId { get; set; }//primaryKey u bazi
        public string fourSqaureId { get; set; }//trebati ce za sihronizaciju kasnije
        public string imePacijenta { get; set; }
        public string prezimePacijenta { get; set; }
        public string KrvnaGrupa { get; set; }
        public byte[] Slika { get; set; }//slika pacijenta
        public List<String> Pregledi { get; set; }//lista ID-eva pregleda iz baze za Preglede

        public ZdravstveniKarton()
        {
            Pregledi = new List<String>();
        }
    }

}

