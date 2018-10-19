using Microsoft.EntityFrameworkCore;
using System.Linq;
using TuiFlightModel.Models;

namespace TuiFlightDataContext
{
    public class TuiFlightDbContext : DbContext
    {
        public TuiFlightDbContext(DbContextOptions<TuiFlightDbContext> options)
            : base(options)
        { }

        public DbSet<Airline> Airlines { get; set; }
        public DbSet<Airport> Airports { get; set; }
        public DbSet<City> Cities { get; set; }
        public DbSet<Country> Countries { get; set; }
        public DbSet<Customer> Customers { get; set; }
        public DbSet<Flight> Flights { get; set; }
        public DbSet<Travel> Travels { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Airline>()
                .HasKey(k => k.AirlineId);

            modelBuilder.Entity<Airport>()
                .HasKey(k => k.AirportId);

            modelBuilder.Entity<Country>()
                .HasKey(k => k.CountryId);

            modelBuilder.Entity<Customer>()
                .HasKey(k => k.CustomerId);

            modelBuilder.Entity<Flight>()
                .HasKey(k => k.FlightId);

            modelBuilder.Entity<Flight>()
                .HasOne(bc => bc.DepartureAirport)
                .WithMany(b => b.FlightsFrom)
                .HasForeignKey(fk => fk.DepAirportId)
                .HasConstraintName("FK_Flight_Airport_From");

            modelBuilder.Entity<Flight>()
                .HasOne(p => p.DestinationAirport)
                .WithMany(b => b.FlightsOnArrival)
                .HasForeignKey(fk => fk.DesAirportId)
                .HasConstraintName("FK_Airport_Flight_To");

            //modelBuilder.Entity<Flight>()
            //    .HasOne(p => p.Airline)
            //    .WithMany(b => b.Flights)
            //    .HasForeignKey(fk => fk.AirlineId)
            //    .HasConstraintName("FK_Airline_Flight");

            modelBuilder.Entity<Travel>()
                .HasKey(k => new
                {
                    k.OutboundFlightId,
                    k.CustomerId,
                    k.OutboundDate
                });

            modelBuilder.Entity<Travel>()
                .HasOne(bc => bc.Traveller)
                .WithMany(b => b.Travels)
                .HasForeignKey(fk => fk.CustomerId)
                .HasConstraintName("FK_Travel_Customer");

            foreach (var relationship in modelBuilder.Model.GetEntityTypes().SelectMany(e => e.GetForeignKeys()))
            {
                relationship.DeleteBehavior = DeleteBehavior.Restrict;
            }
        }
    }
}
