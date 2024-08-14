using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models
{
    public class Contract
    {
        public int ContractId { get; set; }
        public int CounterpartyId { get; set; }
        public LegalPerson Counterparty { get; set; }
        public int DesigneeId { get; set; }
        public PrivatePerson Designee { get; set; }
        public decimal Amount { get; set; }
        public Status Status { get; set; }
        public DateTime DateOfSigning { get; set; }

    }
}
