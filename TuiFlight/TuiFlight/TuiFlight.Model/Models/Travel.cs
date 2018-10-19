using System;

namespace TuiFlightModel.Models
{
    public class Travel
    {
        public Guid OutboundFlightId { get; set; }
        public Guid CustomerId { get; set; }
        public DateTime OutboundDate { get; set; }

        public bool OneWay { get; set; }
        public Guid? ReturnFlightId { get; set; }
        public DateTime? ReturnDate { get; set; }

        public virtual Customer Traveller { get; set; }
    }
}
