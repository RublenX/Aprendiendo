﻿using SendGrid;
using SendGrid.Helpers.Mail;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using TiendaServicios.Mensajeria.Email.SendGridLibreria.Interface;
using TiendaServicios.Mensajeria.Email.SendGridLibreria.Modelo;

namespace TiendaServicios.Mensajeria.Email.SendGridLibreria.Implement
{
    public class SendGridEnviar : ISendGridEnviar
    {
        public async Task<(bool resultado, string errorMessage)> EnviarEmail(SendGridData data)
        {
            try
            {
                var sendGridCliente = new SendGridClient(data.SendGridAPIKey);
                var destinatario = new EmailAddress(data.EmailDestinatario, data.NombreDestinatario);
                var tituloEmail = data.Titulo;
                var sender = new EmailAddress("vaxi.drez@gmail.com", "Vaxi Drez");
                var contenidoMensaje = data.Contenido;

                var objMensaje = MailHelper.CreateSingleEmail(sender, destinatario, tituloEmail, contenidoMensaje, contenidoMensaje);

                var resultado = await sendGridCliente.SendEmailAsync(objMensaje);

                return (true, null);
            }
            catch (Exception ex)
            {
                return (false, ex.Message);
            }
        }
    }
}
