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
using System.Linq;
using NHibernate.Linq;
using NHibernate.Criterion;

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
        public void Test()
        {
            //ICriteria crt = Session.CreateCriteria<Customer>();
            //crt.SetProjection(Projections.Property<Customer>(it => it.FirstName));
            //crt.AddOrder(Order.Desc("FirstName"));
            //var list = crt.List<string>();
            //list.ToList().ForEach(it =>
            //{
            //    Console.WriteLine(it);
            //});
            var cls = new Class { Name = "1班" };

            var liu = new Student { Name = "刘冬", Class = cls };
            var zhang = new Student { Name = "test", Class = cls };

            ITransaction tran = Session.BeginTransaction();
            try
            {
                Session.Save(liu);
                Session.Save(zhang);
                tran.Commit();
            }
            catch (Exception ex)
            {
                tran.Rollback();
                throw ex;
            }
        }
    }
}
