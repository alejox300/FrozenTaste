using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace FrozenTaste.Models
{
    [Table("TMP_H.Bases")]
    public class Bases
    {
        [Key]
        public int Id_Base { get; set; }
        [Display(Name = "Base")]
        [Required(ErrorMessage = "Debes ingresar {0}")]
        [StringLength(20, ErrorMessage = "El campo {0} desbe estar entre {1} y {2} caracteres", MinimumLength = 3)]
        public String Base { get; set; }

        public virtual ICollection<Productos_Bases> Productos_Bases { get; set; }
        public virtual ICollection<Productos_Sabor_Base> Productos_Sabor_Base { get; set; }

    }
}