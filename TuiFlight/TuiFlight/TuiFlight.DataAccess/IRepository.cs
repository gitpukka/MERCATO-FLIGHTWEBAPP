using System.Collections.Generic;
using System.Threading.Tasks;
using TuiFlightModel.Models;

namespace TuiFlight.DataAccess
{
    public interface IRepository
    {
        IEnumerable<Airline> ListAllAirlines();
        void Add(Airline a);

        IAsyncEnumerable<Airline> ListAllAirlinesAsync();
        Task<int> AddAsync(Airline a);

        IEnumerable<Airport> ListAllAirports();
        void Add(Airport a);

        IAsyncEnumerable<Airport> ListAllAirportsAsync();
        Task<int> AddAsync(Airport a);

        IEnumerable<City> ListAllCities();
        void Add(City r);

        IAsyncEnumerable<City> ListAllCitiesAsync();
        Task<int> AddAsync(City r);

        IEnumerable<Country> ListAllCountries();
        void Add(Country c);

        IAsyncEnumerable<Country> ListAllCountriesAsync();
        Task<int> AddAsync(Country c);

        IEnumerable<Customer> ListAllCustomers();
        void Add(Customer c);

        IAsyncEnumerable<Customer> ListAllCustomersAsync();
        Task<int> AddAsync(Customer c);

        IEnumerable<Flight> ListAllFlights();
        void Add(Flight f);

        IAsyncEnumerable<Flight> ListAllFlightsAsync();
        Task<int> AddAsync(Flight f);

        IEnumerable<Travel> ListAllTravels();
        void Add(Travel f);

        IAsyncEnumerable<Travel> ListAllTravelsAsync();
        Task<int> AddAsync(Travel f);
    }
}