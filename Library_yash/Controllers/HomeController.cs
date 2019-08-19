using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Library_yash.Models;
using System.Data.SqlClient;

namespace Library_yash.Controllers
{
    public class HomeController : Controller
    {
        SqlConnection con = new SqlConnection();
        SqlCommand com = new SqlCommand();
        SqlDataReader dr;

        public ActionResult Welcome()
        {
            return View();
        }
        public ActionResult Error()
        {
            return View();
        }
        public ActionResult Index()
        {
            return View();
        }
        //[HttpPost]
        //public ActionResult Index()
        //{
        //    return View();
        //}
        [HttpGet]
        public ActionResult Login()
        {
            return View();
        }
        void connectionString()
        {
            con.ConnectionString = "data source=YH1008656DT;initial catalog=Library_yash;integrated security=True;multipleactiveresultsets=True;application name=EntityFramework&quot;";
        }
        
        [HttpPost]
        public ActionResult Login(Register log)
        {

            connectionString();
            con.Open();
            com.Connection = con;
            com.CommandText = "select * from Registers where UserName='"+log.UserName+"' and Password='"+log.Password+"'";
            dr = com.ExecuteReader();
            if(dr.Read())
            {
                con.Close();
                return View("Welcome");
            }
            else
            {
                con.Close();
                return View("Error");
            }
           
            
        }
       
       


        public ActionResult Register()
        {
            return View();
        }




       
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Register(Register obj)
        {
            if (ModelState.IsValid)
            {
                using (Library_yashEntities dc = new Library_yashEntities())
                {
                    dc.Registers.Add(obj);
                    dc.SaveChanges();
                    ModelState.Clear();
                    obj = null;
                    ViewBag.Message = "Successfully Registration Done";
                }
            }
            return View(obj);
        }



    }
}