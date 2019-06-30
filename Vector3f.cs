using System;

namespace lab1
{
    class Vector3f : IVector3f
    {
        public float X { get; private set; }
        public float Y { get; private set; }
        public float Z { get; private set; }

        static Vector3f()
        {
            Console.WriteLine("static constructor of base class Vector3f is called");
        }

        public Vector3f()
        {
            X = 0f;
            Y = 0f;
            Z = 0f;
        }

        public Vector3f(float x, float y, float z)
        {
            X = x;
            Y = y;
            Z = z;
        }

        public virtual IVector3f Sum(IVector3f other) => new Vector3f(X + other.X, Y + other.Y, Z + other.Z);

        public virtual IVector3f Diff(IVector3f other) => new Vector3f(X - other.X, Y - other.Y, Z - other.Z);

        public virtual float Dot(IVector3f other) => X * other.X + Y * other.Y + Z * other.Z;

        public virtual float Lenght() => (float) Math.Sqrt(X*X + Y*Y + Z*Z);

        public virtual float Cos(IVector3f other) => Dot(other) / (Lenght() * other.Lenght());
    }
}
