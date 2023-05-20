using Project.Entities.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project.MAP.Options
{
    public class ProductMap : BaseMap<Product> // basemap bu ayarlamaları product için yap ve bu özellikleri product mape aktar dedik. bu class product tablosu için ilgili ayarları yapar. sadece productu özel ayarlama yapmak için constructor açılır ve ayarlar oraya yazılır.
    {
        public ProductMap()
        {
            ToTable("Ürünler");
            Property(x => x.ProductName).HasColumnName("Ürün İsmi"); // burda x product oldugu için sadece productun özellikleri gelir.
            Property(x => x.UnitPrice).HasColumnName("Fiyat").HasColumnType("money"); // hascolumntype ile sql veritabanıonda fiyat money tipinde kaydedilsin diyoruz.
        }
    }
}
