using System;
using System.Collections.Generic;

public class Playlist{
    public string naam;
    public string persoon;
    public List<Music> Nummers;

    public string Naam{
        get {return naam;}
        set {naam = value;}
    }
    public string Persoon{
        get {return persoon;}
        set {persoon = value;}
    }
    public void verNummer(){
        Console.WriteLine("Welk nummer wil je verwijderen?: ");
        string Nummer = Console.ReadLine();
        for (int a = 0; a < Nummers.Count; a++){
            if (Nummers[a].Naam == Nummer){
                Nummers.RemoveAt(a);
            }
        }
    }

    public void verAfspeellijst(){
        for (int a = 0; a < Nummers.Count; a++){
            if (Nummers[a].Naam == Nummers[a].Naam){
                Nummers.RemoveAt(a);
            }
        }
    }

    public void voegNummer(Music Nummer){
        Nummers.Add(Nummer);
    }
    public Playlist(string Naam, List<Music> Nummers, string Persoon){
        naam = Naam;
        persoon = Persoon;
        Nummers = Nummers;
    }

    public override string ToString(){
        string output1 = this.naam + "\n";
        foreach (Music Music in this.Nummers){
            output1 += Music.ToString() + "\n";
        }
        return output1;
    }
}