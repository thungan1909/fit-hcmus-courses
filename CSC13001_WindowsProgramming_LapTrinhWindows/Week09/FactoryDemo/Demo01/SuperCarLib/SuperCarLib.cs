using System;

namespace SuperCarLib
{
    public interface Car
    {
        string Name { get; }
        void Depart();
        Car Clone();
    }
}
