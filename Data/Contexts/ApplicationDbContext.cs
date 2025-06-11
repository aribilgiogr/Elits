using Core.Concretes.Entities;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System.Reflection.Emit;

namespace Data.Contexts
{
    public class ApplicationDbContext : IdentityDbContext<ApplicationUser, ApplicationRole, Guid>
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {
        }

        public DbSet<Post> Posts { get; set; }
        public DbSet<Comment> Comments { get; set; }
        public DbSet<Follower> Followers { get; set; }
        public DbSet<PostLike> PostLikes { get; set; }
        public DbSet<DirectMessage> DirectMessages { get; set; }
        public DbSet<Notification> Notifications { get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);

            //Kompozit birincil anahtar oluşturur.İki sütunun durumunun aynı anda tekil olması olayıdır.
            builder.Entity<Follower>()
                   .HasKey(f => new { f.FollowerMemberId, f.FollowedMemberId });

            //Bir tablo başka bir tablonun iki ayrı primary key yapısına ayrı ayrı foreignkey bağlantısı aşağıdaki gibi bir fluent api kullanmadan bağlanamaz.
            builder.Entity<Follower>()
                   .HasOne(f => f.FollowerMember)
                   .WithMany(u => u.Following)
                   .HasForeignKey(f => f.FollowerMemberId)
                   .OnDelete(DeleteBehavior.NoAction);

            builder.Entity<Follower>()
                   .HasOne(f => f.FollowedMember)
                   .WithMany(u => u.Followers)
                   .HasForeignKey(f => f.FollowedMemberId)
                   .OnDelete(DeleteBehavior.NoAction);

            // DirectMessage (Senders, Receivers) için bağlantıları (one2many) oluştur
            builder.Entity<DirectMessage>()
                   .HasOne(dm => dm.Sender)
                   .WithMany(u => u.SentMessages)
                   .HasForeignKey(dm => dm.SenderId)
                   .OnDelete(DeleteBehavior.NoAction);

            builder.Entity<DirectMessage>()
                   .HasOne(dm => dm.Receiver)
                   .WithMany(u => u.ReceivedMessages)
                   .HasForeignKey(dm => dm.ReceiverId)
                   .OnDelete(DeleteBehavior.NoAction);

            builder.Entity<ApplicationUser>()
                .Navigation(u => u.Posts).AutoInclude();

            builder.Entity<ApplicationUser>()
                .Navigation(u => u.PostLikes).AutoInclude();

            builder.Entity<ApplicationUser>()
                .Navigation(u => u.Comments).AutoInclude();

            builder.Entity<ApplicationUser>()
                .Navigation(u => u.Notifications).AutoInclude();
        }
    }
}
