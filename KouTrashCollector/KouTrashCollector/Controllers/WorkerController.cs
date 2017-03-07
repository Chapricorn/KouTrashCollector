using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;
using System.Web.Mvc;
using KouTrashCollector.Models;
using KouTrashCollector.ViewModel;
using System.Net;

namespace KouTrashCollector.Controllers
{
    public class WorkerController : Controller
    {

        private ApplicationDbContext _context;
        public WorkerController()
        {
            _context = new ApplicationDbContext();

        }
        protected override void Dispose(bool disposing)
        {
            _context.Dispose();
        }
        // GET: Worker
        public ActionResult Index()
        {
            var workers = _context.Workers.Include(m => m.ZipcodeTerritory).ToList();
            return View(workers);
        }
        public ActionResult DoWRoute(int id, int zipId)
        {
            var customerZipList = _context.Customers.Include(m => m.Zipcode).Include(d => d.PickUpDay).ToList();

            var temporaryCustomerList2 = new List<Customer>();



            foreach (var customer in customerZipList)
            {
                if (customer.ZipcodeId == zipId && customer.PickUpDayId == id)
                {
                    temporaryCustomerList2.Add(customer);
                }
            }

            return View("Route", temporaryCustomerList2);
        }
        public ActionResult DoWTerritory(int id, int zipId)
        {
            var customerZipList = _context.Customers.Include(m => m.Zipcode).Include(c => c.City).Include(s => s.State).Include(d => d.PickUpDay).ToList();

            var customers = customerZipList;
            var customerz = new List<Customer>();
            foreach (var customer in customers)
            {
                if (customer.ZipcodeId == zipId && customer.PickUpDayId == id)
                {
                    customerz.Add(customer);
                }
            }
            customers = customerZipList;

            Worker temporaryWorker = new Worker();
            temporaryWorker.CustomerList = customers;

            var viewModel = new CustomerRoute
            {
                DayOfWeekId = id,
                Customers = customerz,
                WorkerZipId = zipId
            };



            return View("CustomerSameZipCode", viewModel);
        }
        public ActionResult Route(int id)
        {
            var customerZipList = _context.Customers.Include(m => m.Zipcode).ToList();

            var temporaryCustomerList2 = new List<Customer>();



            foreach (var customer in customerZipList)
            {
                if (customer.ZipcodeId == id)
                {
                    temporaryCustomerList2.Add(customer);
                }
            }

            return View(temporaryCustomerList2);
        }

        public ActionResult Territory(Zipcode zipId, Worker id)
        {
            var customerZipList = _context.Customers.Include(m => m.Zipcode).Include(c => c.City).Include(s => s.State).Include(d => d.PickUpDay).ToList();

            var customers = customerZipList;
            var customerz = new List<Customer>();
            foreach (var customer in customers)
            {
                if (customer.ZipcodeId == zipId.Id)
                {
                    customerz.Add(customer);
                }
            }
            customers = customerZipList;

            Worker temporaryWorker = new Worker();
            temporaryWorker.CustomerList = customers;

            var viewModel = new CustomerRoute
            {

                Customers = customerz,
                WorkerZipId = zipId.Id
            };


            //customer.ConcatAddress = customer.Address.StreetOne + " " + customer.Address.StreetTwo + " " + customer.Address.City.CityName + "," + customer.Address.State.StateName + " " + customer.Address.Zipcode.ZipcodeNum;
            return View("Territory", viewModel);
        }
        public ActionResult New()
        {
            var zipcode = _context.Zipcodes.ToList();
            var viewModel = new WorkerForm
            {
                Worker = new Worker(),
                ZipCodes = zipcode,

            };
            return View("WorkerForm", viewModel);
        }
        public ActionResult Edit(int id)
        {
            var worker = _context.Workers.SingleOrDefault(c => c.Id == id);

            if (worker == null)
                return HttpNotFound();
            var viewModel = new WorkerForm
            {
                Worker = worker,
                ZipCodes = _context.Zipcodes
            };
            return View("WorkerForm", viewModel);
        }

        [HttpPost]
        public ActionResult Save(Worker worker)
        {
            //if (!ModelState.IsValid)
            //{
            //    var viewModel = new WorkerFormViewModel
            //    {
            //        Worker = worker,
            //        ZipCodes = _context.Zipcodes.ToList(),                                   
            //    };

            //    return View("WorkerForm", viewModel);
            //}

            if (worker.Id == 0)
                _context.Workers.Add(worker);
            else
            {
                var workerInDb = _context.Workers.Include(m => m.ZipcodeTerritory).Single(c => c.Id == worker.Id);

                /*TryUpdateModel(workerInDb); */  //Malicious users can mess-up database
                workerInDb.FirstName = worker.FirstName;
                workerInDb.LastName = worker.LastName;
                //customerInDb.Address = customer.Address;
                //customerInDb.Address.City = customer.Address.City;
                workerInDb.ZipcodeTerritoryId = worker.ZipcodeTerritoryId;
                //customerInDb.Address.StateId = customer.Address.StateId;
                //customerInDb.DayOfWeekPickUpId = customer.DayOfWeekPickUpId;
                //customerInDb.MembershipTypeId = customer.MembershipTypeId;
                //customerInDb.IsCurrentCustomer = customer.IsCurrentCustomer;
                //customerInDb.StartDate = customer.StartDate;
                //customerInDb.EMailAddress = customer.EMailAddress;
                //Or use AutoMapper
            }
            _context.SaveChanges();
            return RedirectToAction("Index", "Worker");
        }

        public ActionResult EditWorker(int id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Worker worker = _context.Workers.Find(id);
            if (worker == null)
            {
                return HttpNotFound();
            }
            return View(worker);
        }

        // POST: Workers/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult EditWorker([Bind(Include = "Id,FirstName,LastName,ZipcodeTerritory,EmailAddress")] Worker worker)
        {
            if (ModelState.IsValid)
            {
                _context.Entry(worker).State = EntityState.Modified;
                _context.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(worker);
        }

        // GET: Workers/Delete/5
        public ActionResult Delete(int id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Worker worker = _context.Workers.Find(id);
            if (worker == null)
            {
                return HttpNotFound();
            }
            return View(worker);
        }

        // POST: Workers/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Worker worker = _context.Workers.Find(id);
            _context.Workers.Remove(worker);
            _context.SaveChanges();
            return RedirectToAction("Index");
        }






        //// POST: Admin/Edit/5
        //// To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        //// more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        //[HttpPost]
        //[ValidateAntiForgeryToken]
        //public ActionResult EditAdmin([Bind(Include = "Id,FirstName,LastName,ZipcodeTerritory,EmailAddress")] Admin admin)
        //{
        //    if (ModelState.IsValid)
        //    {
        //        _context.Entry(admin).State = EntityState.Modified;
        //        _context.SaveChanges();
        //        return RedirectToAction("Index");
        //    }
        //    return View(admin);
        //}

        //// GET: Admin/Delete/5
        //public ActionResult Delete(int id)
        //{
        //    if (id == null)
        //    {
        //        return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
        //    }
        //    Admin admin = _context.Admins.Find(id);
        //    if (admin == null)
        //    {
        //        return HttpNotFound();
        //    }
        //    return View(admin);
        //}

        //// POST: Admin/Delete/5
        //[HttpPost, ActionName("Delete")]
        //[ValidateAntiForgeryToken]
        //public ActionResult DeleteConfirmed(int id)
        //{
        //    Worker admin = _context.Admins.Find(id);
        //    _context.Admins.Remove(admin);
        //    _context.SaveChanges();
        //    return RedirectToAction("Index");
        //}

    }
}


