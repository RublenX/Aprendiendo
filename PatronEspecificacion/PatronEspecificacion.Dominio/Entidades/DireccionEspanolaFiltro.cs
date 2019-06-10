using PatronEspecificacion.Dominio.Bases;

namespace PatronEspecificacion.Dominio.Entidades
{
    public class DireccionEspanolaFiltro : EntidadBase
    {
        #region Propiedades
        public string Provincia { get; set; }
        public string Municipio { get; set; }
        public DireccionEspanolaFiltro Exclusion { get; set; }
        #endregion

        #region Métodos Sobreescritos
        public override EntidadBase Clone()
        {
            DireccionEspanolaFiltro resultado = base.Clone() as DireccionEspanolaFiltro;
            resultado.Exclusion = null;

            if (Exclusion != null)
            {
                resultado.Exclusion = this.Exclusion.Clone() as DireccionEspanolaFiltro;
            }

            return resultado;
        } 
        #endregion
    }
}
