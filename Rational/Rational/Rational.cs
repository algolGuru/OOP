using System;

namespace RationalLw
{
    public class Rational
    {
        public Rational()
        {
            _numerator = 0;
            _denominator = 1;
        }

        public Rational( int value )
        {
            _numerator = value;
            _denominator = 1;
        }

        public Rational( int numerator, int denominator )
        {
            if( denominator == 0 )
            {
                _numerator = 0;
                _denominator = 1;
                return;
            }
            var nod = FindNOD( numerator, denominator );
            if( nod < 0 )
            {
                nod *= -1;
            }
            _numerator = numerator / nod;
            _denominator = denominator / nod;
        }

        private int _numerator;
        private int _denominator;

        public static Rational operator +( Rational rational1, Rational rational2 )
        {
            var NOK = FindNOK( rational1.GetDenominator(), rational2.GetDenominator() );
            var mn1 = NOK / rational1.GetDenominator();
            var mn2 = NOK / rational2.GetDenominator();
            var resultNumerator = rational1.GetNumerator() * mn1 + rational2.GetNumerator() * mn2;

            return new Rational( resultNumerator, NOK );
        }

        public static Rational operator -( Rational rational1, Rational rational2 )
        {
            var NOK = FindNOK( rational1.GetDenominator(), rational2.GetDenominator() );
            var mn1 = NOK / rational1.GetDenominator();
            var mn2 = NOK / rational2.GetDenominator();
            var resultNumerator = rational1.GetNumerator() * mn1 - rational2.GetNumerator() * mn2;

            return new Rational( resultNumerator, NOK );
        }

        public static Rational operator +( Rational rational )
        {
            return rational;
        }

        public static Rational operator -( Rational rational )
        {
            return rational * -1;
        }

        public static Rational operator *( Rational rational1, Rational rational2 )
        {
            return new Rational( rational1.GetNumerator() * rational2.GetNumerator(), rational1.GetDenominator() * rational2.GetDenominator() );
        }

        public static Rational operator /( Rational rational1, Rational rational2 )
        {
            return new Rational( rational1.GetNumerator() * rational2.GetDenominator(), rational1.GetDenominator() * rational2.GetNumerator() );
        }

        public static bool operator ==( Rational rational1, Rational rational2 )
        {
            if( ReferenceEquals( rational1, rational2 ) )
            {
                return true;
            }

            if( rational1.GetNumerator() == rational2.GetNumerator() && rational1.GetDenominator() == rational2.GetDenominator() )
            {
                return true;
            }

            return false;
        }

        public static bool operator !=( Rational rational1, Rational rational2 )
        {
            return !( rational1 == rational2 );
        }

        public static implicit operator Rational( int value )
        {
            return new Rational( value );
        }

        public static bool operator >( Rational rational1, Rational rational2 )
        {
            if( rational1.ToDouble() > rational2.ToDouble() )
            {
                return true;
            }

            return false;
        }

        public static bool operator <( Rational rational1, Rational rational2 )
        {
            if( rational1.ToDouble() < rational2.ToDouble() )
            {
                return true;
            }

            return false;
        }

        public static bool operator >=( Rational rational1, Rational rational2 )
        {
            if( rational1.ToDouble() >= rational2.ToDouble() )
            {
                return true;
            }

            return false;
        }

        public static bool operator <=( Rational rational1, Rational rational2 )
        {
            if( rational1.ToDouble() <= rational2.ToDouble() )
            {
                return true;
            }

            return false;
        }

        public int GetNumerator()
        {
            return _numerator;
        }

        public int GetDenominator()
        {
            return _denominator;
        }

        public double ToDouble()
        {
            double num = _numerator;
            double denum = _denominator;

            return num / ( double ) denum;
        }

        private static int FindNOK( int a, int b )
        {
            var NOD = FindNOD( a, b );
            return a * b / NOD;
        }

        private static int FindNOD( int a, int b )
        {
            if( a == b )
            {
                return a;
            }

            if( a > b )
            {
                var temp = a % b;
                while( temp != 0 )
                {
                    a = b;
                    b = temp;
                    temp = a % b;
                }

                return b;
            }

            else
            {
                var temp = b % a;
                while( temp != 0 )
                {
                    b = a;
                    a = temp;
                    temp = b % a;
                }

                return a;
            }
        }
    }
}
