using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace KouTrashCollector.Models
{
    public class Vacation
    {
        public int Id { get; set; }

        public Customer Customer { get; set; }

        public int CustomerId { get; set; }

        [DisplayFormat(DataFormatString = "{0:dd MM yyyy}")]
        public DateTime? StartVacation { get; set; }

        [DisplayFormat(DataFormatString = "{0:dd MM yyyy}")]
        public DateTime? EndVacation { get; set; }
    }
}