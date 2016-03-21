using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using CatMM.Infrastructure.Singleton;
using NHibernate;
using NHibernate.Cfg;
using CatMM.Domain.Repository.NH;
using System.IO;
using CatMM.Domain.User;
using HibernatingRhinos.Profiler.Appender.NHibernate;
using System.Collections.Generic;

namespace CatMM.NHibernate.Test
{
    [TestClass]
    public class UnitTest1
    {
        public ISessionFactory SessionFactory
        {
            get
            {
                if (Singleton<ISessionFactory>.Instance == null)
                {

                    string cfgPath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "hibernate.cfg.xml");
                    Singleton<ISessionFactory>.Instance = (new Configuration()).Configure().BuildSessionFactory();
                    NHibernateProfiler.Initialize();
                }
                return Singleton<ISessionFactory>.Instance;
            }
        }

        private ISession _session;

        public ISession Session
        {
            get
            {
                if (_session == null)
                {
                    _session = SessionFactory.OpenSession();
                }
                return _session;
            }
        }

        [TestMethod]
        public void TestMethod1()
        {
            CustomerRepository repository = new CustomerRepository(Session);
            List<Customer> customers = new List<Customer>();
            for (int i = 0; i < 1000; i++)
            {
                customers.Add(new Customer
                {
                    FirstName = String.Format("huang_{0}", i),
                    LastName = string.Format("qing_{0}", i)
                });
            }
            repository.Insert(customers);
            Session.Flush();
        }
        
        [TestMethod]
        public void Query()
        {
            CustomerRepository repository = new CustomerRepository(Session);
            

        }
    }
}
