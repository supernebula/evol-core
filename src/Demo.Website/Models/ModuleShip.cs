using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Demo.Website.Models
{
    public class ModuleShip
    {
        public List<Module> Modules { get; set; }
    }

    public class Module
    {
        public string Name { get; set; }

        public int Count { get; set; }
    }
}


