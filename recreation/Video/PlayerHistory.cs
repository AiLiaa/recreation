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

namespace recreation.Video
{
    public partial class PlayerHistory : UserControl
    {
        public PlayerHistory()
        {
            InitializeComponent();
        }

        private void PlayerHistory_Load(object sender, EventArgs e)
        {
            string path = @"D:\\history.txt";
            if (!File.Exists(path))
            {

                //如果找不到这个文件，说明还没有访问就打开了历史记录
                textBox1.Text = "暂无消息";

            }
            else
            {
                //打开文件
                FileStream fs = File.OpenRead(path);

                //读取文件的一行数据到字符串中
                StreamReader sr = new StreamReader(fs);
                //string str;
                //str = sr.ReadLine();
                //读取到最后
                while (!sr.EndOfStream)
                {
                    textBox1.Text += sr.ReadLine() + "\r\n";
                }
                sr.Close();
            }
        }

        private void PlayerHistory_Layout(object sender, LayoutEventArgs e)
        {
            
        }

        private void uiButton1_Click(object sender, EventArgs e)
        {
            textBox1.Text = "";
            string path = @"D:\\history.txt";
            if (!File.Exists(path))
            {

                //如果找不到这个文件，说明还没有访问就打开了历史记录
                textBox1.Text = "暂无消息";

            }
            else
            {
                //打开文件
                FileStream fs = File.OpenRead(path);

                //读取文件的一行数据到字符串中
                StreamReader sr = new StreamReader(fs);
                //string str;
                //str = sr.ReadLine();
                //读取到最后
                while (!sr.EndOfStream)
                {
                    textBox1.Text += sr.ReadLine() + "\r\n";
                }
                sr.Close();
            }
        }
    }
}
