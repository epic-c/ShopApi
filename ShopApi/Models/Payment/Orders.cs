using System.Collections.Generic;

namespace ShopApi.Models.Payment
{
    public class Orders
    {
        public List<Order> Value { get; set; }
        //TODO 下面欄位先做接收，收完就把東西丟掉
        public string Address { get; set; }
        public string Name { get; set; }
        public string Phone { get; set; }
    }
}
