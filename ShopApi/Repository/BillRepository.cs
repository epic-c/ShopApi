using ShopApi.Models.Bill;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text.Json;
using System.Threading.Tasks;

namespace ShopApi.Repository
{
    public class BillRepository : IBillRepository
    {
        private const string DbFile = @"./DB/BillHistory/BillHistory.json";
        public async Task<IEnumerable<Bill>> GetBills(string name)
        {
         

            throw new System.NotImplementedException();
        }

        public async Task<IEnumerable<Bill>> GetBills()
        {
            using StreamReader r = new(DbFile);
            var json = await r.ReadToEndAsync();
            var billListValue = JsonSerializer.Deserialize<IEnumerable<Bill>>(json)
                           ?? throw new Exception($"{DbFile} json value deserialize Bill Fail.");

            return billListValue;
            throw new System.NotImplementedException();
        }

        public Task<string> InsertBills(Bill bill)
        {
            throw new System.NotImplementedException();
        }
    }
}
