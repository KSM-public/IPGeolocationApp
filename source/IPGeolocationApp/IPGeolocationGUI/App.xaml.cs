using IPGeolocationApp.ViewModels;
using IPGeolocationService.Providers;
using IPGeolocationService.Storages.SQLServer;
using System.Configuration;
using System.Data;
using System.Windows;

namespace IPGeolocationApp
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        protected override void OnStartup(StartupEventArgs e)
        {
            var connectionString = GetConnectionStringByName("SQLServerConnectionString");

            if (connectionString == null)
            {
                MessageBox.Show("Invalid connection string, check configuration");
                Shutdown(1);
                return;
            }

            string? ipStackComAPIKey = ConfigurationManager.AppSettings["IPStackComAPIKey"];

            if (ipStackComAPIKey == null)
            {
                MessageBox.Show("Invalid ipstack.com API, check configuration");
                Shutdown(1);
                return;
            }

            var ipStackComGeolocationProvider = new IPStackComGeolocationProvider(ipStackComAPIKey);
            var sqlServerStorage = new SQLServerStorage(connectionString);

            var viewModel = new MainWindowViewModel(ipStackComGeolocationProvider, sqlServerStorage);

            var mainWindow = new MainWindow
            {
                DataContext = viewModel
            };

            mainWindow.Show();
            base.OnStartup(e);
        }

        private string? GetConnectionStringByName(string name)
        {
            // Look for the name in the connectionStrings section.
            ConnectionStringSettings? settings =
                ConfigurationManager.ConnectionStrings[name];

            // If found, return the connection string (otherwise return null)
            return settings?.ConnectionString;
        }
    }

}
