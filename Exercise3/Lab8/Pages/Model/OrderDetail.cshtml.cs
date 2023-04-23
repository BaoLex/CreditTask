using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Data.SqlClient;

namespace Lab8.Pages.Model
{
    public class OrderDetailModel : PageModel
    {
		public List<OrderDeInfo> listOrderDe = new List<OrderDeInfo>();
		public void OnGet()
		{
			try
			{
				String connectionString = "Data Source=(local)\\SQLEXPRESS;Initial Catalog=CreditTask2;Integrated Security=True";

				using (SqlConnection connection = new SqlConnection(connectionString))
				{
					connection.Open();
					String sql = "select * from OrderDetail";
					using (SqlCommand cmd = new SqlCommand(sql, connection))
					{
						using (SqlDataReader reader = cmd.ExecuteReader())
						{
							while (reader.Read())
							{
								OrderDeInfo OrderDeInfo = new OrderDeInfo();
								OrderDeInfo.ID = reader.GetString(0);
								OrderDeInfo.OrderID = reader.GetString(1);
								OrderDeInfo.ItemID = reader.GetString(2);
								OrderDeInfo.Quantity = reader.GetString(3);
                                OrderDeInfo.UnitAmount = reader.GetString(3);

                                listOrderDe.Add(OrderDeInfo);
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

	public class OrderDeInfo
	{
		public String? ID;
		public String? OrderID;
		public String? ItemID;
		public String? Quantity;
		public String? UnitAmount;
    }
}
