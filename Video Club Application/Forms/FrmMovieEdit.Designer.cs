namespace Video_Club_Application
{
    partial class FrmMovieEdit
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.label12 = new System.Windows.Forms.Label();
            this.label11 = new System.Windows.Forms.Label();
            this.cbxCategories = new System.Windows.Forms.ComboBox();
            this.btnBrowse = new System.Windows.Forms.Button();
            this.picBoxImage = new System.Windows.Forms.PictureBox();
            this.btnSave = new System.Windows.Forms.Button();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.chboxBehindScenes = new System.Windows.Forms.CheckBox();
            this.chboxDeletedScenes = new System.Windows.Forms.CheckBox();
            this.chboxCommentaries = new System.Windows.Forms.CheckBox();
            this.chboxTrailers = new System.Windows.Forms.CheckBox();
            this.cbxRatings = new System.Windows.Forms.ComboBox();
            this.cbxLangueages = new System.Windows.Forms.ComboBox();
            this.txtDescription = new System.Windows.Forms.TextBox();
            this.txtReplacementCost = new System.Windows.Forms.TextBox();
            this.txtLength = new System.Windows.Forms.TextBox();
            this.txtRentalRate = new System.Windows.Forms.TextBox();
            this.txtRentalDuration = new System.Windows.Forms.TextBox();
            this.txtReleaseYear = new System.Windows.Forms.TextBox();
            this.label10 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.txtTitle = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.btnDeleteImage = new System.Windows.Forms.Button();
            this.btnDelete = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.picBoxImage)).BeginInit();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(161)));
            this.label12.ForeColor = System.Drawing.Color.White;
            this.label12.Location = new System.Drawing.Point(965, 15);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(55, 16);
            this.label12.TabIndex = 57;
            this.label12.Text = "Image:";
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(161)));
            this.label11.ForeColor = System.Drawing.Color.White;
            this.label11.Location = new System.Drawing.Point(76, 119);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(75, 16);
            this.label11.TabIndex = 56;
            this.label11.Text = "Category:";
            // 
            // cbxCategories
            // 
            this.cbxCategories.FormattingEnabled = true;
            this.cbxCategories.Location = new System.Drawing.Point(157, 118);
            this.cbxCategories.Name = "cbxCategories";
            this.cbxCategories.Size = new System.Drawing.Size(253, 21);
            this.cbxCategories.TabIndex = 35;
            // 
            // btnBrowse
            // 
            this.btnBrowse.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(161)));
            this.btnBrowse.Location = new System.Drawing.Point(850, 438);
            this.btnBrowse.Name = "btnBrowse";
            this.btnBrowse.Size = new System.Drawing.Size(100, 25);
            this.btnBrowse.TabIndex = 52;
            this.btnBrowse.Text = "Browse";
            this.btnBrowse.UseVisualStyleBackColor = true;
            this.btnBrowse.Click += new System.EventHandler(this.btnBrowse_Click);
            // 
            // picBoxImage
            // 
            this.picBoxImage.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.picBoxImage.Location = new System.Drawing.Point(812, 34);
            this.picBoxImage.Name = "picBoxImage";
            this.picBoxImage.Size = new System.Drawing.Size(359, 399);
            this.picBoxImage.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.picBoxImage.TabIndex = 55;
            this.picBoxImage.TabStop = false;
            // 
            // btnSave
            // 
            this.btnSave.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(161)));
            this.btnSave.Location = new System.Drawing.Point(455, 504);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(100, 25);
            this.btnSave.TabIndex = 53;
            this.btnSave.Text = "Save";
            this.btnSave.UseVisualStyleBackColor = true;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.chboxBehindScenes);
            this.groupBox1.Controls.Add(this.chboxDeletedScenes);
            this.groupBox1.Controls.Add(this.chboxCommentaries);
            this.groupBox1.Controls.Add(this.chboxTrailers);
            this.groupBox1.Location = new System.Drawing.Point(484, 34);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(254, 121);
            this.groupBox1.TabIndex = 54;
            this.groupBox1.TabStop = false;
            // 
            // chboxBehindScenes
            // 
            this.chboxBehindScenes.AutoSize = true;
            this.chboxBehindScenes.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(161)));
            this.chboxBehindScenes.ForeColor = System.Drawing.Color.White;
            this.chboxBehindScenes.Location = new System.Drawing.Point(7, 95);
            this.chboxBehindScenes.Name = "chboxBehindScenes";
            this.chboxBehindScenes.Size = new System.Drawing.Size(139, 20);
            this.chboxBehindScenes.TabIndex = 13;
            this.chboxBehindScenes.Text = "Behind the Scenes";
            this.chboxBehindScenes.UseVisualStyleBackColor = true;
            // 
            // chboxDeletedScenes
            // 
            this.chboxDeletedScenes.AutoSize = true;
            this.chboxDeletedScenes.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(161)));
            this.chboxDeletedScenes.ForeColor = System.Drawing.Color.White;
            this.chboxDeletedScenes.Location = new System.Drawing.Point(7, 69);
            this.chboxDeletedScenes.Name = "chboxDeletedScenes";
            this.chboxDeletedScenes.Size = new System.Drawing.Size(124, 20);
            this.chboxDeletedScenes.TabIndex = 12;
            this.chboxDeletedScenes.Text = "Deleted Scenes";
            this.chboxDeletedScenes.UseVisualStyleBackColor = true;
            // 
            // chboxCommentaries
            // 
            this.chboxCommentaries.AutoSize = true;
            this.chboxCommentaries.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(161)));
            this.chboxCommentaries.ForeColor = System.Drawing.Color.White;
            this.chboxCommentaries.Location = new System.Drawing.Point(7, 44);
            this.chboxCommentaries.Name = "chboxCommentaries";
            this.chboxCommentaries.Size = new System.Drawing.Size(114, 20);
            this.chboxCommentaries.TabIndex = 11;
            this.chboxCommentaries.Text = "Commentaries";
            this.chboxCommentaries.UseVisualStyleBackColor = true;
            // 
            // chboxTrailers
            // 
            this.chboxTrailers.AutoSize = true;
            this.chboxTrailers.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(161)));
            this.chboxTrailers.ForeColor = System.Drawing.Color.White;
            this.chboxTrailers.Location = new System.Drawing.Point(7, 21);
            this.chboxTrailers.Name = "chboxTrailers";
            this.chboxTrailers.Size = new System.Drawing.Size(73, 20);
            this.chboxTrailers.TabIndex = 10;
            this.chboxTrailers.Text = "Trailers";
            this.chboxTrailers.UseVisualStyleBackColor = true;
            // 
            // cbxRatings
            // 
            this.cbxRatings.FormattingEnabled = true;
            this.cbxRatings.Location = new System.Drawing.Point(157, 389);
            this.cbxRatings.Name = "cbxRatings";
            this.cbxRatings.Size = new System.Drawing.Size(253, 21);
            this.cbxRatings.TabIndex = 44;
            // 
            // cbxLangueages
            // 
            this.cbxLangueages.FormattingEnabled = true;
            this.cbxLangueages.Location = new System.Drawing.Point(158, 172);
            this.cbxLangueages.Name = "cbxLangueages";
            this.cbxLangueages.Size = new System.Drawing.Size(253, 21);
            this.cbxLangueages.TabIndex = 36;
            // 
            // txtDescription
            // 
            this.txtDescription.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(161)));
            this.txtDescription.Location = new System.Drawing.Point(433, 198);
            this.txtDescription.Multiline = true;
            this.txtDescription.Name = "txtDescription";
            this.txtDescription.Size = new System.Drawing.Size(356, 263);
            this.txtDescription.TabIndex = 51;
            // 
            // txtReplacementCost
            // 
            this.txtReplacementCost.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(161)));
            this.txtReplacementCost.Location = new System.Drawing.Point(156, 335);
            this.txtReplacementCost.Name = "txtReplacementCost";
            this.txtReplacementCost.Size = new System.Drawing.Size(254, 22);
            this.txtReplacementCost.TabIndex = 42;
            // 
            // txtLength
            // 
            this.txtLength.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(161)));
            this.txtLength.Location = new System.Drawing.Point(157, 227);
            this.txtLength.Name = "txtLength";
            this.txtLength.Size = new System.Drawing.Size(254, 22);
            this.txtLength.TabIndex = 38;
            // 
            // txtRentalRate
            // 
            this.txtRentalRate.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(161)));
            this.txtRentalRate.Location = new System.Drawing.Point(158, 439);
            this.txtRentalRate.Name = "txtRentalRate";
            this.txtRentalRate.Size = new System.Drawing.Size(254, 22);
            this.txtRentalRate.TabIndex = 46;
            // 
            // txtRentalDuration
            // 
            this.txtRentalDuration.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(161)));
            this.txtRentalDuration.Location = new System.Drawing.Point(158, 281);
            this.txtRentalDuration.Name = "txtRentalDuration";
            this.txtRentalDuration.Size = new System.Drawing.Size(254, 22);
            this.txtRentalDuration.TabIndex = 40;
            // 
            // txtReleaseYear
            // 
            this.txtReleaseYear.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(161)));
            this.txtReleaseYear.Location = new System.Drawing.Point(157, 64);
            this.txtReleaseYear.Name = "txtReleaseYear";
            this.txtReleaseYear.Size = new System.Drawing.Size(254, 22);
            this.txtReleaseYear.TabIndex = 34;
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(161)));
            this.label10.ForeColor = System.Drawing.Color.White;
            this.label10.Location = new System.Drawing.Point(556, 172);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(91, 16);
            this.label10.TabIndex = 50;
            this.label10.Text = "Description:";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(161)));
            this.label9.ForeColor = System.Drawing.Color.White;
            this.label9.Location = new System.Drawing.Point(546, 15);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(130, 16);
            this.label9.TabIndex = 49;
            this.label9.Text = "Special Features:";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(161)));
            this.label8.ForeColor = System.Drawing.Color.White;
            this.label8.Location = new System.Drawing.Point(92, 390);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(57, 16);
            this.label8.TabIndex = 48;
            this.label8.Text = "Rating:";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(161)));
            this.label7.ForeColor = System.Drawing.Color.White;
            this.label7.Location = new System.Drawing.Point(13, 338);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(139, 16);
            this.label7.TabIndex = 47;
            this.label7.Text = "Replacement Cost:";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(161)));
            this.label6.ForeColor = System.Drawing.Color.White;
            this.label6.Location = new System.Drawing.Point(94, 230);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(58, 16);
            this.label6.TabIndex = 45;
            this.label6.Text = "Length:";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(161)));
            this.label5.ForeColor = System.Drawing.Color.White;
            this.label5.Location = new System.Drawing.Point(55, 442);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(94, 16);
            this.label5.TabIndex = 43;
            this.label5.Text = "Rental Rate:";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(161)));
            this.label4.ForeColor = System.Drawing.Color.White;
            this.label4.Location = new System.Drawing.Point(33, 284);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(119, 16);
            this.label4.TabIndex = 41;
            this.label4.Text = "Rental Duration:";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(161)));
            this.label3.ForeColor = System.Drawing.Color.White;
            this.label3.Location = new System.Drawing.Point(68, 173);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(81, 16);
            this.label3.TabIndex = 39;
            this.label3.Text = "Language:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(161)));
            this.label2.ForeColor = System.Drawing.Color.White;
            this.label2.Location = new System.Drawing.Point(41, 67);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(108, 16);
            this.label2.TabIndex = 37;
            this.label2.Text = "Release Year:";
            // 
            // txtTitle
            // 
            this.txtTitle.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(161)));
            this.txtTitle.Location = new System.Drawing.Point(156, 12);
            this.txtTitle.Name = "txtTitle";
            this.txtTitle.Size = new System.Drawing.Size(254, 22);
            this.txtTitle.TabIndex = 33;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(161)));
            this.label1.ForeColor = System.Drawing.Color.White;
            this.label1.Location = new System.Drawing.Point(107, 15);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(43, 16);
            this.label1.TabIndex = 32;
            this.label1.Text = "Title:";
            // 
            // btnDeleteImage
            // 
            this.btnDeleteImage.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(161)));
            this.btnDeleteImage.Location = new System.Drawing.Point(1033, 442);
            this.btnDeleteImage.Name = "btnDeleteImage";
            this.btnDeleteImage.Size = new System.Drawing.Size(100, 25);
            this.btnDeleteImage.TabIndex = 58;
            this.btnDeleteImage.Text = "Delete Image";
            this.btnDeleteImage.UseVisualStyleBackColor = true;
            this.btnDeleteImage.Click += new System.EventHandler(this.btnDeleteImage_Click);
            // 
            // btnDelete
            // 
            this.btnDelete.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(161)));
            this.btnDelete.Location = new System.Drawing.Point(625, 504);
            this.btnDelete.Name = "btnDelete";
            this.btnDelete.Size = new System.Drawing.Size(100, 25);
            this.btnDelete.TabIndex = 59;
            this.btnDelete.Text = "Delete";
            this.btnDelete.UseVisualStyleBackColor = true;
            this.btnDelete.Click += new System.EventHandler(this.btnDelete_Click);
            // 
            // FrmMovieEdit
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.DodgerBlue;
            this.ClientSize = new System.Drawing.Size(1184, 541);
            this.Controls.Add(this.btnDelete);
            this.Controls.Add(this.btnDeleteImage);
            this.Controls.Add(this.label12);
            this.Controls.Add(this.label11);
            this.Controls.Add(this.cbxCategories);
            this.Controls.Add(this.btnBrowse);
            this.Controls.Add(this.picBoxImage);
            this.Controls.Add(this.btnSave);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.cbxRatings);
            this.Controls.Add(this.cbxLangueages);
            this.Controls.Add(this.txtDescription);
            this.Controls.Add(this.txtReplacementCost);
            this.Controls.Add(this.txtLength);
            this.Controls.Add(this.txtRentalRate);
            this.Controls.Add(this.txtRentalDuration);
            this.Controls.Add(this.txtReleaseYear);
            this.Controls.Add(this.label10);
            this.Controls.Add(this.label9);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.txtTitle);
            this.Controls.Add(this.label1);
            this.Name = "FrmMovieEdit";
            this.Text = "FrmMovieEdit";
            this.Load += new System.EventHandler(this.FrmMovieEdit_Load);
            ((System.ComponentModel.ISupportInitialize)(this.picBoxImage)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.ComboBox cbxCategories;
        private System.Windows.Forms.Button btnBrowse;
        private System.Windows.Forms.PictureBox picBoxImage;
        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.CheckBox chboxBehindScenes;
        private System.Windows.Forms.CheckBox chboxDeletedScenes;
        private System.Windows.Forms.CheckBox chboxCommentaries;
        private System.Windows.Forms.CheckBox chboxTrailers;
        private System.Windows.Forms.ComboBox cbxRatings;
        private System.Windows.Forms.ComboBox cbxLangueages;
        private System.Windows.Forms.TextBox txtDescription;
        private System.Windows.Forms.TextBox txtReplacementCost;
        private System.Windows.Forms.TextBox txtLength;
        private System.Windows.Forms.TextBox txtRentalRate;
        private System.Windows.Forms.TextBox txtRentalDuration;
        private System.Windows.Forms.TextBox txtReleaseYear;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txtTitle;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btnDeleteImage;
        private System.Windows.Forms.Button btnDelete;
    }
}