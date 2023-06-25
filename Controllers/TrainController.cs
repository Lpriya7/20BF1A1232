using _20BF1A1232.Models;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Net.Http.Headers;
using System.Text;

namespace _20BF1A1232.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class TrainController : ControllerBase
    {
        TokenResponse token;
        public TrainController() {
            token=GetNewToken().Result;
        }

        [HttpGet]
        public IEnumerable<Train> Get()
        {
            IEnumerable<Train> train = new List<Train>();
            using (HttpClient client = new HttpClient())
            {
                client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token.AccessToken);
                HttpResponseMessage response =  client.GetAsync("http://104.211.219.98/train/trains").Result;
                if (response.IsSuccessStatusCode) {
                    string responseContent = response.Content.ReadAsStringAsync().Result;
                    train = (IEnumerable<Train>)JsonConvert.DeserializeObject<Train>(responseContent);
                }
            }
            return train;
        }

        [HttpGet]
        //[Route("/{}")]
        public Train GetTrain(int trainId)
        {
             Train train = new Train();
            using (HttpClient client = new HttpClient())
            {
                client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token.AccessToken);
                HttpResponseMessage response = client.GetAsync("http://104.211.219.98/train/trains"+"/"+trainId).Result;
                if (response.IsSuccessStatusCode)
                {
                    string responseContent = response.Content.ReadAsStringAsync().Result;
                    train = JsonConvert.DeserializeObject<Train>(responseContent);
                }
            }
            return train;
        }

        private void GetToken()
        {
            long currentTime = DateTimeOffset.Now.ToUnixTimeSeconds();
            if (token.ExpiresIn - 15 < currentTime)
            {
                token= GetNewToken().Result;
            }            
        }

        private async Task<TokenResponse> GetNewToken()
        {
            TokenResponse tokenResponse = new TokenResponse();
            TokenRequest tokenRequest= new TokenRequest();
            tokenRequest.ClientID = "859194e1-692a-49e6-b966-0a6dd7c33d1e";
            tokenRequest.CompanyName = "Train Central";
            tokenRequest.OwnerName = "M Likhitha priya";
            tokenRequest.OwnerEmail = "2020it.r32@svce.edu.in";
            tokenRequest.RollNo = "20BF1A1232";
            tokenRequest.ClientSecret = "RaHjfFcQtXovQyXb";
            using (HttpClient client = new HttpClient())
            {
                string json = JsonConvert.SerializeObject(tokenRequest);
                var content = new StringContent(json, Encoding.UTF8, "application/json");

                // Send the POST request
                HttpResponseMessage response = await client.PostAsync("http://104.211.219.98/train/auth", content);

                // Process the response
                if (response.IsSuccessStatusCode)
                {
                    string responseContent = await response.Content.ReadAsStringAsync();
                    tokenResponse = JsonConvert.DeserializeObject<TokenResponse>(responseContent);
                }
            }
            return tokenResponse;
        }

    }
}
