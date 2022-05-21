using System.Collections.Generic;
using System.Threading.Tasks;
using ShopApi.Models.Commodity;

namespace ShopApi.Repository.CommodityRepository
{
    public interface ICommodityRepository
    {
        public Task<Commodity> GetCommodityAndAllImage(string id);
        public Task<List<Commodity>> GetCommodities();
        public Task<CommodityValue> GetCommodityValue(string id);
    }
}