using WebApplication2.Data.Models;

namespace WebApplication2.Data.Interfaces
{
    public interface ICurrencyService
    {
        public Task<List<CurrencyModel>> GetAllCurrencies();
        public Task<CurrencyModel> GetCurrency(string name, DateTime date);
    }
}
