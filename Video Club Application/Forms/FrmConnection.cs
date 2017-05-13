using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Video_Club_Application
{
    public partial class FrmConnection : Form
    {
        public FrmConnection()
        {
            InitializeComponent();

            ShowConnectionState();
        }

        // METHODS
        private void ShowConnectionState()
        {
            this.BackColor = (DataBase.connection.State == ConnectionState.Open) ? Color.Green : Color.Red;
        }

        // EVENTS
        private void btnConnect_Click(object sender, EventArgs e)
        {
            DataBase.Connect(txtServer.Text, txtPort.Text, txtUser.Text, txtPassword.Text);
            ShowConnectionState();
        }

        private void btnDiconnect_Click(object sender, EventArgs e)
        {
            DataBase.Disconnect();
            ShowConnectionState();
        }
    }
}
