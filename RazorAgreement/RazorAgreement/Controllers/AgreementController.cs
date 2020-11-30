using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using RazorAgreement.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;

namespace RazorAgreement.Controllers
{
    public class AgreementController:Controller
    {
        //Controlador para realizar las peticiones al api
        public async Task<IActionResult> Index() {
            List<Agreement> agreementList = new List<Agreement>();
            using (var httpClient = new HttpClient())
            {
                using (var response = await httpClient.GetAsync("http://localhost:6020/api/Agreement"))
                {
                    string apiResponse = await response.Content.ReadAsStringAsync();
                    agreementList = JsonConvert.DeserializeObject<List<Agreement>>(apiResponse);
                }
            }
            return View(agreementList);
        }
    }
}
