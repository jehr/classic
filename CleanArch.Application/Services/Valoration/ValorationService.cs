using Application.Core.Exceptions;
using Application.CQRS.Valoration;
using Application.Interfaces.Valoration;
using Application.ViewModel.Valoration;
using AutoMapper;
using Domain.Interfaces.User;
using Domain.Interfaces.Valoration;
using Domain.Models.Valoration;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Net.Mime;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Application.Services.Valoration
{
    public class ValorationService : IValorationService
    {
        private readonly IValorationRepository _valorationRepository;
        private readonly IUserRepository _userRepository;
        private readonly IMapper _mapper;
        public ValorationService(IValorationRepository valorationRepository, IMapper mapper, IUserRepository userRepository)
        {
            _valorationRepository = valorationRepository;
            _mapper = mapper;
            _userRepository = userRepository;
        }

        public async Task<VModelValoration> Post(PostValorationCommand command, CancellationToken cancellationToken)
        {
            Valorations citedValoration;

            try
            {
                var user = await _userRepository.Get().Where(x => x.Document == command.Document).FirstOrDefaultAsync();

                if (user == null)
                {
                    return new VModelValoration()
                    {
                        Code = "200",
                        Message = "El usuario no existe",
                        Status = true
                    };
                }

                var valoration = new Valorations()
                {
                    UserId = user.Id,
                    Hour = command.Hour,
                    DateValoration = command.Date,
                    Status = true
                };

               citedValoration = await _valorationRepository.Post(valoration);
                // Envio de correo electronico
                await SendEmailCodeRecoveryPassWord(user.Email, user.Names, valoration.DateValoration.ToString("yyyy-MM-dd"), valoration.Hour);
            }
            catch (Exception ex)
            {
                throw new NotFoundException("valoration", ex.Message);
            }
            
            return new VModelValoration()
            {
                Code = "200",
                Message = "Se ha guardado la cita de valoración exito",
                Status = true,
                Valoration = citedValoration
            };
        }

        public async Task<bool> SendEmailCodeRecoveryPassWord(string email, string names, string date, string hour)
        {

            _Correo correo = new _Correo()
            {
                ServerName = "smtp.gmail.com",
                Port = "587",
                SenderEmailId = "gym.classic2022@gmail.com",
                SenderPassword = "qxsrdcjewhllcyqc",
                IMG = "Resources/PublicFiles/Images/classic.jpeg",
            };

            try
            {
                var smtpServerName = correo.ServerName;
                var port = correo.Port;
                var senderEmailId = correo.SenderEmailId;
                var senderPassword = correo.SenderPassword;

                MailMessage mail = new MailMessage();
                mail.From = new System.Net.Mail.MailAddress(correo.SenderEmailId);
                mail.Subject = "Classic GYM";
                // The important part -- configuring the SMTP client
                SmtpClient smtp = new SmtpClient();
                smtp.Port = Int32.Parse(port);   // [1] You can try with 465 also, I always used 587 and got success
                smtp.EnableSsl = true;
                smtp.DeliveryMethod = SmtpDeliveryMethod.Network; // [2] Added this
                smtp.UseDefaultCredentials = false; // [3] Changed this
                smtp.Credentials = new NetworkCredential(senderEmailId, senderPassword);  // [4] Added this. Note, first parameter is NOT string.
                smtp.Host = smtpServerName;
                ServicePointManager.SecurityProtocol = SecurityProtocolType.Tls12;


                //recipient address . el problema es el correo electronico.
                mail.To.Add(new MailAddress(email));

                string request = "Has solicitado tu cita de valoración la cual fue agendada para el día " + date + " a las " + hour + " horas";
                string enunciado2 = "Recuerda asistir con ropa comoda";
                string grax = "Muchas gracias por utilizar nuestros servicios y recuerda no dejes para mañana lo que puedes hacer hoy!";
                string team = "El Equipo de Classic GYM";

                string html = "<p>"
                                    + "Hola " + "<b>" + names + "</b>" + ","
                                    + "<br>" + "<br>"
                                    + request
                                    + "<br>"
                                    + "<br>"
                                    + enunciado2
                                    + "<br>"
                                    + grax
                                    + "<br>"
                                    + "<br>"
                                    + "<b>" + team + "</b>" +
                             "</p>" +
                              "<img src='cid:imagen' width='280' height='220' />";

                AlternateView htmlView =
                    AlternateView.CreateAlternateViewFromString(html,
                                            Encoding.UTF8,
                                            MediaTypeNames.Text.Html);
                var path = Path.GetDirectoryName(Process.GetCurrentProcess().MainModule.FileName);

                var logoimage = Path.Combine(Directory.GetCurrentDirectory(), correo.IMG);

                string relLogo = new Uri(logoimage).LocalPath;

                LinkedResource img = new LinkedResource(relLogo, MediaTypeNames.Image.Jpeg);
                img.ContentId = "imagen";

                htmlView.LinkedResources.Add(img);
                mail.AlternateViews.Add(htmlView);

                smtp.Send(mail);
            }
            catch (Exception ex)
            {
                Console.WriteLine("Exception caught in CreateTimeoutTestMessage(): {0}", ex.ToString());
            }

            return true;
        }

        public class _Correo
        {
            public string ServerName { get; set; }
            public string Port { get; set; }
            public string SenderEmailId { get; set; }
            public string SenderPassword { get; set; }
            public string IMG { get; set; }
        }
    }
}
