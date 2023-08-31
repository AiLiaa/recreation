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
    public partial class VideoDownloadPage : Form
    {
        public string videourl;
        public DownloadStep1 step1;
        public DownloadStep2 step2;
        int page = 1;


        public VideoDownloadPage()
        {
            InitializeComponent();
            step1 = new DownloadStep1();
            step2 = new DownloadStep2();
            uiPanel1.Controls.Add(step1);
            step1.Show();
        }

        private void VideoDownloadPage_Load(object sender, EventArgs e)
        {
            resourcesLabel.Text = videourl;
        }

        private void uiButton3_Click(object sender, EventArgs e)
        {
            Clipboard.SetDataObject(resourcesLabel.Text);
        }

        private void uiButton1_Click(object sender, EventArgs e)
        {
            if (page == 1)
            {
                MessageBox.Show("没有上一步咯！");
            }
            else {
                step1.Show();//对窗体1进行显示
                uiPanel1.Controls.Clear();
                uiPanel1.Controls.Add(step1);
            }
        }

        private void uiButton2_Click(object sender, EventArgs e)
        {
            if (page == 2)
            {
                MessageBox.Show("没有下一步咯！");
            }
            else
            {
                step2.Show();//对窗体2进行显示
                uiPanel1.Controls.Clear();
                uiPanel1.Controls.Add(step2);
            }
        }
    }
}
