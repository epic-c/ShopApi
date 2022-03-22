using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ShopApi.Models
{
    public class Commodity
    {
        public string[] Images { get; set; }    //Base64
        public string Name { get; set; }
        public double Price { get; set; }
        public string Comment { get; set; }
    }
}
