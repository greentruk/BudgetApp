using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BudgetApp.Models.CodeFirst
{
    public class Transaction
    {
        public int Id { get; set; }
        public DateTimeOffset Created { get; set; }
        public DateTimeOffset? Modified { get; set; }
        public decimal Amount { get; set; }
        public int? AccountId { get; set; }
        public int? BudgetCategoryId { get; set; }
        public bool IsReconciled { get; set; }
        public string Description { get; set; }

        public virtual Account Account { get; set; }
        public virtual TransactionType TransactionType { get; set; }
        public virtual BudgetCategory BudgetCategory { get; set; }
    }
}