using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Application.Agreements;
using Domain;
using Infrastructure;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace WebApiAgreement.Controllers
{
    //Controlador para Agreements
    [ApiController]
    [Route("api/[controller]")]
    public class AgreementController:MyControllerBase
    {

        [HttpGet]
        public async Task<ActionResult<List<AgreementDto>>> Get()
        {
            //metodo para consultar la lista de Agreements
            return await Mediator.Send(new Consult.AgreementList());
        }

        [HttpPost]
        public async Task<ActionResult<Unit>> Post(){
            return await Mediator.Send(new NewAgreement.runNewAgreement());
        }
        
    }
}