using IPGeolocationApp.ViewModels;
using IPGeolocationService.Models;
using IPGeolocationService.Tests.Helpers;
using IPGeolocationService;
using NSubstitute;

namespace IPGeolocationGUI.Tests.ViewModels
{
    [TestFixture]
    public class MainWindowViewModelTests
    {
        [Test]
        public void AddressDataIsAddedCorrectly()
        {
            var storage = Substitute.For<IIPGeolocationStorage>();
            var provider = Substitute.For<IIPGeolocationProvider>();

            var viewModel = new MainWindowViewModel(provider, storage);
            viewModel.Addresses = new System.Collections.ObjectModel.ObservableCollection<Address>();

            viewModel.AddressIP = "1.2.3.4";
            viewModel.ButtonAddCommand.Execute(null);

            storage.Received().AddAddressData("1.2.3.4", provider);
        }

        [Test]
        public void AddressDataIsAddedCorrectlyWithURL()
        {
            var storage = Substitute.For<IIPGeolocationStorage>();
            var provider = Substitute.For<IIPGeolocationProvider>();

            var viewModel = new MainWindowViewModel(provider, storage);
            viewModel.Addresses = new System.Collections.ObjectModel.ObservableCollection<Address>();

            viewModel.AddressURL = "foo.bar";
            viewModel.ButtonAddCommand.Execute(null);

            storage.Received().AddAddressData("foo.bar", provider);
        }

        [Test]
        public void AddressDataIsRemovedCorrectly()
        {
            var storage = new FakeStorage();
            var provider = Substitute.For<IIPGeolocationProvider>();

            var viewModel = new MainWindowViewModel(provider, storage);

            var firstAddress = new StorageData();
            firstAddress.Address = new Address();
            firstAddress.Address.AddressIp = "1.2.3.4";
            firstAddress.GeolocationDetails = new GeolocationDetails();

            var secondAddress = new StorageData();
            secondAddress.Address = new Address();
            secondAddress.Address.AddressIp = "4.3.2.1";
            secondAddress.GeolocationDetails = new GeolocationDetails();

            storage.StorageData = new List<StorageData> { firstAddress, secondAddress };

            viewModel.SelectedAddress = storage.StorageData[0].Address;
            viewModel.ButtonRemoveCommand.Execute(null);

            Assert.That(storage.StorageData.Count, Is.EqualTo(1));
            Assert.That(storage.StorageData[0].Address.AddressIp, Is.EqualTo("4.3.2.1"));
        }

        [TestCase("8.8.8.8", true)]
        [TestCase("::1", true)]
        [TestCase("2001:0000:130F:0000:0000:09C0:876A:130B", true)]
        [TestCase("1.2.3.256", false)]
        [TestCase("2001:0000:130G:0000:0000:09Z0:876A:130B", false)]
        [TestCase("2001:0000:130F:0000:0000:09C0:876A:130B:0000", false)]
        [TestCase("foo", false)]
        public void AddressValidationIsCorrect(string address, bool expectedResult)
        {
            var storage = Substitute.For<IIPGeolocationStorage>();
            var provider = Substitute.For<IIPGeolocationProvider>();

            var viewModel = new MainWindowViewModel(provider, storage);
            viewModel.Addresses = new System.Collections.ObjectModel.ObservableCollection<Address>();

            viewModel.AddressIP = address;
            viewModel.ButtonAddCommand.Execute(null);

            Assert.That(viewModel.AddressValid, Is.EqualTo(expectedResult));
        }
    }
}
