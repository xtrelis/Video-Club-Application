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
    public partial class FrmActorsInfo : Form
    {
        OdbcCommand command;
        OdbcDataReader reader;
        DataTable dtActors = new DataTable();
        string movieTitle;

        public FrmActorsInfo(string movieTitle)
        {
            InitializeComponent();

            command = new OdbcCommand();
            command.Connection = DataBase.connection;
            this.movieTitle = movieTitle;
        }

        // METHODS
        private void LoadActors(string movieTitle)
        {
            string query;
            try
            {
                query = "SELECT actor.`first_name`,actor.`last_name`" + Environment.NewLine +
                        "FROM actor" + Environment.NewLine +
                        "Left JOIN film_actor ON actor.`actor_id`= film_actor.`actor_id`" + Environment.NewLine +
                        "Left JOIN film ON film_actor.`film_id`= film.`film_id`" + Environment.NewLine +
                    "WHERE film.`title`=" + Methods.Quote(movieTitle);

                command.CommandText = query;
                reader = command.ExecuteReader();
                dtActors.Rows.Clear();
                dtActors.Load(reader);
                dgvActorsInfo.DataSource = dtActors;
                lblMovieTitle.Text = movieTitle;

                if (reader != null) reader.Close();
            }
            catch (Exception ex) { MessageBox.Show(ex.ToString()); }
        }

        private void FrmActorsInfo_Load(object sender, EventArgs e)
        {
            LoadActors(movieTitle);
        }
    }
}
