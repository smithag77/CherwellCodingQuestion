using System;
using CherwellCodingQuestion;
using NUnit.Framework;

namespace CherwellCodingQuestionTests
{
    public class Vertex_should_
    {
        [Test]
        public void prevent_negative_x_values()
        {
            var error = Assert.Throws<ArgumentOutOfRangeException>(() => new Vertex(Any.IntBetween(-10, -1), Any.PositiveInt()));

            Assert.AreEqual("X", error.ParamName.ToUpper());
        }

        [Test]
        public void prevent_negative_y_values()
        {
            var error = Assert.Throws<ArgumentOutOfRangeException>(() => new Vertex(Any.PositiveInt(), Any.IntBetween(-10, -1)));

            Assert.AreEqual("Y", error.ParamName.ToUpper());
        }

        [Test]
        public void have_expected_x_and_y_values_upon_creation()
        {
            var expectedX = Any.PositiveInt();
            var expectedY = Any.PositiveInt();

            var vertex = new Vertex(expectedX, expectedY);

            Assert.AreEqual(expectedX, vertex.X, "X");
            Assert.AreEqual(expectedY, vertex.Y, "Y");
        }
    }
}
