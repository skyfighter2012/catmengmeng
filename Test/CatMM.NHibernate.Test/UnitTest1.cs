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

        }

        [TestMethod]
        public void QueryStudent()
        {

        }


        [TestMethod]
        public void QueryOneToOne()
        {
            var teacher = new Teacher
            {
                Name = "王老师",
            };

            var cls = new Class
            {
                Name = "班级1",
                Teacher = teacher
            };


            Session.Save(cls);
            Session.Flush();
        }

        [TestMethod]
        public void OneToManySaveTest()
        {
            using (Session)
            {
                var teacher = new Teacher
                {
                    Name = "老王哈"
                };

                var liu = new Student { Name = "刘冬" };
                var zhang = new Student { Name = "张三" };

                var cls = new Class { Name = "1班", Teacher = teacher };
                cls.Students = new List<Student> { liu, zhang };
                liu.Class = cls;
                zhang.Class = cls;
                ITransaction tran = Session.BeginTransaction();
                try
                {
                    Session.Save(cls);
                    tran.Commit();
                }
                catch (Exception ex)
                {
                    tran.Rollback();
                    throw ex;
                }
            }
        }

        [TestMethod]
        public void QueryOneToManySaveTest()
        {
            using (Session)
            {
                var cls = Session.Query<Class>().First();
                if (cls != null)
                {
                    cls.Students.ToList().ForEach(it =>
                    {
                        Console.WriteLine(String.Format("班级：{0}，姓名：{1}", cls.Name, it.Name));
                    });
                }
            }
        }


        [TestMethod]
        public void SaveManyToManySaveTest()
        {
            using (Session)
            {
                //var role1 = new Role { Name = "Admin" };
                //var role2 = new Role { Name = "Customer" };
                //var role3 = new Role { Name = "Manager" };

                //var user1 = new Customer
                //{
                //    Name = "张三",
                //    Roles = new List<Role> { role1, role2 }
                //};
                //var user2 = new Customer
                //{
                //    Name = "李四",
                //    Roles = new List<Role> { role2, role3 }
                //};

                //ITransaction tran = Session.BeginTransaction();
                //try
                //{

                //    Session.Save(user1);
                //    Session.Save(user2);

                //    tran.Commit();
                //}
                //catch (Exception ex)
                //{
                //    tran.Rollback();
                //    throw ex;
                //}
            }
        }

        [TestMethod]
        public void UpdateManyToManySaveTest()
        {
            using (Session)
            {
                //var role1 = new Role { Name = "Admin" };

                //ITransaction tran = Session.BeginTransaction();
                //var customer = Session.Query<Customer>().FirstOrDefault();
                //customer.Roles.Clear();
                //customer.Roles.Add(role1);
                //try
                //{
                //    Session.Update(customer);             
                //    tran.Commit();
                //}
                //catch (Exception ex)
                //{
                //    tran.Rollback();
                //    throw ex;
                //}
            }
        }

        [TestMethod]
        public void Test123()
        {
            using (Session)
            {
                //var customer = new Customer
                //{
                //    Name = "黄"
                //};

                //var role = new Role
                //{
                //    Name = "Admin"
                //};

                //var customerRole = new CustomerRole()
                //{
                //    Role = role,
                //    Customer = customer
                //};

                //customer.CustomerRoles = new List<CustomerRole> { customerRole };
                //Session.Save(role);
                //Session.Save(customer);

                //Session.Flush();
            }
        }

        [TestMethod]
        public void TestComponent()
        {
            var product = new Product
            {
                Name = new Name
                {
                    FirstName="",
                    MiddleName="qing",
                    LastName="lu"
                }
            };

            Session.Save(product);
            Session.Flush();
        }

        [TestMethod]
        public void QueryComponent()
        {
            var pro = Session.CreateCriteria<Product>()
                           .SetMaxResults(1)
                           .List<Product>()
                           .FirstOrDefault();

            Console.WriteLine(pro.Name.FullName);
        }
    }
}
