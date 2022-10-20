using Application.Interfaces.Payment;
using Application.ViewModel.Payment;
using Domain.Interfaces.Payment;
using Domain.Interfaces.User;
using Domain.Models.Payment;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Services.Payment
{
    public class PaymentService : IPaymentService
    {
        private readonly IPaymentRepository _paymentRepository;
        private readonly IUserRepository _userRepository;

        public PaymentService(IPaymentRepository paymentRepository, IUserRepository userRepository)
        {
            _paymentRepository = paymentRepository;
            _userRepository = userRepository;
        }

        public async Task<VModelResponsePayment> Payment(string document)
        {
            var user = await _userRepository.Get().Where(x => x.Document == document).FirstOrDefaultAsync();

            var rpta = new VModelResponsePayment();

            if (user == null)
            {
                rpta.Message = "El usuario con el documento " + document + " no se ha encontrado, comuniquese con el administrador.";
                rpta.Code = "200";
                rpta.Status = true;

                return rpta;
            }

            // Inserta el pago
            var payment = new Payments()
            {
                UserId = user.Id,
                DatePayment = DateTime.Today,
                NextDatePayment = DateTime.Today.AddDays(+30)
            };

            try
            {
                var rptaPayment = await _paymentRepository.Post(payment);

                if (rptaPayment != null)
                {
                    rpta.Message = "Se ha realizado el pago con exito, la proxima fecha del pago es el " + payment.NextDatePayment;
                    rpta.Code = "200";
                    rpta.Status = true;
                }
            }
            catch (Exception ex)
            {
                rpta.Message = ex.Message;
                rpta.Code = "500";
                rpta.Status = false;
            }

            return rpta;
        }
    }
}
