using IPGeolocationService.Models;
using System.Collections.ObjectModel;

namespace IPGeolocationService
{
    public interface IIPGeolocationStorage
    {
        ObservableCollection<Address> LoadAddressData();
        GeolocationDetails LoadGeolocationDetails(Address address);
        Task<Address> AddAddressData(string address, IIPGeolocationProvider provider);
        void RemoveAddressData(Address address);
        bool AddressExist(string address);
    }
}
