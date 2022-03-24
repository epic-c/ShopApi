using System.Collections.Generic;

namespace ShopApi.Models
{
    public class Bill
    {
        public List<string> Commodities { get; set; }
        public string MemberId { get; set; }
        public string Comment { get; set; }
    }
}
