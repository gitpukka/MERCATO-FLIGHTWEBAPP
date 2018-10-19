using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using TuiFlight.DataAccess;
using TuiFlightModel.Models;

namespace TuiFlight.Business
{
    public class DataBusiness
    {
        private readonly IRepository _repository;

        public DataBusiness(IRepository repository)
        {
            _repository = repository;
        }

        #region " Airline   "

        public CommandRresult CheckAirLine(Airline a)
        {
            if (a == null)
            {
                return new CommandRresult {
                    CommandSucceed = false,
                    Message = "Impossible to add an empty airline company",
                    ResultCode = CommandRresult.ReturnCode.ImpossibleToAddAnEmptyAirlineCompany
                };
            }

            if (Guid.Empty == a.AirlineId)
            {
                return new CommandRresult {
                    CommandSucceed = false,
                    Message = "An error occured while adding the airline company. The Id is missing",
                    ResultCode = CommandRresult.ReturnCode.TheAirlineCompanyIdIsMissing
                };
            }

            if (string.IsNullOrEmpty(a.Name))
            {
                return new CommandRresult {
                    CommandSucceed = false,
                    Message = "You must specify the airline company name",
                    ResultCode = CommandRresult.ReturnCode.YouMustSpecifyTheAirlineCompanyName
                };
            }

            return new CommandRresult {
                CommandSucceed = true,
                Message = "The airline has been added",
                ResultCode = CommandRresult.ReturnCode.TheAirlineCompanyHasBeenAdded
            };
        }

        public CommandRresult AddAirline(Airline a)
        {
            var result = CheckAirLine(a);

            if (result.CommandSucceed)
                _repository.Add(a);

            return result;
        }

        public CommandRresult AddAirlineAsync(Airline a)
        {
            var result = CheckAirLine(a);

            if (result.CommandSucceed)
               result.AsyncResult = _repository.AddAsync(a);

            return result;
        }

        public IEnumerable<Airline> ListAllAirlines()
        {
            return _repository.ListAllAirlines();
        }

        public IAsyncEnumerable<Airline> ListAllAirlinesAsync()
        {
            return _repository.ListAllAirlinesAsync();
        }

        #endregion Airline

        #region " Airport   "

        CommandRresult CheckAirport(Airport a)
        {
            if (a == null)
            {
                return new CommandRresult
                {
                    CommandSucceed = false,
                    Message = "Impossible to add an empty airport",
                    ResultCode = CommandRresult.ReturnCode.ImpossibleToAddAnEmptyAirport
                };
            }

            if (Guid.Empty == a.AirportId)
            {
                return new CommandRresult
                {
                    CommandSucceed = false,
                    Message = "An error occured while adding the airport",
                    ResultCode = CommandRresult.ReturnCode.TheAirportIdIsMissing
                };
            }

            if (string.IsNullOrEmpty(a.Name))
            {
                return new CommandRresult
                {
                    CommandSucceed = false,
                    Message = "You must specify the airport name",
                    ResultCode = CommandRresult.ReturnCode.YouMustSpecifyTheAirportName
                };
            }

            return new CommandRresult
            {
                CommandSucceed = true,
                Message = "The airport has been added",
                ResultCode = CommandRresult.ReturnCode.TheAirportHasBeenAdded
            };
        }

        public CommandRresult AddAirport(Airport a)
        {
            var result = CheckAirport(a);

            if (result.CommandSucceed)
                _repository.Add(a);

            return result;
        }

        public CommandRresult AddAirportAsync(Airport a)
        {
            var result = CheckAirport(a);

            if (result.CommandSucceed)
                result.AsyncResult = _repository.AddAsync(a);

            return result;
        }

        public IEnumerable<Airport> ListAllAirports()
        {
            return _repository.ListAllAirports();
        }

        public IAsyncEnumerable<Airport> ListAllAirportsAsync()
        {
            return _repository.ListAllAirportsAsync();
        }

        #endregion Airline

        #region " City      "

        public CommandRresult CheckCity(City c)
        {
            if (c == null)
            {
                return new CommandRresult
                {
                    CommandSucceed = false,
                    Message = "Impossible to add an empty city",
                    TechnicalMessage = "Impossible to add an empty city. The city is empty",
                    ResultCode = CommandRresult.ReturnCode.ImpossibleToAddAnEmptyCity
                };
            }

            if (Guid.Empty == c.CityId)
            {
                return new CommandRresult
                {
                    CommandSucceed = false,
                    Message = "An error occured while adding the city",
                    TechnicalMessage = "An error occured while adding the city. You must specify an Id",
                    ResultCode = CommandRresult.ReturnCode.TheCityIdIsMissing
                };
            }

            if (Guid.Empty == c.CountryId)
            {
                return new CommandRresult
                {
                    CommandSucceed = false,
                    Message = "An error occured while adding the city. You must specify a country",
                    TechnicalMessage = "An error occured while adding the city. You must specify a country",
                    ResultCode = CommandRresult.ReturnCode.YouMustSpecifyTheCountryOfTheCity
                };
            }

            if (string.IsNullOrEmpty(c.Name))
            {
                return new CommandRresult
                {
                    CommandSucceed = false,
                    Message = "An error occured while adding the city. You must specify the city name",
                    TechnicalMessage = "An error occured while adding the city. You must specify the city name",
                    ResultCode = CommandRresult.ReturnCode.YouMustSpecifyTheCityName
                };
            }

            return new CommandRresult
            {
                CommandSucceed = true,
                Message = "The city has been added",
                ResultCode = CommandRresult.ReturnCode.TheCityHasBeenAdded
            };
        }

        public CommandRresult AddCity(City c)
        {
            var result = CheckCity(c);

            if (result.CommandSucceed)
                _repository.Add(c);

            return result;
        }

        public CommandRresult AddCityAsync(City c)
        {
            var result = CheckCity(c);

            if (result.CommandSucceed)
                result.AsyncResult = _repository.AddAsync(c);

            return result;
        }

        public IEnumerable<City> ListAllCities()
        {
            return _repository.ListAllCities();
        }

        public IAsyncEnumerable<City> ListAllCitiesAsync()
        {
            return _repository.ListAllCitiesAsync();
        }

        #endregion City

        #region " Country   "

        public CommandRresult CheckCountry(Country c)
        {
            if (c == null)
            {
                return new CommandRresult {
                    CommandSucceed = false,
                    Message = "Impossible to add an empty country",
                    ResultCode = CommandRresult.ReturnCode.ImpossibleToAddAnEmptyCountry
                };
            }

            if (Guid.Empty == c.CountryId)
            {
                return new CommandRresult {
                    CommandSucceed = false,
                    Message = "An error occured while adding the country",
                    ResultCode = CommandRresult.ReturnCode.TheCountryIdIsMissing
                };
            }

            if (string.IsNullOrEmpty(c.Name))
            {
                return new CommandRresult {
                    CommandSucceed = false,
                    Message = "You must specify the country name",
                    ResultCode = CommandRresult.ReturnCode.YouMustSpecifyTheCountryName
                };
            }

            return new CommandRresult {
                CommandSucceed = true,
                Message = "The country has been added",
                ResultCode = CommandRresult.ReturnCode.TheCountryHasBeenAdded
            };
        }

        public CommandRresult AddCountry(Country c)
        {
            var result = CheckCountry(c);

            if (result.CommandSucceed)
                _repository.Add(c);

            return result;
        }

        public CommandRresult AddCountryAsync(Country c)
        {
            var result = CheckCountry(c);

            if (result.CommandSucceed)
                result.AsyncResult = _repository.AddAsync(c);

            return result;
        }

        public IEnumerable<Country> ListAllCountries()
        {
            return _repository.ListAllCountries();
        }

        public IAsyncEnumerable<Country> ListAllCountriesAsync()
        {
            return _repository.ListAllCountriesAsync();
        }

        #endregion Country

        #region " Customer  "

        public CommandRresult CheckCustomer(Customer c)
        {
            if (c == null)
            {
                return new CommandRresult {
                    CommandSucceed = false,
                    Message = "Impossible to add an empty customer",
                    ResultCode = CommandRresult.ReturnCode.ImpossibleToAddAnEmptyCustomer
                };
            }

            if (Guid.Empty == c.CustomerId)
            {
                return new CommandRresult {
                    CommandSucceed = false,
                    Message = "An error occured while adding the customer",
                    ResultCode = CommandRresult.ReturnCode.TheCustomerIdIsMissing
                };
            }

            if (string.IsNullOrEmpty(c.FirstName))
            {
                return new CommandRresult {
                    CommandSucceed = false,
                    Message = "You must specify the customer firstname",
                    ResultCode = CommandRresult.ReturnCode.YouMustSpecifyTheCustomerFirstname
                };
            }

            if (string.IsNullOrEmpty(c.LastName))
            {
                return new CommandRresult {
                    CommandSucceed = false,
                    Message = "You must specify the customer lastname",
                    ResultCode = CommandRresult.ReturnCode.YouMustSpecifyTheCustomerLastname
                };
            }

            return new CommandRresult {
                CommandSucceed = true,
                Message = "The customer has been added",
                ResultCode = CommandRresult.ReturnCode.TheCustomerHasBeenAdded
            };
        }

        public CommandRresult AddCustomer(Customer c)
        {
            var result = CheckCustomer(c);

            if (result.CommandSucceed)
                _repository.Add(c);

            return result;
        }

        public CommandRresult AddCustomerAsync(Customer c)
        {
            var result = CheckCustomer(c);

            if (result.CommandSucceed)
                result.AsyncResult = _repository.AddAsync(c);

            return result;
        }

        public IEnumerable<Customer> ListAllCustomers()
        {
            return _repository.ListAllCustomers();
        }

        public IAsyncEnumerable<Customer> ListAllCustomersAsync()
        {
            return _repository.ListAllCustomersAsync();
        }

        #endregion Customer

        #region " Flight    "

        public CommandRresult CheckFlight(Flight f)
        {
            if (f == null)
            {
                return new CommandRresult {
                    CommandSucceed = false,
                    Message = "Impossible to add an empty flight",
                    ResultCode = CommandRresult.ReturnCode.ImpossibleToAddAnEmptyFlight
                };
            }

            if (Guid.Empty == f.FlightId)
            {
                return new CommandRresult {
                    CommandSucceed = false,
                    Message = "An error occured while adding the flight",
                    ResultCode = CommandRresult.ReturnCode.TheFlightIdIsMissing
                };
            }

            if (Guid.Empty == f.AirlineId)
            {
                return new CommandRresult {
                    CommandSucceed = false,
                    Message = "An error occured while adding the flight. You must specify an airline company",
                    ResultCode = CommandRresult.ReturnCode.YouMustSpecifyAnAirlineCompany
                };
            }

            if (string.IsNullOrEmpty(f.Name))
            {
                return new CommandRresult {
                    CommandSucceed = false,
                    Message = "An error occured while adding the flight. You must specify the name of the flight",
                    ResultCode = CommandRresult.ReturnCode.YouMustSpecifyTheNameOfTheFlight
                };
            }

            if (Guid.Empty == f.DepAirportId)
            {
                return new CommandRresult {
                    CommandSucceed = false,
                    Message = "An error occured while adding the flight. You must specify a departure airport",
                    ResultCode = CommandRresult.ReturnCode.YouMustSpecifyTheDepartureAirport
                };
            }

            if (f.OutboundDate < DateTime.Now)
            {
                return new CommandRresult {
                    CommandSucceed = false,
                    Message = "You must specify an outbound date greater than today",
                    ResultCode = CommandRresult.ReturnCode.YouMustSpecifyAnOutboundDateGreaterThanToday
                };
            }

            return new CommandRresult {
                CommandSucceed = true,
                Message = "The flight has been added",
                ResultCode = CommandRresult.ReturnCode.TheFlightHasBeenAdded
            };
        }

        public CommandRresult AddFlight(Flight f)
        {
            var result = CheckFlight(f);

            if (result.CommandSucceed)
                _repository.Add(f);

            return result;
        }

        public CommandRresult AddFlightAsync(Flight f)
        {
            var result = CheckFlight(f);

            if (result.CommandSucceed)
                result.AsyncResult = _repository.AddAsync(f);

            return result;
        }

        public IEnumerable<Flight> ListAllFlights()
        {
            return _repository.ListAllFlights();
        }

        public IAsyncEnumerable<Flight> ListAllFlightsAsync()
        {
            return _repository.ListAllFlightsAsync();
        }

        #endregion Flight

        #region " Travel    "

        public CommandRresult CheckTravel(Travel t)
        {
            if (t == null)
            {
                return new CommandRresult {
                    CommandSucceed = false,
                    Message = "Impossible to add an empty travel",
                    ResultCode = CommandRresult.ReturnCode.ImpossibleToAddAnEmptyTravel
                };
            }

            if (Guid.Empty == t.OutboundFlightId)
            {
                return new CommandRresult {
                    CommandSucceed = false,
                    Message = "An error occured while adding the travel. You must specify an outbound flight",
                    ResultCode = CommandRresult.ReturnCode.YouMustSpecifyAnOutboundFlight
                };
            }

            if (Guid.Empty == t.CustomerId)
            {
                return new CommandRresult {
                    CommandSucceed = false,
                    Message = "An error occured while adding the travel. You must specify a customer",
                    ResultCode = CommandRresult.ReturnCode.YouMustSpecifyACustomer
                };
            }

            if (t.OutboundDate < DateTime.Now)
            {
                return new CommandRresult {
                    CommandSucceed = false,
                    Message = "You must specify an outbound date greater than today",
                    ResultCode = CommandRresult.ReturnCode.YouMustSpecifyAnOutboundDateGreaterThanToday
                };
            }

            if (t.ReturnDate.HasValue && t.ReturnDate < DateTime.Now)
            {
                return new CommandRresult {
                    CommandSucceed = false,
                    Message = "You must specify an return date greater than today",
                    ResultCode = CommandRresult.ReturnCode.YouMustSpecifyAReturnDateGreaterThanToday
                };
            }

            if (t.ReturnDate.HasValue && t.ReturnDate < t.OutboundDate)
            {
                return new CommandRresult {
                    CommandSucceed = false,
                    Message = "You must specify an return date greater than the outbound date",
                    ResultCode = CommandRresult.ReturnCode.YouMustSpecifyAReturnDateGreaterThanTheOutboundDate
                };
            }

            return new CommandRresult {
                CommandSucceed = true,
                Message = "The travel has been added",
                ResultCode = CommandRresult.ReturnCode.TheTravelHasBeenAdded
            };
        }

        public CommandRresult AddTravel(Travel t)
        {
            var result = CheckTravel(t);

            if (result.CommandSucceed)
                _repository.Add(t);

            return result;
        }

        public Task<int> AddTravelAsync(Travel t)
        {
            var result = CheckTravel(t);

            if (result.CommandSucceed)
                result.AsyncResult = _repository.AddAsync(t);

            return result.AsyncResult;
        }

        public IEnumerable<Travel> ListAllTravels()
        {
            return _repository.ListAllTravels();
        }

        public IAsyncEnumerable<Travel> ListAllTravelsAsync()
        {
            return _repository.ListAllTravelsAsync();
        }

        #endregion Travel

        public static double GetDistanceBetweenToPoints(double lat1, double lon1, double lat2, double lon2, string unit)
        {
            var rlat1 = Math.PI * lat1 / 180;
            var rlat2 = Math.PI * lat2 / 180;
            var rlon1 = Math.PI * lon1 / 180;
            var rlon2 = Math.PI * lon2 / 180;

            var theta = lon1 - lon2;
            var rtheta = Math.PI * theta / 180;

            var dist = Math.Sin(rlat1) * Math.Sin(rlat2) + Math.Cos(rlat1) * Math.Cos(rlat2) * Math.Cos(rtheta);
            dist = Math.Acos(dist);
            dist = dist * 180 / Math.PI;
            dist = dist * 60 * 1.1515;

            if (unit == "K") { dist = dist * 1.609344; }
            if (unit == "M") { dist = dist * 1.609344 * 1000; }
            if (unit == "N") { dist = dist * 0.8684; }

            return dist;
        }
    }
}
