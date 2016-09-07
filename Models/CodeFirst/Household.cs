using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace BudgetApp.Models.CodeFirst
{
    public class Household
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public DateTimeOffset Create { get; set; }

        public virtual ICollection<Account> Accounts { get; set; }
        public virtual ICollection<ApplicationUser> Users { get; set; }

    }
}
