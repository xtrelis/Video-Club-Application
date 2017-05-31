using System;
using System.Collections.Generic;
using System.Data.Odbc;
using System.IO;
using System.Windows.Forms;

namespace Video_Club_Application
{
    public partial class FrmMovieRegistration : Form
    {
        OdbcCommand command;
        OdbcDataReader reader;
        List<Category> listLanguages, listRatings, listMovies;
        Movie NewMovie;
        string imageLocation = "";

        public FrmMovieRegistration()
        {
            InitializeComponent();

            command = new OdbcCommand();
            command.Connection = DataBase.connection;
        }

        // METHODS
        private void LoadLanguages()
        {
            Category category;
            listLanguages = new List<Category>();

            try
            {
                string query = "SELECT language.`language_id`, language.`name` FROM language";
                command.CommandText = query;
                reader = command.ExecuteReader();
                listLanguages.Clear();

                while (reader.Read())
                {
                    category = new Category(reader[0].ToString(), reader["name"].ToString());
                    listLanguages.Add(category);
                }

                Methods.Bind(cbxLangueages, listLanguages);
                cbxLangueages.SelectedIndex = -1;
                cbxLangueages.Text = "Choose";

                if (reader != null) reader.Close();
            }
            catch (Exception ex) { MessageBox.Show(ex.Message); }
        }

        private void LoadRatings()
        {
            Category category;
            listRatings = new List<Category>();
            int counter = -1;

            try
            {
                string query = "SELECT DISTINCT film.`rating` AS `name` FROM film";
                command.CommandText = query;
                reader = command.ExecuteReader();
                listRatings.Clear();

                while (reader.Read())
                {
                    category = new Category(counter++.ToString(), reader["name"].ToString());
                    listRatings.Add(category);
                }

                Methods.Bind(cbxRatings, listRatings);
                cbxRatings.SelectedIndex = -1;
                cbxRatings.Text = "Choose";

                if (reader != null) reader.Close();
            }
            catch (Exception ex) { MessageBox.Show(ex.Message); }
        }

        private void LoadCategories()
        {
            Category category;
            listMovies = new List<Category>();

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
                
                Methods.Bind(cbxCategories, listMovies);
                cbxCategories.SelectedIndex = -1;
                cbxCategories.Text = "Choose";

                if (reader != null) reader.Close();
            }
            catch (Exception ex) { MessageBox.Show(ex.Message); }
        }

        private bool CheckForNull()
        {
            bool boolean = true;

            if (txtTitle.Text == string.Empty || txtReleaseYear.Text == string.Empty || txtRentalDuration.Text == string.Empty ||
                txtRentalRate.Text == string.Empty || txtLength.Text == string.Empty || txtReplacementCost.Text == string.Empty ||
                txtDescription.Text == string.Empty || cbxLangueages.SelectedIndex == -1 || cbxRatings.SelectedIndex == -1 ||
                cbxCategories.SelectedIndex == -1 || (!chboxTrailers.Checked && !chboxCommentaries.Checked && !chboxBehindScenes.Checked 
                && !chboxDeletedScenes.Checked))
            {
                MessageBox.Show("You haven't completed the requiered fields.");
                boolean = false;                
            }

            return boolean;
        }

        private void FormValuesToMovieObject()
        {
            try
            {
                NewMovie = new Movie(CalculateMovieId(), txtTitle.Text, txtDescription.Text, 
                    int.Parse(txtReleaseYear.Text), cbxLangueages.SelectedIndex + 1, int.Parse(txtRentalDuration.Text), 
                    decimal.Parse(txtRentalRate.Text), int.Parse(txtLength.Text), 
                    decimal.Parse(txtReplacementCost.Text), cbxRatings.Text, SpecialFeaturesToString(), cbxCategories.SelectedIndex + 1);
            }
            catch (Exception ex) { MessageBox.Show(ex.Message); }
            
        }

        private int CalculateMovieId()
        {
            int id = 0;

            try
            {
                string query = "SELECT MAX(film_id) AS `count` FROM film";
                command.CommandText = query;
                reader = command.ExecuteReader();

                if (reader.Read())
                {
                    id = Convert.ToInt32(reader[0].ToString());
                }

                if (reader != null) reader.Close();
            }
            catch (Exception ex) { MessageBox.Show(ex.Message); }
            return id + 1;
        }

        private string SpecialFeaturesToString()
        {
            string specialFeatures = string.Empty;

            if (chboxTrailers.Checked) specialFeatures += chboxTrailers.Text;
            if (chboxCommentaries.Checked) specialFeatures += "," + chboxCommentaries.Text;
            if (chboxDeletedScenes.Checked) specialFeatures += "," + chboxDeletedScenes.Text;
            if (chboxBehindScenes.Checked) specialFeatures += "," + chboxBehindScenes.Text;

            return specialFeatures;
        }

        private void SaveNewMovieToDatabase()
        {
            try
            {
                string query = "INSERT INTO film VALUES (" + NewMovie.Id + ",'" + NewMovie.Title + "','" + NewMovie.Description + "'," +
                    NewMovie.ReleaseYear + "," + NewMovie.LanguageId + ",NULL," + NewMovie.RentalDuration + "," + NewMovie.RentalRate +
                    "," + NewMovie.Length + "," + NewMovie.ReplacementCost + ",'" + NewMovie.Rating + "','" + NewMovie.SpecialFeatures +
                    "','" + NewMovie.LastUpdate + "',NULL);";

                command.CommandText = query;
                reader = command.ExecuteReader();

                if (reader != null) reader.Close();
            }
            catch (Exception ex) { MessageBox.Show(ex.Message); }
        }

        private void OpenTheFileDialog()
        {
            try
            {
                OpenFileDialog dialog = new OpenFileDialog();
                dialog.InitialDirectory = "C:/Picture/";
                dialog.Filter = "All Files (*.*)|*.*|JPG|*.jpg|PNG|*.png|GIF|*.gif";
                dialog.Title = "Select Movie Picture";

                if (dialog.ShowDialog() == DialogResult.OK)
                {
                    imageLocation = dialog.FileName.ToString();
                    picBoxMovieImage.ImageLocation = imageLocation;
                }
            }
            catch (Exception ex) { MessageBox.Show(ex.Message); }
        }

        private void SaveMovieImage()
        {
            string query = "";
            byte[] imageBytes = null;
            MemoryStream memoryStream = new MemoryStream();

            try
            {
                if (picBoxMovieImage.Image != null)
                {
                    picBoxMovieImage.Image.Save(memoryStream, picBoxMovieImage.Image.RawFormat);
                    imageBytes = memoryStream.ToArray();
                    query = "UPDATE film SET image=?" + " WHERE film_id=?";
                }
                else
                {
                    query = "UPDATE film SET image=null" + " WHERE film_id=?";
                }

                command.Parameters.Clear();
                command.CommandText = query;

                if (picBoxMovieImage.Image != null) command.Parameters.AddWithValue("@picture", imageBytes);

                command.Parameters.AddWithValue("@film_id", NewMovie.Id);
                reader = command.ExecuteReader();

                if (reader != null) reader.Close();

                memoryStream.Close();
            }
            catch (Exception ex) { MessageBox.Show(ex.Message + "\n" + query); }
            finally
            {
                reader.Close();
                memoryStream.Close();
            }
        }

        private void SaveMovieCategory()
        {
            try
            {
                string query = "INSERT INTO film_category VALUES (" + NewMovie.Id + "," + NewMovie.Category + ",'" + NewMovie.LastUpdate + "');";
                command.CommandText = query;
                reader = command.ExecuteReader();

                if (reader != null) reader.Close();
            }
            catch (Exception ex) { MessageBox.Show(ex.Message); }
        }

        private void LoadValues()
        {
            txtTitle.Text = "Movie";
            txtReleaseYear.Text = "2011";
            txtLength.Text = "125";
            txtRentalDuration.Text = "6";
            txtRentalRate.Text = "0.99";
            txtReplacementCost.Text = "21.99";
            txtDescription.Text = "This is my Movie!!";
            cbxCategories.SelectedIndex = 1;
            cbxLangueages.SelectedIndex = 1;
            cbxRatings.SelectedIndex = 1;
            picBoxMovieImage.Image = null;
        }

        // EVENTS
        private void FrmMovieRegistration_Load(object sender, EventArgs e)
        {
            LoadLanguages();
            LoadRatings();
            LoadCategories();
            LoadValues();
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            picBoxMovieImage.Image = null;
        }

        private void btnClear_Click(object sender, EventArgs e)
        {
            txtTitle.Text = txtReleaseYear.Text = txtLength.Text = txtRentalDuration.Text = txtRentalRate.Text = txtReplacementCost.Text =
                txtDescription.Text = "";
            cbxCategories.SelectedIndex = cbxLangueages.SelectedIndex = cbxRatings.SelectedIndex = -1;
            cbxCategories.Text = cbxLangueages.Text = cbxRatings.Text = "Choose";
            picBoxMovieImage.Image = null;
        }

        private void btnBrowse_Click(object sender, EventArgs e)
        {
            OpenTheFileDialog();
        }

        private void btnRegister_Click(object sender, EventArgs e)
        {
            if (CheckForNull())
            {
                FormValuesToMovieObject();
                SaveNewMovieToDatabase();
                SaveMovieCategory();
                SaveMovieImage();

                MessageBox.Show("Register Completed!");
                MessageBox.Show("INSERT INTO film VALUES (" + NewMovie.Id + ",'" + NewMovie.Title + "','" + NewMovie.Description + "'," +
                    NewMovie.ReleaseYear + "," + NewMovie.LanguageId + ",NULL," + NewMovie.RentalDuration + "," + NewMovie.RentalRate +
                    "," + NewMovie.Length + "," + NewMovie.ReplacementCost + ",'" + NewMovie.Rating + "','" + NewMovie.SpecialFeatures +
                    "','" + NewMovie.LastUpdate + "',NULL);");
                LoadValues();
            }
        }
    }
}
