using System;
using System.Collections.Generic;
using System.Text;
using TiendaServicios.RabbitMQ.Bus.Eventos;

namespace TiendaServicios.RabbitMQ.Bus.Comandos
{
    public abstract class Comando : Message
    {
        public DateTime Timestamp { get; protected set; }

        public Comando()
        {
            Timestamp = DateTime.Now;
        }
    }
}
