using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace TuiFlightModel.Models
{
    public class Airport
    {
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public Guid AirportId { get; set; }
        public string Name { get; set; }
        public Guid CityId { get; set; }
        public string Iata { get; set; }
        public double Latitude { get; set; }
        public double Longitude { get; set; }
        public string CountryCode { get; set; }

        public virtual City City { get; set; }
        public virtual System.Collections.Generic.ICollection<Flight> FlightsFrom { get; set; }
        public virtual System.Collections.Generic.ICollection<Flight> FlightsOnArrival { get; set; }

        public Airport()
        {
            AirportId = Guid.NewGuid();
        }
    }
}