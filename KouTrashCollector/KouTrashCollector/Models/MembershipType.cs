using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace KouTrashCollector.Models
{
    public class MembershipType
    {
        public int Id { get; set; }

        public string MembershipName { get; set; }

        public double PickUpRate { get; set; }
    }
}