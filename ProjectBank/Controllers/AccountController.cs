using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
//using System.Web.Http;
using System.Web.Mvc;
//using Microsoft.Ajax.Utilities;
using ProjectBank.Models;

namespace ProjectBank.Controllers
{
    public class AccountController : Controller
    {
        Account account = new Account();
        Context db = new Context();
        // GET: Account
        public ActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Index(Account obj,String btn)
        {
            if(btn=="Deposit")
            {
                var data = db.Accounts.Where(obj1=>obj1.Acno==obj.Acno).FirstOrDefault();
                data.Amount += obj.Amount;
                int msg=db.SaveChanges();

                    if (msg == 1)
                    {
                        ViewBag.data = "Deposit successful!";
                    }
                    else
                    {
                        ViewBag.data = "Deposit unsuccessful!";
                    }
            }
            else if(btn== "Withdraw")
            {
                var data = db.Accounts.Where(obj1 => obj1.Acno == obj.Acno).FirstOrDefault();

                if (obj.Amount <= data.Amount)
                {
                    data.Amount -= obj.Amount;
                    int msg= db.SaveChanges();
                    if(msg==1)
                    {
                        ViewBag.data = "Withdraw successful!";
                    }
                    else
                    {
                        ViewBag.data = "Withdraw unsuccessful!";
                    }

                }
                else
                {
                    ViewBag.data = "Insufficent Balance";
                }
               
            }
            else if(btn=="Balance")
            {
                var data = db.Accounts.Where(obj1 => obj1.Acno==obj.Acno).FirstOrDefault();
                ViewBag.show = data.Amount;

            }
            return View();
        }
       
    }
}