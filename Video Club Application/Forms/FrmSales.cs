using System;
using System.Data;
using System.Data.Odbc;
using System.Windows.Forms;

namespace Video_Club_Application
{
    public partial class FrmSales : Form
    {
        OdbcCommand command = new OdbcCommand();
        OdbcDataReader reader;
        DataTable dtSales = new DataTable();

        public FrmSales()
        {
            InitializeComponent();

            command = new OdbcCommand();
            command.Connection = DataBase.connection;
        }

        // METHODS
        private void LoadSales()
        {
            string query;

            try
            {
                query = "SELECT * FROM sales_by_store";
                command.CommandText = query;
                reader = command.ExecuteReader();
                dtSales.Rows.Clear();
                dtSales.Load(reader);
                dgvSales.DataSource = dtSales;

                if (reader != null) reader.Close();
            }
            catch (Exception ex) { MessageBox.Show(ex.ToString()); }
        }

        // EVENTS
        private void FrmSales_Load(object sender, EventArgs e)
        {
            LoadSales();
        }
    }
}
