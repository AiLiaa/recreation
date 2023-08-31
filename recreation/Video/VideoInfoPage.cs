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
    public partial class VideoInfoPage : Form
    {
        public VideoInfoStorage vis;

        public VideoInfoPage()
        {
            InitializeComponent();
        }

        private void VideoInfoPage_Load(object sender, EventArgs e)
        {
            pictureBox1.Load(vis.cover);
            videoTypeLabel.Text = vis.videoType;
            titleLabel.Text = vis.title;
            directorLabel.Text = vis.director;
            actorLabel.Text = vis.actor;
            regionLabel.Text = vis.region;
            descsLabel.Text = vis.descs;
        }
    }
}
