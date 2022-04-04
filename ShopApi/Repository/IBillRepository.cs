using ShopApi.Models.Bill;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ShopApi.Repository
{
    public interface IBillRepository
    {
        public Task<IEnumerable<Bill>> GetBills(string name);
        public Task<IEnumerable<Bill>> GetBills();
        public Task<string> InsertBills(Bill bill);
    }
}
