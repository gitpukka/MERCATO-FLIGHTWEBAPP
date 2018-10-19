using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace TuiFlightModel.Models
{
    public class City
    {
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public Guid CityId { get; set; }
        public string Name { get; set; }
        public Guid CountryId { get; set; }

        public virtual Country Country { get; set; }
    }
}
