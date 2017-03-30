using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Demo.Website.Models
{
    public class AdminArea
    {
        public List<Area> Areas { get; set; }
    }

    public class Area
    {
        public string Code { get; set; }

        public string  ParentCode { get; set; }

        public string  Name { get; set; }
    }
}
