using System;
using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using Microsoft.AspNet.Identity.Owin;
using System.Data.Entity;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace test_website.Models
{
    // You can add profile data for the user by adding more properties to your ApplicationUser class, please visit http://go.microsoft.com/fwlink/?LinkID=317594 to learn more.
    public class ApplicationUser : IdentityUser
    {
        public async Task<ClaimsIdentity> GenerateUserIdentityAsync(UserManager<ApplicationUser> manager, string authenticationType)
        {
            // Note the authenticationType must match the one defined in CookieAuthenticationOptions.AuthenticationType
            var userIdentity = await manager.CreateIdentityAsync(this, authenticationType);
            // Add custom user claims here
            return userIdentity;
        }

        //admin properties that system can save it to database
        public string FirstName { get; set; }

        public string LastName { get; set; }

        public string NationalCode { get; set; }

    }

    public class ApplicationDbContext : IdentityDbContext<ApplicationUser>
    {
        public ApplicationDbContext()
            : base("DefaultConnection", throwIfV1Schema: false)
        {
        }
        
        public static ApplicationDbContext Create()
        {
            return new ApplicationDbContext();
        }

        public DbSet<CollegeModel> Colleges { get; set; }

        public DbSet<EducationalGroupModel> EducationalGroups { get; set; }

        public DbSet<ResearchGroupModel> ResearchGroups { get; set; }

        public DbSet<EmployerModel> Employers { get; set; }

        public DbSet<ExecuterModel> Executers { get; set; }

        public DbSet<ExecuterResearchGroupModel> ExecuterResearchGroups { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<ResearchGroupModel>()
                .HasRequired(t => t.College)
                .WithMany()
                .HasForeignKey(t => t.CollegeId)
                .WillCascadeOnDelete(false);
            modelBuilder.Entity<ResearchGroupModel>()
                .HasRequired(t => t.EducationalGroup)
                .WithMany()
                .HasForeignKey(t => t.EducationalGroupId)
                .WillCascadeOnDelete(false);
            modelBuilder.Entity<ExecuterModel>()
                 .HasRequired(t => t.College)
                 .WithMany()
                 .HasForeignKey(t => t.CollegeId)
                 .WillCascadeOnDelete(false);
            modelBuilder.Entity<ExecuterModel>()
                .HasRequired(t => t.EducationalGroup)
                .WithMany()
                .HasForeignKey(t => t.EducationalGroupId)
                .WillCascadeOnDelete(false);
            modelBuilder.Entity<ExecuterResearchGroupModel>()
                .HasRequired(t => t.Executer)
                .WithMany()
                .HasForeignKey(t => t.ExeuterId)
                .WillCascadeOnDelete(false);
            modelBuilder.Entity<ExecuterResearchGroupModel>()
                .HasRequired(t => t.ResearchGroup)
                .WithMany()
                .HasForeignKey(t => t.ResearchGroupId)
                .WillCascadeOnDelete(false);

            base.OnModelCreating(modelBuilder);
        }
    }
    
}