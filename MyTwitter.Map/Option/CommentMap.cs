using MyTwitter.Core.Map;
using MyTwitter.Model.Option;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyTwitter.Map.Option
{
   public class CommentMap:CoreMap<Comment>
    {
        public CommentMap()
        {
            ToTable("dbo.Comments");
            Property(x => x.Content).HasMaxLength(140).IsOptional();

            HasRequired(x => x.AppUser).WithMany(x => x.Comments).HasForeignKey(x => x.AppUserID).WillCascadeOnDelete(false);
            HasRequired(x => x.Tweet).WithMany(x => x.Comments).HasForeignKey(x => x.TweetID).WillCascadeOnDelete(false);
        }
    }
}
