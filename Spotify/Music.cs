using System;

public class Music{
    public string artiest;
    public string naam;
    public string lengte;

    public Music (string Artiest, string Naam, string Lengte){
        artiest = Artiest;
        naam = Naam;
        lengte = Lengte;
    }
    public string Artiest{
        get { return artiest; }
        set { artiest = value; }
    }
    public string Naam{
        get {return naam;}
        set {naam = value;}
    }
    public string Lengte{
        get {return lengte;}
        set {lengte = value;}
    }
    public override string ToString(){
        string output = "naam: " + naam;
        string output2 = "artiest: " + artiest;
        string output3 = "lengte: " + lengte;
        return output + output2 + output3;
    }
    public string pNaam(){
        return naam;
    }
}