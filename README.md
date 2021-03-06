﻿## Concordia

1. Panjeta Vildana
2. Puce Amina
3. Selmanović Abdullah
4. Sjeničaku Alen

**Poliklinika**

Poliklinika "Concordia" slovi za jednu od najprestižnijih poliklinika na području Sarajeva. Cilj poliklinike je nastaviti sa radom na razini vodećih svjetskih privatnih poliklinika, stoga se vlasnik "Concordie" odlučio odreći zastarjelog načina pohranjivanja brojnih dokumenata(zdravstenih kartona, uputnica, rasporeda osoblja,...) koji su rad klinike činili znatno sporijim. Uvođenjem novog informacionog sistema će se na adekvatan način pratiti svi pacijenti registrirani na ovoj poliklinici, pri čemu će ljekari imati lakši pristup historiji bolesti svojih pacijenata. Informacioni sistem će olakšati posao i administrativnom osoblju(recepcionista i blagajnik), a podrazumijevat će pregled dnevnog/sedmičnog rasporeda liječnika, zakazanih/otkazanih pregleda pacijenata i njihovih zdravstvenih kartona. Blagajnik će po obavljenom pregledu naplaćivati usluge pacijentima i izvještaje slati direktoru(administratoru) poliklinike. Liječnički tim će s ovim informacionim sistemom imati organizovaniji raspored, sistematičniju historiju bolesti svakog od pacijenata što će im biti od pomoći u budućim pregledima.

**Procesi**

*Registracija novog zaposlenika*

Administrator se prijavljuje na sistem, te bira opciju za registraciju novog zaposlenika. Unosi podatke o novom zaposleniku, i dodjeljuje mu username i password za sistem. Po završetku unosa podataka, te klikom na dugme za unos zaposlenika, mogućnost prijave na sistem dobiva i novi zaposlenik.

*Evidencija*

Administrator nakon prijave na sistem, ima mogućnost da vidi sve zakazane preglede koje je unio recepcionista, kao i zdravstvene kartone svih pacijenata unesenih u sistem poliklinike. Osim toga, omogućen mu je uvid i u prihode/rashode poliklinike i u određene statističke podatke(npr. mjesec sa najvećom zaradom, najčešće bolesti liječene na poliklinici i sl.)

*Prvi dolazak/Kreiranje zdravstvenog kartona na poliklinici*

Pri prvom dolasku na polikliniku, recepcionista kreira zdravstveni karton pacijentu(tj.unosi ga u sistem). Pacijenti su dužni recepcionisti dati svoje lične podatke. Recepcionista im ponudi program porodične medicine(on podrazumijeva da pacijentova matična poliklinika postane „Concordia“). Ukoliko se pacijent odluči za ovaj program, dobiva niz privilegija kao što su: popust svaki peti pregled i mogućnost korištenja naše mobilne aplikacije. Na recepciji se obavlja slikanje pacijenta (vanjski uređaj, kamera) radi unošenja njegove slike u sistem. Pacijent dobiva svoj username i password za pristup mobilnoj aplikaciji.

*Pregled*

Po dolasku na polikliniku pacijent se javlja recepcionisti, koji ga šalje doktoru na zakazani pregled. Doktor može vidjeti na sistemu zdravsteni karton pacijenta koji mu je došao na pregled i njegovu historiju bolesti, te na kraju termina, unijeti novu dijagnozu. Po završetku pregleda blagajnik, također, ima uvid u novu dijagnozu, te kreira račun za pregled i naplaćuje ga. Pacijent može plaćati gotovinom/kreditnom karticom.  Nakon plaćenog računa, račun proslijedi administratoru klinike.

*Mobilna aplikacija*

Svaki pacijent čija je matična poliklinika „Concordia“ može koristiti mobilnu aplikaciju poliklinike. Potrebno je da unese svoj username i password koji je dobio na recepciji. Sat vremena prije pregleda aktivira se reminder na njegovom mobilnom telefonu koji ga napominje na zakazani termin. 


**Funkcionalnosti**

ADMINISTRATOR

- mogućnost registracije/zapošljavanja novih zaposlenika, te brisanje istih

- uvid u zakazane preglede kod svih doktora

- uvid u sve prijavljene pacijente

- uvid u statističke podatke klinike

- uvid u novčano stanje klinike

DOKTOR

- uvid u svoj raspored

- uvid u sve prijavljene pacijente i njihovu historiju bolesti

- unos dijagnoze za pacijenta

RECEPCIONIST

- uvid u sve registrovane pacijente

- mogućnost kreiranja kartona za pacijenta

- zakazivanje termina pregleda 

BLAGAJNIK

- uvid u pacijentov pregled, te kreiranje računa za isti

- naplaćivanje pregleda

- slanje potvrde o plaćenom pregledu administratoru

PACIJENT

- mogućnost korištenja mobilne aplikacije poliklinike

**Akteri**

1. Administrator – predstavlja direktora poliklinike koji ima uvid u sve zaposlenike, zakazene preglede, zaradu, te ima mogućnost registracije novih zaposlenika i sl.
2. Doktor - vrši pregled pacijenata prema predviđenom rasporedu, unosi dijagnoze u sistem
3. Recepcionista - obavlja registraciju pacijenata, odobrava preglede pacijentima, te kreira raspored doktora
4. Blagajnik -  kreira račune za preglede, vrši naplatu istih, te vodi evidenciju o svim računima
5. Pacijent - dolazi na preglede, prethodno zakazane lično
6. Sistem za autorizaciju kartica - sistem van domena našeg sistema


**FINAL**

1. Za komunikaciju sa bazom korišten je Entity Framework (sqllite baza)

2. Kao eksterni uređaj korištena je kamera. Poziva se prilikom kreiranja kartona pacijenta ->  https://github.com/ooad-2015-2016/Concordia/blob/master/Poliklinika/Poliklinika/PoliklinikaMVVM/ViewModels/KreiranjeKartonaViewModel.cs

3. Validacija je ispoštovana na svim mjestima gdje se unose podaci, prilikom kreiranja kartona, zaposlenika, pregleda, te i prilikom unosa dijagnoze(pregleda) vrši se provjera da li je taj pacijent zakazao unaprijed pregled. Također ukoliko se klikne na pregled zdravstvenog kartona pacijenta, a on ga nema, piše da "Nema kreiran karton!"  jedna od klasa na kojoj je ispoštovana validacija -> https://github.com/ooad-2015-2016/Concordia/blob/master/Poliklinika/Poliklinika/PoliklinikaMVVM/ViewModels/PregledViewModel.cs

4. Eksterni servis - nije urađeno

5. Mobilna funkcionalnost - pokušano je omogućavanje slanja sms-a o zakaznom pregledu pacijentu, ali nije odrađeno do kraja -> https://github.com/ooad-2015-2016/Concordia/blob/master/Poliklinika/Poliklinika/PoliklinikaMVVM/Helper/SMSCommunicationHelper.cs

6. Web servis - nije urađeno

7. Odvojen je exe file za igricu

U folderu 'Video' postavljen je video sa osnovnim funkcionalnostima aplikacije.
