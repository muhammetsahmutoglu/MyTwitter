using MyTwitter.Core.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyTwitter.Model.Option
{
    public class Chat:CoreEntity
    {
        public string Message { get; set; }

        public Guid AppUserID { get; set; }
        public virtual AppUser AppUser { get; set; }

        public string UserName { get; set; }
    }
}
