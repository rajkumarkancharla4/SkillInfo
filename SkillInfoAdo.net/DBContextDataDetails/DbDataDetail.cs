using Microsoft.EntityFrameworkCore;
using SkillInfoAdo.net.Entities;

namespace SkillInfoAdo.net.DBContextDataDetails
{
    public class DbDataDetail : DbContext

    {
        public DbDataDetail(DbContextOptions options) : base(options)
        {
        }
        public DbSet<SkillInfoEntity> SkillInfo { get; set; }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<SkillInfoEntity>()
                .HasKey(e => e.SkillID); // Specify the primary key
        }

    }
}
