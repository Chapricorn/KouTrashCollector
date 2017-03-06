using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using KouTrashCollector.Models;

namespace KouTrashCollector.ViewModel
{
    public class CustomerRoute
    {
        public Worker Worker { get; set; }
        public IEnumerable<Customer> Customers { get; set; }
        public int WorkerZipId { get; set; }
        public int DayOfWeekId { get; set; }
    }
}