using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models
{
    public class Country
    {
        public int CountryId { get; set; }
        public string Name { get; set; }
        public ICollection<City> Cities { get; set; }
        public ICollection<LegalPerson> LegalPersons { get; set; }
        public ICollection<PrivatePerson> PrivatePersons { get; set; }
    }
}
