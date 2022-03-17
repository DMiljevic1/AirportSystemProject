using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DomainModel.Models
{
    public class Passenger
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Sex { get; set; }
        public int? FlightId { get; set; }
        public Flight Flight { get; set; }
        public string Seat { get; set; }
        public bool IsChecked { get; set; }
        public int NumberOfLuggage { get; set; }
        public double LuggageWeight { get; set; }
        public string FullNameOnDocument { get; set; }
        public string TypeOfDocument { get; set; }
        public int NumberOfDocument { get; set; }
        public DateTime ExpireDate { get; set; }
    }
}
