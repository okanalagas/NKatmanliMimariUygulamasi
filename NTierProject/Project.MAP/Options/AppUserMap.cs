using Project.Entities.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project.MAP.Options
{
    public class AppUserMap : BaseMap<AppUser>
    {
        public AppUserMap()
        {
            ToTable("Kullanıcılar");
            Property(x=>x.Username).HasColumnName("Kullanıcı Adı");
            Property(x => x.Password).HasColumnName("Şifre");
            HasOptional(x => x.Profile).WithRequired(x => x.AppUser); // burda diyoruz ki appuserin profili boş geçilebilir ama appuserprofilenin appuseri boşgeçilemez... burda yapma kyeterlidir. appuserprofileda da yapmaya gerek yoktur 
        }
    }
}
