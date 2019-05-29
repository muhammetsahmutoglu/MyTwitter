using MyTwitter.Model.Option;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MyTwitter.UI.Areas.Member.Models.VM
{
    public class TweetVM
    {
        public TweetVM()
        {//
            Tweets = new List<Tweet>();
            Likes = new List<Like>();
            Comments = new List<Comment>();
            AppUsers = new List<AppUser>();
            user= new AppUser();
            
        }
        public List<Comment> Comments { get; set; }
        public List<Like> Likes { get; set; }
        public List<AppUser> AppUsers { get; set; }
        public List<Tweet> Tweets { get; set; }
        public  AppUser user{ get; set; }
        public string userName { get; set; }
        public Guid UserID { get; set; }
    }
}