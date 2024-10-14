using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IPGeolocationService.Models
{
    public class GeolocationDetails
    {
        public string IP { get; set; }
        public string ContinentCode { get; set; }
        public string Continent { get; set; }
        public string CountryCode { get; set; }
        public string Country { get; set; }
        public string RegionName { get; set; }
        public string City { get; set; }
        public string Zip { get; set; }

        public GeolocationDetails() 
        { 
            IP = string.Empty;
            ContinentCode = string.Empty;
            Continent = string.Empty;
            CountryCode = string.Empty;
            Country = string.Empty;
            RegionName = string.Empty;
            City = string.Empty;
            Zip = string.Empty;
        }

        public GeolocationDetails(GeolocationData geolocationData, Continent continent, Country country)
        {
            IP = string.Empty;
            ContinentCode = string.Empty;
            CountryCode = string.Empty;
            RegionName = string.Empty;
            City = string.Empty;
            Zip = string.Empty;

            Continent = continent.ContinentName;
            Country = country.CountryName;

            if (!string.IsNullOrEmpty(geolocationData.GeolocationdataRegion))
            {
                RegionName = geolocationData.GeolocationdataRegion;
            }

            if (!string.IsNullOrEmpty(geolocationData.GeolocationdataCity))
            {
                City = geolocationData.GeolocationdataCity;
            }
            
            if (!string.IsNullOrEmpty (geolocationData.GeolocationdataZip))
            {
                Zip = geolocationData.GeolocationdataZip;
            }    
        }

        public GeolocationData ToGeolocationData()
        {
            var geolocationDatum = new GeolocationData();
            geolocationDatum.GeolocationdataContinentCode = ContinentCode;
            geolocationDatum.GeolocationdataCountryCode = CountryCode;
            geolocationDatum.GeolocationdataRegion = RegionName;
            geolocationDatum.GeolocationdataCity = City;
            geolocationDatum.GeolocationdataZip = Zip;

            return geolocationDatum;
        }
    }
}
