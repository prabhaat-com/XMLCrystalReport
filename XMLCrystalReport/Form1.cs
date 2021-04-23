using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace XMLCrystalReport
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void btnShowReport_Click(object sender, EventArgs e)
        {
            DataSet dsReport = new DataSet();
            // create temp dataset to read xml information 
            DataSet dsTempReport = new DataSet();
            try
            {
                // using ReadXml method of DataSet read XML data from books.xml file 
                dsTempReport.ReadXml(@"rs_retrieve_print_so_OUTPUT.xml");
                // copy XML data from temp dataset to our typed data set 
                // dsReport.Tables[0].Merge(dsTempReport.Tables[0]);
                //prepare report for preview 
                rsi_so_print_bfl20210421 rptXMLReport = new rsi_so_print_bfl20210421();
                rptXMLReport.SetDataSource(dsTempReport);
               
                crystalReportViewer1.ReportSource = rptXMLReport;
                crystalReportViewer1.Show();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
    }
}
