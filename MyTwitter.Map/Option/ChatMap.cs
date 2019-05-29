using MyTwitter.Core.Map;
using MyTwitter.Model.Option;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyTwitter.Map.Option
{
    public class ChatMap:CoreMap<Chat>
    {
        public ChatMap()
        {
            ToTable("dbo.Chats");
            Property(x => x.Message).IsOptional();

            HasRequired(x => x.AppUser).WithMany(x => x.Chats).HasForeignKey(x => x.AppUserID).WillCascadeOnDelete(false);
        }
    }
}
