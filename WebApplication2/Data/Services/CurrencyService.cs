using Newtonsoft.Json;
using WebApplication2.Data.Interfaces;
using WebApplication2.Data.Models;

namespace WebApplication2.Data.Services
{
    public class CurrencyService : ICurrencyService
    {
        public async Task<List<CurrencyModel>> GetAllCurrencies()
        {
            try
            {
                using (HttpClientHandler clientHandler = new HttpClientHandler())
                {
                    HttpClient httpClient = new HttpClient();

                    clientHandler.ServerCertificateCustomValidationCallback = (sender, cert, chain, sslPolicyErrors) => { return true; };

                    HttpClient client = new HttpClient(clientHandler);
                    var cancellationToken = new CancellationTokenSource(10 * 1000);
                    var result = httpClient.GetAsync("https://www.nbrb.by/api/exrates/currencies").Result;

                    var data = JsonConvert.DeserializeObject<List<CurrencyModel>>(await result.Content.ReadAsStringAsync());

                    return data;
                }
            }
            catch (Exception ex)
            {
                return null;
            }
        }
        public async Task<CurrencyModel> GetCurrency(string name, DateTime date)
        {
            try
            {
                using (HttpClientHandler clientHandler = new HttpClientHandler())
                {
                    HttpClient httpClient = new HttpClient();

                    clientHandler.ServerCertificateCustomValidationCallback = (sender, cert, chain, sslPolicyErrors) => { return true; };

                    HttpClient client = new HttpClient(clientHandler);
                    var cancellationToken = new CancellationTokenSource(10 * 1000);
                    var result = httpClient.GetAsync("https://www.nbrb.by/api/exrates/currencies").Result;

                    var data = JsonConvert.DeserializeObject<List<CurrencyModel>>(await result.Content.ReadAsStringAsync());
                    var listResult = new List<CurrencyModel>();
                    foreach (var item in data)
                    {
                        if(item.Cur_Name == name)
                        {
                            if(item.Cur_DateStart <= date)
                            {
                                if(date < item.Cur_DateEnd)
                                {
                                    return item;
                                }
                            }
                            
                        }
                    }

                    return null;
                }
            }
            catch (Exception ex)
            {
                return null;
            }
        }
    }
}
