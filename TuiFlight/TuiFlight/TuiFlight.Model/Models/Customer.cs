using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace TuiFlightModel.Models
{
    public class Customer
    {
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public Guid CustomerId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public Guid CityId { get; set; }

        public virtual City City{ get; set; }
        public virtual System.Collections.Generic.ICollection<Travel> Travels { get; set; }
    }
}