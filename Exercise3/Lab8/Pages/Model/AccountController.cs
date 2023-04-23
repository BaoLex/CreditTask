using Microsoft.AspNetCore.Mvc;
using System.Data.SqlClient;

namespace Lab8.Pages.Model
{
    public class AccountController : Controller
    {
        SqlConnection con = new SqlConnection();
        SqlCommand com = new SqlCommand();
        SqlDataReader dr;
        [HttpGet]
        public IActionResult Login()
        {
            return View();
        }
        void connectionString()
        {
            con.ConnectionString = "data source=(local)\\SQLEXPRESS; database=CreditTask2; integrated security= SSPI;";
        }
        public IActionResult Verify(Account acc)
        {
            connectionString();
            con.Open();
            com.Connection = con;
            com.CommandText = "select * from Users where Username ='" + acc.Name + "' and Pass ='" + acc.Pass + "'";
            dr = com.ExecuteReader();
            if (dr.Read())
            {
                con.Close();
                return View();
            }
            else
            {
                con.Close();
                return View();
            }
        }
    }

    public class Account
    {
        public string Name { get; set; }
        public string Pass { get; set; }
    }
}
