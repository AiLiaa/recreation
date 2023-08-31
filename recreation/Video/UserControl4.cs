using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Newtonsoft.Json;

//电影信息搜索

namespace recreation.Video
{
    public partial class UserControl4 : UserControl
    {
        
        public Root r;//放在这方便给刷新按钮使用
       
        bool isRootInit = false; //Root类是否已经被初始化
        
        int resultNumber = 0;//r中有多少个结果

        //给linllabel做页面跳转传参
        VideoInfoStorage videoInfo1 = new VideoInfoStorage();
        VideoInfoStorage videoInfo2 = new VideoInfoStorage();
        VideoInfoStorage videoInfo3 = new VideoInfoStorage();

        int startIndex;//第一条信息在结果数组中的索引
        int endIndex;//第三条信息在结果数组中的索引



        public UserControl4()
        {
            InitializeComponent();
        }

        private void UserControl4_Load(object sender, EventArgs e)
        {

        }

        private void uiButton1_Click(object sender, EventArgs e)
        {
            string name = uiTextBox1.Text;
            if (name == "") {
                return;
            }
            string url = "https://api.pingcc.cn/video/search/title/" + name;
            // 实例化一个http实例
            HttpWebRequest request = (HttpWebRequest)HttpWebRequest.Create(url);
            // 设置请求方式
            request.Method = "GET";
            // 设置请求头
            request.Headers.Add("key", "value");
            using (WebResponse wr = request.GetResponse())
            {
                // 网络返回
                HttpWebResponse response = (HttpWebResponse)request.GetResponse();
                // 设置返回编码格式与读取流
                StreamReader reader = new StreamReader(response.GetResponseStream(), Encoding.UTF8);
                // 读取返回的信息流
                string content = reader.ReadToEnd();
                // 进行json的实体映射
                //RQ_U8 u8 = JsonConvert.DeserializeObject<RQ_U8>(content);

                //textBox2.Text = content;
                //uiTextBox2.Text = content;

                if (content == "") { return; }
                //Console.WriteLine(content);

                //用Json格式转化工具将其转化成对应的类
                r = JsonConvert.DeserializeObject<Root>(content);
                if (r == null) {
                    MessageBox.Show("没有查询到相关数据！");
                    return;
                }
                isRootInit = true;//现在r已经被初始化了

                if (r.data == null) {
                    MessageBox.Show("没有查询到相关数据！");
                    return;
                }

                resultNumber = r.data.Count;//设置一下r中的结果个数
                //uiLabel2.Text = r.data.Count+"";

                if (r.count < 3)
                {
                    if (r.count == 2)
                    {
                        videoName1.Text = r.data[0].title;
                        videoName2.Text = r.data[1].title;

                        videoInfo1 = r.data[0];
                        videoInfo2 = r.data[1];

                        startIndex = 0;
                        endIndex = 1;
                    }
                    if (r.count == 1)
                    {
                        videoName1.Text = r.data[0].title;

                        videoInfo1 = r.data[0];
                        
                        startIndex = 0;
                        endIndex = 0;
                    }
                    if (r.count == 0)
                    {
                        videoName1.Text = "没有找到噢！";
                    }
                }
                else {
                    videoName1.Text = r.data[0].title;
                    videoName2.Text = r.data[1].title;
                    videoName3.Text = r.data[2].title;

                    videoInfo1 = r.data[0];
                    videoInfo2 = r.data[1];
                    videoInfo3 = r.data[2];

                    startIndex = 0;
                    endIndex = 2;
                }
            }
        }

        //应该生成一个新的页面
        private void videoName1_Click(object sender, EventArgs e)
        {
            if (videoInfo1 == null) {
                return;
            }
            VideoInfoPage videoInfoPage = new VideoInfoPage();
            videoInfoPage.vis = videoInfo1;
            videoInfoPage.Show();
        }
        //应该生成一个新的页面
        private void videoName2_Click(object sender, EventArgs e)
        {
            if (videoInfo2 == null)
            {
                return;
            }
            VideoInfoPage videoInfoPage = new VideoInfoPage();
            videoInfoPage.vis = videoInfo2;
            videoInfoPage.Show();
        }
        //应该生成一个新的页面
        private void videoName3_Click(object sender, EventArgs e)
        {
            if (videoInfo3 == null)
            {
                return;
            }
            VideoInfoPage videoInfoPage = new VideoInfoPage();
            videoInfoPage.vis = videoInfo3;
            videoInfoPage.Show();
        }
        //点击换一批
        private void uiButton2_Click(object sender, EventArgs e)
        {
            if (!isRootInit) {//Root未初始化，也就是还没搜索成功时，点击换一批不会有响应
                return;
            }
            if (resultNumber - endIndex >= 4)
            {//还有3个以上数据待展示

                startIndex = endIndex + 1;
                endIndex = endIndex + 3;

                //设置传参
                videoInfo1 = r.data[startIndex];
                videoInfo2 = r.data[startIndex + 1];
                videoInfo3 = r.data[startIndex + 2];

                //重置标签内容
                videoName1.Text = videoInfo1.title;
                videoName2.Text = videoInfo2.title;
                videoName3.Text = videoInfo3.title;
            }
            else if (resultNumber - endIndex == 3)
            {
                startIndex = endIndex + 1;
                endIndex = endIndex + 2;

                //设置传参
                videoInfo1 = r.data[startIndex];
                videoInfo2 = r.data[startIndex + 1];
                videoInfo3 = null;

                //重置标签内容
                videoName1.Text = videoInfo1.title;
                videoName2.Text = videoInfo2.title;
                videoName3.Text = "";
            }
            else if (resultNumber - endIndex == 2)
            {
                startIndex = endIndex + 1;
                endIndex = endIndex + 1;

                //设置传参
                videoInfo1 = r.data[startIndex];
                videoInfo2 = null;
                videoInfo3 = null;

                //重置标签内容
                videoName1.Text = videoInfo1.title;
                videoName2.Text = "";
                videoName3.Text = "";
            }
            else{
                //设置传参
                videoInfo1 = null;
                videoInfo2 = null;
                videoInfo3 = null;

                //重置标签内容
                videoName1.Text = "没有更多结果咯QAQ";
                videoName2.Text = "没有更多结果咯QAQ";
                videoName1.Text = "没有更多结果咯QAQ";
            }
        }
    }
}

public class VideoInfoStorage
{
    /// <summary>
    /// 
    /// </summary>
    public string videoId { get; set; }
    /// <summary>
    /// 间谍1936
    /// </summary>
    public string title { get; set; }
    /// <summary>
    /// 阿尔弗雷德·希区柯克
    /// </summary>
    public string director { get; set; }
    /// <summary>
    /// 约翰·吉尔古德,彼得·洛,玛德琳·卡洛,罗伯特·扬
    /// </summary>
    public string actor { get; set; }
    /// <summary>
    /// 香港
    /// </summary>
    public string region { get; set; }
    /// <summary>
    /// 悬疑,香港,1990,恐怖片
    /// </summary>
    public string videoType { get; set; }
    /// <summary>
    /// 埃德加是一名小说家，在机缘巧合之下，他参与了政治工作，成为了一名情报工作人员。第一次世界大战爆发了，他和妻子艾尔莎来到了瑞士，同行的还有一位绰号“将军”的神秘杀手。三人来到瑞士的目的只有一个，那就是追踪寻找一名德国间谍，然而，这位间谍先生姓甚名谁，样貌又是如何，三人却一无所知。敌人在暗处，埃德加在明处，只要有一丝疏忽和闪失，都有可能危及性命。每一个人似乎都有着双重身份，每一句话似乎都有着话外之音，最终，埃德加能够顺利找到间谍，成功完成任务吗？
    /// </summary>
    public string descs { get; set; }
    /// <summary>
    /// http://api.pingcc.cn/video/img/间谍1936/间谍1936.jpg
    /// </summary>
    public string cover { get; set; }
    /// <summary>
    /// 
    /// </summary>
    public string releaseTime { get; set; }
    /// <summary>
    /// 
    /// </summary>
    public string updateTime { get; set; }
}

public class Root
{
    /// <summary>
    /// 成功
    /// </summary>
    public string msg { get; set; }
    /// <summary>
    /// 
    /// </summary>
    public int code { get; set; }
    /// <summary>
    /// 
    /// </summary>
    public int count { get; set; }
    /// <summary>
    /// 
    /// </summary>
    public List<VideoInfoStorage> data { get; set; }
}
