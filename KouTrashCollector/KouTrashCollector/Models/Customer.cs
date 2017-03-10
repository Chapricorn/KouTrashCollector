using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace KouTrashCollector.Models
{
    public class Customer
    {
        public int Id { get; set; }
        [Display(Name = "First Name")]
        public string FirstName { get; set; }
        [Display(Name = "Last Name")]
        public string LastName { get; set; }
        [Display(Name = "Street")]
        public string StreetOne { get; set; }


        public City City { get; set; }

        public int CityId { get; set; }

        public State State { get; set; }

        public int StateId { get; set; }

        public Zipcode Zipcode { get; set; }

        public int ZipcodeId { get; set; }

        public string Email { get; set; }

        [Display(Name = "Day Pick Up")]
        public PickUpDay PickUpDay { get; set; }

        public int PickUpDayId { get; set; }
        [Display(Name = "Membership Types")]
        public MembershipType MembershipType { get; set; }

        public int MembershipTypeId { get; set; }
        [Display(Name = "Start Date")]
        public DateTime StartDate { get; set; }

        public string ConcatAddress { get; set; }

        public IEnumerable<Vacation> Vacations { get; set; }
    }
}