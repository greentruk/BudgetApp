﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BudgetApp.Models.CodeFirst
{
    public class Account
    {
        public Account()
        {
        this.Transactions = new HashSet<Transaction>();
        }
       
        public int Id { get; set; }
        public string Name { get; set; }
        public decimal Balance { get; set; }
        public bool IsReconciled { get; set; }
        public int? HouseholdId { get; set; }
        public DateTimeOffset Created { get; set; }

        public virtual Household Household { get; set; }
        public virtual ICollection<Transaction> Transactions { get; set; }
    }
    }
