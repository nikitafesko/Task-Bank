using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;
using WebApplication1.Models;

namespace WebApplication1.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            ViewBag.Message = GetCurrency();
            return View();
        }
        private async Task<Currency> GetCurrency()
        {
            using (HttpClient client = new HttpClient())
            {
                var response = await client.GetAsync("https://localhost:7228/getData");
                response.EnsureSuccessStatusCode();
                var st = await response.Content.ReadAsStringAsync();
                var model = JsonConvert.DeserializeObject<Currency>(st);
                return model;
            }
        }
        private async Task<Currency> GetCurrencyByName(string name, DateTime date)
        {
            using (HttpClient client = new HttpClient())
            {
                var response = await client.GetAsync("https://localhost:7228/getData");
                response.EnsureSuccessStatusCode();
                var st = await response.Content.ReadAsStringAsync();
                var model = JsonConvert.DeserializeObject<Currency>(st);
                return model;
            }
        }
        public ActionResult About()
        {

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}