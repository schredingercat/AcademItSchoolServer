using NUnit.Framework;

namespace Vector.Tests
{
    public class Tests
    {
        [SetUp]
        public void Setup()
        {
        }

        [TestCase(new[] { 1.1, 2.6, 3 }, new[] { 8.1, 32, 7 }, ExpectedResult = new[] { 9.2, 34.6, 10 })]
        [TestCase(new[] { 3.2, 5 }, new[] { 1, 2.4 }, ExpectedResult = new[] { 4.2, 7.4 })]
        [TestCase(new[] { 10.8, 2, 3 }, new[] { 4.6 }, ExpectedResult = new[] { 15.4, 2, 3 })]
        public double[] TestAdd(double[] components1, double[] components2)
        {
            var vector1 = new Vector(components1);
            var vector2 = new Vector(components2);
            vector1.Add(vector2);
            return vector1.GetComponents();
        }

        [TestCase(new[] { -8.45, 5.9, -45.5, 52 }, new[] { 2.3, 4.5, 7 }, ExpectedResult = -311.385)]
        public double TestScalarProduct(double[] components1, double[] components2)
        {
            var vector1 = new Vector(components1);
            var vector2 = new Vector(components2);
            return Vector.ScalarProduct(vector1, vector2);
        }
    }
}