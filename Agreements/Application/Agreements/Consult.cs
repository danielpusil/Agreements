using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using Domain;
using Infrastructure;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Application.Agreements
{
    public class Consult
    {
        public class AgreementList: IRequest<List<AgreementDto>>{}

        public class Handler : IRequestHandler<AgreementList, List<AgreementDto>>
        {
            //Manejador que utiliza el contexto para consultar a la capa de infraestructura mediante MediatR
            //Esta clase maneja dos clases, una clase para consultar los datos y otra para manejar la logica
            private readonly AgreementContext _context;
            private readonly IMapper _mapper;
            public Handler(AgreementContext context, IMapper mapper){
                _context = context;
                _mapper = mapper;
            }
            public async Task<List<AgreementDto>> Handle(AgreementList request, CancellationToken cancellationToken)
            {
                var agreements = await _context.Agreement.ToListAsync();
                //Se hace el mapeo de agrements a AgreementDto
                var AgreementsDto = _mapper.Map<List<Agreement>, List<AgreementDto>>(agreements);
                return AgreementsDto;
            }
        }
    }
}