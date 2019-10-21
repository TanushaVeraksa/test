using System;

namespace InequalityTriangles
{
    public class MyTriangle
    {
        public static bool TheExistenceOfTriangle(double X, double Y, double Z)
        {
            return (X > 0 && Y > 0 && Z > 0 && X <= Y + Z && Y <= X + Z && Z <= X + Y);
        }
    }
}
