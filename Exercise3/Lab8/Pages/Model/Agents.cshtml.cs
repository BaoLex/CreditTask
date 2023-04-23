using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Data.SqlClient;

namespace Lab8.Pages.Model
{
    public class AgentsModel : PageModel
    {
		public List<AgentsInfo> listAgent = new List<AgentsInfo>();
		public void OnGet()
		{
			try
			{
				String connectionString = "Data Source=(local)\\SQLEXPRESS;Initial Catalog=CreditTask2;Integrated Security=True";

				using (SqlConnection connection = new SqlConnection(connectionString))
				{
					connection.Open();
					String sql = "select * from Agent";
					using (SqlCommand cmd = new SqlCommand(sql, connection))
					{
						using (SqlDataReader reader = cmd.ExecuteReader())
						{
							while (reader.Read())
							{
								AgentsInfo AgentsInfo = new AgentsInfo();
								AgentsInfo.AgentID = reader.GetString(0);
								AgentsInfo.AgentName = reader.GetString(1);
								AgentsInfo.Address = reader.GetString(2);

								listAgent.Add(AgentsInfo);
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

	public class AgentsInfo
	{
		public String? AgentID;
		public String? AgentName;
		public String? Address;
	}
}
