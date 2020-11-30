using System;

namespace Application.Agreements
{
    //Clase que se va a enviar a el cliente
    public class AgreementDto
    {
        public Guid AgreementId {get;set;}

        public string Name {get;set;}

        public string Description{get;set;}

        public long Amount{get;set;}
    }
}