using IPGeolocationService.Models;
using System.Collections.ObjectModel;

namespace IPGeolocationService.Storages.SQLServer
{
    public class SQLServerStorage : IIPGeolocationStorage
    {
        private SQLServerDataContext _dataContext;

        public SQLServerStorage(string connectionString)
        {
            _dataContext = new SQLServerDataContext(connectionString);
        }

        public ObservableCollection<Address> LoadAddressData()
        {
            if (!_dataContext.Database.CanConnect())
            {
                throw new Exception("Cannot connect to the database.");
            }

            var addressesData = (from a in _dataContext.Addresses
                                 select a).ToList();

            return new ObservableCollection<Address>(addressesData);
        }

        public GeolocationDetails LoadGeolocationDetails(Address address)
        {
            if (address != null)
            {
                var geolocationData = _dataContext.GeolocationData.First(n => n.GeolocationdataAddress == address.AddressId);
                var continentData = _dataContext.Continents.First(n => n.ContinentCode == geolocationData.GeolocationdataContinentCode);
                var countryData = _dataContext.Countries.First(n => n.CountryCode == geolocationData.GeolocationdataCountryCode);

                return new GeolocationDetails(geolocationData, continentData, countryData);
            }

            return new GeolocationDetails();
        }

        public async Task<Address> AddAddressData(string address, IIPGeolocationProvider provider)
        {
            var geolocationDetails = await provider.GetGeolocationDetails(address);

            if (geolocationDetails == null)
            {
                throw new Exception("Geolocation data couldn't be retrieved.");
            }

            var addressData = new Address();

            if (Uri.CheckHostName(address) == UriHostNameType.Dns) //URL was provided, get IP from geolocation data provider
            {
                addressData.AddressIp = geolocationDetails.IP;
                addressData.AddressUrl = address;
            }
            else //Only IP address was provided
            {
                addressData.AddressIp = address;
            }

            addressData.GeolocationData = new List<GeolocationData>
            {
                geolocationDetails.ToGeolocationData()
            };

            _dataContext.Addresses.Add(addressData);
            _dataContext.SaveChanges();

            return addressData;
        }

        public void RemoveAddressData(Address address)
        {
            _dataContext.Addresses.Remove(address);
            _dataContext.SaveChanges();
        }

        public UriHostNameType GetAddressType(string address)
        {
            return Uri.CheckHostName(address);
        }

        public bool AddressExist(string address)
        {
            Address? addressData = null;

            if (Uri.CheckHostName(address) == UriHostNameType.IPv4 || Uri.CheckHostName(address) == UriHostNameType.IPv6)
            {
                addressData = _dataContext.Addresses.FirstOrDefault(n => n.AddressIp == address);
            }
            else
            {
                addressData = _dataContext.Addresses.FirstOrDefault(n => n.AddressUrl == address);
            }

            return addressData != null;
        }
    }
}
