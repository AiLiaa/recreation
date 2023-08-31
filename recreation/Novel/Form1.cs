using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace recreation.Novel
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        //上一章
        private void uiButton1_Click(object sender, EventArgs e)
        {
            SelectChapter(uiTreeView1.Nodes[uiTreeView1.SelectedNode.Index - 1].Tag.ToString()) ;
            uiTreeView1.SelectedNode = uiTreeView1.Nodes[uiTreeView1.SelectedNode.Index - 1];
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            List<ChapterListItem> chaplist = Datastatic.chapterList;
            foreach (ChapterListItem chap in chaplist) {
                TreeNode chap_node = new TreeNode();
                chap_node.Text = chap.title;
                chap_node.Tag = chap.chapterId;
                this.uiTreeView1.Nodes.Add(chap_node);
            }
            //默认选取第一个节点
            uiTreeView1.SelectedNode = uiTreeView1.Nodes[0];
            //选择章节内容
            SelectChapter(uiTreeView1.Nodes[0].Tag.ToString());

        }
      
        private void uiTreeView1_NodeMouseClick(object sender, TreeNodeMouseClickEventArgs e)
        {
            uiTreeView1.SelectedNode = e.Node;
            string id = uiTreeView1.SelectedNode.Tag.ToString();
            SelectChapter(id);
        }

        private async void SelectChapter(string chapter_id)
        {
            if (uiTextBox1.Text != null) { uiTextBox1.Text = null; }
            chapContent chap_json = await HttpUtils.find_chap_cont(chapter_id);
            List<string> strContent = chap_json.data;
            uiLabel2.Text = uiTreeView1.SelectedNode.Text;
            foreach (string a in strContent)
            {
                uiTextBox1.Text += a + "\r\n";
            }
        }

        //下一章
        private void uiButton2_Click(object sender, EventArgs e)
        {
            SelectChapter(uiTreeView1.Nodes[uiTreeView1.SelectedNode.Index + 1].Tag.ToString());
            uiTreeView1.SelectedNode = uiTreeView1.Nodes[uiTreeView1.SelectedNode.Index + 1];
        }
    }
}
