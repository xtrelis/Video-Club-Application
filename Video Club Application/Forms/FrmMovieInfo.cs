using System;
using System.Data;
using System.Data.Odbc;
using System.Drawing;
using System.IO;
using System.Windows.Forms;

namespace Video_Club_Application
{
    public partial class FrmMovieInfo : Form
    {
        OdbcCommand command;
        OdbcDataReader reader;
        DataTable dtActors = new DataTable();
        string movieTitle;

        public FrmMovieInfo(string movieTitle)
        {
            InitializeComponent();

            command = new OdbcCommand();
            command.Connection = DataBase.connection;
            this.movieTitle = movieTitle;
        }

        // METHODS
        private void LoadActors(string movieTitle)
        {
            try
            {
                string query = "SELECT actor.`first_name`,actor.`last_name`" + Environment.NewLine +
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

        private void LoadDescription(string movieTitle)
        {
            try
            {
                string query = "SELECT film.`description` FROM film WHERE film.`title`=" + Methods.Quote(movieTitle);

                command.CommandText = query;
                reader = command.ExecuteReader();
                if (reader.Read()) txtDescription.Text = reader["description"].ToString();

                if (reader != null) reader.Close();
            }
            catch (Exception ex) { MessageBox.Show(ex.Message); }
        }

        private void LoadImage(string movieTitle)
        {
            try
            {
                string query = "SELECT film.`image` FROM film WHERE film.`title`=" + Methods.Quote(movieTitle);
                
                command.CommandText = query;
                reader = command.ExecuteReader();
                byte[] imageBytes = null;

                if (reader.Read()) imageBytes = (byte[])reader["image"];

                MemoryStream memoryStream = new MemoryStream(imageBytes);
                Image image = Image.FromStream(memoryStream);
                picBoxImage.Image = image;

                if (reader != null) reader.Close();
            }
            catch (Exception ex) { MessageBox.Show("There is no image." + ex.Message); }
        }

        // EVENTS
        private void FrmActorsInfo_Load(object sender, EventArgs e)
        {
            LoadActors(movieTitle);
            LoadDescription(movieTitle);
            LoadImage(movieTitle);
        }
    }
}
