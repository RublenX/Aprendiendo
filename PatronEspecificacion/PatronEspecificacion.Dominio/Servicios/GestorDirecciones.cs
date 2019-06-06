using PatronEspecificacion.Dominio.Entidades;
using PatronEspecificacion.Dominio.Servicios.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
using PatronEspecificacion.Dominio.Contratos;
using PatronEspecificacion.Dominio.Consultas;
using PatronEspecificacion.Dominio.Consultas.PatronDdd;

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
            // Código de prueba de concepto
            var esp1 = new DireccionesPorProvinciaSpecification("Madrid");
            var esp2 = new DireccionesPorMunicipioSpecification("Madrid");
            var dirPro1 = direccionesRepository.GetDirecciones(esp1&esp2);
            //var dirPro1 = direccionesRepository.GetDirecciones(esp1&esp2);

            // Sin las especificaciones y con el arbol de expresiones
            var dirPro2 = direccionesRepository.GetDirecciones(d => d.Provincia == "Madrid" && d.Municipio == "Madrid");

            //return direccionesRepository.GetDirecciones();
            return dirPro1;
        }
    }
}
