using IPGeolocationService.Models;

namespace IPGeolocationService
{
    public interface IIPGeolocationProvider
    {
        Task<GeolocationDetails?> GetGeolocationDetails(string requestAddress);
    }
}
