using System;
using System.Data;
using System.Data.Odbc;
using System.Linq;
using System.Windows.Forms;

namespace Video_Club_Application
{
    public partial class FrmCustomers : Form
    {
        OdbcCommand command;
        OdbcDataReader reader;
        DataTable dtCustomers = new DataTable();

        public FrmCustomers()
        {
            InitializeComponent();

            command = new OdbcCommand();
            command.Connection = DataBase.connection;
        }

        // METHODS
        private void LoadCustomers()
        {       
            try
            {
                string query = "SELECT" + Environment.NewLine +
                   "customer.`customer_id` AS ID," + Environment.NewLine +
                    "CONCAT(customer.`first_name`, _utf8' ', customer.`last_name`) AS `FullName`," + Environment.NewLine +
                    "customer.`email` AS `E-Mail`," + Environment.NewLine +
                    "address.`address` AS `Address`," + Environment.NewLine +
                    "address.`postal_code` AS `Zip Code`," + Environment.NewLine +
                    "address.`phone` AS `Phone`," + Environment.NewLine +
                    "city.`city` AS City," + Environment.NewLine +
                    "country.`country` AS Country," + Environment.NewLine +
                    "IF(customer.`active`, _utf8'active', _utf8'') AS `Notes`," + Environment.NewLine +
                    "customer.`store_id` AS SID " + Environment.NewLine +
                    "FROM customer" + Environment.NewLine +
                    "JOIN address ON customer.`address_id`= address.`address_id`" + Environment.NewLine +
                    "JOIN city ON address.`city_id`= city.`city_id`" + Environment.NewLine +
                    "JOIN country ON city.`country_id`= country.`country_id`" + Environment.NewLine;

                if (txtCustomerName.Text != string.Empty)
                {
                    string where = "Where last_name LIKE " + Methods.Quote(txtCustomerName.Text + "%");
                    query += Environment.NewLine + where;
                }

                command.CommandText = query;
                reader = command.ExecuteReader();
                dtCustomers.Rows.Clear();
                dtCustomers.Load(reader);
                dgvCustomers.DataSource = dtCustomers;

                if (reader != null) reader.Close();
            }
            catch (Exception ex) { MessageBox.Show(ex.Message); }
        }

        // EVENTS
        private void btnSearch_Click(object sender, EventArgs e)
        {
            LoadCustomers();
        }

        private void Customers_Load(object sender, EventArgs e)
        {
            LoadCustomers();
        }

        private void dgvCustomers_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            string customerName = dgvCustomers.Rows[e.RowIndex].Cells[1].Value.ToString();
            FrmRentals CustomerRentalsForm = new FrmRentals(customerName.Split(' ').First(), customerName.Split(' ').Last());
            CustomerRentalsForm.Show();
        }
    }
}
