using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BudgetApp.Models.CodeFirst
{
    public class HouseholdInvitation
    {
        public int Id { get; set; }
        public Guid InviteCode { get; set; }
        public int? HouseholdId { get; set; }
    }
}