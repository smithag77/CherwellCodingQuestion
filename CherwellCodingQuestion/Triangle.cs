using System;
using System.Collections.Generic;
using System.Linq;

namespace CherwellCodingQuestion
{
    public class Triangle
    {
        private const string _invalidVertexListErrorMessage = "A triangle can have 3 and only 3 vertices.";

        public char Row { get; private set; }
        public int Col { get; private set; }

        public Triangle(IEnumerable<Vertex> vertices)
        {
            if (vertices == null || vertices.Count() != 3)
            {
                throw new ArgumentException(_invalidVertexListErrorMessage);
            }

            CalculateRow(vertices);
        }

        private void CalculateRow(IEnumerable<Vertex> vertices)
        {
            var mostCommonX = vertices
                .GroupBy(v => v.X)
                .OrderByDescending(v => v.Count())
                .Select(v => v.Key)
                .FirstOrDefault();
            Row = (char)(65 + mostCommonX / 10);
        }
    }
}
