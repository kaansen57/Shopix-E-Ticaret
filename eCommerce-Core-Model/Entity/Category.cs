using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace eCommerce_Core_Model.Entity
{
    public class Category : EntityBase
    {
        public int ParentID { get; set; } = 0; // DEFAULT değeri 0 

        public string Name { get; set; }

        public bool IsActive { get; set; }

        public virtual IEnumerable<Product> Product { get; set; }
    }
}
