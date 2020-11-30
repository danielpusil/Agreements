using System.Threading.Tasks;
using Application.Security;
using Domain;
using Microsoft.AspNetCore.Mvc;

namespace WebApiAgreement.Controllers
{
    public class UserController:MyControllerBase
    {
        [HttpPost("login")]
        public async Task<ActionResult<UserData>> Login(Login.runLogin parameters){
            return await Mediator.Send(parameters);
        }
    }
}