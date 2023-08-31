using Newtonsoft.Json;
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

namespace recreation.Video
{
    public partial class UserControl3 : UserControl
    {
        public V1_state vstate;

        V1 videoInfo1 = new V1();
        V1 videoInfo2 = new V1();
        V1 videoInfo3 = new V1();
        int startIndex;//第一条信息在结果数组中的索引
        int endIndex;//第三条信息在结果数组中的索引

        public bool isStateInit=false;

        public int resultNumber = 0;

        public UserControl3()
        {
            InitializeComponent();
        }

        private void UserControl3_Load(object sender, EventArgs e)
        {

        }

        private void uiButton1_Click(object sender, EventArgs e)
        {
            string name = uiTextBox1.Text;
            if (name == "")
            {
                return;
            }
            string url = "https://api.pingcc.cn/video/search/title/" + name;
            // 实例化一个http实例
            HttpWebRequest request = (HttpWebRequest)HttpWebRequest.Create(url);
            // 设置请求方式
            request.Method = "GET";
            // 设置请求头
            request.Headers.Add("key", "value");

            using (WebResponse wr = request.GetResponse()) {
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
                vstate = JsonConvert.DeserializeObject<V1_state>(content);
                if (vstate == null)
                {
                    MessageBox.Show("没有查询到相关数据！");
                    return;
                }
                isStateInit = true;//现在vstate已经被初始化了

                resultNumber = vstate.data.Count;//设置一下r中的结果个数

                if (vstate.count < 3)
                {
                    if (vstate.count == 2)
                    {
                        videoName1.Text = vstate.data[0].title;
                        videoName2.Text = vstate.data[1].title;

                        videoInfo1 = vstate.data[0];
                        videoInfo1 = vstate.data[1];

                        startIndex = 0;
                        endIndex = 1;
                    }
                    if (vstate.count == 1)
                    {
                        videoName1.Text = vstate.data[0].title;

                        videoInfo1 = vstate.data[0];

                        startIndex = 0;
                        endIndex = 0;
                    }
                    if (vstate.count == 0)
                    {
                        videoName1.Text = "没有找到噢！";
                    }
                }
                else
                {
                    videoName1.Text = vstate.data[0].title;
                    videoName2.Text = vstate.data[1].title;
                    videoName3.Text = vstate.data[2].title;

                    videoInfo1 = vstate.data[0];
                    videoInfo2 = vstate.data[1];
                    videoInfo3 = vstate.data[2];

                    startIndex = 0;
                    endIndex = 2;
                }
            }
        }

        private void uiButton2_Click(object sender, EventArgs e)
        {
            if (!isStateInit)
            {//State未初始化，也就是还没搜索成功时，点击换一批不会有响应
                return;
            }
            if (resultNumber - endIndex >= 4)
            {//还有3个以上数据待展示

                startIndex = endIndex + 1;
                endIndex = endIndex + 3;

                //设置传参
                videoInfo1 = vstate.data[startIndex];
                videoInfo2 = vstate.data[startIndex + 1];
                videoInfo3 = vstate.data[startIndex + 2];

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
                videoInfo1 = vstate.data[startIndex];
                videoInfo2 = vstate.data[startIndex + 1];
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
                videoInfo1 = vstate.data[startIndex];
                videoInfo2 = null;
                videoInfo3 = null;

                //重置标签内容
                videoName1.Text = videoInfo1.title;
                videoName2.Text = "";
                videoName3.Text = "";
            }
            else
            {
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

        private void videoName1_Click(object sender, EventArgs e)
        {
            if (videoInfo1 == null)
            {
                return;
            }

            //现在确保videoInfo1不是空指针，可以进行访问
            var videoid = videoInfo1.videoId;

            //用videoid发起网络请求，获取资源下载地址
            String url = "https://api.pingcc.cn/videoChapter/search/" + videoid;

            // 实例化一个http实例
            HttpWebRequest request = (HttpWebRequest)HttpWebRequest.Create(url);

            // 设置请求方式
            request.Method = "GET";

            // 设置请求头
            request.Headers.Add("key", "value");

            using (WebResponse wr = request.GetResponse()) {
                // 网络返回
                HttpWebResponse response = (HttpWebResponse)request.GetResponse();
                
                // 设置返回编码格式与读取流
                StreamReader reader = new StreamReader(response.GetResponseStream(), Encoding.UTF8);
                
                // 读取返回的信息流
                string content = reader.ReadToEnd();

                //进行实体映射
                if (content == "") { return; }
                ChapterListItemRoot clir = JsonConvert.DeserializeObject<ChapterListItemRoot>(content);

                //判断是否转化成功
                if (clir == null) {
                    MessageBox.Show("转化Json类时出错咯!");
                    return;
                }

                //转化成功就可以访问内容
               string videourl = clir.data.chapterList.ToArray()[0].chapterPath;

                VideoDownloadPage videoDownloadPage = new VideoDownloadPage();
                videoDownloadPage.videourl = videourl;
                videoDownloadPage.Show();
            }
        }

        private void videoName2_Click(object sender, EventArgs e)
        {
            if (videoInfo2 == null)
            {
                return;
            }
            //现在确保videoInfo1不是空指针，可以进行访问
            var videoid = videoInfo2.videoId;

            //用videoid发起网络请求，获取资源下载地址
            String url = "https://api.pingcc.cn/videoChapter/search/" + videoid;

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

                //进行实体映射
                if (content == "") { return; }
                ChapterListItemRoot clir = JsonConvert.DeserializeObject<ChapterListItemRoot>(content);

                //判断是否转化成功
                if (clir == null)
                {
                    MessageBox.Show("转化Json类时出错咯!");
                    return;
                }

                //转化成功就可以访问内容
                string videourl = clir.data.chapterList.ToArray()[0].chapterPath;

                VideoDownloadPage videoDownloadPage = new VideoDownloadPage();
                videoDownloadPage.videourl = videourl;
                videoDownloadPage.Show();
            }
        }

        private void videoName3_Click(object sender, EventArgs e)
        {
            if (videoInfo3 == null)
            {
                return;
            }
            //现在确保videoInfo1不是空指针，可以进行访问
            var videoid = videoInfo3.videoId;

            //用videoid发起网络请求，获取资源下载地址
            String url = "https://api.pingcc.cn/videoChapter/search/" + videoid;

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

                //进行实体映射
                if (content == "") { return; }
                ChapterListItemRoot clir = JsonConvert.DeserializeObject<ChapterListItemRoot>(content);

                //判断是否转化成功
                if (clir == null)
                {
                    MessageBox.Show("转化Json类时出错咯!");
                    return;
                }

                //转化成功就可以访问内容
                string videourl = clir.data.chapterList.ToArray()[0].chapterPath;

                VideoDownloadPage videoDownloadPage = new VideoDownloadPage();
                videoDownloadPage.videourl = videourl;
                videoDownloadPage.Show();
            }
        }
    }
}
public class V1
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

public class V1_state
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
    public List<V1> data { get; set; }
}

//如果好用，请收藏地址，帮忙分享。
public class ChapterListItem
{
    /// <summary>
    /// 坏老师
    /// </summary>
    public string title { get; set; }
    /// <summary>
    /// 
    /// </summary>
    public string chapterPath { get; set; }
}

public class Data
{
    /// <summary>
    /// 
    /// </summary>
    public string videoId { get; set; }
    /// <summary>
    /// 坏老师
    /// </summary>
    public string title { get; set; }
    /// <summary>
    /// 伊丽莎白（卡梅隆·迪亚茨CameronDiaz饰）在生活中是个不折不扣的贱人，但同时她还有着另一个身份——人民教师。在被前男友抛弃之后，她不得不重新回到了自己所厌恶的工作岗位上消极怠工。她一直对自己的胸部尺寸不太满意，这一次，她终于下定决心做隆乳手术，但在此之前，她得先凑齐昂贵的手术费用。新人教师斯科特（贾斯汀·汀布莱克JustinTimberlake饰）出现在了伊丽莎白的视线里，他的年轻帅气很快就吸引了她的目光，但糟糕的是，她那表面友善内心阴险的同事艾米（露茜·彭奇LucyPunch饰）也向他送去了秋波。斯科特和艾米在一起了，这令伊丽莎白十分沮丧，不过一直在追求伊丽莎白的体育老师罗塞尔（杰森·席格尔JasonSegel饰）对此似乎十分高兴。被横刀夺爱的伊丽莎白将全部精力放在了赚钱上，她得知若班级的考试成绩在州里名列前茅的话，作为班主任的她将获得5700美元的奖金。这一消息振奋了消沉的伊丽莎白，但同时，班上这些不争气的孩子们让她在试卷的答案上动起了歪脑筋。
    /// </summary>
    public string descs { get; set; }
    /// <summary>
    /// http://api.pingcc.cn/video/img/坏老师/坏老师.jpg
    /// </summary>
    public string cover { get; set; }
    /// <summary>
    /// 杰克·卡斯丹
    /// </summary>
    public string director { get; set; }
    /// <summary>
    /// 卡梅隆·迪亚兹|凯瑟琳·纽顿|凯特琳·德弗|贾斯汀·汀布莱克|瑞克·欧弗顿|阿兰娜·乌巴赫|罗斯·阿卜杜|杰夫·犹大|诺亚·芒克|奈特·法松|菲尼亚斯·奥康奈尔|瑞安·西克莱斯特|珍妮弗·厄文|YoulandaDavis|奥斯汀·迈克尔·科尔曼|大卫·佩默|MelvinMar|菲利丝·史密斯|李·艾森伯格|保罗·贝茨|马修·J·伊万斯|ChristineSmith|安德拉·内切塔|ClaraSoyoung|WilliamNeroJr.|戴夫·艾伦|AndyScottHarris|马特·贝瑟|基思·米德尔布鲁克|多特-玛丽·琼斯|保罗·费格|杰瑞·兰伯特|迪尔德丽·罗夫乔|露茜·彭奇|诺亚·达尔|布鲁诺·冈恩|莫莉·香侬|托马斯·列农|斯蒂芬妮·法拉希|吉利安·阿美娜特|杰森·席格尔|艾瑞克·斯通斯崔特|约翰·迈克尔·辛吉斯
    /// </summary>
    public string actor { get; set; }
    /// <summary>
    /// 美国
    /// </summary>
    public string region { get; set; }
    /// <summary>
    /// 喜剧
    /// </summary>
    public string videoType { get; set; }
    /// <summary>
    /// 
    /// </summary>
    public string releaseTime { get; set; }
    /// <summary>
    /// 
    /// </summary>
    public string updateTime { get; set; }
    /// <summary>
    /// 
    /// </summary>
    public List<ChapterListItem> chapterList { get; set; }
}

public class ChapterListItemRoot
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
    public Data data { get; set; }
}
