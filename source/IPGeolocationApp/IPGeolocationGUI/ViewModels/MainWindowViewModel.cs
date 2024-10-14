using IPGeolocationService;
using IPGeolocationService.Models;
using System.Collections.ObjectModel;
using System.Net;
using System.Windows.Input;

namespace IPGeolocationApp.ViewModels
{
    public class MainWindowViewModel : ViewModelBase
    {
        private ObservableCollection<Address> _addresses;

        private IIPGeolocationProvider _geolocationProvider;
        private IIPGeolocationStorage _geolocationStorage;

        public ObservableCollection<Address> Addresses { get => _addresses; set => _addresses = value; }
        public GeolocationDetails SelectedAddressGeolocationDetails { get; set; }

        private Address _selectedAddress;
        public Address SelectedAddress 
        { 
            get
            {
                return _selectedAddress;
            }

            set
            {
                _selectedAddress = value;

                if (_selectedAddress != null)
                {
                    try
                    {
                        SelectedAddressGeolocationDetails = _geolocationStorage.LoadGeolocationDetails(_selectedAddress);
                    }
                    catch (Exception ex)
                    {
                        Status = "Database read failed: " + ex.Message;
                        Connected = false;
                    }
                    
                    OnPropertyChanged(nameof(SelectedAddressGeolocationDetails));
                }
            }
        }

        private string _addressIP;
        public string AddressIP
        {
            get
            {
                return _addressIP;
            }

            set
            {
                AddressValid = true;

                _addressIP = value;
                OnPropertyChanged(nameof(AddressIP));
            }
        }

        private string _addressURL;
        public string AddressURL
        {
            get
            {
                return _addressURL;
            }

            set
            {
                _addressURL = value;
                OnPropertyChanged(nameof(AddressURL));
            }
        }

        private string _status;
        public string Status
        {
            get
            {
                return _status;
            }

            set
            {
                _status = value;
                OnPropertyChanged(nameof(Status));
            }
        }

        private bool _connected;
        public bool Connected
        {
            get
            {
                return _connected;
            }

            set
            {
                _connected = value;
                OnPropertyChanged(nameof(Connected));
            }
        }

        private bool _addressValid;
        public bool AddressValid
        {
            get
            {
                return _addressValid;
            }

            set
            {
                _addressValid = value;
                OnPropertyChanged(nameof(AddressValid));
            }
        }

        public ICommand ButtonAddCommand { get; set; }
        public ICommand ButtonRemoveCommand { get; set; }

        public MainWindowViewModel(IIPGeolocationProvider geolocationProvider, IIPGeolocationStorage geolocationStorage)
        {
            _status = "OK";
            _connected = false;

            _geolocationProvider = geolocationProvider;
            _geolocationStorage = geolocationStorage;

            _addressIP = string.Empty;
            _addressURL = string.Empty;
            _selectedAddress = new Address();
            _addresses = new ObservableCollection<Address>();
            _addressValid = true;

            ButtonAddCommand = new RelayCommand(AddCommand);
            ButtonRemoveCommand = new RelayCommand(RemoveCommand);
            SelectedAddressGeolocationDetails = new GeolocationDetails();

            LoadAddressData();
        }

        private async void AddCommand(object? parameter)
        {
            if (!_connected)
            {
                return;
            }

            if (string.IsNullOrEmpty(_addressIP) && string.IsNullOrEmpty(_addressURL))
            {
                Status = "Error: No address provided.";
                return;
            }

            string address;

            if (!string.IsNullOrEmpty(_addressURL))
            {
                address = _addressURL;
            }
            else
            {
                if (!IPAddress.TryParse(_addressIP, out _))
                {
                    AddressValid = false;
                    Status = "Error: Invalid address format.";
                    return;
                }

                address = _addressIP;
            }

            if (GetAddressType(address) == UriHostNameType.Unknown)
            {
                Status = "Error: Unknown address.";
                return;
            }

            if (_geolocationStorage.AddressExist(address))
            {
                Status = "Error: Address already exist.";
                return;
            }

            try
            {
                var addressData = await _geolocationStorage.AddAddressData(address, _geolocationProvider);
                Addresses.Add(addressData);
            }
            catch (Exception ex)
            {
                Status = "Error: Adding address data failed with error: " + ex.Message;
                return;
            }

            Status = "OK";
        }

        private void RemoveCommand(object? parameter)
        {
            if (SelectedAddress == null)
            {
                return;
            }

            if (!_connected)
            {
                return;
            }

            try
            {
                _geolocationStorage.RemoveAddressData(SelectedAddress);
                _addresses.Remove(SelectedAddress);
            }
            catch (Exception ex)
            {
                Status = "Error: Removing address data failed with error: " + ex.Message;
                return;
            }

            Status = "OK";
        }

        private void LoadAddressData()
        {
            try
            {
                _addresses = _geolocationStorage.LoadAddressData();
                Connected = true;
            }
            catch (Exception ex)
            {
                Status = "Database connection failed: " + ex.Message;
            }
        }

        private UriHostNameType GetAddressType(string address)
        {
            return Uri.CheckHostName(address);
        }
    }
}
