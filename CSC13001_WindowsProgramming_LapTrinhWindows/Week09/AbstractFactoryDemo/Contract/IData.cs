﻿using Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Contract
{
    public interface IData
    {
        string Name { get; }
        string Description { get; }
        List<Fraction> GetAll();
        bool Save(Fraction f);
    
    }
}
