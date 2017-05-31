using System;
using System.Data;
using System.Data.Odbc;
using System.Windows.Forms;

namespace Video_Club_Application
{
    public partial class FrmActors : Form
    {
        OdbcCommand command;
        OdbcDataReader reader;
        DataTable dtActors = new DataTable();

        public FrmActors()
        {
            InitializeComponent();
            command = new OdbcCommand();
            command.Connection = DataBase.connection;
        }

        // METHODS
        private void LoadActors()
        {
            try
            {
                string query = "SELECT * FROM actor_info", where;

                if (txtActorName.Text != string.Empty)
                {
                    where = "Where last_name LIKE " + Methods.Quote(txtActorName.Text + "%");
                    query += Environment.NewLine + where;
                }

                command.CommandText = query;
                reader = command.ExecuteReader();
                dtActors.Rows.Clear();
                dtActors.Load(reader);
                dgvActors.DataSource = dtActors;
                lblActors.Text = "Total Actors: " + dtActors.Rows.Count.ToString();

                if (reader != null) reader.Close();
            }
            catch (Exception exc)
            {
                MessageBox.Show(exc.ToString());
            }
        }

        // EVENTS
        private void FrmActors_Load(object sender, EventArgs e)
        {
            LoadActors();
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            LoadActors();
        }
    }
}
