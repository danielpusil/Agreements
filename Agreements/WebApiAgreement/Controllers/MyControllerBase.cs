using MediatR;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.DependencyInjection;

namespace WebApiAgreement.Controllers
{
    //Clase base para todos los controladores
    [Route("api/[controller]")]
    [ApiController]
    public class MyControllerBase:ControllerBase 
    {
        private IMediator _mediator;

        protected IMediator Mediator => _mediator ?? (_mediator = HttpContext.RequestServices.GetService<IMediator>());
        
    }
}