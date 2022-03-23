using System.Collections.Generic;

namespace ShopApi.Models
{
    public class Commodity
    {
        public List<string> Images { get; set; }    //Base64
        public string Name { get; set; }
        public double Price { get; set; }
        public string Comment { get; set; }
    }
}
