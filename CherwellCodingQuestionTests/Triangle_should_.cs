using System;
using System.Collections.Generic;
using System.Linq;
using CherwellCodingQuestion;
using NUnit.Framework;

namespace CherwellCodingQuestionTests
{
    public class Triangle_should_
    {
        private const string _invalidVertexListErrorMessage = "A triangle can have 3 and only 3 vertices.";
        [Test]
        public void reject_null_vertex_list()
        {
            var error = Assert.Throws<ArgumentException>(() => new Triangle(null));
            Assert.AreEqual(error.Message, _invalidVertexListErrorMessage);
        }

        [Test]
        public void reject_less_than_3_vertices()
        {
            var tooFewVertices = new List<Vertex> { new Vertex(Any.PositiveInt(), Any.PositiveInt()) };
            var error = Assert.Throws<ArgumentException>(() => new Triangle(tooFewVertices));
            Assert.AreEqual(error.Message, _invalidVertexListErrorMessage);
        }

        [Test]
        public void reject_more_than_3_vertices()
        {
            var tooManyVertices = new List<Vertex>();
            tooManyVertices.AddRange(Enumerable.Range(0, Any.IntBetween(4, 10))
                .Select(x => new Vertex(Any.PositiveInt(), Any.PositiveInt())));

            var error = Assert.Throws<ArgumentException>(() => new Triangle(tooManyVertices));
            Assert.AreEqual(error.Message, _invalidVertexListErrorMessage);
        }

        [Test]
        public void set_row_A_from_vertices()
        {
            var vertices = new List<Vertex>
                           {
                               new Vertex(0,0),
                               new Vertex(0, 10),
                               new Vertex(10,10)
                           };

            var Triangle = new Triangle(vertices);
            Assert.AreEqual('A', Triangle.Row);
        }

        [Test]
        public void set_row_F_from_vertices()
        {
            var vertices = new List<Vertex>
                           {
                               new Vertex(50,0),
                               new Vertex(50, 10),
                               new Vertex(60,10)
                           };

            var Triangle = new Triangle(vertices);
            Assert.AreEqual('F', Triangle.Row);
        }
    }
}
