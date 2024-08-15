using Microsoft.EntityFrameworkCore;
using Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ContractsAndDot.Services
{
    class ContractService
    {
        //1.Вывести сумму всех заключенных договоров за текущий год
        public void QuerySumAmount()
        {
            using (var context = new DataContext())
            {
                var query_sum_amount = context.Database.SqlQuery<decimal>(@$"select sum(Amount)
                                                       from contracts
                                                       where datepart(year, Contracts.DateOfSigning) = datepart(year, getDate())").ToList();
                Console.WriteLine(query_sum_amount.First());
            }
        }

        //2.Вывести сумму заключенных договоров по каждому контрагенту из России.
        public void QuerySumAmountForCounterparty()
        {
            using (var context = new DataContext())
            {
                var contracts2 = context.Database.SqlQuery<decimal>(@$"select sum(Amount), lp.CompanyName, ctr.Name
                                                        from contracts c
                                                        join LegalPersons lp
                                                        on c.CounterpartyId = lp.LegalPersonId
                                                        join Countries ctr
                                                        on lp.CountryId = ctr.CountryId
                                                        where ctr.Name = 'Россия'
                                                        group by lp.LegalPersonId, lp.CompanyName, ctr.Name
                                                        ");
                foreach (var c in contracts2)
                {
                    Console.WriteLine(c);
                }
            }
        }

        //3.Вывести список e-mail уполномоченных лиц, заключивших договора за последние 30 дней, на сумму больше 40000.
        public void QueryEmails()
        {
            using (var context = new DataContext())
            {
                var query_emails = context.Database.SqlQuery<string>(@$"select email 
                                                         from PrivatePersons pp
                                                         join Contracts c
                                                         on pp.PrivatePersonId = c.DesigneeId
                                                         where c.DateOfSigning > dateadd(day, -30, getdate())
                                                         and c.Amount > 40000
                                                         ");
                foreach (var qe in query_emails)
                {
                    Console.WriteLine(qe);
                }
            }
        }

        //4.Изменить статус договора на "Расторгнут" для физических лиц, у которых есть действующий договор, и возраст которых старше 60 лет включительно.
        public void UpdateStatus()
        {
            using (var context = new DataContext())
            {
                var status = Status.Closed;
                var query_update = context.Database.ExecuteSql(@$"update c 
                                                   set Status = {status}
                                                   from Contracts c
                                                   join PrivatePersons pp
                                                   on c.DesigneeId = pp.PrivatePersonId
                                                   where pp.Age >= 60").ToString();
                var simple_query = context.Contracts.FromSql(@$"select * from Contracts");

                foreach (var sq in simple_query)
                {
                    Console.WriteLine(sq.Status);
                }
            }
        }

        //5. Запрос для отчета
        public dynamic QueryForReport()
        {
            using (var context = new DataContext())
            {
                var status = Status.Closed;
                var query_for_ser = (from pp in context.PrivatePersons
                                     join c in context.Contracts on pp.PrivatePersonId equals c.DesigneeId
                                     join lp in context.LegalPersons on c.CounterpartyId equals lp.LegalPersonId
                                     join cit in context.Cities on lp.CityId equals cit.CityId
                                     where cit.Name == "Москва" && c.Status == status
                                     select new
                                     {
                                         pp.FirstName,
                                         pp.LastName,
                                         pp.MiddleName,
                                         pp.Email,
                                         pp.Phone,
                                         Bithday = pp.Birthday
                                     }
                    ).ToList();
                foreach (var qfs in query_for_ser)
                {
                    Console.WriteLine(@$"{qfs.FirstName} {qfs.LastName} {qfs.MiddleName} {qfs.Email} {qfs.Phone} {qfs.Bithday}");
                }
                return query_for_ser;
            }
        }
    }
}
