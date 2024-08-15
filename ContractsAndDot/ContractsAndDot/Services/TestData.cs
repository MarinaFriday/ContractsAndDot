using Models;


namespace ContractsAndDot.Services
{
    internal class TestData
    {
        void AddedData()
        {
            using (var context = new DataContext())
            {
                var countries = new List<Country> {
                    new Country { Name = "Россия"},
                    new Country { Name = "Англия"},
                    new Country { Name = "Франция"}
                };
                foreach (var country in countries)
                {
                    context.Countries.Add(country);
                }
                context.SaveChanges();

                var cities = new List<City> {
                    new City { Name = "Москва", Country = context.Countries.First(c => c.Name == "Россия")},
                    new City { Name = "Самара", Country = context.Countries.First(c => c.Name == "Россия")},
                    new City { Name = "Лондон", Country = context.Countries.First(c => c.Name == "Англия")},
                    new City { Name = "Оксфорд", Country = context.Countries.First(c => c.Name == "Англия")},
                    new City { Name = "Париж", Country = context.Countries.First(c => c.Name == "Франция")},
                    new City { Name = "Тулуза", Country = context.Countries.First(c => c.Name == "Франция")},
                };
                foreach (var city in cities)
                {
                    context.Cities.Add(city);
                }
                context.SaveChanges();

                var privatePersons = new List<PrivatePerson> {
                new PrivatePerson { FirstName = "Иванов",
                                LastName = "Иван",
                                MiddleName = "Иванович",
                                Gender = Gender.Male,
                                PlaceOfWork = "Завод1",
                                Age = 61,
                                Country = context.Countries.First(c => c.Name == "Россия"),
                                City = context.Cities.First(c => c.Name == "Москва"),
                                Address = "г. Москва, ул. Выдуманная, д. 1, кв. 1",
                                Email = "ivanov@list.ru",
                                Phone = "+79371111111",
                                Birthday = new DateTime (1963,8,1)
                },
                new PrivatePerson { FirstName = "Петров",
                                LastName = "Петр",
                                MiddleName = "Петрович",
                                Gender = Gender.Male,
                                PlaceOfWork = "Завод2",
                                Age = 39,
                                Country = context.Countries.First(c => c.Name == "Россия"),
                                City = context.Cities.First(c => c.Name == "Москва"),
                                Address = "г. Москва, ул. Придуманная, д. 1, кв. 1",
                                Email = "petrov@list.ru",
                                Phone = "+79371111112",
                                Birthday = new DateTime (1985,8,1)
                },
                new PrivatePerson { FirstName = "Кириллов",
                                LastName = "Кирилл",
                                MiddleName = "Кириллович",
                                Gender = Gender.Male,
                                PlaceOfWork = "Завод3",
                                Age = 28,
                                Country = context.Countries.First(c => c.Name == "Россия"),
                                City = context.Cities.First(c => c.Name == "Самара"),
                                Address = "г. Самара, ул. Вольская, д. 1, кв. 1",
                                Phone = "+79371111113",
                                Email = "kirillov@list.ru",
                                Birthday = new DateTime (1995,9,2)
                },
                new PrivatePerson { FirstName = "Сидоров",
                                LastName = "Сидр",
                                MiddleName = "Сидорович",
                                Gender = Gender.Male,
                                PlaceOfWork = "Завод4",
                                Age = 44,
                                Country = context.Countries.First(c => c.Name == "Россия"),
                                City = context.Cities.First(c => c.Name == "Самара"),
                                Address = "г. Самара, ул. Тополей, д. 1, кв. 1",
                                Email = "sidorov@list.ru",
                                Phone = "+79371111114",
                                Birthday = new DateTime (1980,8,1)
                },
                new PrivatePerson { FirstName = "Ivanov",
                                LastName = "Ivan",
                                MiddleName = "Ivanovich",
                                Gender = Gender.Male,
                                PlaceOfWork = "Zavod1",
                                Age = 62,
                                Country = context.Countries.First(c => c.Name == "Англия"),
                                City = context.Cities.First(c => c.Name == "Лондон"),
                                Address = "г. Лондон, ул. Выдуманная, д. 1, кв. 1",
                                Email = "ivanov_english_man@list.ru",
                                Phone = "+79371111115",
                                Birthday = new DateTime (1962,8,1)
                },
                new PrivatePerson { FirstName = "Petrova",
                                LastName = "Helga",
                                MiddleName = "Petrovna",
                                Gender = Gender.Female,
                                PlaceOfWork = "Zavod43",
                                Age = 48,
                                Country = context.Countries.First(c => c.Name == "Англия"),
                                City = context.Cities.First(c => c.Name == "Оксфорд"),
                                Address = "г. Оксфорд, ул. Придуманная, д. 1, кв. 1",
                                Email = "petrova_helga@list.ru",
                                Phone = "+79371111116",
                                Birthday = new DateTime (1976,8,1)
                },
                new PrivatePerson { FirstName = "Kruasanova",
                                LastName = "Zaza",
                                MiddleName = "Olegovna",
                                Gender = Gender.Female,
                                PlaceOfWork = "Zavod34",
                                Age = 36,
                                Country = context.Countries.First(c => c.Name == "Франция"),
                                City = context.Cities.First(c => c.Name == "Париж"),
                                Address = "г. Париж, ул. Придуманная, д. 1, кв. 1",
                                Email = "kruasanova@list.ru",
                                Phone = "+79371111117",
                                Birthday = new DateTime (1988,8,1)
                },
                new PrivatePerson { FirstName = "Kruasanova",
                                LastName = "Maria",
                                MiddleName = "Olegovna",
                                Gender = Gender.Female,
                                PlaceOfWork = "Zavod6589",
                                Age = 36,
                                Country = context.Countries.First(c => c.Name == "Франция"),
                                City = context.Cities.First(c => c.Name == "Тулуза"),
                                Address = "г. Тулуза, ул. Выдуманная, д. 1, кв. 1",
                                Email = "kruasanova_m@list.ru",
                                Phone = "+79371111118",
                                Birthday = new DateTime (1988,8,1)
                }
                };
                foreach (var pPerson in privatePersons)
                {
                    context.PrivatePersons.Add(pPerson);
                }
                context.SaveChanges();

                var legalPersons = new List<LegalPerson>()
        {
            new LegalPerson { CompanyName = "CompanyName1",
                              TIN = "1111111111",
                              PSRN = "222222222222222",
                              Country = context.Countries.First(c => c.Name == "Россия"),
                              City = context.Cities.First(c => c.Name == "Москва"),
                              Address = "Адрес1",
                              Email = "сompanyName1@gmail.com",
                              Phone = "+79471111111"
            },
            new LegalPerson { CompanyName = "CompanyName2",
                              TIN = "2222222222",
                              PSRN = "333333333333333",
                              Country = context.Countries.First(c => c.Name == "Россия"),
                              City = context.Cities.First(c => c.Name == "Самара"),
                              Address = "Адрес6",
                              Email = "сompanyName2@gmail.com",
                              Phone = "+79471111125"
            },
            new LegalPerson { CompanyName = "CompanyName3",
                              TIN = "3333333333",
                              PSRN = "444444444444444",
                              Country = context.Countries.First(c => c.Name == "Англия"),
                              City = context.Cities.First(c => c.Name == "Лондон"),
                              Address = "Адрес98",
                              Email = "сompanyName3@gmail.com",
                              Phone = "+79471115125"
            },
            new LegalPerson { CompanyName = "CompanyName4",
                              TIN = "4444444444",
                              PSRN = "555555555555555",
                              Country = context.Countries.First(c => c.Name == "Англия"),
                              City = context.Cities.First(c => c.Name == "Оксфорд"),
                              Address = "Адрес198",
                              Email = "сompanyName4@gmail.com",
                              Phone = "+79475915125"
            },
            new LegalPerson { CompanyName = "CompanyName5",
                              TIN = "5555555555",
                              PSRN = "666666666666666",
                              Country = context.Countries.First(c => c.Name == "Франция"),
                              City = context.Cities.First(c => c.Name == "Париж"),
                              Address = "Адрес478",
                              Email = "сompanyName5@gmail.com",
                              Phone = "+79475425125"
            },
            new LegalPerson { CompanyName = "CompanyName6",
                              TIN = "6666666666",
                              PSRN = "777777777777777",
                              Country = context.Countries.First(c => c.Name == "Франция"),
                              City = context.Cities.First(c => c.Name == "Тулуза"),
                              Address = "Адрес987",
                              Email = "сompanyName6@gmail.com",
                              Phone = "+79478525125"
            },
        };
                foreach (var lPerson in legalPersons)
                {
                    context.LegalPersons.Add(lPerson);
                }
                context.SaveChanges();

                var contracts = new List<Contract>() {
            new Contract {
                    Counterparty = context.LegalPersons.First(c => c.Country.Name == "Россия" && c.City.Name == "Москва"),
                    Designee = context.PrivatePersons.First(d => d.Country.Name == "Англия"),
                    Amount = 4500000,
                    Status = Status.InWork,
                    DateOfSigning = new DateTime(2024,8,10)
            },
            new Contract {
                    Counterparty = context.LegalPersons.First(c => c.Country.Name == "Россия" && c.City.Name == "Самара"),
                    Designee = context.PrivatePersons.First(d => d.Age > 60),
                    Amount = 39000,
                    Status = Status.InWork,
                    DateOfSigning = new DateTime(2024,6,12)
            },
        };
                foreach (var contract in contracts)
                {
                    context.Contracts.Add(contract);
                }
                context.SaveChanges();
            }
        }
    }
}
