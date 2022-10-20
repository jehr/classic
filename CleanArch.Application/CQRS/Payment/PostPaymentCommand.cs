
using Application.Interfaces.Payment;
using Application.ViewModel.Payment;
using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace Application.CQRS.Payment
{
    public class PostPaymentCommand : IRequest<VModelResponsePayment>
    {
        public string Document { get; set; }
    }

    public class PostPaymentCommandHandler : IRequestHandler<PostPaymentCommand, VModelResponsePayment>
    {
        private readonly IPaymentService _paymentService;

        public PostPaymentCommandHandler(IPaymentService paymentService)
        {
            _paymentService = paymentService;
        }

        public async Task<VModelResponsePayment> Handle(PostPaymentCommand request, CancellationToken cancellationToken)
        {
            return await _paymentService.Payment(request.Document);
        }
    }
}
