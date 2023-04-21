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
    public partial class frmOrder : Form
    {
        public frmOrder()
        {
            InitializeComponent();
        }

        private void frmOrder_Load(object sender, EventArgs e)
        {
            
        }

        private void btnView_Click(object sender, EventArgs e)
        {
            String strConn = ConfigurationManager.ConnectionStrings["MyConn"].ConnectionString;
            SqlConnection conn = new SqlConnection(strConn);
            conn.Open();

            String sSQL1 = "SELECT OrderDate, AgentID FROM Orders WHERE OrderID = '" + txtOrderID.Text + "'";
            String sSQL2 = "SELECT ID, ItemID, Quantity, UnitAmount FROM OrderDetail WHERE OrderID = '" + txtOrderID.Text + "'";

            SqlCommand cmd1= new SqlCommand(sSQL1, conn);
            SqlDataAdapter da1 = new SqlDataAdapter(cmd1);
            DataTable dt1 = new DataTable();
            da1.Fill(dt1);
            if(dt1.Rows.Count > 0 )
            {
                dataGridView2.DataSource = dt1;
            }
            else
            {
                MessageBox.Show("Error");
            }

            SqlCommand cmd2 = new SqlCommand(sSQL2, conn);
            SqlDataAdapter da2 = new SqlDataAdapter(cmd2);
            DataTable dt2 = new DataTable();
            da2.Fill(dt2);
            if(dt2.Rows.Count > 0 )
            {
                dataGridView1.DataSource = dt2;
            }
            else
            {
                MessageBox.Show("Error");
            }
        }

        private void btnPrint_Click(object sender, EventArgs e)
        {
            String strConn = ConfigurationManager.ConnectionStrings["MyConn"].ConnectionString;
            SqlConnection conn = new SqlConnection(strConn);
            conn.Open();

            frmPrint frmPrint = new frmPrint();
            frmPrint.Show();

            String sSQL = "SELECT * FROM OrderDetail WHERE OrderID = '" + txtOrderID.Text + "'";
            SqlCommand cmd = new SqlCommand(sSQL, conn);
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataSet ds = new DataSet();
            da.Fill(ds, "OrderDetail");

            rptOrder rpt = new rptOrder();
            rpt.SetDataSource(ds);
            frmPrint.crystalReportViewer1.ReportSource = rpt;
            frmPrint.crystalReportViewer1.Refresh();
        }
    }
}
