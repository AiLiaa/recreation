using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;
using System.Windows.Forms;
using System.IO;

namespace recreation.Novel
{
    public partial class mainForm : Form
    {

        List<DataItem> tempresult;
        public static List<fiction_json> bookshelf_json { get; set; }
        public mainForm()
        {
            InitializeComponent();
            bookshelf_json = new List<fiction_json>();
            this.fiction_json_init();
        }

        //搜索按钮
        private async void button1_Click(object sender, EventArgs e)
        {
           
            if (TextBox1.Text.Length!=0 )
            {
                string url = "https://api.pingcc.cn/fiction/search/title/" + TextBox1.Text + "/1/20";

                string getJson = await HttpUtils.Get(url);

                Root rt = JsonConvert.DeserializeObject<Root>(getJson);

                List<DataItem> searchresult = rt.data;

                listView1.Items.Clear();

                if (searchresult != null)
                {
                    for (int i = 0; i < searchresult.Count; i++)
                    {

                        ListViewItem item = new ListViewItem();             //先实例化ListViewItem这个类
                        item.Text = searchresult[i].fictionType;            //添加作品名称内容,注意是"Text"
                        item.SubItems.Add(searchresult[i].title);           //添加小说类型内容
                        item.SubItems.Add(searchresult[i].author);          //添加作者内容
                        item.SubItems.Add(searchresult[i].updateTime);      //添加最近更新时间
                        listView1.Items.Add(item);                          //集体添加进去

                    }
                    tempresult = searchresult;
                }
                else {

                    MessageBox.Show("没有找到与" + TextBox1.Text + "相关小说");
                }
            }
            else {

                MessageBox.Show("请输入书名！");
            
            }
        }

  

        private async void listView1_DoubleClick(object sender, EventArgs e)
        {
            if (listView1.SelectedItems.Count > 0) { 

            int x = listView1.SelectedIndices.Count;
            int y = listView1.SelectedIndices[x - 1];

            string fictionid = tempresult[y].fictionId;
            Data tempdata = await HttpUtils.findnovel(fictionid);
            Datastatic.author = tempdata.author;
            Datastatic.chapterList = tempdata.chapterList;
            Datastatic.cover = tempdata.cover;
            Datastatic.descs = tempdata.descs;
            Datastatic.fictionId = tempdata.fictionId;
            Datastatic.fictionType = tempdata.fictionType;
            Datastatic.title = tempdata.title;
            Datastatic.updateTime = tempdata.updateTime;

        }
            detailPage dp = new detailPage();
            dp.Show();
            
        }

        private void mainForm_Load(object sender, EventArgs e)
        {
            //设置行高
            ImageList imgList = new ImageList();

            imgList.ImageSize = new Size(1, 20);//分别是宽和高

            listView1.SmallImageList = imgList;   //这里设置listView的SmallImageList ,用imgList将其撑大。
        }


        //读取txt文件并反序列化
        public void fiction_json_init()
        {
            string nextLine;
            StreamReader sR = new StreamReader(@"C:\Users\86177\Desktop\一大堆\C#\recreation\Novel\bookshelf_json\a.txt", Encoding.UTF8);
            if (bookshelf_json.Count > 0)
            {
                bookshelf_json.Clear();
            }
            while ((nextLine = sR.ReadLine()) != null)
                {

                    fiction_json fj = JsonConvert.DeserializeObject<fiction_json>(nextLine);
                    /*Console.WriteLine(fj.fiction_name);*/
                    bookshelf_json.Add(fj);
                }
            sR.Close();
        }


        //书架展示
        public void showbook()
        {
            
            int ColumnNum = 6;//每一行显示的列数

            int controlWidth = 145;//每个控件占位宽度

            int controlHeight = 164;//每个控件占位高度

            for (int i = 0; i < bookshelf_json.Count; i++)
            {
                int rowsCount = i/ ColumnNum;//第几行
                /*图片*/
                PictureBox pic = new PictureBox
                {
                    Size = new Size(76, 100),
                    Name = bookshelf_json[i].fiction_name,
                    Tag=bookshelf_json[i].fiction_id,
                    Parent = tabPage2,
                    Location = new Point(controlWidth * (i - ColumnNum * rowsCount) + 35, rowsCount * controlHeight + 25)
                };
                pic.Load(bookshelf_json[i].fiction_cover);
                pic.SizeMode = PictureBoxSizeMode.StretchImage;
                this.tabPage2.Controls.Add(pic);
                pic.ContextMenuStrip = uiContextMenuStrip1;
                /*pic.MouseClick += new MouseEventHandler(pictureBox1_MouseClick);*/
                /*标题*/
                Label lab = new Label
                {
                    Size = new Size(120, 30),//设置大小
                    Location = new Point(controlWidth * (i - ColumnNum * rowsCount) + 35, rowsCount * controlHeight + 136),//设置坐标
                    Text = bookshelf_json[i].fiction_name
                };

                this.tabPage2.Controls.Add(lab);
            }
        }

 /*       private async void pictureBox1_MouseClick(object sender, MouseEventArgs e)
        {
            string fiction_id = ;
            Data tempdata = await HttpUtils.findnovel(fiction_id);
            Datastatic.author = tempdata.author;
            Datastatic.chapterList = tempdata.chapterList;
            Datastatic.cover = tempdata.cover;
            Datastatic.descs = tempdata.descs;
            Datastatic.fictionId = tempdata.fictionId;
            Datastatic.fictionType = tempdata.fictionType;
            Datastatic.title = tempdata.title;
            Datastatic.updateTime = tempdata.updateTime;
            detailPage dp = new detailPage();
            dp.Show();
        }*/

        private void tabControl1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (tabControl1.SelectedTab.Name == "tabPage2")
            {
                this.showbook();
            }
        }

        //判断书架相关书籍是否存在
        //<return>true:存在，false:不存在。
        public static bool check_ficton_exist(fiction_json fiction_Json)
        {
            foreach (fiction_json fj in bookshelf_json) {
                if (fiction_Json.fiction_id==fj.fiction_id) {
                    return true;
                }
            }
            return false;
        }


        string pic_id = "";
        private async void 阅读小说ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            string fiction_id = pic_id;
            Data tempdata = await HttpUtils.findnovel(fiction_id);
            Datastatic.author = tempdata.author;
            Datastatic.chapterList = tempdata.chapterList;
            Datastatic.cover = tempdata.cover;
            Datastatic.descs = tempdata.descs;
            Datastatic.fictionId = tempdata.fictionId;
            Datastatic.fictionType = tempdata.fictionType;
            Datastatic.title = tempdata.title;
            Datastatic.updateTime = tempdata.updateTime;
            detailPage dp = new detailPage();
            dp.Show();
        }

        string picName = "";

        private void 删除小说ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            string filePath = @"C:\Users\86177\Desktop\一大堆\C#\recreation\Novel\bookshelf_json\a.txt";

            
            try
            {
                fiction_json Fj = new fiction_json();

                Fj = bookshelf_json.FirstOrDefault(t=>t.fiction_name==picName);

                bookshelf_json.Remove(Fj);//删除对应书籍在bookshelf_json数组中的对象

                StreamWriter sW = new StreamWriter(filePath, false, Encoding.UTF8);//覆盖原有的txt文件

                foreach (fiction_json updata_novel in bookshelf_json) {
                    /*Console.WriteLine(updata_novel.fiction_name);*/
                    string json_fic_detail = JsonConvert.SerializeObject(updata_novel);
                    sW.WriteLine(json_fic_detail);
                }
                sW.Flush();
                sW.Close();
                this.tabPage2.Controls.Clear();

                this.fiction_json_init();
               
                showbook();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

        }

        private void uiContextMenuStrip1_Opening(object sender, CancelEventArgs e)
        {
            picName = (sender as ContextMenuStrip).SourceControl.Name;
            pic_id = (sender as ContextMenuStrip).SourceControl.Tag.ToString();
        }

       

    }
}
