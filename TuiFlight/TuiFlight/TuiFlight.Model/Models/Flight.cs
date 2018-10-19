using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace TuiFlightModel.Models
{
    public class Flight
    {
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public Guid FlightId { get; set; }
        public Guid AirlineId { get; set; }
        public string Name { get; set; }
        public Guid DepAirportId { get; set; }
        public Guid DesAirportId { get; set; }
        public DateTime OutboundDate { get; set; }

        public virtual Airline Airline { get; set; }
        public virtual Airport DepartureAirport { get; set; }
        public virtual Airport DestinationAirport { get; set; }
    }
}