using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project.Entities.Models
{
    public class OrderDetail : BaseEntity
    {
        public int OrderId { get; set; } // junction tablo olduğu için idler başka tablolardan gelsin diye böyle yazıyoruz.
        public int ProductId { get; set; }

        //Relational Properties 
        public virtual Order Order { get; set; }
        public virtual Product Product { get; set; }

    }
}
