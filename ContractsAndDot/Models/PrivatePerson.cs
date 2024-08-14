

namespace Models
{
    public class PrivatePerson
    {
        public int PrivatePersonId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string MiddleName { get; set; }
        public Gender Gender { get; set; }
        public string PlaceOfWork { get; set; }
        public int Age { get; set; }
        public int CountryId { get; set; }
        public Country Country { get; set; }
        public int CityId { get; set; }
        public City City { get; set; }
        public string Address { get; set; }
        public string Email { get; set; }
        public string Phone { get; set; }
        public DateTime Birthday { get; set; }
        public ICollection<Contract> Contracts { get; set; }
    }
}
