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
    public partial class LYH_main : Form
    {
        public playerPage f1; //创建用户控件一变量
        public UserControl2 f2; //创建用户控件二变量
        public UserControl3 f3; //创建用户控件三变量
        public UserControl4 f4; //创建用户控件四变量
        public PlayerHistory ph;//创建用户控件五变量

        public LYH_main()
        {
            InitializeComponent();
        }

        private void LYH_main_Load(object sender, EventArgs e)
        {
            f1 = new playerPage();    //实例化f1
            f2 = new UserControl2();    //实例化f2
            f3 = new UserControl3();    //实例化f3
            f4 = new UserControl4();
            ph = new PlayerHistory();
            uiPanel1.Controls.Add(f1);
        }

        private void uiButton1_Click(object sender, EventArgs e)
        {
            f1.Show();//对窗体1进行显示
            uiPanel1.Controls.Clear();
            uiPanel1.Controls.Add(f1);

        }

        private void uiButton2_Click(object sender, EventArgs e)
        {
            f2.Show();//对窗体2进行显示
            uiPanel1.Controls.Clear();
            uiPanel1.Controls.Add(f2);
        }

        private void uiButton3_Click(object sender, EventArgs e)
        {
            f3.Show();//对窗体2进行显示
            uiPanel1.Controls.Clear();
            uiPanel1.Controls.Add(f3);
        }

        private void uiButton4_Click(object sender, EventArgs e)
        {
            f4.Show();//对窗体4进行显示
            uiPanel1.Controls.Clear();
            uiPanel1.Controls.Add(f4);
        }

        private void uiButton5_Click(object sender, EventArgs e)
        {
            ph.Show();//对窗体4进行显示
            uiPanel1.Controls.Clear();
            uiPanel1.Controls.Add(ph);
        }
    }
}
