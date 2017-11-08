using System;
using System.Collections.Generic;
using System.Linq;
using CherwellCodingQuestion;
using NUnit.Framework;

namespace CherwellCodingQuestionTests
{
    public class Triangle_should_
    {
        private const string InvalidVertexListErrorMessage = "A triangle can have 3 and only 3 vertices.";
        [Test]
        public void reject_null_vertex_list()
        {
            var error = Assert.Throws<ArgumentNullException>(() => new Triangle(null));
            Assert.AreEqual("VERTICES", error.ParamName.ToUpper());
        }

        [Test]
        public void reject_less_than_3_vertices()
        {
            var tooFewVertices = new List<Vertex> { new Vertex(Any.PositiveInt(), Any.PositiveInt()) };
            var error = Assert.Throws<ArgumentException>(() => new Triangle(tooFewVertices));
            Assert.AreEqual(error.Message, InvalidVertexListErrorMessage);
        }

        [Test]
        public void reject_more_than_3_vertices()
        {
            var tooManyVertices = new List<Vertex>();
            tooManyVertices.AddRange(Enumerable.Range(0, Any.IntBetween(4, 10))
                .Select(x => new Vertex(Any.PositiveInt(), Any.PositiveInt())));

            var error = Assert.Throws<ArgumentException>(() => new Triangle(tooManyVertices));
            Assert.AreEqual(error.Message, InvalidVertexListErrorMessage);
        }

        [Test]
        public void prevent_negative_x_values()
        {
            var verticesWithNegativeX = new List<Vertex>
            {
                new Vertex(Any.PositiveInt(), Any.PositiveInt()),
                new Vertex(Any.PositiveInt(), Any.PositiveInt()),
                new Vertex(Any.NegativeInt(), Any.PositiveInt())
            };
            var error = Assert.Throws<ArgumentOutOfRangeException>(() => new Triangle(verticesWithNegativeX));

            Assert.AreEqual("VERTICES", error.ParamName.ToUpper());
        }

        [Test]
        public void prevent_negative_y_values()
        {
            var verticesWithNegativeY = new List<Vertex>
            {
                new Vertex(Any.PositiveInt(), Any.PositiveInt()),
                new Vertex(Any.PositiveInt(), Any.PositiveInt()),
                new Vertex(Any.PositiveInt(), Any.NegativeInt())
            };
            var error = Assert.Throws<ArgumentOutOfRangeException>(() => new Triangle(verticesWithNegativeY));

            Assert.AreEqual("VERTICES", error.ParamName.ToUpper());
        }

        [Test]
        public void prevent_x_gt_60()
        {
            var verticesWithNegativeY = new List<Vertex>
            {
                new Vertex(Any.IntBetween(61, 100), Any.PositiveInt()),
                new Vertex(Any.PositiveInt(), Any.PositiveInt()),
                new Vertex(Any.PositiveInt(), Any.PositiveInt())
            };
            var error = Assert.Throws<ArgumentOutOfRangeException>(() => new Triangle(verticesWithNegativeY));

            Assert.AreEqual("VERTICES", error.ParamName.ToUpper());
        }

        [Test]
        public void prevent_y_gt_60()
        {
            var verticesWithNegativeY = new List<Vertex>
            {
                new Vertex(Any.PositiveInt(), Any.IntBetween(61, 100)),
                new Vertex(Any.PositiveInt(), Any.PositiveInt()),
                new Vertex(Any.PositiveInt(), Any.PositiveInt())
            };
            var error = Assert.Throws<ArgumentOutOfRangeException>(() => new Triangle(verticesWithNegativeY));

            Assert.AreEqual("VERTICES", error.ParamName.ToUpper());
        }

        [Test]
        public void store_valid_vertices_correctly()
        {
            var validVertices = new List<Vertex>
            {
                new Vertex(Any.PositiveInt(), Any.PositiveInt()),
                new Vertex(Any.PositiveInt(), Any.PositiveInt()),
                new Vertex(Any.PositiveInt(), Any.PositiveInt())
            };

            var triangle = new Triangle(validVertices);

            CollectionAssert.AreEqual(validVertices, triangle.Vertices);
        }

        [Test]
        public void get_row_A_from_vertices_for_bottom_left_triangle_in_top_row()
        {
            var vertices = new List<Vertex>
                           {
                               new Vertex(0,0),
                               new Vertex(0, 10),
                               new Vertex(10,10)
                           };

            var triangle = new Triangle(vertices);
            Assert.AreEqual('A', triangle.GetRow());
        }

        [Test]
        public void get_row_A_from_vertices_for_top_right_triangle_in_top_row()
        {
            var vertices = new List<Vertex>
            {
                new Vertex(0,0),
                new Vertex(0, 10),
                new Vertex(10,10)
            };

            var triangle = new Triangle(vertices);
            Assert.AreEqual('A', triangle.GetRow());
        }

        [Test]
        public void get_row_F_from_vertices_for_bottom_left_triangle_in_bottom_row()
        {
            var vertices = new List<Vertex>
                           {
                               new Vertex(0, 50),
                               new Vertex(0, 60),
                               new Vertex(10, 60)
                           };

            var triangle = new Triangle(vertices);
            Assert.AreEqual('F', triangle.GetRow());
        }

        [Test]
        public void get_row_F_from_vertices_for_top_right_triangle_in_bottom_row()
        {
            var vertices = new List<Vertex>
            {
                new Vertex(0, 50),
                new Vertex(10, 50),
                new Vertex(10, 60)
            };

            var triangle = new Triangle(vertices);
            Assert.AreEqual('F', triangle.GetRow());
        }

        [Test]
        public void get_the_correct_row_for_a_bottom_left_triangle_in_the_middle_somewhere()
        {
            var vertices = new List<Vertex>
            {
                new Vertex(0, 20),
                new Vertex(0, 30),
                new Vertex(10, 30)
            };

            var triangle = new Triangle(vertices);
            Assert.AreEqual('C', triangle.GetRow());
        }

        [Test]
        public void get_the_correct_row_for_a_top_right_triangle_in_the_middle_somewhere()
        {
            var vertices = new List<Vertex>
            {
                new Vertex(0, 20),
                new Vertex(10, 20),
                new Vertex(10, 30)
            };

            var triangle = new Triangle(vertices);
            Assert.AreEqual('C', triangle.GetRow());
        }

        [Test]
        public void get_col_1_from_vertices_for_bottom_left_triangle_in_top_row_first_square()
        {
            var vertices = new List<Vertex>
            {
                new Vertex(0,0),
                new Vertex(0, 10),
                new Vertex(10,10)
            };

            var triangle = new Triangle(vertices);
            Assert.AreEqual(1, triangle.GetCol());
        }

        [Test]
        public void get_col_2_from_vertices_for_top_right_triangle_in_top_row_first_square()
        {
            var vertices = new List<Vertex>
            {
                new Vertex(0,0),
                new Vertex(10, 0),
                new Vertex(10,10)
            };

            var triangle = new Triangle(vertices);
            Assert.AreEqual(2, triangle.GetCol());
        }

        [Test]
        public void get_col_11_from_vertices_for_bottom_left_triangle_in_top_row_last_square()
        {
            var vertices = new List<Vertex>
            {
                new Vertex(50, 0),
                new Vertex(50, 10),
                new Vertex(60, 10)
            };

            var triangle = new Triangle(vertices);
            Assert.AreEqual(11, triangle.GetCol());
        }

        [Test]
        public void get_col_12_from_vertices_for_top_right_triangle_in_top_row_last_square()
        {
            var vertices = new List<Vertex>
            {
                new Vertex(50, 0),
                new Vertex(60, 0),
                new Vertex(60, 10)
            };

            var triangle = new Triangle(vertices);
            Assert.AreEqual(12, triangle.GetCol());
        }

        [Test]
        public void get_the_correct_column_for_a_bottom_left_triangle_in_the_middle_somewhere()
        {
            var vertices = new List<Vertex>
            {
                new Vertex(20, 0),
                new Vertex(20, 10),
                new Vertex(30, 10)
            };

            var triangle = new Triangle(vertices);
            Assert.AreEqual(5, triangle.GetCol());
        }

        [Test]
        public void get_the_correct_column_for_a_top_right_triangle_in_the_middle_somewhere()
        {
            var vertices = new List<Vertex>
            {
                new Vertex(20, 0),
                new Vertex(30, 0),
                new Vertex(30, 10)
            };

            var triangle = new Triangle(vertices);
            Assert.AreEqual(6, triangle.GetCol());
        }
    }
}
