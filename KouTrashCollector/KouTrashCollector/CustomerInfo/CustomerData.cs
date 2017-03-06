using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace KouTrashCollector.CustomerInfo
{
    public class CustomerData
    {
        public int Id { get; set; }

        public string FirstName { get; set; }

        public string LastName { get; set; }

        [Required]
        public int AddressId { get; set; }

        public string EMailAddress { get; set; }


        public int PickUpDayId { get; set; }

        public int MembershipTypeId { get; set; }

        public DateTime StartDate { get; set; }

        public string ConcatAddress { get; set; }
    }
}