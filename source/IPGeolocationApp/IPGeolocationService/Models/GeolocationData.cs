namespace IPGeolocationService.Models;
public partial class GeolocationData
{
    public int GeolocationdataId { get; set; }

    public int GeolocationdataAddress { get; set; }

    public string? GeolocationdataContinentCode { get; set; }

    public string? GeolocationdataCountryCode { get; set; }

    public string? GeolocationdataRegion { get; set; }

    public string? GeolocationdataCity { get; set; }

    public string? GeolocationdataZip { get; set; }

    public virtual Address GeolocationdataAddressNavigation { get; set; } = null!;

    public virtual Continent? GeolocationdataContinentCodeNavigation { get; set; }

    public virtual Country? GeolocationdataCountryCodeNavigation { get; set; }
}
