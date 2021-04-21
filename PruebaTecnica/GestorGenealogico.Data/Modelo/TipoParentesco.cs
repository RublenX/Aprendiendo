using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

#nullable disable

namespace GestorGenealogico.Data.Modelo
{
    public partial class TipoParentesco
    {
        public TipoParentesco()
        {
            Genealogia = new HashSet<Genealogia>();
        }

        [Key]
        public int Id { get; set; }
        [Required]
        [StringLength(50)]
        public string Parentesco { get; set; }

        [InverseProperty("IdTipoParentescoNavigation")]
        public virtual ICollection<Genealogia> Genealogia { get; set; }
    }
}
