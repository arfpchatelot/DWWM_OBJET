using System;
using System.Collections.Generic;
using lib_kiloutou;
namespace AppVoiture
{
    class Program
    {
        static void Main(string[] args)
        {
            List<Voiture> garageKiloutou = new List<Voiture>();
            garageKiloutou.Add(new Voiture(2098, "peugeot","2010/10/30", "307"));
            garageKiloutou.Add(new Voiture(1987, "Renault","2006/8/10", "Espace"));
            garageKiloutou.Add(new Voiture(1203, "Lancia","1986/5/25","Dedra"));
            garageKiloutou.Add(new Voiture(3049, "BMW","1991/06/20","324d"));
            garageKiloutou.Add(new Voiture(1500, "Peugeot","2004/04/12", "406"));
            garageKiloutou.Add(new Voiture(2500, "Ford","2006/04/12", "Mondeo"));
           
            
            Console.WriteLine("-----------------liste kiloutou avant le tri par marque --------------");
            garageKiloutou.ForEach(Voiture => Console.WriteLine(Voiture));

            garageKiloutou.Sort(new ComparerParDateCirc());
            Console.WriteLine("-----------------liste kiloutou après le tri par numero --------------");

            garageKiloutou.ForEach(Voiture => Console.WriteLine(Voiture));


            //garageKiloutou.Sort();

            //Console.WriteLine("-----------------liste kiloutou après le tri --------------");

            //garageKiloutou.ForEach(Voiture => Console.WriteLine(Voiture));

            Console.ReadKey();

        }
    }
}
