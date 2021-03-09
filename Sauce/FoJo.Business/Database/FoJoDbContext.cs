using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace FoJo.Business.Database
{
    public class FoJoDbContext : IdentityDbContext
    {
        public FoJoDbContext(DbContextOptions<FoJoDbContext> options)
    : base(options)
        {
        }

        public DbSet<PostEntity> Posts { get; set; }

        public DbSet<AttachmentEntity> Attachments { get; set; }

        public DbSet<CommentEntity> Comments { get; set; }
    }
}
