using Application.CQRS.Valoration;
using Application.ViewModel.Valoration;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Application.Interfaces.Valoration
{
    public interface IValorationService
    {
        Task<VModelValoration> Post(PostValorationCommand command, CancellationToken cancellationToken);
    }
}
