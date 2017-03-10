using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace KouTrashCollector.Models
{
    public class Zipcode
    {
        public int Id { get; set; }
        [Display(Name = "Zipcode Territory")]
        public string ZipcodeNum { get; set; }
    }
}