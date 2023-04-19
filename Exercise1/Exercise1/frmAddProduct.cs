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
    public partial class frmAddProduct : Form
    {
        public frmAddProduct()
        {
            InitializeComponent();
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            String strConn = ConfigurationManager.ConnectionStrings["MyConn"].ConnectionString;
            SqlConnection conn = new SqlConnection(strConn);
            conn.Open();

            String sSQL = "INSERT INTO Item (ItemID, ItemName, Size, Price, Quantity) VALUES (@ProdID, @ProdName, @ProdSize, @ProdPrice, @ProdQuant)";
            SqlCommand cmd = new SqlCommand(sSQL, conn);

            cmd.Parameters.Add(new SqlParameter("@ProdID", txtProdID.Text));
            cmd.Parameters.Add(new SqlParameter("@ProdName", txtProdName.Text));
            cmd.Parameters.Add(new SqlParameter("@ProdSize", txtProdPrice.Text));
            cmd.Parameters.Add(new SqlParameter("@ProdPrice", txtProdPrice.Text));
            cmd.Parameters.Add(new SqlParameter("@ProdQuant", txtProdQuant.Text));

            try
            {
                cmd.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                throw new Exception("Error: " + ex.Message);
            }
            MessageBox.Show("Add product successfully!");
        }
    }
}
