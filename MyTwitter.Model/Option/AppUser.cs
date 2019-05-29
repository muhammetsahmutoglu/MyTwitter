using MyTwitter.Core.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyTwitter.Model.Option
{
    public class AppUser : CoreEntity
    {
        public string UserName { get; set; }
        public string Password { get; set; }
        public string PhoneNumber { get; set; }        
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }        
        public DateTime? Birthdate { get; set; }
        public string UserImage { get; set; }
        public string XSmallUserImage { get; set; }
        public string CruptedUserImage { get; set; }
        public string ImagePath { get; set; }
        public int Following { get; set; }
        public int  Followers { get; set; }


        public virtual List<Comment> Comments { get; set; }
        public virtual List<Like> Likes { get; set; }
        public virtual List<Tweet> Tweets { get; set; }
        public virtual List<Chat> Chats { get; set; }
    }
}
