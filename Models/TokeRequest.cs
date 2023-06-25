using Newtonsoft.Json;
namespace _20BF1A1232.Models
{
    public class TokenRequest
    {
        [JsonProperty("companyName")]
        public string CompanyName { get; set; }

        [JsonProperty("clientID")]
        public string ClientID { get; set; }

        [JsonProperty("clientSecret")]
        public string ClientSecret { get; set; }

        [JsonProperty("ownerName")]
        public string OwnerName { get; set; }

        [JsonProperty("ownerEmail")]
        public string OwnerEmail { get; set; }

        [JsonProperty("rollNo")]
        public string RollNo { get; set; }
    }

}
