using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace BudgetApp.Models.CodeFirst
{
    public class Household
    {
        public Household()
        {
            this.Accounts = new HashSet<Account>();
            this.Users = new HashSet<ApplicationUser>();
            this.Budgets = new HashSet<Budget>();
            this.Categories = new HashSet<BudgetCategory>();
            this.Invitations = new HashSet<HouseholdInvitation>();
            this.Email = new HashSet<HouseholdInvitation>();
            this.DisplayName = new HashSet<HouseholdInvitation>();
        }
        
        public int Id { get; set; }
        public string Name { get; set; }
        public DateTimeOffset Create { get; set; }

        public virtual ICollection<Account> Accounts { get; set; }
        public virtual ICollection<ApplicationUser> Users { get; set; }
        public virtual ICollection<Budget> Budgets { get; set; }
        public virtual ICollection<BudgetCategory> Categories { get; set; }
        public virtual ICollection<HouseholdInvitation> Invitations { get; set; }
        public virtual ICollection<HouseholdInvitation> Email{ get; set; }
        public virtual ICollection<HouseholdInvitation> DisplayName { get; set; }

    }
}

