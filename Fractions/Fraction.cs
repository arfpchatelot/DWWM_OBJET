using System;

namespace Fractions
{
    public class Fraction
    {
        //attributs
        int num;
        int denom;


        //propriétés
        public int Num { get => num; }
        public int Denom { get => denom; }


        //Constructeur

        public Fraction()
        {
            this.num = 0;
            this.denom = 1;
        }

        public Fraction(int _num)
        {
            this.num = _num;
            this.denom = 1;

                
        }
        public Fraction(int _num, int _denom)
        {
           
            try
            {
                this.num = _num;
                this.denom = _denom;
                double q = num / denom;
            }
            catch (DivideByZeroException e)
            {
                Console.WriteLine(e.Message);
                
            }
            this.Reduire();

        }

        private int GetPgcd()
        {
            int a = this.num;
            int b = this.denom;
            int pgcd = -1;
            if (a != 0 && b != 0)
            {
                if (a < 0) a = -a;
                if (b < 0) b = -b;
                while (a != b)
                {
                    if (a < b)
                    {
                        b = b - a;
                    }
                    else
                    {
                        a = a - b;
                    }
                    pgcd = a;

                }
            }
            return pgcd;
        }

        private void Reduire()
        {
            int pgcd = this.GetPgcd();

            this.num /= pgcd;
            this.denom /= pgcd;
            if (denom < 0)
            {
                this.num = -num;
                this.denom = -denom;
            
            }
        }
        public void Oppose()
        {
            this.num = -num;
            this.Reduire();
        }
        public void Inverse()
        {
            int tampon;
            try
            {
                double q = denom / num;
            }
            catch (DivideByZeroException e)
            {
                Console.WriteLine(e.Message);
            }

            tampon = num;
            num = denom;
            denom = tampon;
            this.Reduire();
        }

        public Fraction Plus(Fraction _autreFraction)
        {
            Fraction temp = new Fraction();

            temp.num = this.num * _autreFraction.denom + this.denom * _autreFraction.num;
            temp.denom = this.denom * _autreFraction.denom;
            temp.Reduire();
            return temp;
        
        }

        public Fraction Addition(Fraction _autreFraction)
        {
          
            return new Fraction(this.num * _autreFraction.denom + this.denom * _autreFraction.num, this.denom * _autreFraction.denom);

        }

        public static Fraction operator +(Fraction _un, Fraction _deux)
        {
            return new Fraction(_un.num * _deux.denom + _un.denom * _deux.num, _un.denom * _deux.denom);
        }

        public override string ToString()

        {
            return  this.num+"/"+this.denom ;
        }
    }
}
