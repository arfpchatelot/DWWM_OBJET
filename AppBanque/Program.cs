using System;
using financier;

namespace AppComptes
{
    class Program
    {
        static void Main(string[] args)
        {

            //Compte A = new Compte(123456, "Haddock", 15000, -2000);
            //Compte B = new Compte(456789, "Tournesol",2000, -1000);
            //Console.WriteLine(A);
            //Console.WriteLine("----------------------------");
            //Console.WriteLine(B);
           
            //bool test = A.Debiter(17000);

            //if (!test)
            //{
            //    Console.WriteLine("debit non autorisé, dépassement de découvert ");


            //}
            //else
            //{
            //    Console.WriteLine("-----------Débit autorisé--------------");
            //    Console.WriteLine(A);

            //}
            Banque BNP = new Banque("BANQUE NATIONAL PARIS", "MULHOUSE");
            bool ajout;

           ajout= BNP.AjouterCompte("Séraphin", 123456, 3000.10, -5000);

            ajout = BNP.AjouterCompte("Bianca",123457, 1500.10, -2000);
            
            ajout = BNP.AjouterCompte("Dupont",653215, 1500.10, -2000);
            ajout = BNP.AjouterCompte( "Haddock",145689, 15000.50, -2000);
            ajout = BNP.AjouterCompte("Tournesol",894561, 29000.10, -2000);

            if (ajout)
            {
                Console.WriteLine(BNP);

            }
            else
            {
                Console.WriteLine("numero de compte existant, ajout impossible");
            }
            Console.WriteLine("recherche d'un compte: " + BNP.RendCompte(123458));


            // Compte max = BNP.CompteSup();
          //  Console.WriteLine(" Le compte ayant la provision maximum de la banque est : " + BNP.CompteSup());

            Console.ReadKey();

        }
    }
}
