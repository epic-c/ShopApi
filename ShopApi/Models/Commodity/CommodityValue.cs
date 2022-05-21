using System.ComponentModel.DataAnnotations;

namespace ShopApi.Models.Commodity
{
    public class CommodityValue
    {
        [Key]
        public string Id { get; set; }
        public string Name { get; set; }
        public double Price { get; set; }
        public string Comment { get; set; }
        public double Star { get; set; }
    }
}