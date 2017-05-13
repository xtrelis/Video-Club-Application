using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.Odbc;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Video_Club_Application
{
    public partial class FrmPayments : Form
    {
        OdbcCommand command;
        OdbcDataReader reader;
        List<Category> listStores = new List<Category>();
        DataTable dtPayments = new DataTable();

        public FrmPayments()
        {
            InitializeComponent();

            command = new OdbcCommand();
            command.Connection = DataBase.connection;
        }

        // METHODS
        private void LoadStores()
        {
            Category category;
            string query = "SELECT store.`store_id`,address.`address`" + Environment.NewLine +
                        "FROM store" + Environment.NewLine +
                        "LEFT JOIN address ON store.`address_id`= address.`address_id`;";

            try
            {
                command.CommandText = query;
                reader = command.ExecuteReader();
                listStores.Clear();

                while (reader.Read())
                {
                    category = new Category(reader[0].ToString(), reader["address"].ToString());
                    listStores.Add(category);
                }

                cbxStores.SelectedIndexChanged -= new EventHandler(cbxStores_SelectedIndexChanged);
                Bind(cbxStores);
                cbxStores.SelectedIndex = -1;
                cbxStores.Text = "Stores";
                cbxStores.SelectedIndexChanged += new EventHandler(cbxStores_SelectedIndexChanged);

                if (reader != null) reader.Close();
            }
            catch (Exception ex) { MessageBox.Show(ex.Message); }
        }

        private void Bind(ComboBox cbx)
        {
            cbx.BeginUpdate();
            cbx.DataSource = null;
            cbx.DataSource = listStores;
            cbx.ValueMember = "id";
            cbx.DisplayMember = "name";
            cbx.EndUpdate();
        }

        private void ShowPayments()
        {
            string dateFrom, dateTo, query, where = string.Empty;
            int storeId;

            try
            {
                dateFrom = dtpFrom.Value.ToString("yyyy-MM-dd");
                dateTo = dtpTo.Value.ToString("yyyy-MM-dd");
                query = "SELECT payment.`payment_id`,CONCAT(customer.`first_name`,' ', customer.`last_name`) AS Customer,customer.`email`,payment.`amount`,payment.`payment_date`, address.`address` AS StoreAddress" + Environment.NewLine +
                    "FROM payment" + Environment.NewLine +
                    "JOIN customer ON payment.`customer_id`=customer.`customer_id`" + Environment.NewLine +
                    "JOIN store ON customer.`store_id`=store.`store_id`" + Environment.NewLine +
                    "JOIN address ON store.`address_id`=address.`address_id`" + Environment.NewLine;
                where = "WHERE payment.`payment_date` BETWEEN '" + dateFrom + "' AND '" + dateTo + "'";
                where += " AND customer.`last_name` LIKE '%" + txtCustomerName.Text + "%'";

                if (cbxStores.SelectedIndex != -1)
                {
                    Category category = (Category)cbxStores.SelectedItem;
                    storeId = Convert.ToInt32(category.id);
                    where += "  AND store.`store_id`=" + storeId;
                }

                query += where;
                command.CommandText = query;
                reader = command.ExecuteReader();
                dtPayments.Rows.Clear();
                dtPayments.Load(reader);
                dgvPayments.DataSource = dtPayments;

                if (reader != null) reader.Close();
            }
            catch (Exception ex) { MessageBox.Show(ex.ToString()); }
        }

        // EVENTS
        private void cbxStores_SelectedIndexChanged(object sender, EventArgs e)
        {
            ShowPayments();
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            ShowPayments();
        }

        private void txtCustomerName_TextChanged(object sender, EventArgs e)
        {
            cbxStores.SelectedIndex = -1;
            cbxStores.Text = "Stores";
        }

        private void FrmPayments_Load(object sender, EventArgs e)
        {
            ShowPayments();
            LoadStores();
        }
    }
}
