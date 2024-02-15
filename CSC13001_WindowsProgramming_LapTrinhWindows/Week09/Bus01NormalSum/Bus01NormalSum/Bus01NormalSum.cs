using Contract;
using Entity;
using System;
using System.Collections.Generic;

namespace Bus01NormalSum
{
    public class Bus01NormalSum : IBus
    {
        private IData _idata = null;
        public string Name => "Bus01NormalSum";

        public string Description => "Bus01 Normal sum";

        public Fraction Add(Fraction a, Fraction b)
        {
            int dx = a.Num * b.Den + a.Den * b.Num;
            int dy = a.Den * b.Den;
            Fraction result = new Fraction()
            {
                Num = dx,
                Den = dy
            };
            return result; 
        }

        public void DependsOn(IData idata)
        {
            throw new NotImplementedException();
        }

        public List<Fraction> GetAll()
        {
            var result = new List<Fraction>();
            return result;
        }

        public bool Save(Fraction f)
        {
            return true;
        }
    }
}
