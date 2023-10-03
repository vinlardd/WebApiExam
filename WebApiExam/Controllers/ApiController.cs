using Newtonsoft.Json;
using RestSharp;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Principal;
using System.Text;
using System.Threading.Tasks;
using WebApiExam.Models;

namespace WebApiExam.Controllers
{
    public class ApiController : BaseController
    {

        public ApiController(string connectionstring) : base(connectionstring)
        { }

        public RestResponse CreateAccount(Account account)
        {
            Request = new RestRequest("/Account/CreateAccount", Method.Post);
            Request.AddBody(account);
            Response = Client.Execute(Request);
            return Response;
        }
        public TokenResult GetToken(string login, string password)
        {
            Request = new RestRequest("/Account/GetToken", Method.Get);
            Request.AddParameter("login", login);
            Request.AddParameter("password", password);
            Response = Client.Execute(Request);
            if (Response.IsSuccessStatusCode)
            {
                TokenResult result = JsonConvert.DeserializeObject<TokenResult>(Response.Content);
                return result;
            }
            return null;
        }
        public List<City> GetCities(TokenResult token)
        {
            Request = new RestRequest("/Weather/GetCities", Method.Get);
            Request.AddParameter("token", token.Token);
            Response = Client.Execute(Request);
            if (Response.IsSuccessStatusCode)
            {
                List<City> result = JsonConvert.DeserializeObject<List<City>>(Response.Content);
                return result;
            }
            return null;
        }
        public List<WeatherResult> GetWeatherByCity(TokenResult token, City SelectedCity)
        {
            Request = new RestRequest("/Weather/GetWeatherByCity", Method.Get);
            Request.AddParameter("token", token.Token);
            Request.AddParameter("idCity", SelectedCity.IdCity);
            Response = Client.Execute(Request);
            if (Response.IsSuccessStatusCode)
            {
                List<WeatherResult> result = JsonConvert.DeserializeObject<List<WeatherResult>>(Response.Content);
                return result;
            }
            return null;
        }
    }
}
