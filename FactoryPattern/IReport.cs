﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FactoryMethod
{
    // Product
    public interface IReport
    {
        public void Generate(List<string> datos);
    }
}
