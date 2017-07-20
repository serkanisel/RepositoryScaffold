using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using A.Blog.Entity;
using System.Diagnostics;
using A.Blog.Data.Repository;
using System.Linq;

namespace A.Blog.Data.Test
{
    [TestClass]
    public class ConsumerTests
    {
        private IRepository  _repository;

        [TestInitialize]
        public void Initialise()
        {
            _repository = new BlogRepository();
        }
        [TestMethod]
        public void Query_AllCustomers_NoException()
        {
            var query = _repository.All<Customer>();

            var list = query.ToList();

            foreach (var item in list)
            {
                Trace.TraceInformation("Company Name : {0}", item.CompanyName);
            }

        }

        [TestMethod]
        public void Query_AllCustomersIncludingOrders_NoException()
        {
            var query = _repository.AllIncluding<Customer>(p => p.Orders);

            var list = query.ToList();

            foreach (var item in list)
            {
                Trace.TraceInformation("Company Name : {0}", item.CompanyName);
            }

        }

        [TestMethod]
        public void Query_AllCustomersSelectCompanyNameAndOrderCount_NoException()
        {
            var query = _repository.AllIncluding<Customer>().Select(s => new { s.CompanyName, Count = s.Orders.Count });

            var list = query.ToList();

            foreach (var item in list)
            {
                Trace.TraceInformation("Company Name : {0}", item.CompanyName);
                Trace.TraceInformation("Orders : {0}", item.Count);
            }

        }
    }
}
