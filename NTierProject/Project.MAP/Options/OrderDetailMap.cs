using Project.Entities.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project.MAP.Options
{
    public class OrderDetailMap : BaseMap<OrderDetail>
    {
        public OrderDetailMap()
        {
            ToTable("Satışlar");
            Ignore(x => x.Id); //yoksay ve sqle gönderme demek istiyoruz.böylece keyi olmaycağı için aşağıudaki şekilde keyi bizim belirlememiz lazım..
            HasKey(x => new //anoynmous type 
            {
                x.OrderId,
                x.ProductId
            });
        }
    }
}
