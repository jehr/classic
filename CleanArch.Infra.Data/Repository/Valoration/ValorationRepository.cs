using Application.Core.Exceptions;
using CleanArch.Infra.Data.Context;
using Domain.Interfaces.Valoration;
using Domain.Models.Valoration;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Infra.Data.Repository.Valoration
{
    public class ValorationRepository : IValorationRepository
    {
        private U27ApplicationDBContext _ctx;

        public ValorationRepository(U27ApplicationDBContext ctx)
        {
            _ctx = ctx;
        }

        public async Task<Valorations> Post(Valorations request)
        {
            try
            {
                _ctx.Valorations.Add(request);
                _ctx.SaveChanges();
            }
            catch (Exception)
            {
                throw new NotFoundException("valoration", "No se ha guardado la valoración con exito");
            }

            return request;
        }
    }
}
