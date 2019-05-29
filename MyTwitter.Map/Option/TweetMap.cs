using MyTwitter.Core.Map;
using MyTwitter.Model.Option;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyTwitter.Map.Option
{
    public class TweetMap:CoreMap<Tweet>
    {
        public TweetMap()
        {
            ToTable("dbo.Tweets");

            Property(x => x.Content).HasMaxLength(140).IsOptional();
            Property(x => x.ImagePath).IsOptional();
            Property(x => x.TweetImage).IsOptional();
            Property(x => x.XSmallTweetImage).IsOptional();
            Property(x => x.CruptedTweetImage).IsOptional();

            HasRequired(x => x.AppUser).WithMany(x => x.Tweets).HasForeignKey(x => x.AppUserID).WillCascadeOnDelete();

            HasMany(x => x.Likes).WithRequired(x => x.Tweet).HasForeignKey(x => x.TweetID).WillCascadeOnDelete(false);
            HasMany(x => x.Likes).WithRequired(x => x.Tweet).HasForeignKey(x => x.TweetID).WillCascadeOnDelete(false);
        }
    }
}
