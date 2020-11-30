using System.Threading;
using System.Threading.Tasks;
using Domain;
using FluentValidation;
using MediatR;
using Microsoft.AspNetCore.Identity;

namespace Application.Security
{
    public class Login
    {
        //La clase que va utilizar el manejador para realizar el login
        public class runLogin:IRequest<UserData>{
            public string Email{get;set;}
            public string Password{get;set;}

        }
        public class runValidation: AbstractValidator<runLogin>{
            public runValidation(){
                RuleFor(x=>x.Email).NotEmpty();
                RuleFor(x=>x.Password).NotEmpty();
            }
        }
        public class Handler : IRequestHandler<runLogin, UserData>
        {
            private readonly UserManager<User> _userManager;
            private readonly SignInManager<User> _signInManager;
            public Handler(UserManager<User> userManager,SignInManager<User> signInManager){
                _userManager = userManager;
                _signInManager = signInManager;
            }
            public async Task<UserData> Handle(runLogin request, CancellationToken cancellationToken)
            {
                //Busca el Email en la base de datos
                var user = await _userManager.FindByEmailAsync(request.Email);
                if(user == null){
                    throw new System.ArgumentException("Not Authorized");
                }
                var result = await _signInManager.CheckPasswordSignInAsync(user, request.Password, false);
                if(result.Succeeded){
                    return new UserData{
                        FullName = user.FullName,
                        Token = "logica de token",
                        UserName = user.UserName,
                        Email = user.Email
                    };
                }
                throw new System.ArgumentException("Not Authorized");

            }
        }
    }
}