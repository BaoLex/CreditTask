using CreditTask.Models;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace CreditTask.Controllers
{
	public class AccountController : Controller
	{
		SqlConnection con = new SqlConnection();
		SqlCommand com = new SqlCommand();
		SqlDataReader dr;
		[HttpGet]
		public ActionResult Login()
		{
			return View();
		}
		void connectionString()
		{
			con.ConnectionString = "data source=(local)\\SQLEXPRESS; database=CreditTask2; integrated security= SSPI;";
		}
		[HttpPost]
		public ActionResult Verify(Account acc)
		{
			connectionString();
			con.Open();
			com.Connection = con;
			com.CommandText = "select * from Users where Username ='" + acc.Name + "' and Pass ='" + acc.Pass + "'";
			dr = com.ExecuteReader();
			if (dr.Read())
			{
				con.Close();
				return View("Create");
			}
			else
			{
				con.Close();
				return View("Create");
			}

		}
	}
}