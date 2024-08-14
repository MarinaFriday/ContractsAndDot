using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models
{
    public class LegalPerson
    {
        public int LegalPersonId { get; set; }
        public string CompanyName { get; set; }
        public string TIN { get; set; }
        public string PSRN { get; set; }
        public int CountryId { get; set; }
        public Country Country { get; set; }
        public int CityId { get; set; }
        public City City { get; set; }
        public string Address { get; set; }
        public string Email { get; set; }
        public string Phone { get; set; }
        public ICollection<Contract> Contracts { get; set; }
    }
}
