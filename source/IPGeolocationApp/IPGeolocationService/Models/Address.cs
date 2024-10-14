namespace IPGeolocationService.Models;

public partial class Address
{
    public int AddressId { get; set; }

    public string? AddressIp { get; set; }

    public string? AddressUrl { get; set; }

    public virtual ICollection<GeolocationData> GeolocationData { get; set; } = new List<GeolocationData>();
}
