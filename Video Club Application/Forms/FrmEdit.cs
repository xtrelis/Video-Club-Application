using System;
using System.Data;
using System.Data.Odbc;
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
                string query = "SELECT" + Environment.NewLine +
                    "`film`.`film_id` AS `Id`," + Environment.NewLine +
                    "`film`.`title` AS `Title`," + Environment.NewLine +
                    "`film`.`release_year` AS `Release Year`," + Environment.NewLine +
                    "`film`.`length` AS `Length`," + Environment.NewLine +
                    "`film`.`language_id` AS `Language Id`," + Environment.NewLine +
                    "`film`.`rating` AS `Rating`," + Environment.NewLine +
                    "`film`.`rental_rate` AS `Price`," + Environment.NewLine +
                    "film.`special_features` AS `Special Features`," + Environment.NewLine +
                    "film.`rental_duration` AS `Rental Duration`," + Environment.NewLine +
                    "film.`replacement_cost` AS `Replacement Cost`," + Environment.NewLine +
                    "`film`.`description` AS `Description`," + Environment.NewLine +
                    "`film`.`image` AS `Image`" + Environment.NewLine +
                    "FROM film WHERE film.`title` LIKE " + Methods.Quote(txtMovieName.Text + "%");

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

        private void dgvEdit_CellMouseDoubleClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            if (e.RowIndex != -1)
            {
                string movieTitle = dgvEdit.Rows[e.RowIndex].Cells[1].Value.ToString();
                FrmMovieEdit MovieEditForm = new FrmMovieEdit(movieTitle);
                MovieEditForm.Show();
            }
        }
    }
}
