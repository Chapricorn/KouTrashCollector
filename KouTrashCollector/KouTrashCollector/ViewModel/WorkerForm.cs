using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using KouTrashCollector.Models;
namespace KouTrashCollector.ViewModel
{
    public class WorkerForm
    {
        public Worker Worker { get; set; }
        public IEnumerable<Zipcode> ZipCodes { get; set; }
    }
}