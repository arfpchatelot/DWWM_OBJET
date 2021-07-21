using System;
using System.Collections.Generic;
using System.Text;

namespace jeu421
{
    public class De
    {
        //attributs
        private int valeur;
        //propriétées
        public int Valeur { get => valeur; set => valeur = value; }
        //Constructeur
        public De()
        {
            this.valeur = 0;
        }

        public void jeter()
        {
            this.valeur = (Alea.Instance()).Nouveau(1, 6);
        }
    }
}
