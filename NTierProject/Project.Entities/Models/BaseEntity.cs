using Project.Entities.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project.Entities.Models
{
    public abstract class BaseEntity // bu classtan instance alınması anlamsız bir veri oluşturacağı için ve sadece miras vereceği için abstraction yapılır.
    {
        public int Id { get; set; }
        public DateTime CreatedDate { get; set; }   
        public DateTime? ModifiedDate { get; set;} //? işareti nullable olduğunu gösterir.
        public DateTime? DeletedDate { get; set; }   
        public DataStatus Status { get; set; }

        public BaseEntity()
        {
            CreatedDate= DateTime.Now;  // Yeni bir nesne oluşturulduğunda default olarak verilecek özellikler yazılır.
            Status = DataStatus.Inserted;
        }

    }
}
