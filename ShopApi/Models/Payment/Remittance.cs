using System;
using System.Collections.Generic;

namespace ShopApi.Models.Payment
{
    public class Remittance
    {
        public List<ConsumerDetail> ConsumerDetails { get; set; }
        public string Account { get; set; }
        public DateTime Deadline { get; set; }
    }
}
