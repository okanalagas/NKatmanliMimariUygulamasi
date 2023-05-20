using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project.Entities.Models
{
    public class AppUser : BaseEntity
    {
        public string Username { get; set; }
        public string Password { get; set; }

        //Relational Properties => İlişki kuracak propertiler
        public virtual AppUserProfile Profile { get; set; } //Birerbir ilişki tanımlaması yapıldı.
        public virtual List<Order> Orders { get; set; } // 1 kişinin birden fazla siparişi olabilir.
    }
}
