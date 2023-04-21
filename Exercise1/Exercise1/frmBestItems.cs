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
    public partial class frmBestItems : Form
    {
        public frmBestItems()
        {
            InitializeComponent();
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void frmBestItems_Load(object sender, EventArgs e)
        {
            String strConn = ConfigurationManager.ConnectionStrings["MyConn"].ConnectionString;
            SqlConnection conn = new SqlConnection(strConn);
            conn.Open();

            String sSQL = "SELECT I.ItemID, I.ItemName, I.Size, I.Quantity, I.Price, COUNT(O.ItemID) as TimesPurchased FROM Item I JOIN OrderDetail O ON I.ItemID = O.ItemID GROUP BY I.ItemID, I.ItemName, I.Size, I.Quantity, I.Price ORDER BY COUNT(O.ItemID) DESC";
            SqlCommand cmd = new SqlCommand(sSQL, conn);
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            da.Fill(dt);
            if(dt.Rows.Count > 0)
            {
                dataGridView1.DataSource = dt;
            }
            else
            {
                MessageBox.Show("Error");
            }
        }
    }
}
