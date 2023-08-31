using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using recreation.Login;
using recreation.Music;
using recreation.Novel;
using recreation.Video;

namespace recreation
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void musicButton_Click(object sender, EventArgs e)
        {
            MusicPlayer player = new MusicPlayer();
            player.Show();
        }

        private void loginButton_Click(object sender, EventArgs e)
        {
            LoginMain login = new LoginMain();
            login.Show();
        }

        private void novelButton_Click(object sender, EventArgs e)
        {
            mainForm form1 = new mainForm();
            form1.Show();
        }

        private void videaButton_Click(object sender, EventArgs e)
        {
            LYH_main lYH_Main = new LYH_main();
            lYH_Main.Show();
        }
    }
}
