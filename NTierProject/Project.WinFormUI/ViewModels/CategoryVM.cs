using Project.Entities.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project.WinFormUI.ViewModels
{
    public class CategoryVM
    {
        public int Id { get; set; }  //ilgili propertiler oluşturuldu
        public string CategoryName { get; set; }
        public string Description { get; set; }
        public List<Product> Products { get; set; }

        public override string ToString()   // Görselde gözükecek yapıyı bu sınıfın içinde tanımladık...
        {
            return $"{CategoryName} {Description}";
        }
    }
}
