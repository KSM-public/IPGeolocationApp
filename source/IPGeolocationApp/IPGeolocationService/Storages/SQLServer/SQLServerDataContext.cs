using IPGeolocationService.Models;
using Microsoft.EntityFrameworkCore;

namespace IPGeolocationService.Storages.SQLServer;
public partial class SQLServerDataContext : DbContext
{
    private string _connectionString;

    public SQLServerDataContext(string connectionString)
    {
        _connectionString = connectionString;
    }

    public SQLServerDataContext(DbContextOptions<SQLServerDataContext> options)
        : base(options)
    {
        _connectionString = string.Empty;
    }

    public virtual DbSet<Address> Addresses { get; set; }

    public virtual DbSet<Continent> Continents { get; set; }

    public virtual DbSet<Country> Countries { get; set; }

    public virtual DbSet<GeolocationData> GeolocationData { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        => optionsBuilder.UseSqlServer(_connectionString,
            sqlOptionsBuilder => sqlOptionsBuilder.EnableRetryOnFailure());

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Address>(entity =>
        {
            entity.Property(e => e.AddressId).HasColumnName("address_id");
            entity.Property(e => e.AddressIp)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("address_ip");
            entity.Property(e => e.AddressUrl)
                .HasMaxLength(50)
                .HasColumnName("address_url");
        });

        modelBuilder.Entity<Continent>(entity =>
        {
            entity.HasKey(e => e.ContinentCode);

            entity.Property(e => e.ContinentCode)
                .HasMaxLength(2)
                .IsUnicode(false)
                .HasColumnName("continent_code");
            entity.Property(e => e.ContinentName)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("continent_name");
        });

        modelBuilder.Entity<Country>(entity =>
        {
            entity.HasKey(e => e.CountryCode);

            entity.Property(e => e.CountryCode)
                .HasMaxLength(2)
                .IsUnicode(false)
                .HasColumnName("country_code");
            entity.Property(e => e.CountryName)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("country_name");
        });

        modelBuilder.Entity<GeolocationData>(entity =>
        {
            entity.HasKey(e => e.GeolocationdataId);

            entity.Property(e => e.GeolocationdataId).HasColumnName("geolocationdata_id");
            entity.Property(e => e.GeolocationdataAddress).HasColumnName("geolocationdata_address");
            entity.Property(e => e.GeolocationdataCity)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("geolocationdata_city");
            entity.Property(e => e.GeolocationdataContinentCode)
                .HasMaxLength(2)
                .IsUnicode(false)
                .HasColumnName("geolocationdata_continent_code");
            entity.Property(e => e.GeolocationdataCountryCode)
                .HasMaxLength(2)
                .IsUnicode(false)
                .HasColumnName("geolocationdata_country_code");
            entity.Property(e => e.GeolocationdataRegion)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("geolocationdata_region");
            entity.Property(e => e.GeolocationdataZip)
                .HasMaxLength(15)
                .IsUnicode(false)
                .HasColumnName("geolocationdata_zip");

            entity.HasOne(d => d.GeolocationdataAddressNavigation).WithMany(p => p.GeolocationData)
                .HasForeignKey(d => d.GeolocationdataAddress)
                .OnDelete(DeleteBehavior.Cascade)
                .HasConstraintName("FK_GeolocationData_Addresses");

            entity.HasOne(d => d.GeolocationdataContinentCodeNavigation).WithMany(p => p.GeolocationData)
                .HasForeignKey(d => d.GeolocationdataContinentCode)
                .HasConstraintName("FK_GeolocationData_Continents");

            entity.HasOne(d => d.GeolocationdataCountryCodeNavigation).WithMany(p => p.GeolocationData)
                .HasForeignKey(d => d.GeolocationdataCountryCode)
                .HasConstraintName("FK_GeolocationData_Countries");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
