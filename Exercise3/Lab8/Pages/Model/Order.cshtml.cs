using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Data.SqlClient;

namespace Lab8.Pages.Model
{
	public class OrderModel : PageModel
	{
		public List<OrderInfo> listOrder = new List<OrderInfo>();
		public void OnGet()
		{
			try
			{
				String connectionString = "Data Source=(local)\\SQLEXPRESS;Initial Catalog=CreditTask2;Integrated Security=True";

				using (SqlConnection connection = new SqlConnection(connectionString))
				{
					connection.Open();
					String sql = "select * from Orders";
					using (SqlCommand cmd = new SqlCommand(sql, connection))
					{
						using (SqlDataReader reader = cmd.ExecuteReader())
						{
							while (reader.Read())
							{
								OrderInfo OrderInfo = new OrderInfo();
								OrderInfo.OrderID = reader.GetString(0);
								OrderInfo.OrderDate = reader.GetString(1);
								OrderInfo.AgentID = reader.GetString(2);
							
								listOrder.Add(OrderInfo);
							}
						}
					}
				}
			}
			catch (Exception ex)
			{
				Console.WriteLine("Exception: " + ex.ToString());
			}
		}
	}

	public class OrderInfo
	{
		public String? OrderID;
		public String? OrderDate;
		public String? AgentID;
	}
}
