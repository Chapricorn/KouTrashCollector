using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using KouTrashCollector.Models;
using AutoMapper;
using KouTrashCollector.CustomerInfo;

namespace KouTrashCollector.Controllers.API
{
    public class CustomersController : ApiController
    {
        private ApplicationDbContext _context;

        public CustomersController()
        {
            _context = new ApplicationDbContext();
        }
        public IEnumerable<CustomerData> GetCustomers()
        {
            return _context.Customers.ToList().Select(Mapper.Map<Customer, CustomerData>);

        }

        public CustomerData GetCustomer(int id)
        {
            var customer = _context.Customers.SingleOrDefault(c => c.Id == id);

            if (customer == null)
            //throw new HttpRequestException(HttpStatusCode.BadRequest);
            {
                var message = string.Format("Product with id = {0} not found", id);
                HttpError err = new HttpError(message);
                Request.CreateResponse(HttpStatusCode.NotFound, err);
            }

            return Mapper.Map<Customer, CustomerData>(customer);

        }

        [HttpPost]
        public CustomerData CreateCustomer(CustomerData customerdata)
        {
            if (!ModelState.IsValid)
                throw new HttpResponseException(HttpStatusCode.BadRequest);

            var customer = Mapper.Map<CustomerData, Customer>(customerdata);
            _context.Customers.Add(customer);
            _context.SaveChanges();

            customerdata.Id = customer.Id;

            return customerdata;
        }
        [HttpPut]
        public void UpdateCustomer(int id, CustomerData customerDto)
        {
            if (!ModelState.IsValid)
                throw new HttpResponseException(HttpStatusCode.BadRequest);

            var customerInDb = _context.Customers.SingleOrDefault(c => c.Id == id);

            if (customerInDb == null)
            {
                var message = string.Format("Product with id = {0} not found", id);
                HttpError err = new HttpError(message);
                Request.CreateResponse(HttpStatusCode.NotFound, err);
            }

            Mapper.Map/*<CustomerDto, Customer>*/(customerDto, customerInDb);


            _context.SaveChanges();
        }
        [HttpDelete]
        public void DeleteCustomer(int id)
        {
            var customerInDb = _context.Customers.SingleOrDefault(c => c.Id == id);

            if (customerInDb == null)
            {
                var message = string.Format("Product with id = {0} not found", id);
                HttpError err = new HttpError(message);
                Request.CreateResponse(HttpStatusCode.NotFound, err);
            }

            _context.Customers.Remove(customerInDb);
            _context.SaveChanges();
        }
    }
}