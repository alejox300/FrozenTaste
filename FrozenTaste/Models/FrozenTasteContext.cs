using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace FrozenTaste.Models
{
    public class FrozenTasteContext : DbContext
    {
        // You can add custom code to this file. Changes will not be overwritten.
        // 
        // If you want Entity Framework to drop and regenerate your database
        // automatically whenever you change your model schema, please use data migrations.
        // For more information refer to the documentation:
        // http://msdn.microsoft.com/en-us/data/jj591621.aspx
    
        public FrozenTasteContext() : base("name=FrozenTasteContext")
        {
        }

        public System.Data.Entity.DbSet<FrozenTaste.Models.Productos> Productos { get; set; }

        public System.Data.Entity.DbSet<FrozenTaste.Models.Sabores> Sabores { get; set; }

        public System.Data.Entity.DbSet<FrozenTaste.Models.Bases> Bases { get; set; }

        public System.Data.Entity.DbSet<FrozenTaste.Models.Productos_Sabores> Productos_Sabores { get; set; }

        public System.Data.Entity.DbSet<FrozenTaste.Models.Productos_Bases> Productos_Bases { get; set; }

        public System.Data.Entity.DbSet<FrozenTaste.Models.Productos_Sabor_Base> Productos_Sabor_Base { get; set; }
    }
}
