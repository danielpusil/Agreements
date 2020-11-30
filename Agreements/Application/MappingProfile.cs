using Application.Agreements;
using AutoMapper;
using Domain;

namespace Application
{
    //Clase que se encarga de hacer el mapeo entre las entidades y los Dtos
    public class MappingProfile : Profile
    {
        public MappingProfile(){
            CreateMap<Agreement, AgreementDto>();
        }
    }
}