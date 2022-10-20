using Application.ViewModel.Payment;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Application.Interfaces.Payment
{
    public interface IPaymentService
    {
        Task<VModelResponsePayment> Payment(string document);
    }
}
