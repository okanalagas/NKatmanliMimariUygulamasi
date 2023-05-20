using Project.Entities.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project.MAP.Options
{
    public abstract class BaseMap<T> : EntityTypeConfiguration<T> where T : BaseEntity //T yazılmasının sebebi hangi tipe  göre işlem yapacağını tanımlamak içindir. ama bu yetmez generic tipimizin class olduğu şartını koymak da lazım. burda t sadece class olabilir diyoruz. int vb olamaz. aynı zamanda bu t sadece veritabanındaki sınıflardan olabilmelidir. rastgele sınıf verilmemesi için  güvenlik açısından BaseEntity yazılır ve baseentity tipindeki classlar için çalışır mapping baseentityden miras alan classlar birer base entitydir.
    {
        public BaseMap()
        {
            Property(x => x.CreatedDate).HasColumnName("Yaratılma Tarihi"); // bu bir linq sorgusudur. x, => (lambda operatörü) ile birlikte kullanılırsa x t yi temsil eder t ne ise x onun ortak bütün propertylerine yani sütunlarına  erişebilir. 
            Property(x => x.DeletedDate).HasColumnName("Silme Tarihi"); // sütunların ismini değiştiriyoruz...
            Property(x => x.ModifiedDate).HasColumnName("Güncelleme Tarihi");
            Property(x => x.Status).HasColumnName("Veri Durumu");
        }
    }
}
