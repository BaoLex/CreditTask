using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Data.SqlClient;

namespace Lab8.Pages.Model
{
    public class ItemsModel : PageModel
    {
		public List<ItemInfo> listItem = new List<ItemInfo>();
		public void OnGet()
		{
			try
			{
				String connectionString = "Data Source=(local)\\SQLEXPRESS;Initial Catalog=CreditTask2;Integrated Security=True";

				using (SqlConnection connection = new SqlConnection(connectionString))
				{
					connection.Open();
					String sql = "select * from Item";
					using (SqlCommand cmd = new SqlCommand(sql, connection))
					{
						using (SqlDataReader reader = cmd.ExecuteReader())
						{
							while (reader.Read())
							{
								ItemInfo ItemInfo = new ItemInfo();
								ItemInfo.ItemID = reader.GetString(0);
								ItemInfo.ItemName = reader.GetString(1);
								ItemInfo.Size = reader.GetString(2);
								ItemInfo.Price = reader.GetString(3);
								ItemInfo.Quantity = reader.GetString(4);

								listItem.Add(ItemInfo);
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

	public class ItemInfo
	{
		public String? ItemID;
		public String? ItemName;
		public String? Size;
		public String? Price;
		public String? Quantity;
	}
}
