using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace BudgetApp.Models.CodeFirst
{
    public class Budget
    {
        public Budget()
            {
            this.Items = new HashSet<BudgetItem>();
            }

        public int Id { get; set; }
        public DateTimeOffset Created { get; set; }
        public int HouseholdId { get; set; }
        public decimal Amount { get; set; }

        public virtual Household Household { get; set; }
        public virtual ICollection <BudgetItem> Items { get; set; }
    }
}
