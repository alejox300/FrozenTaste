using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace FrozenTaste.Models
{
    [Table("TMP_H.Productos_Sabor_Base")]
    public class Productos_Sabor_Base
    {
        [Key]
        public int Id_Productos_Sabor_Base { get; set; }
        [Display(Name = "Producto")]
        public int Id_Producto { get; set; }
        [Display(Name = "Sabor")]
        public int Id_Sabor { get; set; }
        [Display(Name = "Base")]
        public int Id_Base { get; set; }

        public virtual Productos Productos { get; set; }
        public virtual Sabores Sabores { get; set; }
        public virtual Bases Bases { get; set; }
    }
}