using MyTwitter.Core.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyTwitter.Model.Option
{
    public class Tweet:CoreEntity
    {
        public string Content { get; set; }
        public string TweetImage { get; set; }
        public string XSmallTweetImage { get; set; }
        public string CruptedTweetImage { get; set; }
        public string ImagePath { get; set; }
        public string TweetUserName { get; set; }
        public Guid AppUserID { get; set; }
        public virtual AppUser AppUser { get; set; }

        public virtual List<Comment> Comments { get; set; }

        public virtual List<Like> Likes { get; set; }
    }
    
}
