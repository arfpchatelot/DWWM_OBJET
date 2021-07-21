using System;
using System.Collections.Generic;
using System.Text;

namespace jeu421
{
  public class Lancer
    {

        //attribut

        private De[] Tabde = new De[3];
        int essai;
        //Constructeur

        public Lancer()
        {
            for (int i = 0; i < Tabde.Length; i++)
            {
                Tabde[i] = new De();
                Tabde[i].jeter();
            }
            this.Trier();
        
        }

        public void Trier()
        {
            bool tri;

            do
            {

                tri = false;
                for (int i = 0; i <Tabde.Length-1; i++)
                {
                    if (Tabde[i].Valeur<Tabde[i+1].Valeur)
                    {
                        int temp = Tabde[i].Valeur;
                        Tabde[i].Valeur = Tabde[i + 1].Valeur;
                        Tabde[i + 1].Valeur = temp;
                        tri = true;



                    }
                }

            } while (tri==true);
        
        }

        public bool EstGagnant()
        {
            bool verif = false;

            if (Tabde[0].Valeur==4 && Tabde[1].Valeur==2 && Tabde[2].Valeur==1)
            {
                verif = true;
            }
            return verif;
        
        }
        public void LancerUnDe(int _numeroDe)
        {
            Tabde[_numeroDe - 1].jeter();

        }
        public int GetValeur(int _numeroDe)
        {
            return Tabde[_numeroDe - 1].Valeur; 

        }

    }
}
