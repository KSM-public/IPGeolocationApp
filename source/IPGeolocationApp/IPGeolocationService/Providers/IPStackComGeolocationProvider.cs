using IPGeolocationService.Models;
using System;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace IPGeolocationService.Providers
{
    public class IPStackComGeolocationProvider : IIPGeolocationProvider
    {
        private HttpClient _httpClient;
        private string _apiKey;

        public IPStackComGeolocationProvider(string APIKey)
        {
            _httpClient = new HttpClient();
            _apiKey = APIKey;
        }

        public async Task<GeolocationDetails?> GetGeolocationDetails(string requestAddress)
        {
            var responseStream = await _httpClient.GetStreamAsync($"http://api.ipstack.com/{requestAddress}?access_key={_apiKey}");
            var ipGeolocationData = await JsonSerializer.DeserializeAsync<IPStackComJsonData>(responseStream);

            if (ipGeolocationData != null)
            {
                if (!ipGeolocationData.GeolocationDataPresent())
                {
                    throw new Exception("Response is empty, check if API key is correct and/or entered address is valid.");
                }
                
                return ipGeolocationData.ToGeolocationDetails();
            }

            return null;
        }
    }

    internal class IPStackComJsonData
    {
        [property: JsonPropertyName("ip")]
        public string IP { get; set; }

        [property: JsonPropertyName("continent_code")]
        public string ContinentCode { get; set; }

        [property: JsonPropertyName("country_code")]
        public string CountryCode { get; set; }

        [property: JsonPropertyName("region_name")]
        public string RegionName { get; set; }

        [property: JsonPropertyName("city")]
        public string City { get; set; }

        [property: JsonPropertyName("zip")]
        public string Zip { get; set; }

        public IPStackComJsonData()
        {
            IP = string.Empty;
            ContinentCode = string.Empty;
            CountryCode = string.Empty;
            RegionName = string.Empty;
            City = string.Empty;
            Zip = string.Empty;
        }

        public bool GeolocationDataPresent()
        {
            if (string.IsNullOrEmpty(IP) || string.IsNullOrEmpty(ContinentCode) || string.IsNullOrEmpty(CountryCode)
                    || string.IsNullOrEmpty(RegionName) || string.IsNullOrEmpty(City) || string.IsNullOrEmpty(Zip))
            {
                return false;
            }

            return true;
        }

        public GeolocationDetails ToGeolocationDetails()
        {
            var geolocationDetails = new GeolocationDetails();

            geolocationDetails.IP = IP;
            geolocationDetails.ContinentCode = ContinentCode;
            geolocationDetails.CountryCode = CountryCode;
            geolocationDetails.RegionName = RegionName;
            geolocationDetails.City = City;
            geolocationDetails.Zip = Zip;

            return geolocationDetails;
        }
    }
}
