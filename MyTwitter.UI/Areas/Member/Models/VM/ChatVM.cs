using MyTwitter.Model.Option;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MyTwitter.UI.Areas.Member.Models.VM
{
    public class ChatVM
    {
        public ChatVM()
        {
            AppUsers = new List<AppUser>();
            Chats = new List<Chat>();
            user = new AppUser();
        }
        public List<AppUser> AppUsers { get; set; }
        public List<Chat> Chats  { get; set; }
        public AppUser user { get; set; }
    }
}