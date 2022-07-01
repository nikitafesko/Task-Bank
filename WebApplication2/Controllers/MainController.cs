using Microsoft.AspNetCore.Mvc;
using WebApplication2.Data.Interfaces;
using WebApplication2.Data.Models;

namespace WebApplication2.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class MainController : Controller
    {
        private readonly ILogger<MainController> _logger;
        private ICurrencyService _currencyService;

        public MainController(ILogger<MainController> logger, ICurrencyService currencyService)
        {
            _logger = logger;
            _currencyService = currencyService;
        }

        [HttpGet]
        [Route("/getData")]
        public async Task<List<CurrencyModel>> GetListCurrencies()
        {
            return await _currencyService.GetAllCurrencies();
        }

        [HttpPost]
        [Route("/editModel")]
        public async Task<CurrencyModel> GetListCurrencies(string name, DateTime date)
        {
            return await _currencyService.GetCurrency(name, date);
        }
    }
}
