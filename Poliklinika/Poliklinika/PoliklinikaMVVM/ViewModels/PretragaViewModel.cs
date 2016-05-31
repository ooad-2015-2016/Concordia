using Poliklinika.PoliklinikaBAZA.Models;
using Poliklinika.PoliklinikaMVVM.Helper;
using Poliklinika.PoliklinikaMVVM.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace Poliklinika.PoliklinikaMVVM.ViewModels
{
    class PretragaViewModel
    {
        public PregledViewModel Parent { get; set; }
        public Odjel Odjel { get; set; }
        public Pretraga Stavka { get; set; }//za trenutni odabir u combobox
        public ICommand Dodaj { get; set; }

        public List<Pretraga> pretrage { get; set; }

        public int pr { get; set; }
        public PretragaViewModel(PregledViewModel parent)
        {

            this.Parent = parent;
            // Odjel = new Odjel();
            //Odjel.naziv = parent.pomoc3;

            pretrage = new List<Pretraga>();
            MogucePretrage mogucePretrage = new MogucePretrage();
            //prema nazivu odjela povuci iz bazee sve pretrage
            if (parent.pomoc3.Equals("dermatologija"))
            {
                pretrage = mogucePretrage.pretrageDermatologija();
            }
            else if (parent.pomoc3.Equals("ginekologija"))
            {
                pretrage = mogucePretrage.pretrageGinekologija();
            }
            else if(parent.pomoc3.Equals("interna medicina"))
            {
                pretrage = mogucePretrage.pretrageInterna();
            }
            else if(parent.pomoc3.Equals("gastroenterologija"))
            {
                pretrage = mogucePretrage.pretrageGastroenterologija();
            }
            else if (parent.pomoc3.Equals("porodicna medicina"))
            {
                pretrage = mogucePretrage.pretragePorodicna();
            }
            

            Dodaj = new RelayCommand<object>(dodaj, mozeLiDodati);
            Stavka = new Pretraga();
            Stavka = pretrage[0];
            Stavka.pregledId = parent.prId;
   
        }

        public void dodaj(object parametar)
        {
            Parent.Pregled.pretrage.Add(Stavka);
            Stavka.pregledId = Parent.prId;

            using (var db = new PoliklinikaDbContext())
            {
                db.Pretrage.Add(Stavka);
                db.SaveChanges();
            }
            Parent.NavigationService.GoBack();
        }

        public bool mozeLiDodati(object parametar)
        {
            return true;
        }
    }
}

