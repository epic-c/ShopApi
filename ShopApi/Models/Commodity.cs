using System.Collections.Generic;

namespace ShopApi.Models
{
    public class CommodityValue
    {
        public string Name { get; set; }
        public double Price { get; set; }
        public string Comment { get; set; }
    }

    public class Commodity:CommodityValue
    {
        public List<string> Images { get; set; }    //Base64
    }
}
