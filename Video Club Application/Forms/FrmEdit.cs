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
    public partial class FrmEdit : Form
    {
        OdbcConnection connection;
        OdbcDataAdapter dataAdapter = new OdbcDataAdapter();
        DataTable dtMovies = new DataTable();

        public FrmEdit()
        {
            InitializeComponent();

            dgvEdit.DataSource = dtMovies;
            connection = DataBase.connection;
        }

        // METHODS
        private void LoadMovies()
        {
            try
            {
                string query = "SELECT * FROM film WHERE film.`title` LIKE " + Methods.Quote(txtMovieName.Text + "%");
                dataAdapter.SelectCommand = new OdbcCommand(query, DataBase.connection);
                OdbcCommandBuilder commandBuilder = new OdbcCommandBuilder(dataAdapter);
                dtMovies.Clear();
                dataAdapter.Fill(dtMovies);
            }
            catch (Exception ex) { MessageBox.Show(ex.Message); }
        }

        private void SaveChanges()
        {
            try { dataAdapter.Update(dtMovies); }
            catch (Exception ex) { MessageBox.Show(ex.Message); }
        }

        // EVENTS
        private void btnLoad_Click(object sender, EventArgs e)
        {
            LoadMovies();
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            SaveChanges();
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            LoadMovies();
        }

        private void FrmEdit_Load(object sender, EventArgs e)
        {
            LoadMovies();
        }
    }
}
