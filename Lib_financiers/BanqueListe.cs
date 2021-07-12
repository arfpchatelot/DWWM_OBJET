using System;
using System.Collections.Generic;
using System.Text;

namespace financier
{
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
            if (RendCompte(_numerodebiteur) != null)
            {

                if (RendCompte(_numerobeneficaire) != null)
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
                        return true;
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
}
