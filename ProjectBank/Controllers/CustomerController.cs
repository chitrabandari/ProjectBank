using System;
using System.CodeDom;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Configuration;
using System.Data.Entity;
using System.Linq;
using System.Net;
//using System.Runtime.Remoting.Contexts;
using System.Web;
using System.Web.Mvc;
using Newtonsoft.Json.Linq;
//using Microsoft.Ajax.Utilities;
//using Microsoft.Ajax.Utilities;
using ProjectBank.Models;

namespace ProjectBank.Controllers
{
    public class CustomerController : Controller
    {
        // GET: Customer
        /* public ActionResult Index()
         {
             return View();
         }*/
        [HandleError]
        public ActionResult Exception()
        {
            throw new Exception("Something Went Wrong");
        }
        private Context db = new Context();

        // GET: Students
        public ActionResult Index()
        {
            return View(db.Customers.ToList());
        }

        // GET: Students/Details/5
        //[HttpGet]
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Customer customer = db.Customers.Find(id);
            if (customer == null)
            {
                return HttpNotFound();
            }
            return View(customer);
        }

        // GET: Students/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Students/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,Name,Password,RetypePassword,Acno,Phoneno,Age,Address,Dob,IniAmount")] Customer customer)
        {
            if (ModelState.IsValid)
            {
                db.Customers.Add(customer);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(customer);
        }

        // GET: Students/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Customer customer = db.Customers.Find(id);
            if (customer == null)
            {
                return HttpNotFound();
            }
            return View(customer);
        }

        // POST: Students/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,Name,Password,RetypePassword,Acno,Phoneno,Age,Address,Dob,IniAmount")] Customer customer)
        {
            if (ModelState.IsValid)
            {
                db.Entry(customer).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(customer);
        }

        // GET: Students/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Customer customer = db.Customers.Find(id);
            if (customer == null)
            {
                return HttpNotFound();
            }
            return View(customer);
        }

        // POST: Students/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Customer customer = db.Customers.Find(id);
            db.Customers.Remove(customer);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        [HttpGet]
        public ActionResult Login(Customer obj,String btn)
        {
            /*if (btn == "Login")
            {
                var data = db.Customers.Where(obj1 => obj1.Name == obj.Name && obj1.Password == obj.Password).FirstOrDefault();

                var data = db.Customers.Where(obj1 => obj1.Name == obj.Name).FirstOrDefault();
                var data1 = db.Customers.Where(obj2 => obj2.Password == obj.Password).FirstOrDefault();
                data.Name = obj.Name;
                data1.Password = obj.Password;
                int msg = db.SaveChanges();
                if (data != null)
                {
                    Session["Name"] = obj.Name;
                    //return RedirectToAction("Account/Index");
                    ViewBag.Status = "Login successful!";
                }
                else
                {
                    ViewBag.Status = "Username or Password is incorrect";
                }
            else
                {
                    //ViewBag.data("Invalid");
                }*/
           
            return View();
        }


       /* [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Login(Customer obj)
        {
            if(ModelState.IsValid)
            {
                using(Context db=new Context())
                {
                    var data= db.Customers.Where(a => a.Name.Equals(obj.Name) && a.Password.Equals(obj.Password)).FirstOrDefault();
                    if(data!=null)
                    {
                        Session["Name"] = data.Name;
                        Session["Password"] = data.Password;
                        return RedirectToAction("Account/Index");
                    }
                }
            }
            return View(obj);

        }*/
       [HttpGet]
       public ActionResult Login1(Customer obj)
        {
            var data = db.Customers.Where(obj1 => obj1.Name == obj.Name && obj1.Password == obj.Password).FirstOrDefault();
            if(data!=null)
            {
                ViewBag.Status = "CORRECT UserNAme and Password";
            }
            else
            {
                ViewBag.Status = "INCORRECT UserName or Password";
            }
            return View(obj);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
        public JsonResult SendOTP()
        {
            int otpValue = new Random().Next(100000, 999999);
            var status = "";
            try
            {
                string recipient = ConfigurationManager.AppSettings["RecipientNumber"].ToString();
                string APIKey = ConfigurationManager.AppSettings["APIKey"].ToString();

                string message = "Your OTP Number is" + otpValue + "(Sent by: I BANK)";
                string encodedMessage = HttpUtility.UrlEncode(message);

                using (var webClient = new WebClient())
                {
                    byte[] response = webClient.UploadValues("https://api.textlocal.in/send/", new NameValueCollection(){
                        {"apikey",APIKey },
                        {"numbers",recipient },
                        {"message",encodedMessage },
                        {"sender","TXTLCL" } });
                     string result = System.Text.Encoding.UTF8.GetString(response);

                     var jsonObject = JObject.Parse(result);

                     status = jsonObject["status"].ToString();

                    Session["CurrentOTP"] = otpValue;
                }
                return Json(status, JsonRequestBehavior.AllowGet);

            }
            catch(Exception e)
            {
                throw (e);
            }

            
        }
        public ActionResult EnterOTP()
        {
            return View();
        }

        [HttpPost]
        public JsonResult VerifyOTP(string otp)
        {
            bool result = false;
            string sessionOTP = Session["CurrentOTP"].ToString();
            if(otp== sessionOTP)
            {
                result = true;
            }
            return Json(result, JsonRequestBehavior.AllowGet);
        }
    }
}