using System;
using System.Collections.Generic;
using System.Collections;
namespace financier
{
   
   

    public class Compte
    {
        //attributs

         private int numero;
         private string nomCli;
         private double solde;
       private double decouvertCli;

        //propriétés
        public string NomCli { get => nomCli;  }
        public double Solde { get => solde; set => solde = value; }
        public int Numero { get => numero; }
        public double DecouvertCli { get => decouvertCli; set => decouvertCli = value; }

        //constructeurs
        public Compte(int _numero, string _nomCli, double _solde, double _decouvert    )
        {
            this.numero = _numero;
            this.nomCli = _nomCli;
            this.Solde=_solde;
            this.DecouvertCli = _decouvert;
        }

        

        public Compte() 
        {
            this.numero = 000001;
            this.nomCli = "_sansNom";
            this.Solde = 0;
            this.DecouvertCli = 0;
        }


        //methodes
        public void Crediter( double _valeur)
        {
            this.Solde += _valeur;

        }

        public bool Debiter(double _valeur)
        {
            if ((this.Solde - _valeur) < this.DecouvertCli)
            {
                return false;
            }
            else 
            {
                this.Solde -= _valeur;
                return true;

            }
             
        
        }
        public override string ToString()
        {
            return  " \n Compte : \n numero : "+ this.Numero+ " \n Nom : "+this.NomCli+ " \n Solde : "+ this.Solde+ "\n Découvert Autorisé : " + this.DecouvertCli;
        }


        public bool Transferer(double _valeur, Compte _autreCompte  )
        {
            if (this.Debiter(_valeur) == true)
            {
                _autreCompte.Crediter(_valeur);

                return true;
            }
            else
            { 
            return false;

              }

   
        }
        public bool Superieur( Compte _autreCompte)
        {

            if (this.Solde > _autreCompte.Solde)
            {
                return true;
            }
            else
            {
                return false;
            }
            
                
            
        }



    }
}
