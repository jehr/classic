using Domain.Models.Payment;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Interfaces.Payment
{
    public interface IPaymentRepository
    {
        Task<Payments> Post(Payments payment);
    }
}
