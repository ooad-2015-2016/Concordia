using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Poliklinika.PoliklinikaMVVM.Models
{
    public class MogucePretrage
    {
        public MogucePretrage() { }

        public List<Pretraga> pretrageDermatologija()
        {
            List<Pretraga> lista = new List<Pretraga>();
            lista.Add(new Pretraga("Hemijski piling", 120));
            lista.Add(new Pretraga("Mezoterapija", 120));
            lista.Add(new Pretraga("Veneroloski pregled", 120));
            lista.Add(new Pretraga("Vistabel terapija bora lica", 120));
            lista.Add(new Pretraga("Povećanje usana", 120));
            lista.Add(new Pretraga("Digitalna dermatoskopija", 120));
            lista.Add(new Pretraga("Dermatoloski pregled", 120));
            lista.Add(new Pretraga("Radiofrekvencijsko uklanjanje madeza", 120));
            lista.Add(new Pretraga("Lijecenje HPV infekcije", 120));
            return lista;
        }

        public List<Pretraga> pretrageGinekologija()
        {
            List<Pretraga> lista = new List<Pretraga>();
            lista.Add(new Pretraga("Specijalisticki pregled ginekologa", 120));
            lista.Add(new Pretraga("Pregled trudnice", 120));
            lista.Add(new Pretraga("Trudnicki UZV", 120));
            lista.Add(new Pretraga("PAPA test", 120));
            lista.Add(new Pretraga("Kolposkopija", 120));
            lista.Add(new Pretraga("Vaginalni brisevi", 120));
            lista.Add(new Pretraga("Folikulometrija", 120));
            lista.Add(new Pretraga("Mikrobiološka dijagnostika", 120));
            lista.Add(new Pretraga("Postavljanje spirale", 120));
            
            return lista;
        }

        public List<Pretraga> pretrageInterna()
        {
            List<Pretraga> lista = new List<Pretraga>();
            lista.Add(new Pretraga("Pregled specijaliste", 120));
            lista.Add(new Pretraga("UZ srca", 120));
            lista.Add(new Pretraga("EKG s ocitanjem", 120));
            lista.Add(new Pretraga("Konsultacija za TH i očitanje INR-a", 120));
            lista.Add(new Pretraga("Specijalisticki pregled kardiologa", 120));
            lista.Add(new Pretraga("Holter EKG", 120));
            lista.Add(new Pretraga("Holter tlaka", 120));
            lista.Add(new Pretraga("Ultrazvuk srca", 120));
            lista.Add(new Pretraga("Brzi ureaza test", 120));
            
            return lista;
        }

        public List<Pretraga> pretrageGastroenterologija()
        {
            List<Pretraga> lista = new List<Pretraga>();
            lista.Add(new Pretraga("Specijalisticki pregled gastroenterologa", 120));
            lista.Add(new Pretraga("Gastroskopija", 120));
            lista.Add(new Pretraga("Kolonoskopija", 120));
            lista.Add(new Pretraga("Urea izdisajni test", 120));
            lista.Add(new Pretraga("Uzimanje biopsijskog materijala", 120));
            return lista;
        }

        public List<Pretraga> pretragePorodicna()
        {
            List<Pretraga> lista = new List<Pretraga>();
            lista.Add(new Pretraga("Konsultacije sa doktorom", 120));
            lista.Add(new Pretraga("Kontrola šećernih bolesnika", 120));
            lista.Add(new Pretraga("Kontrola masnoća u krvi", 120));
            lista.Add(new Pretraga("Liječenje reumatskih bolesti", 120));
            lista.Add(new Pretraga("Test alergije", 120));
            lista.Add(new Pretraga("Sistematski pregled", 120));
            return lista;
        }
    }
}
