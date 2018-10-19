using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using TuiFlight.Business;
using TuiFlight.DataAccess;
using TuiFlight.View.Models;
using TuiFlight.View.ViewModel;
using TuiFlightModel.Models;

namespace TuiFlight.View.Controllers
{
    public class HomeController : Controller
    {
        private readonly IRepository _repository;

        public HomeController(IRepository repository)
        {
            _repository = repository;
        }

        public IActionResult Index()
        {
            var service = new DataBusiness(_repository);
            var model = new SearchViewModel(service.ListAllAirports())
            {
                DisplaySearchResult = true,
                Flights = service.ListAllFlights()
            };

            return View(model);
        }

        // POST: Travel/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Index([Bind("AirportFromId,CustomerId,OutboundDate,OneWay,AirportToId,ReturnDate")] SearchViewModel travel)
        {
            if (ModelState.IsValid)
            {
                var service = new DataBusiness(_repository);
                var flights = await service.ListAllFlightsAsync().ToList();

                travel.DisplaySearchResult = true;
                travel.Airports = service.ListAllAirports();
                travel.Flights = flights.Where(f =>
                    f.DepartureAirport.AirportId == travel.AirportFromId &&
                    f.DestinationAirport.AirportId == travel.AirportToId);

                //return RedirectToAction(nameof(Book), travel);
                return View(travel);
            }

            return View(travel);
        }

        public IActionResult Book(Guid id)
        {
            var service = new DataBusiness(_repository);
            var flight = service.ListAllFlights().FirstOrDefault(f => f.FlightId == id);

            var model = new BookingViewModel
            {
                FlightId = flight.FlightId,
                FlightName = flight.Name,
                OutboundDate = flight.OutboundDate,
                AirportFrom = flight.DepartureAirport.Name,
                AirportTo = flight.DestinationAirport.Name,
            };

            return View(model);
        }

        // POST: Travel/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Book([Bind("FlightId,FlightName,OutboundDate,ArrivalDate,AirportFrom,AirportTo,TravellerFirstName,TravellerLastName,OneWay")] BookingViewModel book)
        {
            if (ModelState.IsValid)
            {
                var service = new DataBusiness(_repository);

                var customer = new Customer {
                    CustomerId = Guid.NewGuid(),
                    CityId = service.ListAllCities().FirstOrDefault().CityId,
                    FirstName = book.TravellerFirstName,
                    LastName = book.TravellerLastName,
                };

                var result = service.AddCustomer(customer);
                var travel = new Travel {
                    OutboundFlightId = book.FlightId,
                    CustomerId = customer.CustomerId,
                    OutboundDate = book.OutboundDate,
                    OneWay = true,

                    Traveller = customer
                };

                await service.AddTravelAsync(travel);

                return RedirectToAction(nameof(Index), "Travel", travel);
            }

            return View(book);
        }

        public IActionResult About()
        {
            ViewData["Message"] = "Your application description page.";

            return View();
        }

        public IActionResult Contact()
        {
            ViewData["Message"] = "Your contact page.";

            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
