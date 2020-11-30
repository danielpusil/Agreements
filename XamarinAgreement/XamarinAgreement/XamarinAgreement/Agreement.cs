using System;
using System.Collections.Generic;
using System.Text;

namespace XamarinAgreement
{
    class Agreement
    {
        public Guid AgreementId { get; set; }

        public string Name { get; set; }

        public string Description { get; set; }

        public long Amount { get; set; }
    }
}
