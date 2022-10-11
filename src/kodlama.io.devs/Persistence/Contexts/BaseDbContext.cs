using Core.Security.Entities;
using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using System.Text;

namespace Persistence.Contexts
{
    public class BaseDbContext : DbContext
    {
        protected IConfiguration Configuration { get; set; }
        public DbSet<Language> Languages { get; set; }
        public DbSet<Framework> Frameworks { get; set; }
        public DbSet<Member> Members { get; set; }
        public DbSet<GithubAccount> GithubAccounts { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<UserOperationClaim> UserOperationClaims { get; set; }
        public DbSet<OperationClaim> OperationClaims { get; set; }
        public DbSet<RefreshToken> RefreshTokens { get; set; }


        public BaseDbContext(DbContextOptions dbContextOptions, IConfiguration configuration) : base(dbContextOptions)
        {
            Configuration = configuration;
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            //if (!optionsBuilder.IsConfigured)
            //    base.OnConfiguring(
            //        optionsBuilder.UseSqlServer(Configuration.GetConnectionString("SomeConnectionString")));
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Language>(a =>
            {
                a.ToTable("Language").HasKey(k => k.Id);
                a.Property(p => p.Id).HasColumnName("Id");
                a.Property(p => p.Name).HasColumnName("Name");
                a.Property(p => p.CreateDate).HasColumnName("CreateDate");
            });



            Language[] languageEntitySeeds = { new(1, "C#", DateTime.Now), new(2, "Java", DateTime.Now), new(3, "Python", DateTime.Now) };
            modelBuilder.Entity<Language>().HasData(languageEntitySeeds);


            modelBuilder.Entity<Framework>(f =>
            {
                f.ToTable("Frameworks").HasKey(f => f.Id);
                f.Property(f => f.Id).HasColumnName("Id");
                f.Property(f => f.LanguageId).HasColumnName("ProgrammingLanguageId");
                f.Property(f => f.Name).HasColumnName("Name");
                f.HasOne(f => f.Language);
            });
            Framework[] frameworkEntitySeeds =
                        {
                new (1, 1, ".net"),
                new (2,1, "c#"),
                new (3,2,"piton"),
                new (4,1,"vv")

            };
            modelBuilder.Entity<Framework>().HasData(frameworkEntitySeeds);




            modelBuilder.Entity<User>(u =>
            {
                u.ToTable("Users").HasKey(u => u.Id);
                u.Property(u => u.Id).HasColumnName("Id");
                u.Property(u => u.FirstName).HasColumnName("FirstName");
                u.Property(u => u.LastName).HasColumnName("LastName");
                u.Property(u => u.Email).HasColumnName("Email");
                u.Property(u => u.PasswordHash).HasColumnName("PasswordHash");
                u.Property(u => u.PasswordSalt).HasColumnName("PasswordSalt");
                u.Property(u => u.Status).HasColumnName("Status");
                u.Property(u => u.AuthenticatorType).HasColumnName("AuthenticatorType");
                u.HasMany(u => u.UserOperationClaims);
                u.HasMany(u => u.RefreshTokens);
            });
            User[] userEntitySeeds =
            {
                new(1,"Taygun","taygun","taygun@taygun.com",Encoding.ASCII.GetBytes("taygun"), Encoding.ASCII.GetBytes("taygun"),false, 0),
                new(2, "Sercan","sercan","sercan@sercan.com",Encoding.ASCII.GetBytes("sercan"), Encoding.ASCII.GetBytes("sercan"),false, 0 )
            };
            modelBuilder.Entity<User>().HasData(userEntitySeeds);



            modelBuilder.Entity<OperationClaim>(a =>
            {
                a.ToTable("OperationClaims").HasKey(k => k.Id);
                a.Property(p => p.Id).HasColumnName("Id");
                a.Property(p => p.Name).HasColumnName("Name");

            });
            OperationClaim[] operationClaimEntitySeeds = { new(1, "user"), new(2, "admin") };
            modelBuilder.Entity<OperationClaim>().HasData(operationClaimEntitySeeds);



            modelBuilder.Entity<UserOperationClaim>(a =>
            {
                a.ToTable("UserOperationClaims").HasKey(k => k.Id);
                a.Property(a => a.Id).HasColumnName("Id");
                a.Property(a => a.OperationClaimId).HasColumnName("OperationClaimId");
                a.Property(a => a.UserId).HasColumnName("UserId");
                a.HasOne(a => a.OperationClaim);
                a.HasOne(a => a.User);

            });
            UserOperationClaim[] userOperationClaimEntitySeeds = { new(1, 1, 2) };
            modelBuilder.Entity<UserOperationClaim>().HasData(userOperationClaimEntitySeeds);



            modelBuilder.Entity<Member>(p =>
            {
                p.ToTable("Members");
                p.HasMany(p => p.GithubAccounts);
            });

            modelBuilder.Entity<GithubAccount>(p =>
            {
                p.ToTable("GithubAccounts").HasKey(k => k.Id);
                p.Property(p => p.Id).HasColumnName("Id");
                p.Property(p => p.MemberId).HasColumnName("MemberId");
                p.Property(p => p.GithubLink).HasColumnName("GithubLink");
                p.HasOne(p => p.Member);
            });
        }

    }
}