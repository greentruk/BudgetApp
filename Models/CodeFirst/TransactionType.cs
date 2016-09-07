using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace BudgetApp.Models.CodeFirst
{
    public enum TransactionType
    {
        [Display(Name = "Expense")]
        Expense,
        [Display(Name = "Income")]
        Income
    }
}