using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using PJJ.Models;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace PJJ.Controllers
{
    public class FraudController : Controller
    {
        private readonly IHttpClientFactory _httpClientFactory;

        public FraudController(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
        }

        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Index(TransactionInput input)
        {
            var client = _httpClientFactory.CreateClient();

            var json = JsonConvert.SerializeObject(input);
            var content = new StringContent(json, Encoding.UTF8, "application/json");
            

            var response = await client.PostAsync("https://transactionsmlapi-production.up.railway.app/predict", content);

            var responseString = await response.Content.ReadAsStringAsync();

            var result = JsonConvert.DeserializeObject<PredictionResult>(responseString);
            


            ViewBag.Result = result.prediction == 1 ? "Fraud Detected" : "Transaction Safe";
            return View("Result");
        }
    }
}

