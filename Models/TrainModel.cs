using Newtonsoft.Json;
namespace _20BF1A1232.Models
{
    public class Train
    {
        [JsonProperty("trainName")]
        public string TrainName { get; set; }

        [JsonProperty("trainNumber")]
        public string TrainNumber { get; set; }

        [JsonProperty("departureTime")]
        public DepartureTime DepartureTime { get; set; }

        [JsonProperty("seatsAvailable")]
        public SeatsAvailable SeatsAvailable { get; set; }

        [JsonProperty("price")]
        public Price Price { get; set; }

        [JsonProperty("delayedBy")]
        public int DelayedBy { get; set; }
    }

    public class DepartureTime
    {
        [JsonProperty("Hours")]
        public int Hours { get; set; }

        [JsonProperty("Minutes")]
        public int Minutes { get; set; }

        [JsonProperty("Seconds")]
        public int Seconds { get; set; }
    }

    public class SeatsAvailable
    {
        [JsonProperty("sleeper")]
        public int Sleeper { get; set; }

        [JsonProperty("AC")]
        public int AC { get; set; }
    }

    public class Price
    {
        [JsonProperty("sleeper")]
        public decimal Sleeper { get; set; }

        [JsonProperty("AC")]
        public decimal AC { get; set; }
    }

}
