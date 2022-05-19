using ShopApi.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ShopApi.Repository
{
    public interface ICommodityRepository
    {
        public Task<Commodity> GetCommodity(string id);
        public Task<List<Commodity>> GetCommodities();
    }
}