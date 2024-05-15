using Microsoft.EntityFrameworkCore;
using ParcelApi.Models;
using ParcelApi.Models.Bags;


namespace ParcelApi.Data;

public class ParcelManagerContext : DbContext
{

  public ParcelManagerContext (DbContextOptions<ParcelManagerContext> options) : base(options) {}

  public DbSet<Shipment> Shipments { get; set; }

  public DbSet<Bag> Bags { get; set; }

  public DbSet<ParcelBag> ParcelBags { get; set; }

  public DbSet<LetterBag> LetterBags { get; set; }

  public DbSet<Parcel> Parcels { get; set; }

}
