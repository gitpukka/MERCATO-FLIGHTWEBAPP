using System;

namespace TuiFlight.Business
{
    public class CommandRresult
    {
        public enum ReturnCode
        {
            Success = 0,
            // Impossible to add an empty airline company
            ImpossibleToAddAnEmptyAirlineCompany,
            // The airline company Id is missing
            TheAirlineCompanyIdIsMissing,
            // You must specify the airline company name
            YouMustSpecifyTheAirlineCompanyName,
            // The airline has been added
            TheAirlineCompanyHasBeenAdded,
            // Impossible to add an empty airport
            ImpossibleToAddAnEmptyAirport,
            // The airport Id is missing
            TheAirportIdIsMissing,
            // You must specify the airport name
            YouMustSpecifyTheAirportName,
            // The airport has been added
            TheAirportHasBeenAdded,
            // Impossible to add an empty city
            ImpossibleToAddAnEmptyCity,
            // The city Id is missing
            TheCityIdIsMissing,
            // You must specify a country of the city
            YouMustSpecifyTheCountryOfTheCity,
            // You must specify the city name
            YouMustSpecifyTheCityName,
            // The city has been added
            TheCityHasBeenAdded,
            // Impossible to add an empty country
            ImpossibleToAddAnEmptyCountry,
            // The country Id is missing
            TheCountryIdIsMissing,
            // You must specify the country name
            YouMustSpecifyTheCountryName,
            // The country has been added
            TheCountryHasBeenAdded,
            // Impossible to add an empty customer
            ImpossibleToAddAnEmptyCustomer,
            // The customer Id is missing
            TheCustomerIdIsMissing,
            // You must specify the customer firstname
            YouMustSpecifyTheCustomerFirstname,
            // You must specify the customer lastname
            YouMustSpecifyTheCustomerLastname,
            // The customer has been added
            TheCustomerHasBeenAdded,
            // Impossible to add an empty flight
            ImpossibleToAddAnEmptyFlight,
            // The flight Id is missing
            TheFlightIdIsMissing,
            // You must specify an airline company
            YouMustSpecifyAnAirlineCompany,
            // You must specify the name of the flight
            YouMustSpecifyTheNameOfTheFlight,
            // You must specify a departure airport
            YouMustSpecifyTheDepartureAirport,
            // You must specify an outbound date greater than today
            YouMustSpecifyAnOutboundDateGreaterThanToday,
            // The flight has been added
            TheFlightHasBeenAdded,
            // Impossible to add an empty travel
            ImpossibleToAddAnEmptyTravel,
            // You must specify an outbound flight
            YouMustSpecifyAnOutboundFlight,
            // You must specify a customer
            YouMustSpecifyACustomer,
            // You must specify an return date greater than today
            YouMustSpecifyAReturnDateGreaterThanToday,
            // You must specify an return date greater than the outbound date
            YouMustSpecifyAReturnDateGreaterThanTheOutboundDate,
            // The travel has been added
            TheTravelHasBeenAdded
        }

        public ReturnCode ResultCode { get; set; }
        public System.Threading.Tasks.Task<int> AsyncResult { get; set; }
        public bool CommandSucceed { get; set; }
        public string Message { get; set; }
        public string TechnicalMessage { get; set; }
        public Exception Exception { get; set; }
    }
}
