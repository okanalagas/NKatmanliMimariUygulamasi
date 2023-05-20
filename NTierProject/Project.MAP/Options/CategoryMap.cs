using Project.Entities.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project.MAP.Options
{
    public class CategoryMap:BaseMap<Category>
    {
        public CategoryMap()
        {
            ToTable("Kategoriler"); // burda tablonun ismini kategoriler yaptık.
            Property(x=>x.CategoryName).HasColumnName("Kategori İsmi");
            Property(x => x.Description).HasColumnName("Açıklama");
        }
    }
}
