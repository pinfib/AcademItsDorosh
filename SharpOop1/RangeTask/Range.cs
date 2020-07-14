using System;

namespace Academits.Dorosh
{
    public class Range
    {
        private const double Epsilon = 1.0e-10;

        public double From { get; set; }

        public double To { get; set; }

        public Range()
        {
            From = 0;
            To = 0;
        }

        public Range(double from, double to)
        {
            From = from;
            To = to;
        }

        private static bool IsLargerOrEqual(double a, double b)
        {
            return a - b >= -Epsilon;
        }

        private static bool IsSmallerOrEqual(double a, double b)
        {
            return a - b <= Epsilon;
        }

        public double GetLength()
        {
            return To - From;
        }

        public bool IsInside(double number)
        {
            return IsLargerOrEqual(number, From) && IsSmallerOrEqual(number, To);
        }

        public Range[] Union(Range A)
        {
            if (this.From > A.To)
            {
                return new Range[] { A, this };
            }

            if (this.To < A.From)
            {
                return new Range[] { this, A };
            }

            Range B = new Range();

            B.From = Math.Min(this.From, A.From);
            B.To = Math.Max(this.To, A.To);

            return new Range[] { B };
        }
        public Range Intersection(Range A)
        {
            if (this.To <= A.From || this.From >= A.To)
            {
                return null;
            }

            Range B = new Range();

            B.From = Math.Max(this.From, A.From);
            B.To = Math.Min(this.To, A.To);

            return B;
        }

        public Range[] Complement(Range A)
        {
            if (this.From >= A.From && this.To <= A.To)        //если отрезки равны или второй больше первого
            {
                return null;
            }

            if (this.To <= A.From || this.From >= A.To)       //если второй отрезок не соприкасается с первым
            {
                return new Range[] { this };
            }

            if (this.From < A.From && this.To > A.To)         //если второй отрезок меньше и включен в первый
            {
                Range B = new Range(this.From, A.From);
                Range C = new Range(A.To, this.To);

                return new Range[] { B, C };
            }
            //если второй отрезок соприкасается с первым каким-либо краем
            Range D = new Range();

            if (this.From < A.From)
            {
                D.From = this.From;
                D.To = A.From;
            }
            else
            {
                D.From = A.To;
                D.To = this.To;
            }

            return new Range[] { D };
        }
    }
}