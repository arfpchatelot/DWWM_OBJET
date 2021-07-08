using System;
using System.Collections.Generic;
using System.Collections;
namespace financier
{
    public class Banque
        {
        //attributs 
        public Compte[] mesComptes = new Compte[30];

        private int nbComptes;
        private string nomBanque;
         private string  villeBanque;

        //constructeurs
        public Banque(string _nom, string _ville)
        {
            this.nomBanque = _nom;
            this.villeBanque = _ville;
            this.NbComptes = 0;
        }
        //propriétés
        public string NomBanque { get => NomBanque;  }
        public string VilleBanque { get => villeBanque;  }
        public int NbComptes { get => nbComptes; set => nbComptes = value; }
       
        
        // methodes
        private void AjouterCompte(Compte _autreCompte )
        {  nbComptes++;
            mesComptes[(nbComptes - 1)] = _autreCompte;
        }
        public bool AjouterCompte(string _nom, int _numero, double _solde, double _decouvert )
        {
          
       
            for (int i = 0; i <nbComptes; i++)
            {
                if (mesComptes[i].Numero==_numero)
                {
                    return false;

                }
            }
            Compte _compteTemp = new Compte(_numero, _nom, _solde, _decouvert);
            this.AjouterCompte(_compteTemp);
            return true;

        }


        public override string ToString()
        {
            string chaine ="-------------------- BANQUE "+this.nomBanque+"//"+this.villeBanque+"------------------------\n ---------------------liste des comptes------------------------ \n ";
            for (int i = 0; i < this.nbComptes; i++)
            {
                chaine +="\n"+mesComptes[i].ToString()+"------------------- \n" ;
            }
            chaine += "------------------ fin de liste --------------------------\n";
            return chaine;

        }

        public Compte RendCompte(int _numeroCompte) 
        {
            for (int i = 0; i < this.nbComptes; i++)
            {
                if (mesComptes[i].Numero==_numeroCompte)
                {
                    return mesComptes[i];
                }
            }
            return null;
        }
        public Compte RendCompte2(int _numeroCompte)
        {
            bool test = false;
            int indice = 0;
            for (int i = 0; i < this.nbComptes; i++)
            {
                if (mesComptes[i].Numero == _numeroCompte)
                {
                    test = true;
                    indice = i;
                   
                }
            }
            if (test)
            {
                return mesComptes[indice];
            }
            else
            {
                return null;
            }
        }

        public Compte CompteSup()
        {
            Compte comptemax = this.mesComptes[0];
            for (int i = 1; i < nbComptes; i++)
            {
                if (mesComptes[i].Solde > comptemax.Solde)
                {
                    comptemax = mesComptes[i];
                }

            }
            return comptemax;



        }
    }
    public class BanqueListe
    {
        //attributs 
        private List<Compte> lesComptes = new List<Compte>();
        
        
        private int nbComptes;
        private string nomBanque;
        private string villeBanque;

        //constructeurs
        public BanqueListe(string _nom, string _ville)
        {
            this.nomBanque = _nom;
            this.villeBanque = _ville;
            this.NbComptes = 0;
        }
        //propriétés
        public string NomBanque { get => NomBanque; }
        public string VilleBanque { get => villeBanque; }
        public int NbComptes { get => nbComptes; set => nbComptes = value; }
        public List<Compte> LesComptes { get => lesComptes; }


        // methodes
        private void AjouterCompte(Compte _autreCompte)
        {
           
            lesComptes.Add(_autreCompte);
            nbComptes = LesComptes.Count;
        }
        public bool AjouterCompte(string _nom, int _numero, double _solde, double _decouvert)
        {


            for (int i = 0; i < nbComptes; i++)
            {
                if (lesComptes[i].Numero == _numero)
                {
                    return false;

                }
            }
            Compte _compteTemp = new Compte(_numero, _nom, _solde, _decouvert);
            this.AjouterCompte(_compteTemp);
            return true;

        }


        public override string ToString()
        {
            string chaine = "-------------------- BANQUE " + this.nomBanque + "//" + this.villeBanque + "------------------------\n ---------------------liste des comptes------------------------ \n ";
            foreach (Compte element in this.LesComptes)
            {
                chaine += "\n" + element + "------------------- \n";

            }

            chaine += "------------------ fin de liste --------------------------\n";
            return chaine;

        }

        public Compte RendCompte(int _numeroCompte)
        {
            for (int i = 0; i < this.nbComptes; i++)
            {
                if (lesComptes[i].Numero == _numeroCompte)
                {
                    return lesComptes[i];
                }
            }
            return null;
        }
        public Compte RendCompte2(int _numeroCompte)
        {
            bool test = false;
            int indice = 0;
            for (int i = 0; i < this.nbComptes; i++)
            {
                if (lesComptes[i].Numero == _numeroCompte)
                {
                    test = true;
                    indice = i;

                }
            }
            if (test)
            {
                return lesComptes[indice];
            }
            else
            {
                return null;
            }
        }

        public Compte CompteSup()
        {
            Compte comptemax = this.lesComptes[0];
            for (int i = 1; i < lesComptes.Count; i++)
            {
                if (lesComptes[i].Solde > comptemax.Solde)
                {
                    comptemax = lesComptes[i];
                }

            }
            return comptemax;



        }
        public bool VirementBanque(int _numerodebiteur, int _numerobeneficaire, int _montant, out string _message)
        {
            if (RendCompte(_numerodebiteur)!=null)
            {

                if (RendCompte(_numerobeneficaire)!=null)
                {
                    bool testdecouvert;
                     testdecouvert = RendCompte(_numerodebiteur).Transferer(_montant, RendCompte(_numerobeneficaire));
                    if (!testdecouvert)
                    {

                        _message = "Solde insuffisant, opération impossible";

                        return false;
                    }
                    else
                    {
                        _message = "Virement effectué";
                        return  true;
                    }

                }
                else
                {
                    _message = "Compte bénéficiaire inexistant !";
                    return false;
                }

            }
            else
            {
                _message = "Compte debiteur inexistant !";
                return false;
            }
        
        }


    }

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
