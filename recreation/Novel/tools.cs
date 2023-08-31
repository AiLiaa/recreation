using System;
using System.Threading.Tasks;
using System.Collections.Generic;
using System.Net.Http;
using System.Net.Http.Headers;
using Newtonsoft.Json;


namespace recreation.Novel
{
        
        //小说类
        public class DataItem
        {
            /// <summary>
            /// 小说id
            /// </summary>
            public string fictionId { get; set; }
            /// <summary>
            /// 作品名称
            /// </summary>
            public string title { get; set; }
            /// <summary>
            /// 作者
            /// </summary>
            public string author { get; set; }
            /// <summary>
            /// 小说类型
            /// </summary>
            public string fictionType { get; set; }
            /// <summary>
            /// 小说简介
            /// </summary>
            public string descs { get; set; }
            /// <summary>
            /// 封面链接
            /// </summary>
            public string cover { get; set; }
            /// <summary>
            /// 最近更新时间
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
            public List<DataItem> data { get; set; }
        }

    //章节类
    public class ChapterListItem
    {
        /// <summary>
        /// 
        /// </summary>
        public string title { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string chapterId { get; set; }
    }

    public class Data
    {
 
        /// <summary>
        /// 小说id
        /// </summary>
        public string fictionId { get; set; }
        /// <summary>
        /// 小说名称
        /// </summary>
        public string title { get; set; }
        /// <summary>
        /// 简介
        /// </summary>
        public string descs { get; set; }
        /// <summary>
        /// 封面
        /// </summary>
        public string cover { get; set; }
        /// <summary>
        /// 作者
        /// </summary>
        public string author { get; set; }
        /// <summary>
        /// 小说类型
        /// </summary>
        public string fictionType { get; set; }
        /// <summary>
        /// 更新时间
        /// </summary>
        public string updateTime { get; set; }
        /// <summary>
        /// 章节
        /// </summary>
        public List<ChapterListItem> chapterList { get; set; }

        public Data(string fictionId, string title, string descs, string cover, string author, string fictionType, string updateTime, List<ChapterListItem> chapterList)
        {
            this.fictionId = fictionId;
            this.title = title;
            this.descs = descs;
            this.cover = cover;
            this.author = author;
            this.fictionType = fictionType;
            this.updateTime = updateTime;
            this.chapterList = chapterList;
        }

    }

    public class Root2
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

    public static class Datastatic
    {
        /// <summary>
        /// 小说id
        /// </summary>
        public static string fictionId { get; set; }
        /// <summary>
        /// 小说名称
        /// </summary>
        public static string title { get; set; }
        /// <summary>
        /// 简介
        /// </summary>
        public static string descs { get; set; }
        /// <summary>
        /// 封面
        /// </summary>
        public static string cover { get; set; }
        /// <summary>
        /// 作者
        /// </summary>
        public static string author { get; set; }
        /// <summary>
        /// 小说类型
        /// </summary>
        public static string fictionType { get; set; }
        /// <summary>
        /// 更新时间
        /// </summary>
        public static string updateTime { get; set; }
        /// <summary>
        /// 章节
        /// </summary>
        public static List<ChapterListItem> chapterList { get; set; }
    }

    public class fiction_json {

        public string fiction_id;

        public string fiction_name;

        public string fiction_cover;

        public fiction_json() { }

        public fiction_json(string fiction_id, string fiction_name, string fiction_cover)
        {
            this.fiction_id = fiction_id;
            this.fiction_name = fiction_name;
            this.fiction_cover = fiction_cover;
        }
    }

    public class chapContent
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
        public List<string> data { get; set; }
    }
}

