using System;

namespace lab1
{
    class VerboseVector3f : Vector3f
    {
        static VerboseVector3f()
        {
            Console.WriteLine("static constructor of derived class VerboseVector3f is called");
        }
        public VerboseVector3f() : base()
        {
            Console.WriteLine("overriden default constructor of derived class VerboseVector3f is called");
        }

        public VerboseVector3f(float x, float y, float z) : base(x, y, z)
        {
            Console.WriteLine("overriden parameterized constructor of derived class VerboseVector3f is called");
        }

        public override IVector3f Sum(IVector3f other)
        {
            Console.WriteLine("Overriden method {} is called", System.Reflection.MethodBase.GetCurrentMethod().Name);
            return base.Sum(other);
        }

        public override IVector3f Diff(IVector3f other)
        {
            Console.WriteLine("Overriden method {} is called", System.Reflection.MethodBase.GetCurrentMethod().Name);
            return base.Diff(other);
        }

        public override float Dot(IVector3f other)
        {
            Console.WriteLine("Overriden method {} is called", System.Reflection.MethodBase.GetCurrentMethod().Name);
            return base.Dot(other);
        }

        public override float Lenght()
        {
            Console.WriteLine("Overriden method {} is called", System.Reflection.MethodBase.GetCurrentMethod().Name);
            return base.Lenght();
        }

        public override float Cos(IVector3f other)
        {
            Console.WriteLine("Overriden method {} is called", System.Reflection.MethodBase.GetCurrentMethod().Name);
            return base.Cos(other);
        }

        public override string ToString() => $"VerboseVector3f {{{X}, {Y}, {Z}}}";
    }
}
