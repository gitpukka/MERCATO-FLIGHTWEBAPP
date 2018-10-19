using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace TuiFlightModel.Models
{
    public class Airline
    {
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public Guid AirlineId { get; set; }
        public string Name { get; set; }
    }
}