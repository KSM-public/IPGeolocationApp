namespace IPGeolocationService.Models;
public partial class Country
{
    public string CountryCode { get; set; } = null!;

    public string CountryName { get; set; } = null!;

    public virtual ICollection<GeolocationData> GeolocationData { get; set; } = new List<GeolocationData>();
}
