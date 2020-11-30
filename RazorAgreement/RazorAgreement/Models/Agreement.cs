using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RazorAgreement.Models
{
    public class Agreement
    {
        public Guid AgreementId { get; set; }

        public string Name { get; set; }

        public string Description { get; set; }

        public long Amount { get; set; }

    }
}
