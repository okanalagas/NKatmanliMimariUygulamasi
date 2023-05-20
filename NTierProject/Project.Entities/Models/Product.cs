using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project.Entities.Models
{
    public class Product : BaseEntity
    {
        public string ProductName { get; set; }
        public decimal UnitPrice { get; set; }
        public int? CategoryId { get; set; }  //bire çok ilişkide ilişkiyi veritabanına aktarabilmek için tekil olan tarafın idsi yazılır.Id yazmamızın sebebi foreign key olduğu belli olsun diye

        //Relational Properties  
        public virtual Category Category { get; set; } // 1 productun sadece 1 kategorisi olacağı için tekil tanımlanır.
        public virtual List<OrderDetail> OrderDetails { get; set; } 
    }
}
