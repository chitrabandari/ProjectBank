using ProjectBank.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ProjectBank.Controllers
{
    public class TransactionController : Controller
    {
        Context db = new Context();
        // GET: Transaction
        public ActionResult Index()
        {
            return View();
        }
        public ActionResult Deposit(Transaction obj,String btn)
        {
            if (btn == "Deposit")
            {
                var data = db.Transactions.Where(obj1 => obj1.Acno == obj.Acno).FirstOrDefault();
                data.Amount += obj.Amount;
                int msg = db.SaveChanges();

                if (msg == 1)
                {
                    ViewBag.data = "Deposit successful!";
                }
                else
                {
                    ViewBag.data = "Deposit unsuccessful!";
                }
            }
            return View();
        }
    }
}