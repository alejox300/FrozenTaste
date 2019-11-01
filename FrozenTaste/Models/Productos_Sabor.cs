using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace FrozenTaste.Models
{
    [Table("TMP_H.Productos_Sabor")]
    public class Productos_Sabores
    {
        [Key]
        public int Id_Productos_Sabor { get; set; }
        [Display(Name = "Producto")]
        public int Id_Producto { get; set; }
        [Display(Name = "Sabor")]
        public int Id_Sabor { get; set; }

       
        public virtual Productos Productos { get; set; }
        public virtual Sabores Sabores { get; set; }

    }
}