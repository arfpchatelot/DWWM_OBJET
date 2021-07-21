using System;
using System.Collections.Generic;
using System.Text;
using jeu421;
namespace AppJeu421
{
    class Test
    {
        public static void Affiche(De _unDe)
        {
            Console.WriteLine(_unDe.Valeur);    
            
        }
        public static void Affiche(Lancer _unLancer)
        {
            Console.WriteLine("--------------------------\n");
            for (int i = 1; i <=3; i++)
            {
                Console.Write(_unLancer.GetValeur(i) + "  ");


            }
            Console.WriteLine("--------------------------\n");
        }

        public static void Recommencer(Partie _maPartie, int _nbreD)
        {
            if (_nbreD == 3)
            {
                for (int i = 1; i < 3; i++)
                {
                    _maPartie.LancerCourant.LancerUnDe(i);
                }
               
            }
            else if (_nbreD == 2)
            {
              
                    Console.WriteLine(" Quel est le premier dé que vous voulez rejouer(1, 2, 3) ? ");
                int res =int.Parse(Console.ReadLine());

               
                Console.WriteLine(" Quel est le deuxième dé que vous voulez rejouer(1, 2, 3) ? ");
                int res2= int.Parse(Console.ReadLine());
                _maPartie.LancerCourant.LancerUnDe(res);
                _maPartie.LancerCourant.LancerUnDe(res2);
                _maPartie.LancerCourant.Trier();



            }
            else
            {
                Console.WriteLine(" Quel est le dé que vous voulez rejouer(1, 2, 3) ? ");
                int res = int.Parse(Console.ReadLine());
                _maPartie.LancerCourant.LancerUnDe(res);
                _maPartie.LancerCourant.Trier();


            }



        
        }

        public static void run()
        {
            Console.WriteLine("Combien de manche voulez-vous jouer ?");
            int nbremanche = int.Parse(Console.ReadLine());
            Partie maPartie = new Partie(nbremanche);
            int nbessai;
            do
            {
                
                maPartie.NouveauLancer();
                Console.WriteLine("manche numero :" + maPartie.NumeroManche);
                Console.WriteLine("score :" + maPartie.NbPoint);
                Affiche(maPartie.LancerCourant);
                nbessai = 1;
                while (maPartie.LancerCourant.EstGagnant()==false &&  nbessai < 3)
                {
                    Console.WriteLine("Combien de Dés voulez-vous rejouer?");
                    int nbre_a_rejouer = int.Parse(Console.ReadLine());
                    Recommencer(maPartie, nbre_a_rejouer);
                    Affiche(maPartie.LancerCourant);
                    nbessai++;
                
                }
                maPartie.MajPoint();
                

            } while (maPartie.NbPoint>0  &&  maPartie.NumeroManche< nbremanche );

            if (maPartie.NbPoint <= 0)
            {
                Console.WriteLine("La partie est perdu vous n'avez plus de point !");
            }
            else
            {
                Console.WriteLine("Vous avez atteint le nombre maximal de manches choisies, la partie est terminée ");
            }

        }



    }
}
