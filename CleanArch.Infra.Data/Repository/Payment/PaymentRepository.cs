using Application.Core.Exceptions;
using CleanArch.Infra.Data.Context;
using Domain.Interfaces.Payment;
using Domain.Models.Payment;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Infra.Data.Repository.Payment
{
    public class PaymentRepository : IPaymentRepository
    {
        private U27ApplicationDBContext _ctx;

        public PaymentRepository(U27ApplicationDBContext ctx)
        {
            _ctx = ctx;
        }

        public async Task<Payments> Post(Payments payment)
        {
            try
            {
                _ctx.Payments.Add(payment);
                _ctx.SaveChanges();
            }
            catch (Exception)
            {
                throw new NotFoundException("payment", "Elpago no pudo ser  realizado");
            }

            return payment;
        }
    }
}
