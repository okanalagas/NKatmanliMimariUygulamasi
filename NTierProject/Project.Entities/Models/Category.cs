using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project.Entities.Models
{
    public class Category : BaseEntity
    {
        public string CategoryName { get; set; }
        public string Description { get; set; }

        //Relational Properties
        public virtual List<Product> Products { get; set; } //Bire çok ilişki tanımlaması yapıldı. 1 kategorinin birden fazla ürünü olacağı için list tipinde açıp çoğul isim veriyoruz.


    }
}
