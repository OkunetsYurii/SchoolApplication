using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using SchoolApplication.Models;

namespace SchoolApplication.Data
{
    public class SchoolDbContext : IdentityDbContext<IdentityUser>
    {
        public DbSet<Test> Tests { get; set; }
        public DbSet<UserTest> UserTests { get; set; }
        public DbSet<Question> Questions { get; set; }
        public DbSet<Answer> Answers { get; set; }
        public DbSet<CorrectAnswer> CorrectAnswers { get; set; }
        public DbSet<News> News { get; set; }


        public SchoolDbContext(DbContextOptions options) :
            base(options)
        {
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<IdentityRole>().HasData(new IdentityRole
            {
                Id = "44546e06-8719-4ad8-b88a-f271ae9d6eab",
                Name = "admin",
                NormalizedName = "ADMIN"
            });
            modelBuilder.Entity<IdentityRole>().HasData(new IdentityRole
            {
                Id = "eaf7b189-75ba-47b7-862f-9c31da2b313c",
                Name = "instructor",
                NormalizedName = "INSTRUCTOR"
            });

            modelBuilder.Entity<IdentityUser>().HasData(new IdentityUser
            {
                Id = "3b62472e-4f66-49fa-a20f-e7685b9565d8",
                UserName = "okunets2010@gmail.com",
                NormalizedUserName = "OKUNETS2010@GMAIL.COM",
                Email = "okunets2010@gmail.com",
                NormalizedEmail = "OKUNETS2010@GMAIL.COM",
                EmailConfirmed = true,
                PasswordHash = new PasswordHasher<IdentityUser>().HashPassword(null, "superpassword"),
                SecurityStamp = string.Empty
            });

            modelBuilder.Entity<IdentityUserRole<string>>().HasData(new IdentityUserRole<string>
            {
                RoleId = "44546e06-8719-4ad8-b88a-f271ae9d6eab",
                UserId = "3b62472e-4f66-49fa-a20f-e7685b9565d8"
            });

            modelBuilder.Entity<IdentityUserRole<string>>().HasData(new IdentityUserRole<string>
            {
                RoleId = "eaf7b189-75ba-47b7-862f-9c31da2b313c",
                UserId = "3b62472e-4f66-49fa-a20f-e7685b9565d8"
            });
        }
    }
}
