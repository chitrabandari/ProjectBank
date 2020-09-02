using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Web.Http.Results;
using ProjectBank.Controllers;
using ProjectBank.Models;
using System.Web.Http;
using System.Web.Mvc;
using System.ComponentModel;
//using ProjectBank.Tests;

namespace ProjectBank.Tests
{
    [TestClass]
    public class UnitTest1
    {
        /*[TestMethod]
        public void Create_Customer()
        {

            Customer cust = new Customer("chitra", "chitra", "chitra", 10001, 9100531489, 21, "warangal", "02-11-1998 00:00:00", 20000);
            int output = cust.Name;

            Assert.AreEqual(output, "chitra");

        }*/
        
        [TestMethod]
        public void Details_Check()
        {
            var controller = new CustomerController();
            var result = controller.Details(1) as ViewResult;
            Assert.AreEqual("Details", result.ViewName);
            //Assert.IsInstanceOfType(result, typeof(NotFoundResult));
            //Assert.IsNotNull(result);
        }

        [TestMethod]
        public void Delete_Check()
        {
            var controller = new CustomerController();
            var result = controller.Delete(100) as ViewResult;
            Assert.AreNotEqual("Delete", result.ViewName);
        }

        [TestMethod]
        public void Get_Balance()
        {
            float expected = 700;
            Account account = new Account();
            float output = account.Amount;
            float actual = account.Amount;
            Assert.AreNotEqual(expected, actual, output);
            Assert.AreNotEqual(output, 1000);
        }

        // Account Accounts = new Account(10001, 1234568);
        /*[TestMethod]
        public void GetAllAccounts_ShouldReturnAllAccounts()
        {
            var testAccounts = GetTestAccounts();
            var controller = new AccountController(testAccounts);

            var result = controller.GetAllAccounts() as List<Account>;
            Assert.AreEqual(testAccounts.Count, result.Count);
        }

        [TestMethod]
        public async Task GetAllProductsAsync_ShouldReturnAllProducts()
        {
            var testProducts = GetTestProducts();
            var controller = new AccountController(testAccounts);

            var result = await controller.GetAllProductsAsync() as List<Product>;
            Assert.AreEqual(testProducts.Count, result.Count);
        }

        [TestMethod]
        public void GetProduct_ShouldReturnCorrectProduct()
        {
            var testProducts = GetTestProducts();
            var controller = new SimpleProductController(testProducts);

            var result = controller.GetProduct(4) as OkNegotiatedContentResult<Product>;
            Assert.IsNotNull(result);
            Assert.AreEqual(testProducts[3].Name, result.Content.Name);
        }

        [TestMethod]
        public async Task GetProductAsync_ShouldReturnCorrectProduct()
        {
            var testProducts = GetTestProducts();
            var controller = new SimpleProductController(testProducts);

            var result = await controller.GetProductAsync(4) as OkNegotiatedContentResult<Product>;
            Assert.IsNotNull(result);
            Assert.AreEqual(testProducts[3].Name, result.Content.Name);
        }

        [TestMethod]
        public void GetAccount_ShouldNotFindProduct()
        {
            var controller = new AccountController(GetTestAccounts());

            var result = controller.GetTestAccounts(999);
            Assert.IsInstanceOfType(result, typeof(NotFoundResult));
        }

    private List<Account> GetTestAccounts()
    {
        var testProducts = new List<Account>();
        testProducts.Add(new Account { Id = 1, Acno = 1001, Amount = 2000 });
        testProducts.Add(new Account { Id = 2, Acno = 1002, Amount = 1000 });
        testProducts.Add(new Account { Id = 3, Acno = 1003, Amount = 30000 });
        testProducts.Add(new Account { Id = 4, Acno = 1004, Amount = 40000 });

        return testProducts;
    }
*/
        /*[TestMethod()]
        [DeploymentItem("Courses.sdf")]
        public void RemoveCourseConfirmedTest()
        {

            CoursesController target = new CoursesController();
            int id = 50;

            ActionResult actual;
            CoursesDBContext db = new CoursesDBContext();
            Course courseToDelete = db.Courses.Find(id);
            List<CourseMeet> meets = db.Meets.Where(a => a.courseID == id).ToList();
            actual = target.RemoveCourseConfirmed(courseToDelete);
            foreach (CourseMeet meet in meets)
            {
                Assert.IsFalse(db.Meets.Contains(meet));
            }
            Assert.IsFalse(db.Courses.Contains(courseToDelete));

        }*/
    }
}
