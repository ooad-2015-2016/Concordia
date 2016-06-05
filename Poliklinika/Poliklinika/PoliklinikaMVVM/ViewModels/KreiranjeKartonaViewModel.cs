using Poliklinika.PoliklinikaBAZA.Models;
using Poliklinika.PoliklinikaMVVM.Helper;
using Poliklinika.PoliklinikaMVVM.Models;
using Poliklinika.PoliklinikaMVVM.Views;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.IO;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices.WindowsRuntime;
using System.Windows.Input;
using Windows.Graphics.Imaging;
using Windows.Storage.Streams;
using Windows.UI.Popups;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Media.Imaging;

namespace Poliklinika.PoliklinikaMVVM.ViewModels
{
    public class KreiranjeKartonaViewModel : INotifyPropertyChanged
    {
        public INavigationService NavigationService { get; set; }
        public CameraHelper Camera { get; set; }        public ICommand Uslikaj { get; set; }
        public ICommand Dodaj { get; set; }

        public string ime { get; set; }
        public string prezime { get; set; }
        public string krvnaGrupa { get; set; }
        public List<string> kgrupe { get; set; }
        public string jmbg { get; set; }

        public DateTime datumRodjenja { get; set; }
        public DateTime datumRegistracije { get; set; }

        public byte[] slicica { get; set; }

        private SoftwareBitmapSource slika;
        public SoftwareBitmapSource Slika
       
        {
            get { return slika; }
            set
            {
                slika = value;
                OnNotifyPropertyChanged("Slika");
            }
        }
        //kontrola krsenje mvvm
        CaptureElement previewControl;
        public KreiranjeKartonaViewModel(CaptureElement previewControl)
        {
            //incijalicacija uredjaja

            Camera = new CameraHelper(previewControl);
            Camera.InitializeCameraAsync();

            Uslikaj = new RelayCommand<object>(uslikaj, (object parametar) => true);
            NavigationService = new NavigationService();
            Dodaj = new RelayCommand<object>(dodaj, (object parametar) => true);
            datumRodjenja = new DateTime();
            datumRegistracije = new DateTime();

            kgrupe = new List<string>();
            kgrupe.Add("A+");
            kgrupe.Add("B+");
            kgrupe.Add("AB+");
            kgrupe.Add("A-");
            kgrupe.Add("B-");
            kgrupe.Add("AB-");
            kgrupe.Add("0+");
            kgrupe.Add("0-");
            
        }
        //komanda koja inicira slikanje
        public async void uslikaj(object parametar)
        {
            await Camera.TakePhotoAsync(SlikanjeGotovo);
        }

        public async void dodaj(object parametar)
        {
            if (ime == "" || prezime == "" || krvnaGrupa == null || jmbg=="")
            {
                var dialog1 = new MessageDialog("Nisu uneseni svi podaci", "Poliklinika Concordia");

                await dialog1.ShowAsync();
            }

           else if(!IsAllDigits(jmbg) || jmbg.Length != 11)
            {
                var dialog1 = new MessageDialog("JMBG mora sadrzavati 11 numeričkih znakova!", "Poliklinika Concordia");

                await dialog1.ShowAsync();
            }
            else
            {
                ZdravstveniKarton zk = new ZdravstveniKarton();
            zk.imePacijenta = ime;
            zk.prezimePacijenta = prezime;

            zk.KrvnaGrupa = krvnaGrupa;
            PictureConverter pc = new PictureConverter();
            zk.Slika = (byte[])pc.Convert(Slika, null, null, null);


                
                RegistrovaniPacijent p = new RegistrovaniPacijent(ime, prezime, datumRodjenja, jmbg);
                TimeSpan ts = new TimeSpan(0, 0, 0);

                datumRegistracije = DateTime.Now;
                datumRegistracije=datumRegistracije.Date + ts;
                p.datumRegistracije = datumRegistracije;
                p.datumRodjenja = p.datumRodjenja.Date + ts;
               


                using (var db = new PoliklinikaDbContext())
                {
                    db.ZdravstveniKartoni.Add(zk);
                    db.RegistrovaniPacijenti.Add(p);
                    db.SaveChanges();
                }

                var dialog = new MessageDialog("Uspješno kreiran karton", "Poliklinika Concordia");

                NavigationService.Navigate(typeof(RecepcionistMenu));

                await dialog.ShowAsync();

                
            }

            
            
        }

        bool IsAllDigits(string s)
        {
            foreach (char c in s)
            {
                if (!char.IsDigit(c))
                    return false;
            }
            return true;
        }

        //callback funkcija kad se uslika
        public void SlikanjeGotovo(SoftwareBitmapSource slikica)
        {
            Slika = slikica;
            
        }
        //proeprty changed observer
        public event PropertyChangedEventHandler PropertyChanged;
        protected void OnNotifyPropertyChanged([CallerMemberName] string memberName = "")
        {
            //? je skracena verzija ako nije null
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(memberName));
        }        
    }
}
