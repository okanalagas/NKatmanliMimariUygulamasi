﻿using Project.Entities.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project.MAP.Options
{
    public class OrderMap : BaseMap<Order>
    {
        public OrderMap()
        {
            Property(x => x.ShippedAddress).HasColumnName("Teslim Adresi");
            ToTable("Siparişler");
        }
    }
}
