namespace PatronEspecificacion.Dominio.Entidades
{
    public class DireccionEspanolaFiltro
    {
        public string Provincia { get; set; }
        public string Municipio { get; set; }
        public DireccionEspanolaFiltro Exclusion { get; set; }
    }
}
