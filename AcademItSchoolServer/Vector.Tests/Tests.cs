using NUnit.Framework;

namespace Vector.Tests
{
    public class Tests
    {
        [SetUp]
        public void Setup()
        {
        }

        [Test]
        public void TestAdd(
            [Range(0, 1, 0.1)] double x1,
            [Range(-1, 1, 0.5)] double x2,
            [Range(-1, 1, 0.5)] double z2)
        {
            var vector1 = new Vector(new[] { x1, 4.5, 7 });
            var vector2 = new Vector(new[] { x2, 5.4, z2 });
            Assert.DoesNotThrow(() => vector1.Add(vector2));
        }

        [Test]
        public void TestScalarProduct(
            [Range(0, 1, 0.1)] double x1,
            [Range(-1, 1, 0.5)] double x2,
            [Range(-1, 1, 0.5)] double y2)
        {
            var vector1 = new Vector(new[] { x1, 4.5, 7 });
            var vector2 = new Vector(new[] { x2, y2, 0.7 });
            Assert.DoesNotThrow(() => Vector.ScalarProduct(vector1, vector2));
        }
    }
}