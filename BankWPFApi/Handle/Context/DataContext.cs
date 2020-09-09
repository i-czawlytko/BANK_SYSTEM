using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Data.Entity;
using System.Net.Http;
using System.Text;

using Newtonsoft.Json;

namespace Handle.Context
{
    public class DataContext
    {
        static public string server_adress { get; set; }
        static public IEnumerable<PhysClients> GetAllPhys(HttpClient httpClient)
        {

            string url = DataContext.server_adress+"phys";
            string json = httpClient.GetStringAsync(url).Result;
            return JsonConvert.DeserializeObject<IEnumerable<PhysClients>>(json);
        }

        static public IEnumerable<CompanyClients> GetAllCompanies(HttpClient httpClient)
        {
            string url = DataContext.server_adress+"company";
            string json = httpClient.GetStringAsync(url).Result;
            return JsonConvert.DeserializeObject<IEnumerable<CompanyClients>>(json);
        }

        static public IEnumerable<Giros> GetAllGiros(HttpClient httpClient)
        {
            string url = DataContext.server_adress+"giro";
            string json = httpClient.GetStringAsync(url).Result;
            return JsonConvert.DeserializeObject<IEnumerable<Giros>>(json);
        }

        static public IEnumerable<Deposit> GetAllDeposits(HttpClient httpClient)
        {
            string url = DataContext.server_adress+"deposit";
            string json = httpClient.GetStringAsync(url).Result;
            return JsonConvert.DeserializeObject<IEnumerable<Deposit>>(json);
        }

        static public IEnumerable<Credits> GetAllCredits(HttpClient httpClient)
        {
            string url = DataContext.server_adress+"credit";
            string json = httpClient.GetStringAsync(url).Result;
            return JsonConvert.DeserializeObject<IEnumerable<Credits>>(json);
        }

        static public void SendPhys(HttpClient httpClient, PhysClients phys_client)
        {
            string url = DataContext.server_adress+"phys";

            var r = httpClient.PostAsync(
                requestUri: url,
                content: new StringContent(JsonConvert.SerializeObject(phys_client), Encoding.UTF8,
                mediaType: "application/json")
                ).Result;
        }

        static public void SendCompany(HttpClient httpClient, CompanyClients comp_client)
        {
            string url = DataContext.server_adress+"company";

            var r = httpClient.PostAsync(
                requestUri: url,
                content: new StringContent(JsonConvert.SerializeObject(comp_client), Encoding.UTF8,
                mediaType: "application/json")
                ).Result;
        }

        static public void SendGiro(HttpClient httpClient, Giros acc)
        {
            string url = DataContext.server_adress+"giro";

            var r = httpClient.PostAsync(
                requestUri: url,
                content: new StringContent(JsonConvert.SerializeObject(acc), Encoding.UTF8,
                mediaType: "application/json")
                ).Result;
        }

        static public void SendDeposit(HttpClient httpClient, Deposit acc)
        {
            string url = DataContext.server_adress+"deposit";

            var r = httpClient.PostAsync(
                requestUri: url,
                content: new StringContent(JsonConvert.SerializeObject(acc), Encoding.UTF8,
                mediaType: "application/json")
                ).Result;
        }

        static public void SendCredit(HttpClient httpClient, Credits acc)
        {
            string url = DataContext.server_adress+"credit";

            var r = httpClient.PostAsync(
                requestUri: url,
                content: new StringContent(JsonConvert.SerializeObject(acc), Encoding.UTF8,
                mediaType: "application/json")
                ).Result;
        }


        static public PhysClients GetPhys(HttpClient httpClient, int id)
        {
            string url = DataContext.server_adress+"phys/" + $"{id}";
            string json = httpClient.GetStringAsync(url).Result;
            return JsonConvert.DeserializeObject<PhysClients>(json);
        }
        static public CompanyClients GetCompany(HttpClient httpClient, int id)
        {
            string url = DataContext.server_adress+"company/" + $"{id}";
            string json = httpClient.GetStringAsync(url).Result;
            return JsonConvert.DeserializeObject<CompanyClients>(json);
        }

        static public Giros GetGiro(HttpClient httpClient, int id)
        {
            string url = DataContext.server_adress+"giro/" + $"{id}";
            string json = httpClient.GetStringAsync(url).Result;
            return JsonConvert.DeserializeObject<Giros>(json);
        }

        static public Deposit GetDeposit(HttpClient httpClient, int id)
        {
            string url = DataContext.server_adress+"deposit/" + $"{id}";
            string json = httpClient.GetStringAsync(url).Result;
            return JsonConvert.DeserializeObject<Deposit>(json);
        }

        static public Credits GetCredit(HttpClient httpClient, int id)
        {
            string url = DataContext.server_adress+"credit/" + $"{id}";
            string json = httpClient.GetStringAsync(url).Result;
            return JsonConvert.DeserializeObject<Credits>(json);
        }

        static public void PutGiro(HttpClient httpClient, Giros acc)
        {
            string url = DataContext.server_adress+"giro/" +$"{acc.id}";

            var r = httpClient.PutAsync(
                requestUri: url,
                content: new StringContent(JsonConvert.SerializeObject(acc), Encoding.UTF8,
                mediaType: "application/json")
                ).Result;
        }
    }


}
