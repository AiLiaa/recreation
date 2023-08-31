using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace recreation.Login
{
    public partial class TipsMessageBox : Form
    {
        private string _titleText = "提示";

        public string TitleText
        {
            get { return _titleText; }
            set { _titleText = value; }
        }


        private string _contentText = "暂无信息!";

        public string ContentText
        {
            get { return _contentText; }
            set { _contentText = value; }
        }

        public TipsMessageBox()
        {
            InitializeComponent();
        }

        private void TipsMessageBox_Load(object sender, EventArgs e)
        {
            if (this._contentText.Trim() != "")
            {
/*                this.lblTitalContent.Text = this._titleText;
                this.lblMessage.Text = this._contentText;*/
            }
        }


    }
}
