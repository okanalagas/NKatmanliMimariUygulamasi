using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project.Entities.Models
{
    public class Order : BaseEntity
    {
        public string ShippedAddress { get; set; }
        public int? AppUserId { get; set; }
        public int? ShipperId { get; set; }

        //Relational Properties 
        public virtual AppUser AppUser { get; set; } // 1 siparişin sadece 1 kullanıcısı olabilir 
        public virtual List<OrderDetail> OrderDetails { get; set; } //Junction tablo için yazılır. çoka çok ilişki için daha tanımlama yapmak lazım. 
        public virtual Shipper  Shipper { get; set; } // bire çok ilişki yine... bir orderin yalnızca bir shipperi olabilir.
    } 
}
