using MyTwitter.Core.Entity;
using MyTwitter.Map.Option;
using MyTwitter.Model.Option;
using MyTwitter.Utility;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;
using System.Linq;
using System.Security.Principal;
using System.Text;
using System.Threading.Tasks;

namespace MyTwitter.DAL.Context
{
    public class ProjectContext : DbContext
    {
        public ProjectContext()
        {
            Database.Connection.ConnectionString = "Server=MONSTER;Database=MyTwitter;uid=sa;pwd=1234;";
        }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Configurations.Add(new AppUserMap());
            modelBuilder.Configurations.Add(new CommentMap());
            modelBuilder.Configurations.Add(new TweetMap());
            modelBuilder.Configurations.Add(new LikeMap());
            modelBuilder.Configurations.Add(new ChatMap());
            

            modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();

            base.OnModelCreating(modelBuilder);
        }

        public DbSet<AppUser> Users { get; set; }
        public DbSet<Comment> Products { get; set; }
        public DbSet<Tweet> Categories { get; set; }        
        public DbSet<Like> Likes { get; set; }
        public DbSet<Chat> Chats { get; set; }

        public override int SaveChanges()
        {
            var modifiedEntries = ChangeTracker.Entries().Where(x => x.State == EntityState.Added || x.State == EntityState.Modified);

            string identity = WindowsIdentity.GetCurrent().Name;
            string computerName = Environment.MachineName;
            DateTime dateTime = DateTime.Now;
            string GetIp = RemoteIP.IpAddress;

            foreach (var item in modifiedEntries)
            {
                CoreEntity entity = item.Entity as CoreEntity;

                if (item.State == EntityState.Added)
                {
                    entity.CreatedUserName = identity;
                    entity.CreatedComputerName = computerName;
                    entity.CreatedDate = dateTime;
                    entity.CreatedIP = GetIp;
                }
                else if (item.State == EntityState.Modified)
                {
                    entity.ModifiedUserName = identity;
                    entity.ModifiedComputerName = computerName;
                    entity.ModifiedDate = dateTime;
                    entity.ModifiedIP = GetIp;
                }
            }
            return base.SaveChanges();
        }
    }
}
