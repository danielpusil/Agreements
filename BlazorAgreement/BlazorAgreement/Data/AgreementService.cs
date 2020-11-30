using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;

namespace BlazorAgreement.Data
{
    public class AgreementService
    {
        //Service que consulta en el api de Agreements
        public async Task<List<Agreement>> getAgreetmensAsync() {
            List<Agreement> agreementList = new List<Agreement>();
            using (var httpClient = new HttpClient())
            {
                using (var response = await httpClient.GetAsync("http://localhost:6020/api/Agreement"))
                {
                    string apiResponse = await response.Content.ReadAsStringAsync();
                    agreementList = JsonConvert.DeserializeObject<List<Agreement>>(apiResponse);
                }
            }
            return await Task.FromResult(agreementList);
        }
    }
}
