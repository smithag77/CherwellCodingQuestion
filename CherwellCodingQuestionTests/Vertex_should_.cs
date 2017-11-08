using System;
using CherwellCodingQuestion;
using NUnit.Framework;

namespace CherwellCodingQuestionTests
{
    public class Vertex_should_
    {
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
