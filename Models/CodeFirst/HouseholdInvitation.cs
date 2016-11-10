using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace BudgetApp.Models.CodeFirst
{
    public class HouseholdInvitation
    {

        public int Id { get; set; }
        public string Email { get; set; }
        public string DisplayNameId { get; set; }
        public Guid InviteCode { get; set; }
        public bool EmailUsed { get; set; }

        [Display(Name = "Household Name")]
        public int? HouseholdId { get; set; }

        public virtual Household Household { get; set;}
        public virtual ApplicationUser DisplayName { get; set; }
    }
}