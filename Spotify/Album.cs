using System;
using System.Collections.Generic;

public class Album
{
    public string naam;
    public string persoon;
    public List<Music> Nummers;
    private List<Music> album;
    private string nameartist;

    public Album(string Naam, string Persoon, List<Music> Nummers){
        naam = Naam;
        persoon = Persoon;
        Nummers = Nummers;
    }

    public Album(string naam, List<Music> album, string nameartist){
        this.naam = naam;
        this.album = album;
        this.nameartist = nameartist;
    }

    public string Naam{
        get {return naam;}
        set {naam = value;}
    }
    public string Persoon{
        get {return persoon;}
        set {persoon = value;}
    }

    public void voegNummer(Music Nummer)
    {
        Nummers.Add(Nummer);
    }
    public void verAfspeellijst()
    {
        for (int a = 0; a < Nummers.Count; a++)
        {
            if (Nummers[a].Naam == Nummers[a].Naam)
            {
                Nummers.RemoveAt(a);
            }
        }
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
    public override string ToString(){
        string output1 = this.naam + "\n";
        foreach (Music Music in this.Nummers){
            output1 += Music.ToString() + "\n";
        }
        return output1;
    }
}