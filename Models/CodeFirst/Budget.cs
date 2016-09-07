using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace BudgetApp.Models.CodeFirst
{
    public class Budget
    {
        public int Id { get; set; }
        public DateTimeOffset Created { get; set; }
        public int HouseholdId { get; set; }

        public virtual Household Household { get; set; }
    }
}