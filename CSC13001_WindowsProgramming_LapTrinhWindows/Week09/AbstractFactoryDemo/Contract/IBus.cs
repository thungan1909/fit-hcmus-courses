using Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Contract
{
    public interface IBus
    {
        string Name { get; }
        string Description { get; }

        Fraction Add(Fraction a, Fraction b);
        List<Fraction> GetAll();
        bool Save(Fraction f);
        void DependsOn(IData idata);
    }
}
