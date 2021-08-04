using System;

namespace Emprunt
{
    public class Credit
    {
        //      // EXPLICATION DE CHAQUE VARIABLE

        //              // tauxInteretAnnuel    ->  taux de l'interet annuel
        //              // nbrAnneeRbmt         ->  le nombre d'annee de remboursement
        //              // capitalEmprunte      ->  le capital emprunte
        //// tauxInteretmensuel	->  taux de l'intérêt mensuel<- tauxInteretAnnuel/12
        //            
        //              // mois                 ->  le nombre de mois de la période
        //              // interetsMensuel       ->  les intérets du mois courant



        //              // amortissementMois    ->  le montant de l'amortissement du capital pour le mois courant
                         // mensualite           ->  la mensualite constante a rembourser
        //1) Réaliser la fonction qui renvoie la mensualité constante du prêt :

        //              En fonction du "tauxInteretAnnuel" et du "capitalEmprunte" et du "nbrAnneeRbmt",

        //              Afficher l'annuité et la "mensualité" constante à rembourser d'après la formule de calcul financière

        //              qui vous est communiqué par la maîtrise d'ouvrage".



        //          formule financière calcul de la mensualité constante : a Avec 2 chiffres decimaux obligatoires.


        //      Soit n nbre de mois de remboursement

        //          tm = tmensuel = txannuel / 12


        //              a= K x tm/Q

        //          Q = (1 - (1 + tm)puissance-n)


        //2) Réaliser une fonction qui renvoie et affiche le tableau d'amortissement du prêt :		

        //              Afficher le tableau d'amortissement mensuel du prêt en mode console.


        //              sur 5 colonnes

        //              compteur numero mois//  part interet(1 décimal) // part capital(1decimal) //  capital restant(pas de décimal) du// mensualité (pas de décimal)  










        //      Soit K(n) capital restant dû au mois n

        //Quand n = 0  k(n) =Capital emprunté

        // autrement k(n+1)=k(n)- part_Capital(n)

        //part_Interet(n+1) = K(n)*tm
        //part_Capital(n+1) = Mensualité- part Interet(n+1).

        //Attributs
       private double tauxInteretAnnuel;
       private int nbrAnneeRbmt;
       private double capitalEmprunte;
       private int nbMois;
       private double interetMensuel;
        
        //Constructeurs
        public Credit(double _montant, double _tauxAnnuel, int _nbAnnee)
        {
            this.capitalEmprunte = _montant;
            this.tauxInteretAnnuel = _tauxAnnuel;
            this.InteretMensuel = this.TauxInteretAnnuel / (double)1200;
            this.nbrAnneeRbmt = _nbAnnee;
            this.NbMois = this.NbrAnneeRbmt * 12;

        
        }
        //propriétés
        public double TauxInteretAnnuel { get => tauxInteretAnnuel;  }
        public int NbrAnneeRbmt { get => nbrAnneeRbmt;  }
        public double CapitalEmprunte { get => capitalEmprunte; }
        public int NbMois { get => nbMois; set => nbMois = value; }
        public double InteretMensuel { get => interetMensuel; set => interetMensuel = value; }

        //Méthodes 

        public double CalculMensualite()
        {
            double mensualite;
            double Q = (1 - Math.Pow((1 + this.InteretMensuel), -this.nbMois));
            mensualite = (this.CapitalEmprunte * this.InteretMensuel) / Q;
            return  Math.Round(mensualite,2);

        }

        public double CoutTotalCredit()
        {
            double mensuel = this.CalculMensualite();
            double coutTotal = mensuel * this.nbMois - this.capitalEmprunte;
            return Math.Round(coutTotal, 2);
        }


    }
}
