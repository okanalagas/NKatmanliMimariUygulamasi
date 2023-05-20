using Project.Entities.Models;
using Project.MAP.Options;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project.DAL.Context
{
    public class MyContext : DbContext // bu class özel bil bildirimde bulunmadan veritabanında işlem yapıp yapamayacağını bilemez. Veritabanı sınıfı olduğunu bilmesi için Db Contexten kalıtım alır.
    {
        public MyContext() : base("MyConnection") // setasstartup projesindeki appconfigin içine git ve bağlantı adresini ara dedik
        {

        }
        protected override void OnModelCreating(DbModelBuilder modelBuilder) //model yaratılırken yapmak sitediğimiz şeyler için burda ezme yapıyoruz. map katmanındaki ayarlamalar için tetikleme yapmamız lazım.
        {
            modelBuilder.Configurations.Add(new AppUserMap()); //bu tiplerde bir instance alınır ve yapıcı metodu tetiklenerek gerekli ayarlamalar yapılmış olur..
            modelBuilder.Configurations.Add(new AppUserProfileMap());
            modelBuilder.Configurations.Add(new CategoryMap());
            modelBuilder.Configurations.Add(new OrderDetailMap());
            modelBuilder.Configurations.Add(new OrderMap());
            modelBuilder.Configurations.Add(new ProductMap());
            modelBuilder.Configurations.Add(new ShipperMap());
        }
        public DbSet<AppUser> AppUsers { get; set; }  //Tablo olacak sınıflar tanımlandı
        public DbSet<AppUserProfile> AppUserProfiles { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<Order> Orders { get; set; }
        public DbSet<OrderDetail> OrderDetails { get; set; }
        public DbSet<Product> Products { get; set; }
        public DbSet<Shipper> Shippers { get; set; }
    }
}
