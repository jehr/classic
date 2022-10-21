using Domain.Models.Valoration;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Interfaces.Valoration
{
    public interface IValorationRepository
    {
        Task<Valorations> Post(Valorations request);
    }
}
