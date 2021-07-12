using System;
using System.Collections.Generic;
using System.Text;

namespace financier
{
    public class Banque
    {
        //attributs 
        public Compte[] mesComptes = new Compte[30];

        private int nbComptes;
        private string nomBanque;
        private string villeBanque;

        //constructeurs
        public Banque(string _nom, string _ville)
        {
            this.nomBanque = _nom;
            this.villeBanque = _ville;
            this.NbComptes = 0;
        }
        //propriétés
        public string NomBanque { get => NomBanque; }
        public string VilleBanque { get => villeBanque; }
        public int NbComptes { get => nbComptes; set => nbComptes = value; }


        // methodes
        private void AjouterCompte(Compte _autreCompte)
        {
            nbComptes++;
            mesComptes[(nbComptes - 1)] = _autreCompte;
        }
        public bool AjouterCompte(string _nom, int _numero, double _solde, double _decouvert)
        {


            for (int i = 0; i < nbComptes; i++)
            {
                if (mesComptes[i].Numero == _numero)
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
            for (int i = 0; i < this.nbComptes; i++)
            {
                chaine += "\n" + mesComptes[i].ToString() + "------------------- \n";
            }
            chaine += "------------------ fin de liste --------------------------\n";
            return chaine;

        }

        public Compte RendCompte(int _numeroCompte)
        {
            for (int i = 0; i < this.nbComptes; i++)
            {
                if (mesComptes[i].Numero == _numeroCompte)
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
}
