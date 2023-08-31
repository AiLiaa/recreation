using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;
using recreation.Music;

namespace recreation.Login
{
    public partial class LoginMain : Form
    {
        public static User user;
        public LoginMain()
        {
            InitializeComponent();
            loginChooseComboBox.SelectedIndex = loginChooseComboBox.Items.IndexOf("网易云");
        }


        private void sureButton_Click(object sender, EventArgs e)
        {
            if (loginChooseComboBox.Text == "网易云")
            {
                netEaseCloud.Visible = true;
                QQMuisc.Visible = false;
            }
            if (loginChooseComboBox.Text == "QQ音乐")
            {
                netEaseCloud.Visible = false;
                QQMuisc.Visible = true;
                QQWebBrowser.Navigate("https://xui.ptlogin2.qq.com/cgi-bin/xlogin?appid=716027609&daid=383&style=33&login_text=%E6%8E%88%E6%9D%83%E5%B9%B6%E7%99%BB%E5%BD%95&hide_title_bar=1&hide_border=1&target=self&s_url=https%3A%2F%2Fgraph.qq.com%2Foauth2.0%2Flogin_jump&pt_3rd_aid=100497308&pt_feedback_link=https%3A%2F%2Fsupport.qq.com%2Fproducts%2F77942%3FcustomInfo%3D.appid100497308&theme=2&verify_theme=");
                //this.QQWebBrowser.Document.Window.ScrollTo(50, 20);
            }
        }

        private async void QQWebBrowser_DocumentCompleted(object sender, WebBrowserDocumentCompletedEventArgs e)
        {
            string cookieStr = QQWebBrowser.Document.Cookie;
            Console.WriteLine(cookieStr);
            if (cookieStr.Contains("qm_keyst") && cookieStr.Contains("qqmusic_key"))
            {
                QQWebBrowser.Visible = false;
                string body = "{\"data\":\"" + cookieStr + "\"}";
                HttpContent content = new StringContent(body);
                content.Headers.ContentType = new System.Net.Http.Headers.MediaTypeHeaderValue("application/json");
                //HttpClient client = new HttpClient();
                //HttpResponseMessage response = await client.PostAsync("http://localhost:3300/user/setCookie", content);
                //response.EnsureSuccessStatusCode();//用来抛异常的
                //string responseBody = await response.Content.ReadAsStringAsync();
                //Console.WriteLine(responseBody);
                QQMuisc.Visible = false;
            }

        }


        #region 网易云登录
        private void necLoginbt_Click(object sender, EventArgs e)
        {
            string phoneNum = phoneNumTextBox.Text;
            string passwd = passwdTextBox.Text;
            HttpClient client = new HttpClient();
            string url = "http://localhost:3000/login/cellphone?phone=" + phoneNum + "&password=" + passwd;
            string response = client.GetStringAsync(url).Result;
            /*Regex nameRegex = new Regex("\"nickname\":\"(.*?)\",\"backgroundImgId");
            MatchCollection mc = nameRegex.Matches(response);*/
            //Regex nameRegex = new Regex("(?<=(nickname\":\"))[.\\s\\S]*?(?=(\",\"backgroundImgId))", RegexOptions.Multiline | RegexOptions.Singleline);
            JToken json = JToken.Parse(response);
            string name = json["profile"]["nickname"].ToString();
            string uid = json["profile"]["userId"].ToString();
            string avatarUrl = json["profile"]["avatarUrl"].ToString();
            user = new User(name, uid, avatarUrl);
            MessageBox.Show("用户：" + user.Name + "  登录成功！");
            Console.WriteLine(avatarUrl);
            MusicPlayer.musicPlayer.pictureBox1.LoadAsync(avatarUrl);
            MusicPlayer.musicPlayer.usernameLabel.Text = name;
        }
        #endregion

    }
}
