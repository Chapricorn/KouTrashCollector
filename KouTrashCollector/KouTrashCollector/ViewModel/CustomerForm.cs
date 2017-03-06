using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using KouTrashCollector.Models;

namespace KouTrashCollector.ViewModel
{
    public class CustomerForm
    {
        public IEnumerable<MembershipType> MembershipTypes { get; set; }
        public Customer Customer { get; set; }
        public IEnumerable<City> Cities { get; set; }
        public IEnumerable<State> States { get; set; }
        public IEnumerable<Zipcode> Zipcodes { get; set; }
        public IEnumerable<PickUpDay> PickUpDays { get; set; }
        public Vacation Vacation { get; set; }
    }
}