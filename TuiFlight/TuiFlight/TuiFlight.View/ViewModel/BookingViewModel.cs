using System;
using System.ComponentModel.DataAnnotations;

namespace TuiFlight.View.ViewModel
{
    public class BookingViewModel
    {
        public Guid FlightId { get; set; }

        [Display(Name = "Flight")]
        public string FlightName { get; set; }

        [Display(Name = "Outbound"), 
            DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:MM/dd/yyyy}")]
        public DateTime OutboundDate { get; set; }

        [Display(Name = "Outbound"),
            DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:MM/dd/yyyy}")]
        public DateTime ArrivalDate { get => OutboundDate.AddDays(2); }

        [Display(Name = "From")]
        public string AirportFrom { get; set; }

        [Display(Name = "To")]
        public string AirportTo { get; set; }

        [Display(Name = "First Name")]
        public string TravellerFirstName { get; set; }

        [Display(Name = "Last Name")]
        public string TravellerLastName { get; set; }

        public bool OneWay { get => true; }
    }
}
