using System;
using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using Domain;
using Infrastructure;
using MediatR;

namespace Application.Agreements
{
    public class NewAgreement
    {
        //Se agrega un nuevo agreement
        public class runNewAgreement:IRequest {
           
            public string Name {get;set;}

            public string Description{get;set;}

            public long Amount{get;set;}
        }

        public class Handler : IRequestHandler<runNewAgreement>
        {
            private readonly AgreementContext _context;
            private readonly IMapper _mapper;
            public Handler(AgreementContext context, IMapper mapper){
                    _context = context;
                    _mapper = mapper;
            }
            public async Task<Unit> Handle(runNewAgreement request, CancellationToken cancellationToken)
            {
                var agreement = new Agreement{
                    Name = request.Name,
                    Description = request.Description,
                    Amount= request.Amount
                };

                _context.Agreement.Add(agreement);
                var value = await _context.SaveChangesAsync();
                if(value>0){
                    return Unit.Value;
                }
                throw new Exception("No se pudo insertar el curso");
            }
        }

    }
}