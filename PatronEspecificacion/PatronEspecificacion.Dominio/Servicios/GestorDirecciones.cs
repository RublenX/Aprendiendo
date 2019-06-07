using PatronEspecificacion.Dominio.Entidades;
using PatronEspecificacion.Dominio.Servicios.Interfaces;
using System.Collections.Generic;
using PatronEspecificacion.Dominio.Contratos;
using PatronEspecificacion.Dominio.Consultas;

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
            // Sin las especificaciones y con el arbol de expresiones
            var dirExp = direccionesRepository.GetDirecciones(d => d.Provincia == "Madrid" && d.Municipio == "Madrid");

            // Consulta por la implementación básica, no admite combinaciones
            var espBas = new DireccionesPorProvinciaSpecificationBasico("Madrid");
            var dirBas = direccionesRepository.GetDireccionesBasico(espBas);

            // Combinación de consultas por la implementación según Wikipedia
            var espWiki1 = new DireccionesPorProvinciaSpecificationWiki("Madrid");
            var espWiki2 = new DireccionesPorMunicipioSpecificationWiki("Madrid");
            var dirWiki = direccionesRepository.GetDireccionesWiki(espWiki1.And(espWiki2));

            // Combinación de consultas por la implementación del proyecto DDD
            var espDdd1 = new DireccionesPorProvinciaSpecificationDdd("Madrid");
            var espddd2 = new DireccionesPorMunicipioSpecificationDdd("Madrid");
            var dirDdd = direccionesRepository.GetDireccionesDdd(espDdd1 & espddd2);

            // Uniendo las especificaciones en una compleja
            DireccionEspanolaFiltro filtro = new DireccionEspanolaFiltro { Provincia = "Madrid", Municipio = "Madrid" };
            var espddd3 = new DireccionesFiltradasSpecificationDdd(filtro);
            var dirComplex = direccionesRepository.GetDireccionesDdd(espddd3);
            // Ahora excluyamos a Madrid capital
            filtro = new DireccionEspanolaFiltro
            {
                Provincia = "Madrid",
                Exclusion = new DireccionEspanolaFiltro() { Municipio = "Madrid"}
            };
            var espddd4 = new DireccionesFiltradasSpecificationDdd(filtro);
            var dirExclus = direccionesRepository.GetDireccionesDdd(espddd4);

            return dirExclus;
        }
    }
}
