using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace FrozenTaste.Models
{
    [Table("TMP_H.Productos")]
    public class Productos
    {      
        [Key]
        
        public int Id_Producto { get; set; }
        [Display(Name = "Producto")]
        [Required(ErrorMessage = "Debes ingresar {0}")]
        [StringLength(20,ErrorMessage ="El campo {0} desbe estar entre {1} y {2} caracteres", MinimumLength = 3)]
        public String Producto { get; set; }

        
        public virtual ICollection<Productos_Sabores> Productos_Sabores { get; set; }
        public virtual ICollection<Productos_Bases> Productos_Bases { get; set; }
        public virtual ICollection<Productos_Sabor_Base> Productos_Sabor_Base { get; set; }


    }
}