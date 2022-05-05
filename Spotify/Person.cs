using System;
public class Person{
	public string naam;
	public Person(string Naam){
		naam = Naam;
	}
	public string Naam{
		get {return naam;}
		set {naam = value;}
	}
}