using Portafolio.Models;
using SendGrid;
using SendGrid.Helpers.Mail;
using System.Net.Mail;

namespace Portafolio.Servicios
{
    public interface IServicioEmail
    {
        Task Enviar(ContactoViewModel contacto);
    }

    public class ServicioEmailSendGrid : IServicioEmail
    {
        private readonly IConfiguration conf;

        public ServicioEmailSendGrid(IConfiguration conf)
        {
            this.conf = conf;
        }

        public async Task Enviar(ContactoViewModel contacto)
        {
            //var apiKey = conf.GetValue<string>("SENDGRID_API_KEY");
            //var email = conf.GetValue<string>("SENDGRID_FROM");
            //var nombre = conf.GetValue<string>("SENDGRID_NOMBRE");

            //var cliente = new SendGridClient(apiKey);
            //var from = new EmailAddress(email, nombre);
            //var subject = $"El cliente {contacto.Email} quiere contactarte.";
            //var to = new EmailAddress(email, nombre);
            //var mensajeTextoPlano = contacto.Mensaje;

            //var contenidoHtml = @$"De: {contacto.Nombre} - Email: {contacto.Email} - Mensaje: {contacto.Mensaje}";

            //var singleEmail = MailHelper.CreateSingleEmail(from, to, subject, mensajeTextoPlano, contenidoHtml);

            //var respuesta = await cliente.SendEmailAsync(singleEmail);

            var email = conf.GetValue<string>("SENDGRID_FROM");
            var nombre = conf.GetValue<string>("SENDGRID_NOMBRE");
            var Password = conf.GetValue<string>("SENDGRID_PASSWORD");
            //quitar los espacios entre smtp y antes del com
            SmtpClient client = new SmtpClient("smtp.office365.com", 587);
            client.EnableSsl = true;
            client.UseDefaultCredentials = false;

            client.Credentials = new System.Net.NetworkCredential(email, Password);

            var from = email;
            var subject = $"El cliente {contacto.Email} quiere contactarte ";
            var to = email;
            var mensajeTextoPlano = contacto.Mensaje;
            var contenidoHtml = @$"De: {contacto.Nombre} - Email: {contacto.Email} Mensaje: {contacto.Mensaje}";
            MailMessage message = new MailMessage(from, to, subject, contenidoHtml);
            client.Send(message);
        }
    }
}
