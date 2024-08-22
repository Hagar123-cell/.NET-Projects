using System;
using System.Collections.Generic;

namespace microtech_task_final.Models
{
    //partial for Scaffolding
    public partial class Account
    {
        public Account()
        {
            InverseAccParentNavigation = new HashSet<Account>();
        }

        public string AccNumber { get; set; } = null!;
        public string? AccParent { get; set; }
        public decimal? Balance { get; set; }

        /*****************self rel representation**************/
        //virtual for lazy loading
        //FK
        public virtual Account? AccParentNavigation { get; set; }
        //1:M rel"Navigation property"
        public virtual ICollection<Account> InverseAccParentNavigation { get; set; }
    }
}
