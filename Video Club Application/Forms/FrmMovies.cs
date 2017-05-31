using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Odbc;
using System.Windows.Forms;

namespace Video_Club_Application
{
    public partial class FrmMovies : Form
    {
        OdbcCommand command;
        OdbcDataReader reader;
        List<Category> listMovies = new List<Category>();
        DataTable dtMovies = new DataTable();

        public FrmMovies()
        {
            InitializeComponent();

            command = new OdbcCommand();
            command.Connection = DataBase.connection;
        }

        // METHODS
        private void LoadCategories()
        {
            Category category;

            try
            {
                string query = "SELECT category.`category_id`, category.`name` FROM category";
                command.CommandText = query;
                reader = command.ExecuteReader();
                listMovies.Clear();

                while (reader.Read())
                {
                    category = new Category(reader[0].ToString(), reader["name"].ToString());
                    listMovies.Add(category);
                }

                cbxCategories.SelectedIndexChanged -= new EventHandler(cbxCategories_SelectedIndexChanged);
                Methods.Bind(cbxCategories, listMovies);
                cbxCategories.SelectedIndex = -1;
                cbxCategories.Text = "Categories";
                cbxCategories.SelectedIndexChanged += new EventHandler(cbxCategories_SelectedIndexChanged);

                if (reader != null) reader.Close();
            }
            catch (Exception ex) { MessageBox.Show(ex.Message); }
        }

        private void LoadMovies()
        {
            int categoryId;
            string query, where = string.Empty;

            try
            {
                query = "SELECT" + Environment.NewLine +
                    "`film`.`film_id` AS `Id`," + Environment.NewLine +
                    "`film`.`title` AS `Title`," + Environment.NewLine +
                    "`category`.`name`    AS `Category`," + Environment.NewLine +
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
                    "FROM category" + Environment.NewLine +
                    "LEFT JOIN film_category ON category.`category_id`= film_category.`category_id`" + Environment.NewLine +
                    "LEFT JOIN film ON film_category.`film_id`= film.`film_id`" + Environment.NewLine;

                where = "where film.`title` LIKE " + Methods.Quote(txtMovieName.Text + "%");

                if (cbxCategories.SelectedIndex != -1)
                {
                    Category category = (Category)cbxCategories.SelectedItem;
                    categoryId = Convert.ToInt32(category.Id);
                    where += " AND category.`category_id`=" + categoryId;
                }

                if (txtMovieName.Text != string.Empty || cbxCategories.SelectedIndex != -1) query += Environment.NewLine + where;

                command.CommandText = query;
                reader = command.ExecuteReader();
                dtMovies.Rows.Clear();
                dtMovies.Load(reader);
                dgvMovies.DataSource = dtMovies;
                lblMovies.Text = "Total Movies: " + dtMovies.Rows.Count.ToString();

                if (reader != null) reader.Close();
            }
            catch (Exception ex) { MessageBox.Show(ex.ToString()); }
        }

        // EVENTS
        private void cbxCategories_SelectedIndexChanged(object sender, EventArgs e)
        {
            LoadMovies();
        }

        private void FrmMovies_Load(object sender, EventArgs e)
        {
            LoadCategories();
            LoadMovies();
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            LoadMovies();
        }

        private void txtMovieName_TextChanged(object sender, EventArgs e)
        {
            cbxCategories.SelectedIndex = -1;
            cbxCategories.Text = "Categories";
        }

        private void dgvMovies_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex != -1)
            {
                string movieTitle = dgvMovies.Rows[e.RowIndex].Cells[1].Value.ToString();
                FrmMovieInfo ActorsInfoform = new FrmMovieInfo(movieTitle);
                ActorsInfoform.Show();
            }
        }
    }
}
