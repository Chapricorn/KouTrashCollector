using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace KouTrashCollector.Models
{
    public class Worker
    {
        public int Id { get; set; }
        [Display(Name = "First Name")]
        public string FirstName { get; set; }
        [Display(Name = "Last Name")]
        public string LastName { get; set; }
        [Display(Name = "Email")]
        public string EmailAddress { get; set; }
        [Display(Name = "Zipcode Territory")]
        public Zipcode ZipcodeTerritory { get; set; }
        [Display(Name = "Zipcode Territory")]
        public int ZipcodeTerritoryId { get; set; }

        public IEnumerable<Customer> CustomerList { get; set; }
    }
}