using System;
class Program{
    static void Main(string[] args){
        string input1 = "";
        string input2 = "";
        string input3 = "";
        string input4 = "";
        string gebruikersnaam = "";
        bool Albumfound = false;
        bool titelCheck = false;
        List<Playlist> afspeellijsten = new List<Playlist>();
        List<Music> muziekLijst = new List<Music>();
        List<Album> albumLijst = new List<Album>();
        List<string> Vrienden = new List<string>();
        List<Music> vriendPlaylist = new List<Music>();

        muziekLijst.Add(new Music("Harry Styles","As It Was","1:00"));
        muziekLijst.Add(new Music("James Hype","Ferrari","3:06"));
        muziekLijst.Add(new Music("Antoon","Hallo","2:12"));
        muziekLijst.Add(new Music("Donnie","Vanavond","2:46"));
        muziekLijst.Add(new Music("Antoon", "Hotelschool", "2:21"));
        Vrienden.Add("Gert");
        foreach (Music Music in muziekLijst){
            if (Music.naam == "As It Was" || Music.naam == "Ferrari"){
                vriendPlaylist.Add(Music);
            }
        }
        void voegAfspeellijst(string naam, List<Music> Playlist, string gebruiker)
        {
            afspeellijsten.Add(new Playlist(naam, Playlist, gebruiker));
        }
        void addAlbums(string naam, List<Music> Album, string nameartist)
        {
            albumLijst.Add(new Album(naam, Album, nameartist));
        }

        Console.WriteLine("Voer je gebruikersnaam in: ");
        gebruikersnaam = Console.ReadLine();
        new Person(gebruikersnaam);
        menu();
        void menu(){
            Console.Clear();
            Console.WriteLine("Welkom: " + gebruikersnaam + "!");
            Console.WriteLine("1) Muziek toevoegen");
            Console.WriteLine("2) Muziek verwijderen");
            Console.WriteLine("3) Afspeellijst aanmaken");
            Console.WriteLine("4) Afspeellijst bijwerken");
            Console.WriteLine("5) Vriendenlijst weergeven");
            Console.WriteLine("6) Album aanmaken");
            Console.WriteLine("7) Album bewerken");
            Console.WriteLine("8) Muziek afspelen");
            Console.WriteLine("9) Afspeellijst afspelen");
            Console.WriteLine("Voer je keuze in: ");
            input1 = Console.ReadLine();
            inputMenu(input1);
        }
        void inputMenu(string input1){
            voegAfspeellijst("Gert's afspeellijst", vriendPlaylist, "Gert");
            switch (input1){
                case "1":
                    Console.WriteLine("Voer de naam in van de artiest:");
                    input2 = Console.ReadLine();
                    Console.WriteLine("Voer de naam in van het nummer:");
                    input4 = Console.ReadLine();
                    Console.WriteLine("Voer de lengte van het nummer in:");
                    input3 = Console.ReadLine();
                    muziekLijst.Add(new Music(input2, input4, input3));
                    menu();
                    break;
                case "2":
                    Console.WriteLine("Voer de naam in van de artiest:");
                    input2 = Console.ReadLine();
                    Console.WriteLine("Voer de naam in van het nummer:");
                    input4 = Console.ReadLine();
                    Console.WriteLine("Voer de lengte van het nummer in:");
                    input3 = Console.ReadLine();
                    muziekLijst.Remove(new Music(input2, input4, input3));
                    menu();
                    break;
                case "3":
                    List<Music> afspeellijstNummers = new List<Music>();
                    Console.WriteLine("Voer de naam van de afspeellijst in:");
                    input2 = Console.ReadLine();
                    bool active = true;
                    while (active == true){
                        Console.WriteLine("Voer de naam van het nummer in. Type 'klaar' als je klaar bent.");
                        input4 = Console.ReadLine();
                        if (input4 == "klaar"){
                            active = false;
                            int a = afspeellijstNummers.Count();
                            if (a < 1){
                                Console.WriteLine("Afspeellijst is leeg! Voeg een nummer toe.");
                            }
                            else{
                                voegAfspeellijst(input2, afspeellijstNummers, gebruikersnaam);
                                Console.WriteLine("Afspeellijst aangemaakt!");
                            }
                        }
                        else{
                            foreach (Music Music in muziekLijst){
                                if (Music.Naam == input4){
                                    titelCheck = true;
                                    afspeellijstNummers.Add(Music);
                                    Console.WriteLine(Music);
                                }
                            }
                            if (titelCheck){
                                Console.WriteLine("Het nummer is toegevoegd.");
                            }
                            else{
                                Console.WriteLine("Nummer niet gevonden.");
                            }
                        }
                    }
                    menu();
                    break;
                case "4":
                    Console.WriteLine("1) Nummer toevoegen in je afspeellijst.");
                    Console.WriteLine("2) Nummer verwijderen uit je afspeellijst.");
                    Console.WriteLine("3) Afspeellijst verwijdern.");
                    input2 = Console.ReadLine();
                    if (input2 == "1"){
                        Console.WriteLine("In welke afspeellijst?");
                        input2 = Console.ReadLine();
                        Console.WriteLine("Voer de naam van het nummer in:");
                        input4 = Console.ReadLine();
                        try{
                            foreach (Music Music in muziekLijst){
                                if (Music.Naam == input4){
                                    titelCheck = true;
                                    foreach (Playlist Playlist in afspeellijsten){
                                        if (Playlist.naam == input2){
                                            Playlist.Nummers.Add(Music);
                                            Console.WriteLine("Nummer is toegevoegd!");
                                        }
                                    }
                                }
                            }
                        }
                        catch{
                            Console.WriteLine("Ongeldige input!");
                        }
                    }
                    if (input2 == "2"){
                        Console.WriteLine("In welke afspeellijst?");
                        input2 = Console.ReadLine();
                        foreach (Playlist Playlist in afspeellijsten){
                            if (Playlist.Naam == input2){
                                Console.WriteLine("Voer de naam van het nummer in:");
                                input4 = Console.ReadLine();
                                foreach (Music Music in Playlist.Nummers){
                                    if (Music.Naam == input4){
                                        Playlist.Nummers.Remove(Music);
                                        Console.WriteLine("Nummer is uit de afspeellijst verwijderd.");
                                        menu();
                                    }
                                }
                            }
                        }
                    }
                    if (input2 == "3"){
                        Console.WriteLine("Welke afspeellijst?");
                        input2 = Console.ReadLine();
                        foreach (Playlist Playlist in afspeellijsten){
                            if (Playlist.Naam == input2){
                                Playlist Albumm = Playlist;
                                Albumm.verAfspeellijst();
                                Console.WriteLine("De afspeellijst is verwijderd.");
                            }
                        }
                    }
                    menu();
                    break;
                case "5":
                    if (Vrienden == null || Vrienden.Count == 0){
                        Console.WriteLine("Je vriendenlijst is leeg");
                        Console.WriteLine("Voer een naam in om een vriend toe te voegen.");
                        input2 = Console.ReadLine();
                        Vrienden.Add(input2);
                    }
                    foreach (string vriend in Vrienden){
                        Console.WriteLine(vriend);
                    }
                    Console.WriteLine("1) Vriend toevoegen.");
                    Console.WriteLine("2) Vriend verwijderen.");
                    Console.WriteLine("3) Afspeellijst van een vriend kopiëren.");
                    input2 = Console.ReadLine();
                    if (input2 == "1"){
                        Console.WriteLine("Hoe heet de vriend die je wilt toevoegen?");
                        input2 = Console.ReadLine();
                        Vrienden.Add(input2);
                        Console.WriteLine(input2 + " is toegevoegd aan je vriendenlijst.");
                    }
                    else if (input2 == "2"){
                        Console.WriteLine("Welke vriend wil je verwijderen?");
                        input2 = Console.ReadLine();
                        Vrienden.Remove(input2);
                        Console.WriteLine(input2 + " is verwijderd van je vriendenlijst.");
                    }
                    else if (input2 == "3"){
                        Console.WriteLine("Van welke vriend wil je de afspeellijst kopieren?");
                        input3 = Console.ReadLine();
                        string cF = "";
                        List<Music> copyFriend = new List<Music>();
                        try{
                            foreach (string vriend in Vrienden){
                                if (input3 == vriend){
                                    Console.WriteLine("Welke afspeellijst?");
                                    input2 = Console.ReadLine();
                                    foreach (Playlist Playlist in afspeellijsten){
                                        if (Playlist.persoon == input3){
                                            if (Playlist.naam == input2){
                                                cF = Playlist.naam;
                                                copyFriend = Playlist.Nummers;
                                            }
                                        }
                                    }
                                }
                            }
                            foreach (Music Music in copyFriend){
                                Console.WriteLine(Music);
                            }
                            voegAfspeellijst(cF, copyFriend, gebruikersnaam);
                        }
                        catch{
                            Console.WriteLine("Ongeldige input!");
                        }
                    }
                    menu();
                    break;
                case "6":
                    List<Music> Album = new List<Music>();
                    Console.WriteLine("Voer de naam in van het album");
                    input2 = Console.ReadLine();
                    Console.WriteLine("Voer de naam in van het nummer:");
                    input4 = Console.ReadLine();
                    Console.WriteLine("Voer de naam in van de artiest:");
                    input3 = Console.ReadLine();
                    foreach (Music Music in muziekLijst){
                        if (Music.Naam == input4){
                            if (Music.Artiest == input4){
                                titelCheck = true;
                                Album.Add(Music);
                                Console.WriteLine("The Music is added");
                                addAlbums(input2, Album, input4);
                            }
                        }
                    }
                    break;
                case "7":
                    Console.WriteLine("1) Muziek toevoegen aan een album.");
                    Console.WriteLine("2) Muziek verwijderen van een album.");
                    Console.WriteLine("3) Album verwijderen.");
                    input2 = Console.ReadLine();
                    if (input2 == "1"){
                        Console.WriteLine("Aan welk album wil je muziek toevoegen?");
                        input2 = Console.ReadLine();
                        foreach (Album albums in albumLijst){
                            if (albums.Naam == input2){
                                Console.WriteLine("Voer de naam van het nummer in:");
                                input4 = Console.ReadLine();
                                foreach (Music Music in muziekLijst){
                                    if (Music.Naam == input4){
                                        Album Albumm = albums;
                                        Albumm.voegNummer(Music);
                                    }
                                }
                            }
                        }
                    }
                    if (input2 == "2"){
                        Console.WriteLine("Van welk album wil je muziek verwijderen?");
                        input2 = Console.ReadLine();
                        foreach (Album albums in albumLijst){
                            if (albums.Naam == input2){
                                Album Albumm = albums;
                                Albumm.verNummer();
                            }
                        }
                    }
                    if (input2 == "3"){
                        Console.WriteLine("Welk album wil je verwijderen?");
                        input2 = Console.ReadLine();
                        foreach (Album albums in albumLijst){
                            if (albums.Naam == input2){
                                albumLijst.Remove(albums);
                                menu();
                            }
                        }
                    }
                    break;
                case "8":
                    Console.WriteLine("Welke muziek wil je afspelen?");
                    input2 = Console.ReadLine();
                    foreach (Music Music in muziekLijst){
                        if (Music.Naam == input2){
                            Console.WriteLine("Wil je " + input2 + " afspelen?");
                            input2 = Console.ReadLine();
                            if (input2 == "ja"){
                                Console.WriteLine(input2 + " word afgespeelt");
                                Console.WriteLine("Artiest: " + Music.artiest);
                                Console.WriteLine("Nummer : " + Music.naam);
                                Console.WriteLine("Lengte : " + Music.Lengte);
                                string plit = Music.lengte.Split(':')[0];
                                string plit2 = Music.lengte.Split(':')[1];
                                int totalsplit1 = Convert.ToInt32(plit) * 60;
                                int totalsplit2 = Convert.ToInt32(plit2) + totalsplit1 * 1000;
                                Thread.Sleep(totalsplit2);
                            }
                            else if (input2 == "nee"){
                                menu();
                            }
                        }
                    }
                    break;
                    case "9":
                    Console.WriteLine("Welke afspeellijst wil je afspelen?");
                    input2 = Console.ReadLine();
                    foreach (Playlist Playlist in afspeellijsten){
                        if (Playlist.naam == input2){
                            Console.WriteLine("Wil je " + Playlist + " Afspelen?");
                            input2 = Console.ReadLine();
                            if (input2 == "ja"){
                                Console.WriteLine("Wil je de afspeellijst shuffelen?");
                                input2 = Console.ReadLine();
                                if (input2 == "ja"){
                                    Random num = new Random();
                                    int ranNum = num.Next(0, Playlist.Nummers.Count);
                                    Console.WriteLine(Playlist.Nummers[ranNum]);
                                    string plit = Playlist.Nummers[ranNum].lengte.Split(':')[0];
                                    string plit2 = Playlist.Nummers[ranNum].lengte.Split(':')[1];
                                    int totalsplit1 = Convert.ToInt32(plit) * 60;
                                    int totalsplit2 = Convert.ToInt32(plit2) + totalsplit1 * 1000;
                                    Thread.Sleep(totalsplit2);
                                }
                                else if (input2 == "nee"){ 
                                    foreach (Music Music in Playlist.Nummers){
                                        Console.WriteLine(Music + " word nu afgespeelt.");
                                        string plit = Music.lengte.Split(':')[0];
                                        string plit2 = Music.lengte.Split(':')[1];
                                        int totalsplit1 = Convert.ToInt32(plit) * 60;
                                        int totalsplit2 = Convert.ToInt32(plit2) + totalsplit1 * 1000;
                                        Thread.Sleep(totalsplit2);
                                    }
                                }
                            }
                        }
                    }
                    break;
                default:
                    menu();
                    break;
            }
        }
    }
}