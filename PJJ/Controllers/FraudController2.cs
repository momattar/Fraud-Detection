using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using PJJ.Models;
using PJJ.ViewModels;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace PJJ.Controllers
{
    public class FraudController2 : Controller
    {
        private readonly IHttpClientFactory _httpClientFactory;

        public FraudController2(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
        }

        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Index(LoansVM input)
        {
            input.Payment_type_0 = 0;
            input.Payment_type_1 = 0;
            input.Payment_type_2 = 0;
            input.Payment_type_3 = 0;
            input.Payment_type_4 = 0;
            input.Payment_type_5 = 0;

            switch (input.SelectedPaymentType)
            {
                case 0: input.Payment_type_0 = 1; break;
                case 1: input.Payment_type_1 = 1; break;
                case 2: input.Payment_type_2 = 1; break;
                case 3: input.Payment_type_3 = 1; break;
                case 4: input.Payment_type_4 = 1; break;
                case 5: input.Payment_type_5 = 1; break;
            }
            var inp = new TransactionInput2
            {
                Dpd_15_cnt = input.Dpd_15_cnt,
                Dpd_30_cnt = input.Dpd_30_cnt,
                Dpd_5_cnt = input.Dpd_5_cnt,
                Close_loans_cnt = input.Close_loans_cnt,
                Federal_district_nm = input.Federal_district_nm,
                Payment_type_0 = input.Payment_type_0,
                Payment_type_1 = input.Payment_type_1,
                Payment_type_2 = input.Payment_type_2,
                Payment_type_3 = input.Payment_type_3,
                Payment_type_4 = input.Payment_type_4,
                Payment_type_5 = input.Payment_type_5,
                Past_billings_cnt = input.Past_billings_cnt,
                Score_1 = input.Score_1,
                Score_2 = input.Score_2,
                Age = input.Age,
                Gender = input.Gender,
                Rep_loan_date_day = input.Rep_loan_date_day,
                Rep_loan_date_month = input.Rep_loan_date_month,
                Rep_loan_date_weekday = input.Rep_loan_date_weekday,
                Rep_loan_date_year = input.Rep_loan_date_year,
                First_loan_day = input.First_loan_day,
                First_loan_month = input.First_loan_month,
                First_loan_weekday = input.First_loan_weekday,
                First_loan_year = input.First_loan_year,
                First_overdue_date_day = input.First_overdue_date_day,
                First_overdue_date_month = input.First_overdue_date_month,
                First_overdue_date_weekday = input.First_overdue_date_weekday,
                First_overdue_date_year = input.First_overdue_date_year,
                Has_delinquency = input.Has_delinquency
            };

            var client = _httpClientFactory.CreateClient();

            var json = JsonConvert.SerializeObject(inp);
            var content = new StringContent(json, Encoding.UTF8, "application/json");
           
           // var response = await client.PostAsync(" http://localhost:5000/predict", content);

            var response = await client.PostAsync("https://loansmlapi-production.up.railway.app/predict", content);
            var responseString = await response.Content.ReadAsStringAsync();

            var result = JsonConvert.DeserializeObject<PredictionResult>(responseString);
            ViewBag.Result = result;

            ViewBag.Result = result.prediction == 1 ? "Fraud Detected" : "Transaction Safe";
            return View("Result");
        }
    }
}

