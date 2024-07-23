using System;

namespace CSC_205_EX13_4
{
    public class Rational
    {
        private int numerator;
        private int denominator;

        // Default constructor
        public Rational()
        {
            numerator = 0;
            denominator = 1;
        }

        // Parametric constructor
        public Rational(int numerator, int denominator)
        {
            if (denominator == 0)
            {
                throw new ArgumentException("Denominator cannot be zero.");
            }
            this.numerator = numerator;
            this.denominator = denominator;
        }

        // Method to write the Rational number
        public void WriteRational()
        {
            Console.WriteLine($"{numerator}/{denominator}");
        }

        // Method to negate the Rational number
        public void Negate()
        {
            numerator = -numerator;
        }

        // Method to invert the Rational number
        public void Invert()
        {
            if (numerator == 0)
            {
                throw new InvalidOperationException("Cannot invert a rational number with a numerator of zero.");
            }
            int temp = numerator;
            numerator = denominator;
            denominator = temp;
        }

        // Method to convert the Rational number to double
        public double ToDouble()
        {
            return (double)numerator / denominator;
        }

        // Method to reduce the Rational number to its lowest terms
        public Rational Reduce()
        {
            int gcd = GCD(Math.Abs(numerator), Math.Abs(denominator));
            return new Rational(numerator / gcd, denominator / gcd);
        }

        // Method to add two Rational numbers
        public Rational Add(Rational r)
        {
            int commonDenominator = this.denominator * r.denominator;
            int numeratorSum = this.numerator * r.denominator + r.numerator * this.denominator;
            Rational result = new Rational(numeratorSum, commonDenominator);
            return result.Reduce();
        }

        // Method to subtract two Rational numbers
        public Rational Subtract(Rational r)
        {
            int commonDenominator = this.denominator * r.denominator;
            int numeratorDifference = this.numerator * r.denominator - r.numerator * this.denominator;
            Rational result = new Rational(numeratorDifference, commonDenominator);
            return result.Reduce();
        }

        // Method to multiply two Rational numbers
        public Rational Multiply(Rational r)
        {
            int numeratorProduct = this.numerator * r.numerator;
            int denominatorProduct = this.denominator * r.denominator;
            Rational result = new Rational(numeratorProduct, denominatorProduct);
            return result.Reduce();
        }

        // Method to divide two Rational numbers
        public Rational Divide(Rational r)
        {
            if (r.numerator == 0)
            {
                throw new DivideByZeroException("Cannot divide by zero.");
            }
            int numeratorQuotient = this.numerator * r.denominator;
            int denominatorQuotient = this.denominator * r.numerator;
            Rational result = new Rational(numeratorQuotient, denominatorQuotient);
            return result.Reduce();
        }

        // Helper method to calculate the greatest common divisor
        private static int GCD(int a, int b)
        {
            while (b != 0)
            {
                int temp = b;
                b = a % b;
                a = temp;
            }
            return a;
        }

        public static void Main(string[] args)
        {
            // Create a new Rational object and test the methods
            Rational r1 = new Rational(6, 8);
            Console.WriteLine("Initial Rational number:");
            r1.WriteRational();

            r1.Negate();
            Console.WriteLine("After Negate:");
            r1.WriteRational();

            r1.Invert();
            Console.WriteLine("After Invert:");
            r1.WriteRational();

            Console.WriteLine($"As a double: {r1.ToDouble()}");

            Rational reduced = r1.Reduce();
            Console.WriteLine("After Reduce:");
            reduced.WriteRational();

            Rational r2 = new Rational(1, 2);
            Rational r3 = new Rational(2, 3);

            // Mistake: Trying to call an instance method as if it were static
            // Rational sum = Rational.Add(r2, r3); // Error: 'Rational.Add' is not a static method

            // Correct usage of the instance method
            Rational sum = r2.Add(r3);
            Console.WriteLine("Sum of 1/2 and 2/3:");
            sum.WriteRational();

            // Mistake: Trying to call a static method as if it were an instance method
            // int gcd = r1.GCD(48, 18); // Error: 'GCD' is not an instance method

            // Correct usage of the static method
            int gcd = Rational.GCD(48, 18);
            Console.WriteLine($"GCD of 48 and 18: {gcd}");

            // Testing Subtract, Multiply, and Divide methods
            Rational difference = r2.Subtract(r3);
            Console.WriteLine("Difference of 1/2 and 2/3:");
            difference.WriteRational();

            Rational product = r2.Multiply(r3);
            Console.WriteLine("Product of 1/2 and 2/3:");
            product.WriteRational();

            Rational quotient = r2.Divide(r3);
            Console.WriteLine("Quotient of 1/2 and 2/3:");
            quotient.WriteRational();
        }
    }
}

// Instance methods are typically more natrual for operations involving specific
//objects, while static methods are useful for utility functions and operations 
// not tied to  a particular instance 