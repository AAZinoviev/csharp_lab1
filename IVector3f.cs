using System;
using System.Collections.Generic;
using System.Text;

namespace lab1
{
    interface IVector3f
    {
        float X { get; }
        float Y { get; }
        float Z { get; }

        IVector3f Sum(IVector3f other);
        IVector3f Diff(IVector3f other);

        float Dot(IVector3f other);
        float Cos(IVector3f other);

        float Lenght();
    }
}
