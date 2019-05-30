using PatronEspecificacion.Dominio.Entidades;
using PatronEspecificacion.Dominio.Servicios.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
using PatronEspecificacion.Dominio.Contratos;

namespace PatronEspecificacion.Dominio.Servicios
{
    public class GestorDirecciones : IGestorDirecciones
    {
        private IDireccionesRepository direccionesRepository;

        public GestorDirecciones(IDireccionesRepository repo)
        {
            direccionesRepository = repo;
        }

        public string MyProperty { get; set; } = "Un valor";

        public ICollection<DireccionEspanolaEntity> ObtenerDirecciones()
        {
            return direccionesRepository.GetDirecciones();
        }
    }
}
