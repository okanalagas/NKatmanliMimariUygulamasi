﻿using Project.BLL.DesignPatterns.GenericRepository.BaseRep;
using Project.Entities.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project.BLL.DesignPatterns.GenericRepository.ConcRep
{
    public class CategoryRepository : BaseRepository<Category> // base repository içindeki tüm metolar t ye göre değişken gönderir.
    {
    }
}
