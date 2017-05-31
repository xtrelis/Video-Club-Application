using System;
using System.Data;
using System.Data.Odbc;
using System.Windows.Forms;

namespace Video_Club_Application
{
    public partial class FrmRentals : Form
    {
        OdbcCommand command;
        OdbcDataReader reader;
        DataTable dtRentals = new DataTable();
        string customerFirstName, customerLastName;

        public FrmRentals(string customerFirstName, string customerLastName)
        {
            InitializeComponent();

            command = new OdbcCommand();
            command.Connection = DataBase.connection;
            this.customerFirstName = customerFirstName;
            this.customerLastName = customerLastName;
            lblCustomerName.Text = customerLastName + " " + customerFirstName;
        }

        // METHODS
        public void LoadRentals()
        {
            try
            {
                string query = "SELECT rental.`rental_id`,rental.`return_date`,inventory.`film_id`,film.`title`" +
                    "FROM customer JOIN rental ON customer.`customer_id`=rental.`customer_id`" +
                    "JOIN inventory ON rental.`inventory_id`=inventory.`inventory_id`" +
                    "JOIN film ON inventory.`film_id`=film.`film_id`" +
                    "WHERE customer.first_name='" + customerFirstName + "' AND customer.last_name='" + customerLastName + "'";

                command.CommandText = query;
                reader = command.ExecuteReader();
                dtRentals.Rows.Clear();
                dtRentals.Load(reader);
                dgvRentals.DataSource = dtRentals;

                if (reader != null) reader.Close();
            }
            catch (Exception ex) { MessageBox.Show(ex.Message); }
        }

        // EVENTS
        private void FrmRentals_Load(object sender, EventArgs e)
        {
            LoadRentals();
        }
    }
}
