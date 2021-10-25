using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HW6
{
    class Wine
    {
        public string title { get; set; }
        public string country { get; set; }
        public double? price { get; set; }

        public override string ToString()
        {
            return $"{title}";
        }
    }
}
