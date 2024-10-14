namespace IPGeolocationService.Models;
public partial class Continent
{
    public string ContinentCode { get; set; } = null!;

    public string ContinentName { get; set; } = null!;

    public virtual ICollection<GeolocationData> GeolocationData { get; set; } = new List<GeolocationData>();
}
