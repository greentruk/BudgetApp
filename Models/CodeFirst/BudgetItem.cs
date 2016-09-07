using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BudgetApp.Models.CodeFirst
{
    public class BudgetItem
    {
        public int Id { get; set; }
        public int BudgetId { get; set; }
        public int? BudgetCategoryId { get; set; }

        public DateTimeOffset Created { get; set; }
        public DateTimeOffset? Modified { get; set; }
        public virtual Budget Budget { get; set; }
        public virtual BudgetCategory BudgetCategory { get; set; }

    }
}