using System;

namespace Points
{
    public class Point
    {
        //attributs
        private double abscisse;
        private double ordonnee;


        // propriétés
        public double Abscisse { get => abscisse; set => abscisse = value; }
        public double Ordonnee { get => ordonnee; set => ordonnee = value; }

        //Constructeur
        public Point()
        {
            this.Abscisse = 0;
            this.Ordonnee = 0;
        }
        public Point(double _abs, double _ord)
        {
            Abscisse = _abs;
            Ordonnee = _ord;
        }

        public override string ToString()
        {
            return " Point a pour abscisse: "+ this.Abscisse+ " et pour ordonnée : "+ this.Ordonnee;
        }
        public void Permuter()
        {
            double temp = this.abscisse;
            this.abscisse = this.Ordonnee;
            this.ordonnee = temp;
        }
        public void Deplacer(double _deplacementabs, double _deplacementord)
        {
            this.abscisse += _deplacementabs;
            this.ordonnee += _deplacementord;
        }

        public Point SymO()
        {
            return new Point(-this.Abscisse, -this.Ordonnee);
        }
        public Point SymAbs()
        {
            return new Point(this.Abscisse, -this.Ordonnee);
        }
        public Point SymOrd()
        {
            return new Point(-this.Abscisse, this.Ordonnee);
        }


        public double MesureDistance( Point _B)
        {
          
            double res = Math.Sqrt(Math.Pow((_B.Abscisse - this.Abscisse), 2) + Math.Pow((_B.Ordonnee - this.Ordonnee), 2));
                return res;




        }

    }
}
