using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models
{
    public class City
    {
        public int CityId { get; set; }
        public string Name { get; set; }
        public int CountryId { get; set; }
        public Country Country { get; set; }
        public ICollection<LegalPerson> LegalPersons { get; set; }
        public ICollection<PrivatePerson> PrivatePersons { get; set; }
    }
}
