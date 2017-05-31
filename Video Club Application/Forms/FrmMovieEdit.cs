using System;
using System.Collections.Generic;
using System.Data.Odbc;
using System.Drawing;
using System.IO;
using System.Windows.Forms;

namespace Video_Club_Application
{
    public partial class FrmMovieEdit : Form
    {
        OdbcCommand command;
        OdbcDataReader reader;
        string movieTitle, imageLocation;
        List<Category> listLanguages, listRatings, listMovies;
        int movieId;
        Movie UpdatedMovie;

        public FrmMovieEdit(string movieTitle)
        {
            InitializeComponent();

            command = new OdbcCommand();
            command.Connection = DataBase.connection;
            this.movieTitle = movieTitle;
        }

        private void LoadMovie(string movieTitle)
        {
            try
            {
                string query = "SELECT `film`.`film_id`,`film`.`title`,`film`.`release_year`,`film`.`length`,`film`.`rental_rate`," +
                    "film.`rental_duration`,film.`replacement_cost`,`film`.`description` FROM film WHERE film.`title`=" + Methods.Quote(movieTitle);

                command.CommandText = query;
                reader = command.ExecuteReader();
               
                while (reader.Read())
                {
                    movieId = Convert.ToInt32(reader["film_id"].ToString());
                    txtTitle.Text = reader["title"].ToString();
                    txtReleaseYear.Text = reader["release_year"].ToString();
                    txtLength.Text = reader["length"].ToString();
                    txtRentalRate.Text = reader["rental_rate"].ToString();
                    txtRentalDuration.Text = reader["rental_duration"].ToString();
                    txtReplacementCost.Text = reader["replacement_cost"].ToString();
                    txtDescription.Text = reader["description"].ToString();
                }                    

                if (reader != null) reader.Close();
            }
            catch (Exception ex) { MessageBox.Show(ex.ToString()); }
        }

        private void LoadCategories()
        {
            Category category;
            listMovies = new List<Category>();
            string query;
            int categoryId = -1;

            try
            {
                query = "SELECT category.`category_id`, category.`name` FROM category";
                command.CommandText = query;
                reader = command.ExecuteReader();
                listMovies.Clear();

                while (reader.Read())
                {
                    category = new Category(reader[0].ToString(), reader["name"].ToString());
                    listMovies.Add(category);
                }

                Methods.Bind(cbxCategories, listMovies);

                if (reader != null) reader.Close();

                try
                {
                    query = "SELECT film_category.`category_id` FROM film_category WHERE film_category.`film_id`=" + movieId;
                    command.CommandText = query;
                    reader = command.ExecuteReader();

                    if (reader.Read()) categoryId = Convert.ToInt32(reader["category_id"].ToString()) - 1;

                    cbxCategories.SelectedIndex = categoryId;

                    if (reader != null) reader.Close();
                }
                catch (Exception ex) { MessageBox.Show(ex.Message); }
            }
            catch (Exception ex) { MessageBox.Show(ex.Message); }
        }

        private void LoadLanguages(string movieTitle)
        {
            Category category;
            listLanguages = new List<Category>();
            string query;
            int languageId = -1;

            try
            {
                query = "SELECT language.`language_id`, language.`name` FROM language";
                command.CommandText = query;
                reader = command.ExecuteReader();
                listLanguages.Clear();

                while (reader.Read())
                {
                    category = new Category(reader[0].ToString(), reader["name"].ToString());
                    listLanguages.Add(category);
                }

                Methods.Bind(cbxLangueages, listLanguages);

                if (reader != null) reader.Close();

                try
                {
                    query = "SELECT film.`language_id` FROM film WHERE film.`title`=" + Methods.Quote(movieTitle);
                    command.CommandText = query;
                    reader = command.ExecuteReader();

                    if (reader.Read()) languageId = Convert.ToInt32(reader["language_id"].ToString()) -1;

                    cbxLangueages.SelectedIndex = languageId;

                    if (reader != null) reader.Close();
                }
                catch (Exception ex) { MessageBox.Show(ex.Message); }
            }
            catch (Exception ex) { MessageBox.Show(ex.Message); }
        }

        private void LoadRatings()
        {
            Category category;
            listRatings = new List<Category>();
            string rating = "", query;
            int counter = 0;

            try
            {
                query = "SELECT DISTINCT film.`rating` AS `name` FROM film";
                command.CommandText = query;
                reader = command.ExecuteReader();
                listRatings.Clear();

                while (reader.Read())
                {
                    category = new Category(counter++.ToString(), reader["name"].ToString());
                    listRatings.Add(category);
                }

                Methods.Bind(cbxRatings, listRatings);

                if (reader != null) reader.Close();

                try
                {
                    query = "SELECT film.`rating` FROM film WHERE film.`film_id`=" + movieId;
                    command.CommandText = query;
                    reader = command.ExecuteReader();

                    if (reader.Read()) rating = reader["rating"].ToString();

                    foreach (Category rate in listRatings) if (rate.Name == rating) cbxRatings.SelectedIndex = Convert.ToInt32(rate.Id);

                    if (reader != null) reader.Close();
                }
                catch (Exception ex) { MessageBox.Show(ex.Message); }
            }
            catch (Exception ex) { MessageBox.Show(ex.Message); }
        }

        private void LoadSpecialFeatures()
        {
            try
            {

                string query = "SELECT film.`special_features` FROM film WHERE film.`film_id`=" + movieId, specialFeatures = "";

                command.CommandText = query;
                reader = command.ExecuteReader();

                while (reader.Read()) specialFeatures = reader["special_features"].ToString();

                if (specialFeatures != string.Empty)
                {
                    if (specialFeatures.IndexOf(chboxTrailers.Text) > -1) chboxTrailers.Checked = true;
                    if (specialFeatures.IndexOf(chboxCommentaries.Text) > -1) chboxCommentaries.Checked = true;
                    if (specialFeatures.IndexOf(chboxDeletedScenes.Text) > -1) chboxDeletedScenes.Checked = true;
                    if (specialFeatures.IndexOf(chboxBehindScenes.Text) > -1) chboxBehindScenes.Checked = true;
                }

                if (reader != null) reader.Close();
            }
            catch (Exception ex) { MessageBox.Show(ex.Message); }
        }

        private void LoadImage()
        {
            byte[] imageBytes = null;
            MemoryStream memoryStream = null;
            Image image = null;

            try
            {
                string query = "SELECT image FROM film WHERE title=?";

                command.Parameters.Clear();
                command.CommandText = query;
                command.Parameters.AddWithValue("title", movieTitle);
                reader = command.ExecuteReader();

                if (reader.Read()) imageBytes = (byte[])reader["image"];

                if (imageBytes != null)
                {
                    try
                    {
                        memoryStream = new MemoryStream(imageBytes);
                        image = Image.FromStream(memoryStream);
                        picBoxImage.Image = image;
                    }
                    catch (Exception ex) { MessageBox.Show(ex.Message); }
                }

                /*if (reader["image"] != System.DBNull.Value)
                {
                    while (reader.Read())
                    {
                        imageBytes = (byte[])reader["image"];
                        memoryStream = new MemoryStream(imageBytes);
                        image = Image.FromStream(memoryStream);
                        picBoxImage.Image = image;
                        memoryStream.Close();
                    }
                }*/

                if (reader != null) reader.Close();

            }
            catch (Exception ex) { MessageBox.Show(ex.Message); }
            finally
            {
                reader.Close();
            }
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

        private void FormValuesToMovieObject()
        {
            try
            {
                UpdatedMovie = new Movie(movieId, txtTitle.Text, txtDescription.Text, int.Parse(txtReleaseYear.Text),
                cbxLangueages.SelectedIndex + 1, int.Parse(txtRentalDuration.Text), decimal.Parse(txtRentalRate.Text), int.Parse(txtLength.Text),
                decimal.Parse(txtReplacementCost.Text), cbxRatings.Text, SpecialFeaturesToString(), cbxCategories.SelectedIndex + 1);
            }
            catch (Exception ex) { MessageBox.Show(ex.Message); }

        }

        private void UpdateMovieToDB()
        {
            try
            {
                string query = "UPDATE film SET title='" + UpdatedMovie.Title + "',description='" + UpdatedMovie.Description + "',release_year=" +
                UpdatedMovie.ReleaseYear + ",language_id=" + UpdatedMovie.LanguageId + ",original_language_id=NULL,rental_duration=" +
                UpdatedMovie.RentalDuration + ",rental_rate=" + UpdatedMovie.RentalRate + ",length=" + UpdatedMovie.Length + ",replacement_cost=" +
                UpdatedMovie.ReplacementCost + ",rating='" + UpdatedMovie.Rating + "',special_features='" + UpdatedMovie.SpecialFeatures +
                "',last_update='" + UpdatedMovie.LastUpdate + "',image=NULL WHERE film_id=" + UpdatedMovie.Id;

                command.CommandText = query;
                reader = command.ExecuteReader();

                if (reader != null) reader.Close();

                MessageBox.Show("Update Completed.");
            }
            catch (Exception ex) { MessageBox.Show(ex.Message); }
        }

        private void UpdateMovieImage()
        {
            string query = "";
            byte[] imageBytes = null;
            MemoryStream memoryStream = new MemoryStream();

            try
            {
                if (picBoxImage.Image != null)
                {
                    picBoxImage.Image.Save(memoryStream, picBoxImage.Image.RawFormat);
                    imageBytes = memoryStream.ToArray();
                    query = "UPDATE film SET image=?" + " WHERE film_id=?";
                }
                else
                {
                    query = "UPDATE film SET image=null" + " WHERE film_id=?";
                }

                command.Parameters.Clear();
                command.CommandText = query;

                if (picBoxImage.Image != null) command.Parameters.AddWithValue("@picture", imageBytes);

                command.Parameters.AddWithValue("@film_id", UpdatedMovie.Id);
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

        private void UpdateMovieCategory()
        {
            try
            {
                string query = "UPDATE film_category SET category_id=" + UpdatedMovie.Category + " WHERE film_id=" + UpdatedMovie.Id;

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
                    picBoxImage.ImageLocation = imageLocation;
                }
            }
            catch (Exception ex) { MessageBox.Show(ex.Message); }
        }

        private void DeleteMovieCategory()
        {
            try
            {
                string query = "DELETE FROM film_category WHERE film_id=" + movieId;
                command.CommandText = query;
                reader = command.ExecuteReader();

                if (reader != null) reader.Close();
            }
            catch (Exception ex) { MessageBox.Show(ex.Message); }
        }

        private void DeleteMovie()
        {
            try
            {
                string query = "DELETE FROM film WHERE film_id=" + movieId;
                command.CommandText = query;
                reader = command.ExecuteReader();

                if (reader != null) reader.Close();

                MessageBox.Show("Delete Completed");
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

        private void Clear()
        {
            txtTitle.Text = txtReleaseYear.Text = txtLength.Text = txtRentalDuration.Text = txtRentalRate.Text = txtReplacementCost.Text =
                txtDescription.Text = "";
            cbxCategories.SelectedIndex = cbxLangueages.SelectedIndex = cbxRatings.SelectedIndex = -1;
            cbxCategories.Text = cbxLangueages.Text = cbxRatings.Text = "Choose";
        }

        private void btnDeleteImage_Click(object sender, EventArgs e)
        {
            picBoxImage.Image = null;
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            DeleteMovieCategory();
            DeleteMovie();
            Clear();
        }

        private void btnBrowse_Click(object sender, EventArgs e)
        {
            OpenTheFileDialog();
        }

        private void FrmMovieEdit_Load(object sender, EventArgs e)
        {
            LoadMovie(movieTitle);
            LoadCategories();
            LoadLanguages(movieTitle);
            LoadRatings();
            LoadSpecialFeatures();
            LoadImage();
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if (CheckForNull())
            {
                FormValuesToMovieObject();
                UpdateMovieToDB();
                UpdateMovieCategory();
                UpdateMovieImage();
                Close();
            }
        }
    }
}
