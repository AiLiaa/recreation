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
    public partial class UserControl2 : UserControl
    {

        public UserControl2()
        {
            InitializeComponent();
        }

        private void uiButton1_Click(object sender, EventArgs e)
        {
            OpenFileDialog fileDialog = new OpenFileDialog();
            fileDialog.Multiselect = false;
            fileDialog.Title = "请选择文件";
            if (fileDialog.ShowDialog() == DialogResult.OK) 
            {
                uiTextBox1.Text = fileDialog.FileName;
                //将用户输入的url信息存入全局类
                URLStorage.url = fileDialog.FileName;


                string path = @"D:\\history.txt";
                if (!File.Exists(path))
                {
                    //文件不存在时，先创建文件
                    using (FileStream fs = File.Create(path))
                    {
                        fs.Close();
                        fs.Dispose();
                    }
                }
                //创建StreamWriter 类的实例
                StreamWriter streamWriter = new StreamWriter(path,append: true);
                //向文件中写入地址
                streamWriter.WriteLine("在 " + DateTime.Now.ToLocalTime().ToString() + " 访问了： " + URLStorage.url);
                //刷新缓存
                streamWriter.Flush();
                //关闭流
                streamWriter.Close();
            }
        }

        private void uiButton2_Click(object sender, EventArgs e)
        {
            //将用户输入的url信息存入全局类
            URLStorage.url = uiTextBox2.Text;

            string path = @"D:\\history.txt";
            if (!File.Exists(path))
            {
                //文件不存在时，先创建文件
                using (FileStream fs = File.Create(path))
                {
                    fs.Close();
                    fs.Dispose();
                }
            }
            //创建StreamWriter 类的实例
            StreamWriter streamWriter = new StreamWriter(path,append: true);
            //向文件中写入地址
            streamWriter.WriteLine("在 " + DateTime.Now.ToLocalTime().ToString()+ " 访问了： " + URLStorage.url);
            //刷新缓存
            streamWriter.Flush();
            //关闭流
            streamWriter.Close();
        }
    }
}
