using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace TuiFlightModel.Models
{
    public class Country
    {
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public Guid CountryId { get; set; }
        public string Code { get; set; }
        public string Name { get; set; }
    }
}
