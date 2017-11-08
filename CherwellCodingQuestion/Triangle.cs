using System;
using System.Collections.Generic;
using System.Linq;

namespace CherwellCodingQuestion
{
    public class Triangle
    {
        private const string InvalidVertexListErrorMessage = "A triangle can have 3 and only 3 vertices.";

        public IList<Vertex> Vertices { get; }

        public Triangle(IEnumerable<Vertex> vertices)
        {
            if (vertices == null)
            {
                throw new ArgumentNullException(nameof(vertices));
            }

            var vertexList = vertices as IList<Vertex> ?? vertices.ToList();
            if (vertexList.Count != 3)
            {
                throw new ArgumentException(InvalidVertexListErrorMessage);
            }
            if (vertexList.Any(v => v.X < 0 ||
                                  v.Y < 0 ||
                                  v.X > 60 ||
                                  v.Y > 60))
            {
                throw new ArgumentOutOfRangeException(nameof(vertices));
            }

            Vertices = vertexList;
        }

        public char GetRow()
        {
            var mostCommonY = Vertices
                .GroupBy(v => v.Y)
                .OrderByDescending(v => v.Count())
                .Select(v => v.Key)
                .First();

            var otherY = Vertices
                .GroupBy(v => v.Y)
                .OrderByDescending(v => v.Count())
                .Select(v => v.Key)
                .Last();

            if (otherY > mostCommonY)
            {
                return (char)(65 + mostCommonY / 10);
            }
            return (char)(65 - 1 + mostCommonY / 10);
        }

        public int GetCol()
        {
            var mostCommonX = Vertices
                .GroupBy(v => v.X)
                .OrderByDescending(v => v.Count())
                .Select(v => v.Key)
                .First();

            var otherX = Vertices
                .GroupBy(v => v.X)
                .OrderByDescending(v => v.Count())
                .Select(v => v.Key)
                .Last();

            if (otherX > mostCommonX)
            {
                return (mostCommonX + otherX) / 10;
            }
            return (mostCommonX + otherX) / 10 + 1;
        }
    }
}
