using Project.DAL.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project.BLL.DesignPatterns.SingletonPattern
{
    public class DBTool
    {
        DBTool() { } // private yaptık çünkü dışardan instance alınmasını istemiyoruz.

        static MyContext _dbInstance;
        public static MyContext DbInstance //encapculation ile read only olmasını sağlıyoruz.
        {
            get
            {
                if (_dbInstance == null) _dbInstance = new MyContext(); //boşsa yeni bi context oluşturuyor
                return _dbInstance; //doluysa bunu yapıyor
            }
        }
    }
}
