using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using TuiFlightModel.Models;

namespace TuiFlight.View.ViewModel
{
    public class SearchViewModel
    {
        public IEnumerable<Airport> Airports { get; set; }

        [Display(Name = "A/R")]
        public bool OneWay { get; set; }

        [Display(Name = "Outbound")]
        public DateTime OutboundDate { get; set; }

        [Display(Name = "Return")]
        public DateTime? ReturnDate { get; set; }

        [Display(Name = "From")]
        public Guid AirportFromId { get; set; }

        [Display(Name = "To")]
        public Guid AirportToId { get; set; }

        [Display(Name = "First Name")]
        public string TravellerFirstName { get; set; }

        [Display(Name = "Last Name")]
        public string TravellerLastName { get; set; }

        public bool DisplaySearchResult { get; set; }

        public IEnumerable<Flight> Flights { get; set; }

        public SearchViewModel() : this(new List<Airport> ())
        {
        }

        public SearchViewModel(IEnumerable<Airport> airports)
        {
            AirportFromId = new Guid();
            AirportToId = new Guid();
            OutboundDate = DateTime.Now;
            Airports = airports;
        }
    }
}