namespace Video_Club_Application
{
    partial class FrmActorsInfo
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
            this.dgvActorsInfo = new System.Windows.Forms.DataGridView();
            this.lblMovieTitle = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.dgvActorsInfo)).BeginInit();
            this.SuspendLayout();
            // 
            // dgvActorsInfo
            // 
            this.dgvActorsInfo.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvActorsInfo.Location = new System.Drawing.Point(12, 32);
            this.dgvActorsInfo.Name = "dgvActorsInfo";
            this.dgvActorsInfo.Size = new System.Drawing.Size(245, 317);
            this.dgvActorsInfo.TabIndex = 0;
            // 
            // lblMovieTitle
            // 
            this.lblMovieTitle.AutoSize = true;
            this.lblMovieTitle.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(161)));
            this.lblMovieTitle.ForeColor = System.Drawing.Color.White;
            this.lblMovieTitle.Location = new System.Drawing.Point(9, 9);
            this.lblMovieTitle.Name = "lblMovieTitle";
            this.lblMovieTitle.Size = new System.Drawing.Size(51, 16);
            this.lblMovieTitle.TabIndex = 6;
            this.lblMovieTitle.Text = "label1";
            // 
            // FrmActorsInfo
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.DodgerBlue;
            this.ClientSize = new System.Drawing.Size(269, 361);
            this.Controls.Add(this.lblMovieTitle);
            this.Controls.Add(this.dgvActorsInfo);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Name = "FrmActorsInfo";
            this.Text = "Actors Info";
            this.Load += new System.EventHandler(this.FrmActorsInfo_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgvActorsInfo)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView dgvActorsInfo;
        private System.Windows.Forms.Label lblMovieTitle;
    }
}