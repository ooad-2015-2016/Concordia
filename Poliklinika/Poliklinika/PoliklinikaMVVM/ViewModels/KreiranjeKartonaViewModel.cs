﻿using Poliklinika.PoliklinikaBAZA.Models;
using Poliklinika.PoliklinikaMVVM.Helper;
using Poliklinika.PoliklinikaMVVM.Models;
using System;
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

        public CameraHelper Camera { get; set; }
        public ICommand Dodaj { get; set; }

        public string ime { get; set; }
        public string prezime { get; set; }
        public object krvnaGrupa { get; set; }

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
            Dodaj = new RelayCommand<object>(dodaj, (object parametar) => true);
        }
        //komanda koja inicira slikanje
        public async void uslikaj(object parametar)
        {
            await Camera.TakePhotoAsync(SlikanjeGotovo);
        }

        public async void dodaj(object parametar)
        {
            if (ime == "" || prezime == "" || krvnaGrupa == null)
            {
                var dialog1 = new MessageDialog("Nisu uneseni svi podaci", "Poliklinika Concordia");

                await dialog1.ShowAsync();
            }
            else
            {
                ZdravstveniKarton zk = new ZdravstveniKarton();
            zk.imePacijenta = ime;
            zk.prezimePacijenta = prezime;
            zk.KrvnaGrupa = krvnaGrupa.ToString();

            //slika?? convert iz SoftwareBitmapSource -> byte[]

           
                RegistrovaniPacijent p = new RegistrovaniPacijent(ime, prezime, DateTime.Now, "proba");


                using (var db = new PoliklinikaDbContext())
                {
                    db.ZdravstveniKartoni.Add(zk);
                    db.RegistrovaniPacijenti.Add(p);
                    db.SaveChanges();
                }

                var dialog = new MessageDialog("Uspješno kreiran karton", "Poliklinika Concordia");

                await dialog.ShowAsync();
            }
            
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