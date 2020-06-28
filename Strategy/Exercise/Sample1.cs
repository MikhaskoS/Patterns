using System;
using System.Numerics;


namespace Strategy.Exercise
{
    public class Sample1
    {
        // Решить квадратное уравнение с использованием стратегии (в действительных и комплексных числах)
        public static void Test()
        {
            IDiscriminantStrategy strategy1 = new OrdinaryDiscriminantStrategy();
            IDiscriminantStrategy strategy2 = new RealDiscriminantStrategy();

            QuadraticEquationSolver solver = new QuadraticEquationSolver(strategy2);
            Tuple<Complex, Complex> solve = solver.Solve(1, 5, 6);  // x^2 + 5x + 6 = 0 

            Console.WriteLine(solve.Item1.ToString());
            Console.WriteLine(solve.Item2.ToString());
        }
    }

    public interface IDiscriminantStrategy
    {
        double CalculateDiscriminant(double a, double b, double c);
    }

    public class OrdinaryDiscriminantStrategy : IDiscriminantStrategy
    {
        public double CalculateDiscriminant(double a, double b, double c)
        {
            double d = b * b - 4 * a * c;
            return d;
        }
    }

    public class RealDiscriminantStrategy : IDiscriminantStrategy
    {
        // todo (return NaN on negative discriminant!)
        public double CalculateDiscriminant(double a, double b, double c)
        {
            double d = b * b - 4 * a * c;
            return (d > 0) ? d : double.NaN;
        }
    }

    public class QuadraticEquationSolver
    {
        private readonly IDiscriminantStrategy strategy;

        public QuadraticEquationSolver(IDiscriminantStrategy strategy)
        {
            this.strategy = strategy;
        }

        public Tuple<Complex, Complex> Solve(double a, double b, double c)
        {
            // todo
            double discriminant = strategy.CalculateDiscriminant(a, b, c);

            if (double.IsNaN(discriminant))
            {
                Complex nan = new Complex(double.NaN, double.NaN);
                return
                    new Tuple<Complex, Complex>(nan, nan);
            }
            else
            {
                Complex SqD = Complex.Sqrt(discriminant);

                Complex x1 = (-b + SqD) / 2 * a;
                Complex x2 = (-b - SqD) / 2 * a;

                return
                   new Tuple<Complex, Complex>(x1, x2);
            }
        }
    }
}
