using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace KouTrashCollector.Models
{
    public class Customer
    {
        public int Id { get; set; }

        public string FirstName { get; set; }

        public string LastName { get; set; }

        public string StreetOne { get; set; }


        public City City { get; set; }

        public int CityId { get; set; }

        public State State { get; set; }

        public int StateId { get; set; }

        public Zipcode Zipcode { get; set; }

        public int ZipcodeId { get; set; }

        public string Email { get; set; }


        public PickUpDay PickUpDay { get; set; }

        public int PickUpDayId { get; set; }

        public MembershipType MembershipType { get; set; }

        public int MembershipTypeId { get; set; }

        public DateTime StartDate { get; set; }

        public string ConcatAddress { get; set; }

        public IEnumerable<Vacation> Vacations { get; set; }
    }
}