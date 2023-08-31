using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace recreation.Video
{
    public partial class playerPage : UserControl
    {

        public playerPage()
        {
            InitializeComponent();
        }

        private void uiSymbolButton1_Click(object sender, EventArgs e)
        {
            axWindowsMediaPlayer1.Ctlcontrols.fastReverse();
        }

        private void uiImageButton1_Click(object sender, EventArgs e)
        {
            axWindowsMediaPlayer1.URL = URLStorage.url;
            axWindowsMediaPlayer1.Ctlcontrols.play();
        }

        private void uiImageButton2_Click(object sender, EventArgs e)
        {
            axWindowsMediaPlayer1.Ctlcontrols.fastForward();
        }

        private void uiImageButton4_Click(object sender, EventArgs e)
        {
            axWindowsMediaPlayer1.Ctlcontrols.pause();
        }

        private void uiImageButton3_Click(object sender, EventArgs e)
        {
            axWindowsMediaPlayer1.Ctlcontrols.fastReverse();
        }
    }
}
