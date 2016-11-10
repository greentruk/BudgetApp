using System.Data.Entity;
using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using System.ComponentModel.DataAnnotations;
using BudgetApp.Models.CodeFirst;
using System.Collections.Generic;

namespace BudgetApp.Models
{
    // You can add profile data for the user by adding more properties to your ApplicationUser class, please visit http://go.microsoft.com/fwlink/?LinkID=317594 to learn more.
    public class ApplicationUser : IdentityUser
    {
  
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string DisplayName { get { return FirstName + " " + LastName; } }
        public int? HouseholdId { get; set; }
        public virtual ICollection<Transaction> Transactions { get; set; }
        public virtual Household Household { get; set; }

        public async Task<ClaimsIdentity> GenerateUserIdentityAsync(UserManager<ApplicationUser> manager)
        {
            // Note the authenticationType must match the one defined in CookieAuthenticationOptions.AuthenticationType
            var userIdentity = await manager.CreateIdentityAsync(this, DefaultAuthenticationTypes.ApplicationCookie);
            // Add custom user claims here
            return userIdentity;
        }
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

        public System.Data.Entity.DbSet<BudgetApp.Models.CodeFirst.Household> Households { get; set; }

        public System.Data.Entity.DbSet<BudgetApp.Models.CodeFirst.HouseholdInvitation> HouseholdInvitations { get; set; }

        public System.Data.Entity.DbSet<BudgetApp.Models.CodeFirst.Account> Accounts { get; set; }

        public System.Data.Entity.DbSet<BudgetApp.Models.CodeFirst.Transaction> Transactions { get; set; }

        public System.Data.Entity.DbSet<BudgetApp.Models.CodeFirst.BudgetCategory> BudgetCategories { get; set; }

        
    }
}