using System;
using System.Collections.Generic;


namespace lib_kiloutou
{
    public class Voiture:IComparable

    {
        //attributs
        private int numeroserie;
        private string marque;
        private string modele;
       private DateTime dateCirculation;

      


        // Propriétés
        public int Numeroserie { get => numeroserie; }
        public string Marque { get => marque; }
        public string Modele { get => modele;  }
       public DateTime DateCirculation { get => dateCirculation;  }

        //Constructeurs
        public Voiture(int _numeroserie, string _marque, string _date , string _modele)
        {
            DateTime tempdate;
            if (DateTime.TryParse(_date, out tempdate))
            {
                this.dateCirculation = tempdate;
            }
            else 
            {
                this.dateCirculation = DateTime.Today;
            }
            this.numeroserie = _numeroserie;
            this.marque = _marque;
            this.modele = _modele;
          
        }
        // Méthodes
        public override string ToString()
        {
            return "Voiture - Numero de serie : " + this.Numeroserie + " || Marque : "+ this.Marque + " || Modele : "+ this.Modele +" || Date de circulation : "+this.DateCirculation.ToShortDateString()+"\n";
        }

        public int CompareTo(object _autreVoiture)
        {
            Voiture voitureTest = (Voiture)_autreVoiture;


            int classement = this.Marque.CompareTo(voitureTest.Marque);
            return classement; 
        }
    }

}
