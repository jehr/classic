using Application.Interfaces.Valoration;
using Application.ViewModel.Valoration;
using MediatR;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Application.CQRS.Valoration
{
    public class PostValorationCommand : IRequest<VModelValoration>
    {
        public string Document { get; set; }
        public string Hour { get; set; }
        public DateTime Date { get; set; }
    }

    public class PostValorationCommandHandler : IRequestHandler<PostValorationCommand, VModelValoration>
    {
        private readonly IValorationService _valorationService;
        public PostValorationCommandHandler(IValorationService valorationService)
        {
            _valorationService = valorationService;
        }

        public async Task<VModelValoration> Handle(PostValorationCommand request, CancellationToken cancellationToken)
        {
            return await _valorationService.Post(request, cancellationToken);
        }
    }
}
