using System;
using System.Collections.Generic;
using System.Text;

namespace jeu421
{
    public class Partie
    {
        //attributs 
        private Lancer lancerCourant;
    
        private int nombreMaxManche;
        private int nbPoint;
        private int numeroManche;
        //
        public Partie(int _unNombre )
        { this.nombreMaxManche = _unNombre;
            this.nbPoint= _unNombre*10;
            numeroManche = 0;
        }
        public void NouveauLancer()
        {
            LancerCourant = new Lancer();
            numeroManche++;
        }

        public void MajPoint()
        {
            if (LancerCourant.EstGagnant() == true)
            {
                NbPoint += 30;

            }
            else
            {

                nbPoint -= 15;
            }
        

        }


        public bool EstPerdu()
        {
            if (NbPoint <= 0)
            {
                return false;
            }
            else
            {
                return true; 
            }
        
        }


        //propriétés
        public int NombreMaxManche { get => nombreMaxManche; }
        public int NbPoint { get => nbPoint; set => nbPoint = value; }
        public int NumeroManche { get => numeroManche; set => numeroManche = value; }
        public Lancer LancerCourant { get => lancerCourant; set => lancerCourant = value; }
    }



        
        

   
}
