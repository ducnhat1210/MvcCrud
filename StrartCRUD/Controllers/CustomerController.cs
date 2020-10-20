using StrartCRUD.DataAccess;
using StrartCRUD.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace StrartCRUD.Controllers
{
    public class CustomerController : Controller
    {
        // GET: CustomerController
        public ActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public ActionResult InsertCustomer()
        {
            return View();
        }

        [HttpPost]
        public ActionResult InsertCustomer(Customer customer)
        {
            customer.Birthdate = Convert.ToDateTime(customer.Birthdate);
            if (ModelState.IsValid)
            {
                DataAccessLayer objDB = new DataAccessLayer();
                string resust = objDB.Insertdata(customer);
                TempData["result1"] = resust;
                ModelState.Clear();
                return RedirectToAction("ShowAll");
            }
            else
            {
                ModelState.AddModelError("", "Loi");
                return View();
            }        
        }

        [HttpGet]
        public ActionResult ShowAll()
        {
            Customer cus = new Customer();
            DataAccessLayer objDB = new DataAccessLayer();
            cus.ShowallCustomer = objDB.SelectAllData();
            return View(cus);
        }

        [HttpGet]
        public ActionResult Detail(string ID)
        {
            Customer objCustomer = new Customer();
            DataAccessLayer objDB = new DataAccessLayer();  
            return View(objDB.SelectDatabyID(ID));
        }

        [HttpGet]
        public ActionResult Update(string ID)
        {
            Customer cus = new Customer();
            DataAccessLayer objDB = new DataAccessLayer();
            return View(objDB.SelectDatabyID(ID));
        }

        [HttpPost]
        public ActionResult Update(Customer customer)
        {
            customer.Birthdate = Convert.ToDateTime(customer.Birthdate);
            if (ModelState.IsValid)
            {
                DataAccessLayer objDB = new DataAccessLayer();
                string result = objDB.Update(customer);
                TempData["result2"] = result;
                ModelState.Clear();
                return RedirectToAction("ShowAll");
            }
            else
            {
                ModelState.AddModelError("", "Loi");
                return View();
            }
        }

        [HttpGet]
        public ActionResult Delete(string ID)
        {
            DataAccessLayer objDB = new DataAccessLayer();
            int result = objDB.Delete(ID);
            TempData["result3"] = result;
            ModelState.Clear();
            return RedirectToAction("ShowAll");
        }
    }
}