using System.Collections.Generic;

namespace ShopApi.Models.Commodity
{
    public class Commodity : CommodityValue
    {
        public List<string> Images { get; set; }    //Base64

        public Commodity()
        {

        }

        public Commodity(CommodityValue commodityValue)
        {
            Id = commodityValue.Id;
            Name = commodityValue.Name;
            Price = commodityValue.Price;
            Comment = commodityValue.Comment;
            Star = commodityValue.Star;
        }
    }
}
