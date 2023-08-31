using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using recreation.Music;

namespace recreation
{
    public partial class List : UserControl
    {
        public static List list;
        public static ListSong song;
        public List()
        {
            InitializeComponent();
            list = this;
        }
        private void List_Load(object sender, EventArgs e)
        {

            listView1.Columns[3].Width = listView1.Width - listView1.Columns[0].Width - listView1.Columns[1].Width- listView1.Columns[2].Width;
        }

        private void listView1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (listView1.SelectedIndices.Count > 0)
            {
                int count = listView1.SelectedIndices[0];
                song = MusicPlayer.allSongs[count];
                Playing.playing.Show();
                MusicPlayer.musicPlayer.panelMain.Controls.Clear();
                MusicPlayer.musicPlayer.panelMain.Controls.Add(Playing.playing);
                MusicPlayer.musicPlayer.uiLight1.Top = MusicPlayer.musicPlayer.playingPage_Btn.Top;
                Playing.playing.Title_label.Text = song.Name;
                Playing.playing.author.Text = song.Artists;
                List<Comment> comments = Search.getComment(song.Id);
                foreach (Comment comment in comments)
                {
                    Playing.playing.uiTextBox1.AppendText(comment.Username + "：" + comment.Content + "——" + "\r\n" + "\r\n");
                }
                string result = Search.findById(song.Id);
                if (result == "no")
                {
                    MessageBox.Show("对不起,暂无版权");
                }
                else
                {
                    MusicPlayer.musicPlayer.player.URL = Search.findById(song.Id);
                    MusicPlayer.musicPlayer.player.Ctlcontrols.play();
                    MusicPlayer.musicPlayer.play_Btn.Image = Properties.Resources.pause_down;
                    string lrc = Search.findLrcById(song.Id);
                    MusicPlayer.musicPlayer.lrcs = lrc.Split('\n');
                    MusicPlayer.musicPlayer.lrcs = MusicPlayer.musicPlayer.lrcs.Take(MusicPlayer.musicPlayer.lrcs.Count() - 1).ToArray();
                    MusicPlayer.writeLrc(lrc);
                    MusicPlayer.FormatLrc(MusicPlayer.musicPlayer.lrcs);
                }
            }
        }


        ////存储音乐文件路径集合
        //List<string> listPath = new List<string>();
        //private void choice_Click(object sender, EventArgs e)
        //{
        //    OpenFileDialog ofd = new OpenFileDialog();
        //    ofd.InitialDirectory = @"C:\Users\86177\Desktop\一大堆\C#\大作业\recreation\Music\mus"; 
        //    ofd.Filter = "所有文件|*.*|音乐文件|*.wav|MP3文件|*.mp3";
        //    ofd.Title = "请选择音乐文件";
        //    ofd.Multiselect = true;
        //    ofd.ShowDialog();

        //    // 获得在文本框中选择文件的全路径
        //    string[] path = ofd.FileNames;
        //    for (int i = 0; i < path.Length; i++)
        //    {
        //        //路径存入集合
        //        listPath.Add(path[i]);

        //        //音乐文件名存储到listBox
        //        listBox1.Items.Add(Path.GetFileName(path[i]));
        //    }

        //}

    }

}
