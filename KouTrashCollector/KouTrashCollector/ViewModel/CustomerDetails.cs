using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using KouTrashCollector.Models;

namespace KouTrashCollector.ViewModel
{
    public class CustomerDetails
    {
        public Customer Customer { get; set; }
        public IEnumerable<MembershipType> MembershipTypes { get; set; }
    }
}