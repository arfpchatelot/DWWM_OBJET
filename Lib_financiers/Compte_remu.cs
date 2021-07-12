using System;
using System.Collections.Generic;
using System.Text;

namespace financier
{
      public class Compte_Remu:Compte
    {
       public static double taux_Interet=0.02;

       private DateTime date_Ouverture;
       private  List<double> tabSoldesCompte = new List<double>();

       public Compte_Remu(int _numero, string _nomCli, double _solde, double _decouvert, int _jour, int _mois,int _annee) : base(_numero, _nomCli, _solde, _decouvert)
        {
            this.date_Ouverture = new DateTime(_annee, _mois, _jour);

            for (int i = 0; i < 24; i++)
            {
                tabSoldesCompte.Add(_solde);
            }
                
      
        }
        public override string ToString()
        {
            return base.ToString()+ "\n pour taux d'intérêt :"+ taux_Interet +" et pour date d'ouverture "+ this.date_Ouverture.ToString("dd-MM-yyyy") ;
        }
        public double  Calculer_Interet( DateTime _uneDate)
        {


            int temp;
            if (_uneDate.Day>15)
            {
                 temp = _uneDate.Month * 2 - 1;
            }
            else
            {
                temp = _uneDate.Month * 2 -2 ;

            }
                double sommeinterets = 0;
            for (int i =0 ; i < temp; i++)
            {
               sommeinterets += this.tabSoldesCompte[i]*taux_Interet/(double)24;
            }

           
            return sommeinterets;
        }
        


    }
}
