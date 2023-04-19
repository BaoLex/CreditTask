using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Exercise1
{
    public partial class frmAddAgent : Form
    {
        public frmAddAgent()
        {
            InitializeComponent();
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            String strConn = ConfigurationManager.ConnectionStrings["MyConn"].ConnectionString;
            SqlConnection conn = new SqlConnection(strConn);
            conn.Open();

            String sSQL = "INSERT INTO Agent (AgentID, AgentName, Address) VALUES (@AgentID, @AgentName, @Address)";
            SqlCommand cmd = new SqlCommand(sSQL, conn);

            cmd.Parameters.Add(new SqlParameter("@AgentID", txtAgentID.Text));
            cmd.Parameters.Add(new SqlParameter("@AgentName", txtAgentName.Text));
            cmd.Parameters.Add(new SqlParameter("@Address", txtAddress.Text));

            try
            {
                cmd.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                throw new Exception("Error: " + ex.Message);
            }
            MessageBox.Show("Add agent successfully!");
        }
    }
}
