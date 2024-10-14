using IPGeolocationService.Models;
using System.Collections.ObjectModel;

namespace IPGeolocationService.Tests.Helpers
{
    public class FakeStorage : IIPGeolocationStorage
    {
        private List<StorageData> _storageData;

        public List<StorageData> StorageData { get => _storageData; set => _storageData = value; }

        public FakeStorage()
        {
            _storageData = new List<StorageData>();
        }

        public ObservableCollection<Address> LoadAddressData()
        {
            var addressData = new ObservableCollection<Address>();

            foreach (var item in _storageData)
            {
                addressData.Add(item.Address);
            }

            return addressData;
        }

        public GeolocationDetails LoadGeolocationDetails(Address address)
        {
            return _storageData.Where(n => n.Address == address).FirstOrDefault().GeolocationDetails;
        }

        public async Task<Address> AddAddressData(string address, IIPGeolocationProvider provider)
        {
            await Task.Yield();

            throw new NotImplementedException();
        }

        public void RemoveAddressData(Address address)
        {
            var storageData = _storageData.Where(n => n.Address == address).FirstOrDefault();
            _storageData.Remove(storageData);
        }

        public bool AddressExist(string address)
        {
            throw new NotImplementedException();
        }
    }

    public struct StorageData
    {
        public Address Address;
        public GeolocationDetails GeolocationDetails;
    }
}
