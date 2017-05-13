using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Video_Club_Application
{
    public partial class FrmMain : Form
    {
        public FrmMain()
        {
            InitializeComponent();
            DataBase.Connect("localhost", "3306", "root", "");
        }

        private void btnConnection_Click(object sender, EventArgs e)
        {
            FrmConnection ConnectionForm = new FrmConnection();
            ConnectionForm.Show();
        }

        private void btnMovies_Click(object sender, EventArgs e)
        {
            FrmMovies MoviesForm = new FrmMovies();
            MoviesForm.Show();
        }

        private void btnActors_Click(object sender, EventArgs e)
        {
            FrmActors ActorsForm = new FrmActors();
            ActorsForm.Show();
        }

        private void btnEdit_Click(object sender, EventArgs e)
        {
            FrmEdit EditForm = new FrmEdit();
            EditForm.Show();
        }

        private void btnCustomers_Click(object sender, EventArgs e)
        {
            FrmCustomers CustomersForm = new FrmCustomers();
            CustomersForm.Show();
        }

        private void btnPayments_Click(object sender, EventArgs e)
        {
            FrmPayments PaymentsForm = new FrmPayments();
            PaymentsForm.Show();
        }

        private void btnSales_Click(object sender, EventArgs e)
        {
            FrmSales SalesForm = new FrmSales();
            SalesForm.Show();
        }
    }
}
