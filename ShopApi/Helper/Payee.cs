using System.Threading.Tasks;

namespace ShopApi.Helper
{
    public class Payee : IPayee
    {
        public async Task<string> GetRemittanceAccount()
        {
            return await Task.Run((() => "0071111-0230000"));
        }
    }

    public interface IPayee
    {
        public Task<string> GetRemittanceAccount();
    }
}
