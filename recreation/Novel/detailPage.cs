using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Newtonsoft.Json;
using System.IO;

namespace recreation.Novel
{
    public partial class detailPage : Form
    {
        mainForm mf = new mainForm();
        public detailPage()
        {
            InitializeComponent();
        }

        private void detailPage_Load(object sender, EventArgs e)
        {   
            label2.Text = Datastatic.title;
            label8.Text = Datastatic.author;
            label10.Text = Datastatic.fictionType;
            label11.Text = Datastatic.updateTime;
            label7.Text = Datastatic.descs;
            pictureBox1.Load(Datastatic.cover);
            pictureBox1.SizeMode = PictureBoxSizeMode.StretchImage;
            //this.pictureBox1.Image = Image.From(Datastatic.cover);
            List<ChapterListItem> chapList = Datastatic.chapterList;
            int n = chapList.Count;
            label9.Text = chapList[n - 1].title;
            foreach (ChapterListItem chaper in chapList ) {
                ListViewItem _chapter = new ListViewItem(chaper.title);
                listView1.Items.Add(_chapter);
                
            }

            //设置行高
            ImageList imgList = new ImageList();

            imgList.ImageSize = new Size(20, 20);//分别是宽和高

            listView1.SmallImageList = imgList;   //这里设置listView的SmallImageList ,用imgList将其撑大。

            //设置每列的宽度
            foreach (ColumnHeader item in listView1.Columns) {
                item.Width = (this.listView1.Width / 100) * 33;
            }

        }

        //添加书籍到书架
        private void add_bookshelf_Click(object sender, EventArgs e)
        {
            
            //序列化小说
            fiction_json selected_novel = new fiction_json(Datastatic.fictionId, Datastatic.title, Datastatic.cover);
            string json_fic_detail = JsonConvert.SerializeObject(selected_novel);
            /*Console.WriteLine(mainForm.bookshelf_json.Count);*/
            Boolean fic_if_exist = mainForm.check_ficton_exist(selected_novel);
            if (fic_if_exist)
            {
                MessageBox.Show("该书已存在在书架中。");
            }
            else
            {
                string str1 = @"D:\ProgramData\sourecVS2019\recreation\Novel\bookshelf_json";
                string str2 = "a.txt";
                string path = Path.Combine(str1, str2);
                StreamWriter sW = new StreamWriter(path, true, Encoding.UTF8);
                sW.WriteLine(json_fic_detail);
                sW.Flush();
                sW.Close();
                MessageBox.Show("添加成功！");
                mf.fiction_json_init();
            }
        }

        private void startRead_Click(object sender, EventArgs e)
        {
            Form1 f1 = new Form1();
            f1.Show();
        }
    }
}
