using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BudgetApp.Models.CodeFirst
{
    public class Account
    {
        public int Id { get; set; }
        public int? HouseholdId { get; set; }
        public DateTimeOffset Created { get; set; }

        public virtual Household Household { get; set; }
    }
}