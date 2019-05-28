using PatronEspecificacion.Dominio.Entidades;
using PatronEspecificacion.Dominio.Servicios.Interfaces;
using PatronEspecificacion.InfraestructuraDatos.Contratos;
using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;

namespace PatronEspecificacion.Dominio.Servicios
{
    public class GestorDirecciones : IGestorDirecciones
    {
        //List<DireccionEspanolaEntity> salida = new List<DireccionEspanolaEntity> {
        //    new DireccionEspanolaEntity
        //    {
        //        IdDireccion = 1, Provincia = "Madrid", Municipio = "Alcobendas", Calle = "Avenida de España"
        //    },
        //    new DireccionEspanolaEntity
        //    {
        //        IdDireccion = 2, Provincia = "Guadalajara", Municipio = "El Casar", Calle = "Calle del Cura"
        //    },
        //    new DireccionEspanolaEntity
        //    {
        //        IdDireccion = 3, Provincia = "Alicante", Municipio = "Torrevieja", Calle = "Calle Mayor"
        //    }
        //};

        private IDireccionesRepository direccionesRepository;

        public GestorDirecciones(IDireccionesRepository repo)
        {
            direccionesRepository = repo;
        }

        public string MyProperty { get; set; } = "Un valor";

        public ICollection<DireccionEspanolaEntity> ObtenerDirecciones()
        {
            return direccionesRepository.GetDirecciones().Select(d => new DireccionEspanolaEntity
            {
                IdDireccion = d.DireccionId,
                Provincia = d.Provincia,
                Municipio = d.Municipio,
                Calle = d.Calle
            }).ToList();
        }
    }
}
