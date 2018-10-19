using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TuiFlightDataContext;
using TuiFlightModel.Models;

namespace TuiFlight.DataAccess
{
    public class EntityFwkRepository : IRepository
    {
        private readonly TuiFlightDbContext _dbContext;

        public EntityFwkRepository(TuiFlightDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        #region " Airline   "

        public void Add(Airline a)
        {
            _dbContext.Airlines.Add(a);
            _dbContext.SaveChanges();
        }

        public Task<int> AddAsync(Airline a)
        {
            _dbContext.Airlines.AddAsync(a);
            return _dbContext.SaveChangesAsync();
        }

        public IEnumerable<Airline> ListAllAirlines()
        {
            return _dbContext.Airlines.AsEnumerable();
        }

        public IAsyncEnumerable<Airline> ListAllAirlinesAsync()
        {
            return _dbContext.Airlines.ToAsyncEnumerable();
        }

        #endregion Airline

        #region " Airport   "

        public void Add(Airport a)
        {
            _dbContext.Airports.Add(a);
            _dbContext.SaveChanges();
        }

        public Task<int> AddAsync(Airport a)
        {
            _dbContext.Airports.AddAsync(a);
            return _dbContext.SaveChangesAsync();
        }

        public IEnumerable<Airport> ListAllAirports()
        {
            return _dbContext.Airports
                    .Include(t => t.City)
                    .Include(t => t.FlightsFrom)
                    .Include(t => t.FlightsOnArrival).AsEnumerable();
        }

        public IAsyncEnumerable<Airport> ListAllAirportsAsync()
        {
            return _dbContext.Airports
                    .Include(t => t.City)
                    .Include(t => t.FlightsFrom)
                    .Include(t => t.FlightsOnArrival).ToAsyncEnumerable();
        }

        #endregion Airport

        #region " Cities    "

        public void Add(City r)
        {
            _dbContext.Cities.Add(r);
            _dbContext.SaveChanges();
        }

        public Task<int> AddAsync(City c)
        {
            _dbContext.Cities.AddAsync(c);
            return _dbContext.SaveChangesAsync();
        }

        public IEnumerable<City> ListAllCities()
        {
            return _dbContext.Cities
                    .Include(t => t.Country)
                    .AsEnumerable();
        }

        public IAsyncEnumerable<City> ListAllCitiesAsync()
        {
            return _dbContext.Cities
                .Include(t => t.Country)
                .ToAsyncEnumerable();
        }

        #endregion Cities

        #region " Country   "

        public void Add(Country c)
        {
            _dbContext.Countries.Add(c);
            _dbContext.SaveChanges();
        }

        public Task<int> AddAsync(Country c)
        {
            _dbContext.Countries.AddAsync(c);
            return _dbContext.SaveChangesAsync();
        }

        public IEnumerable<Country> ListAllCountries()
        {
            return _dbContext.Countries.AsEnumerable();
        }

        public IAsyncEnumerable<Country> ListAllCountriesAsync()
        {
            return _dbContext.Countries.ToAsyncEnumerable();
        }

        #endregion Country

        #region " Customer  "

        public void Add(Customer c)
        {
            _dbContext.Customers.Add(c);
            _dbContext.SaveChanges();
        }

        public IEnumerable<Customer> ListAllCustomers()
        {
            return _dbContext.Customers
                    .Include(t => t.City)
                    .Include(t => t.Travels).AsEnumerable();
        }

        public Task<int> AddAsync(Customer c)
        {
            _dbContext.Customers.AddAsync(c);
            return _dbContext.SaveChangesAsync();
        }

        public IAsyncEnumerable<Customer> ListAllCustomersAsync()
        {
            return _dbContext.Customers
                    .Include(t => t.City)
                    .Include(t => t.Travels).ToAsyncEnumerable();
        }

        #endregion Customer

        #region " Flights   "

        public void Add(Flight f)
        {
            _dbContext.Flights.Add(f);
            _dbContext.SaveChanges();
        }

        public Task<int> AddAsync(Flight f)
        {
            _dbContext.Flights.AddAsync(f);
            return _dbContext.SaveChangesAsync();
        }

        public IEnumerable<Flight> ListAllFlights()
        {
            return _dbContext.Flights
                    .Include(t => t.Airline)
                    .Include(t => t.DepartureAirport)
                    .Include(t => t.DestinationAirport)
                    .AsEnumerable();
        }

        public IAsyncEnumerable<Flight> ListAllFlightsAsync()
        {
            return _dbContext.Flights
                    .Include(t => t.Airline)
                    .Include(t => t.DepartureAirport)
                    .Include(t => t.DestinationAirport)
                    .ToAsyncEnumerable();
        }

        #endregion Flights

        #region " Travels   "

        public void Add(Travel f)
        {
            _dbContext.Travels.Add(f);
            _dbContext.SaveChanges();
        }

        public Task<int> AddAsync(Travel f)
        {
            _dbContext.Travels.AddAsync(f);
            return _dbContext.SaveChangesAsync();
        }

        public IEnumerable<Travel> ListAllTravels()
        {
            return _dbContext.Travels
                    .Include(t => t.Traveller)
                    .AsEnumerable();
        }

        public IAsyncEnumerable<Travel> ListAllTravelsAsync()
        {
            return _dbContext.Travels
                    .Include(t => t.Traveller)
                    .ToAsyncEnumerable();
        }

        #endregion Travels
    }
}