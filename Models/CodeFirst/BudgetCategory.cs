﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace BudgetApp.Models.CodeFirst
{
    public class BudgetCategory
    {
        public int Id { get; set; }
        public string Name { get; set; }

        public virtual BudgetItem BudgetItem { get; set; }
    }
}