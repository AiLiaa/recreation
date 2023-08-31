using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using recreation.Music;
using recreation.Login;
using recreation.Video;
using recreation.Novel;

namespace recreation
{
    public partial class MusicPlayer : Form
    {
        public string[] lrcs;
        public static MusicPlayer musicPlayer;
        public static List<ListSong> allSongs = new List<ListSong>();
        public MusicPlayer()
        {
            InitializeComponent();
            // 在构造中调用此函数
            SetClassLong(this.Handle, GCL_STYLE, GetClassLong(this.Handle, GCL_STYLE) | CS_DropSHADOW);
            musicPlayer = this;
        }
        //阴影
        private const int CS_DropSHADOW = 0x20000;
        private const int GCL_STYLE = (-26);

        [DllImport("user32.dll", CharSet = CharSet.Auto)]
        public static extern int SetClassLong(IntPtr hwnd, int nIndex, int dwNewLong);
        [DllImport("user32.dll", CharSet = CharSet.Auto)]
        public static extern int GetClassLong(IntPtr hwnd, int nIndex);

        //无边框窗体移动
        int oldX, oldY;
        //鼠标按下
        private void DxLogin_MouseDown(object sender, MouseEventArgs e)
        {
            //判断是否为鼠标左键
            if (e.Button == MouseButtons.Left)
            {
                //获取鼠标左键按下时的位置
                this.oldX = e.Location.X;
                this.oldY = e.Location.Y;
            }
        }

        //鼠标移动
        private void DxLogin_MouseMove(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                //计算鼠标移动距离
                this.Left += e.Location.X - this.oldX;
                this.Top += e.Location.Y - this.oldY;
            }
        }

        //用户控件分页
        public Playing playing;
        public List list;

        //初始化为播放页面
        private void MusicPlayer_Load(object sender, EventArgs e)
        {
            playing = new Playing();
            list = new List();
            playing.Show();
            panelMain.Controls.Clear();
            panelMain.Controls.Add(playing);

            player.settings.autoStart = false;
            //player.URL = "C:\\Users\\86177\\Desktop\\一大堆\\C#\\大作业\\recreation\\Music\\mus\\Capo Productions - Journey.mp3";
        }

        //转到播放页面
        private void playingPage_Btn_Click(object sender, EventArgs e)
        {
            playing.Show();
            panelMain.Controls.Clear();
            panelMain.Controls.Add(playing);

            uiLight1.Top = playingPage_Btn.Top;

            uiLabel1.Visible = true;
            uiLabel2.Visible = true;
            uiLabel3.Visible = true;
            uiLabel4.Visible = true;
            uiLabel5.Visible = true;
            uiLabel6.Visible = true;
            uiLabel7.Visible = true;
            uiLabel8.Visible = true;
        }

        //跳转到歌单页面
        private void musicListPage_Btn_Click(object sender, EventArgs e)
        {
            list.Show();
            panelMain.Controls.Clear();
            panelMain.Controls.Add(list);

            uiLight1.Top = musicListPage_Btn.Top;

            uiLabel1.Visible = false;
            uiLabel2.Visible = false;
            uiLabel3.Visible = false;
            uiLabel4.Visible = false;
            uiLabel5.Visible = false;
            uiLabel6.Visible = false;
            uiLabel7.Visible = false;
            uiLabel8.Visible = false;

            if (LoginMain.user == null)
            {
                MessageBox.Show("请先登录！");
            }
            else
            {
                if (allSongs.Count > 0)
                {

                }
                else
                {
                    Search.getSongList(LoginMain.user.Uid);
                    List<ListViewItem> additems = new List<ListViewItem>();
                    foreach (SongList songList in Search.songLists)
                    {
                        List<ListSong> listSongs = Search.getSongByList(songList.Id);
                        allSongs.AddRange(listSongs);
                        foreach (ListSong list in listSongs)
                        {
                            ListViewItem additem = new ListViewItem();
                            additem.SubItems.Clear();
                            additem.Text = list.Name;
                            additem.SubItems.Add(list.Artists);
                            additem.SubItems.Add(list.Time);
                            additem.SubItems.Add("网易云");
                            additems.Add(additem);
                        }
                    }
                    List.list.listView1.LoadListViewItems(additems);
                }
            }
            
            

        }

        //关闭播放器
        private void exit_Btn_Click(object sender, EventArgs e)
        {
            try
            {
                Close();
                player.Ctlcontrols.stop();
            }
            catch
            {

            }

        }

        //播放器
        void play()
        {
            player.Ctlcontrols.play();
            //加载歌词
            //IsExistLrc("C:\\Users\\86177\\Desktop\\一大堆\\C#\\大作业\\recreation\\Music\\mus\\Capo Productions - Journey.txt");
            FormatLrc(lrcs);
            play_Btn.Image = recreation.Properties.Resources.pause_down;
        }
        void pause()
        {
            player.Ctlcontrols.pause();
            play_Btn.Image = recreation.Properties.Resources.play_down;
        }

        private void play_Btn_Click(object sender, EventArgs e)
        {    
            //播放中，点击暂停
            if (player.playState == WMPLib.WMPPlayState.wmppsPlaying)
            {
                player.Ctlcontrols.pause();
                play_Btn.Image = recreation.Properties.Resources.play_down;

            }
            else
            {
                //暂停中，点击播放
                player.Ctlcontrols.play();
                //加载歌词
                //IsExistLrc("C:\\Users\\86177\\Desktop\\一大堆\\C#\\大作业\\recreation\\Music\\mus\\Capo Productions - Journey.txt");
                Console.WriteLine(lrcs);
                FormatLrc(lrcs);
                play_Btn.Image = recreation.Properties.Resources.pause_down;

            }
        }
        //下一首
        private void next_Btn_Click(object sender, EventArgs e)
        {

            player.Ctlcontrols.next();
        }
        //上一首
        private void preview_Btn_Click(object sender, EventArgs e)
        {
            player.Ctlcontrols.previous();
        }
        //搜索框文字变化
        private void searchBox_Click(object sender, EventArgs e)
        {
            searchBox.Text = "";
        }
        //播放组件变化
        private void preview_Btn_MouseHover(object sender, EventArgs e)
        {
            preview_Btn.Image = recreation.Properties.Resources.preview_on;
        }

        private void preview_Btn_MouseLeave(object sender, EventArgs e)
        {
            preview_Btn.Image = recreation.Properties.Resources.preview_down;
        }

        private void play_Btn_MouseHover(object sender, EventArgs e)
        {
            //播放中
            if (player.playState == WMPLib.WMPPlayState.wmppsPlaying)
            {
                play_Btn.Image = recreation.Properties.Resources.pause_on;
            }
            else
            {
                play_Btn.Image = recreation.Properties.Resources.play_on;
            }
        }

        private void play_Btn_MouseLeave(object sender, EventArgs e)
        {
            //播放中
            if (player.playState == WMPLib.WMPPlayState.wmppsPlaying)
            {
                play_Btn.Image = recreation.Properties.Resources.pause_down;
            }
            else
            {
                play_Btn.Image = recreation.Properties.Resources.play_down;
            }
        }

        private void next_Btn_MouseHover(object sender, EventArgs e)
        {
            next_Btn.Image = recreation.Properties.Resources.next_on;
        }

        private void next_Btn_MouseLeave(object sender, EventArgs e)
        {
            next_Btn.Image = recreation.Properties.Resources.next_down;
        }

        private void serachMusicListBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            string keyword = searchBox.Text;
            if (keyword == "")
            {
                searchBtn_Click(new object(), new EventArgs());
            }
            else
            {
                serachMusicListBox.Visible = false;
                if (serachMusicListBox.SelectedIndices.Count > 0)
                {
                    int count = serachMusicListBox.SelectedIndices[0];
                    SearchResultSong song = Search.resultSongs[count];
                    Playing.playing.Title_label.Text = song.Name;
                    Playing.playing.author.Text = song.Artists;
                    
                    List<Comment> comments =  Search.getComment(song.Id);
                    if (comments != null)
                    {
                        foreach (Comment comment in comments)
                        {
                            Playing.playing.uiTextBox1.AppendText(comment.Username + "：" + comment.Content + "——" + "\r\n" + "\r\n");
                        }
                 
                    }
                    string result = Search.findById(song.Id);
                    if (result == "no")
                    {
                        MessageBox.Show("对不起,暂无版权");
                    }
                    else
                    {
                        player.URL = Search.findById(song.Id);
                        player.Ctlcontrols.play();
                        play_Btn.Image = Properties.Resources.pause_down;
                        string lrc = Search.findLrcById(song.Id);
                        lrcs = lrc.Split('\n');
                        lrcs = lrcs.Take(lrcs.Count() - 1).ToArray();
                        writeLrc(lrc);
                        FormatLrc(lrcs);
                    }

                }
            }
        }

        #region 将歌词写入txt
        public static void writeLrc(string lrc)
        {
            try
            {
                string path = Environment.CurrentDirectory;
                string filePath = path + @"\歌词.txt";
                if (!File.Exists(filePath))
                {
                    //没有则创建这个文件
                    FileStream fs1 = new FileStream(filePath, FileMode.Create, FileAccess.Write);//创建写入文件                //设置文件属性为隐藏
                    System.IO.File.SetAttributes(filePath, FileAttributes.Normal);
                    StreamWriter sw = new StreamWriter(fs1);
                    sw.Write(lrc);
                    sw.Close();
                    fs1.Close();
                }
                else
                {
                    File.Delete(filePath);
                    //没有则创建这个文件
                    FileStream fs1 = new FileStream(filePath, FileMode.Create, FileAccess.Write);//创建写入文件                //设置文件属性为隐藏
                    System.IO.File.SetAttributes(filePath, FileAttributes.Normal);
                    StreamWriter sw = new StreamWriter(fs1);
                    sw.Write(lrc);
                    sw.Close();
                    fs1.Close();
                }
            }
            catch (Exception error)
            {
                Console.WriteLine(error.Message);
            }
        }
        #endregion


        //播放歌词
        private void timer1_Tick(object sender, EventArgs e)
        {
            for (int i = 0; i < listTime.Count; i++)
            {
                if (player.Ctlcontrols.currentPosition >= listTime[i] && player.Ctlcontrols.currentPosition < listTime[i + 1])
                {
                    if (i - 2 >= 0)
                    {
                        uiLabel1.Text = listLrcText[i - 2];
                        uiLabel2.Text = listLrcText[i - 1];
                        uiLabel3.Text = listLrcText[i];
                        uiLabel4.Text = listLrcText[i + 1];
                        uiLabel5.Text = listLrcText[i + 2];
                        uiLabel6.Text = listLrcText[i + 3];
                        uiLabel7.Text = listLrcText[i + 4];
                        uiLabel8.Text = listLrcText[i + 5];
                    }
                    else
                    {
                        uiLabel5.Text = "准备歌词中....";
                    }

                }
            }

        }


        void IsExistLrc(string songPath)
        {

            if (File.Exists(songPath))
            {
                //读取歌词文件
                string[] lrcText = File.ReadAllLines(songPath, Encoding.UTF8);
                //格式化歌词
                FormatLrc(lrcText);
            }
            else//歌词不存在
            {
                uiLabel1.Text = "----歌词不存在----";
            }
        }

        //存储时间 歌词
        public static int last;
        public static List<double> listTime = new List<double>();
        public static List<string> listLrcText = new List<string>();

        //格式化歌词，拿到时间和歌词
        public static void FormatLrc(string[] lrcText)
        {
            for (int i = 0; i < lrcText.Length; i++)
            {
                Console.WriteLine(lrcText[i]);
                //分出时间和歌词
                string[] lrcTemp = lrcText[i].Split(new char[] { '[', ']' }, StringSplitOptions.RemoveEmptyEntries);
                //时分秒
                string[] lrcNewTemp = lrcTemp[0].Split(new char[] { ':' }, StringSplitOptions.RemoveEmptyEntries);
                //转换成秒
                double time = double.Parse(lrcNewTemp[0]) * 60 + double.Parse(lrcNewTemp[1]);
                if (lrcTemp.Length == 2)
                {
                    //加入集合中
                    listTime.Add(time);
                    listLrcText.Add(lrcTemp[1]);
                }
                last = listTime.Count - 1;
                MusicPlayer.musicPlayer.timer2.Enabled = true;
                MusicPlayer.musicPlayer.uiLabel9.Text = Until.formatLongToTimeStr((1000 * listTime[last]).ToString());
                /*                else
                                {
                                    listTime.Add(time);
                                    listLrcText.Add("     ");
                                }*/
            }
        }
        private void timer2_Tick(object sender, EventArgs e)
        {

            uiProcessBar1.Value = (int)(100 * (player.Ctlcontrols.currentPosition / listTime[last]));

        }
        private void searchBox_MouseClick(object sender, MouseEventArgs e)
        {
/*            Console.WriteLine("ssssss");
            List<string> singers =  Search.getHotSinger();
            serachMusicListBox.Visible = true;
            foreach (string singer in singers)
            {
                string result = singer;
                serachMusicListBox.Items.Add(result);
            }*/
        }

        private void uiImageButton1_Click(object sender, EventArgs e)
        {
            LoginMain login = new LoginMain();
            login.Show();
        }

        private void uiImageButton2_Click(object sender, EventArgs e)
        {
            mainForm mainform = new mainForm();
            mainform.Show();
        }

        private void uiImageButton3_Click(object sender, EventArgs e)
        {
            LYH_main lYH_Main = new LYH_main();
            lYH_Main.Show();
        }




        //搜索
        private void searchBtn_Click(object sender, EventArgs e)
        {
            string keyword = searchBox.Text;
            Search.search(keyword);
            serachMusicListBox.Visible = true;
            foreach (SearchResultSong song in Search.resultSongs)
            {
                string result = song.Name + "  " + song.Artists +"     " + song.Source;
                serachMusicListBox.Items.Add(result);
            }
        }

    }
}
