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
    public partial class frmPrint : Form
    {
        List<OrderDS> _list;
        String _orderID, _agentID, _date;
        public frmPrint(List<OrderDS> dataSource, String orderID, String agentID, String date)
        {
            InitializeComponent();
            _list = dataSource;
            _orderID = orderID;
            _agentID = agentID;
            _date = date;
        }

        private void frmPrint_Load(object sender, EventArgs e)
        {
            String strConn = ConfigurationManager.ConnectionStrings["MyConn"].ConnectionString;
            SqlConnection conn = new SqlConnection(strConn);
            conn.Open();

            Microsoft.Reporting.WinForms.ReportParameter[] para = new Microsoft.Reporting.WinForms.ReportParameter[]
            {
                new Microsoft.Reporting.WinForms.ReportParameter("pOrderID", _orderID),
                new Microsoft.Reporting.WinForms.ReportParameter("pAgentID", _agentID),
                new Microsoft.Reporting.WinForms.ReportParameter("pDate", _date),
            };
            this.reportViewer.LocalReport.SetParameters(para);  
            this.reportViewer.RefreshReport();
        }
    }
}
