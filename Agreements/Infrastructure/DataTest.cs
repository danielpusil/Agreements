using System.Linq;
using System.Threading.Tasks;
using Domain;
using Microsoft.AspNetCore.Identity;

namespace Infrastructure
{
    //Clase para ingresar data en la bd
    public class DataTest
    {

        public static async Task InsertData(AgreementContext context, UserManager<User> userManager){
            if(!userManager.Users.Any()){
                var user = new User{FullName = "Nuevo Usuario", UserName="nuevo123", Email = "nuevo123@correo.com"};
                await userManager.CreateAsync(user,"Password334$");
            }
        }
    }
}