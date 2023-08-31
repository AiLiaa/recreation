using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using recreation.Login;
using System.Windows.Forms;

namespace recreation.Music
{
    class Search
    {
        public static List<SearchResultSong> resultSongs= new List<SearchResultSong>();
        public static List<SongList> songLists = new List<SongList>();

        #region 搜索歌曲
        public static void search(string keyword)
        {
            try
            {
                HttpClient client = new HttpClient();
                client.DefaultRequestHeaders.Add("User-Agent", "Mozilla/5.0 (Windows NT 10.0; Win64; x64) AppleWebKit/537.36 (KHTML, like Gecko) Chrome/102.0.5005.63 Safari/537.36 Edg/102.0.1245.33");
                string url = "http://localhost:3000/search?keywords=" + keyword;
                string response = client.GetStringAsync(url).Result;
                JToken json = JToken.Parse(response);
                JArray songs = (JArray)json["result"]["songs"];
                if (songs != null)
                {
                    foreach (var song in songs)
                    {
                        string id = song["id"].ToString();
                        string name = song["name"].ToString();
                        string artist = song["artists"][0]["name"].ToString();
                        SearchResultSong searchResultSong = new SearchResultSong(id, name, artist, "网易云");
                        resultSongs.Add(searchResultSong);
                    }
                }

            }catch(Exception e)
            {
                Console.WriteLine(e.Message);
            }
            try
            {
                HttpClient client = new HttpClient();
                client.DefaultRequestHeaders.Add("User-Agent", "Mozilla/5.0 (Windows NT 10.0; Win64; x64) AppleWebKit/537.36 (KHTML, like Gecko) Chrome/102.0.5005.63 Safari/537.36 Edg/102.0.1245.33");
                string url = "http://localhost:3300/search?key=" + keyword;
                string response = client.GetStringAsync(url).Result;
                JToken json = JToken.Parse(response);
                JArray songs = (JArray)json["data"]["list"];
                foreach(var song in songs)
                {
                    string id = song["albummid"].ToString();
                    string name = song["albumname"].ToString();
                    string artist = song["singer"][0]["name"].ToString();
                    SearchResultSong searchResultSong = new SearchResultSong(id, name, artist, "QQ音乐");
                    resultSongs.Add(searchResultSong);
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }

        }
        #endregion


        #region 获取热搜歌手
        public static List<string> getHotSinger()
        {
            HttpClient client = new HttpClient();
            client.DefaultRequestHeaders.Add("User-Agent", "Mozilla/5.0 (Windows NT 10.0; Win64; x64) AppleWebKit/537.36 (KHTML, like Gecko) Chrome/102.0.5005.63 Safari/537.36 Edg/102.0.1245.33");
            string url = "http://localhost:3000/search/hot";
            string response = client.GetStringAsync(url).Result;
            JToken json = JToken.Parse(response);
            JArray hots = (JArray)json["hots"];
            List<string> hotSingers = new List<string>();
            foreach(var hot in hots)
            {
                string hotSinger = hot["first"].ToString();
                hotSingers.Add(hotSinger);
            }
            return hotSingers;
        }
        #endregion


        #region 通过id查找歌曲url
        public static string findById(string id)
        {
            HttpClient client = new HttpClient();
            client.DefaultRequestHeaders.Add("User-Agent", "Mozilla/5.0 (Windows NT 10.0; Win64; x64) AppleWebKit/537.36 (KHTML, like Gecko) Chrome/102.0.5005.63 Safari/537.36 Edg/102.0.1245.33");
/*            string url = "http://localhost:3000/check/music?id=" + id;
            string response;
            try
            {
                response = client.GetStringAsync(url).Result;
            }catch(Exception e)
            {
                return "no";
            }
            JToken json1 = JToken.Parse(response);
            string can = json1["message"].ToString();*/
/*            if (can == "ok")
            {*/
                string url2 = "http://localhost:3000/song/url?id=" + id;
                string response2 = client.GetStringAsync(url2).Result;
                JToken json = JToken.Parse(response2);
                string songUrl = json["data"][0]["url"].ToString();
                return songUrl;
            //}
/*            else
            {
                return "no";
            }*/
        }
        #endregion


        #region 返回用户歌单
        public static void getSongList(string uid)
        {
            if (LoginMain.user == null)
            {
                MessageBox.Show("该用户未登录！");
            }
            else
            {
                HttpClient client = new HttpClient();
                client.DefaultRequestHeaders.Add("User-Agent", "Mozilla/5.0 (Windows NT 10.0; Win64; x64) AppleWebKit/537.36 (KHTML, like Gecko) Chrome/102.0.5005.63 Safari/537.36 Edg/102.0.1245.33");
                string url = "http://localhost:3000/user/playlist?uid=" + uid;
                string response = client.GetStringAsync(url).Result;
                JToken json = JToken.Parse(response);
                JArray lists = (JArray)json["playlist"];
                foreach (var list in lists)
                {
                    string name = list["name"].ToString();
                    string id = list["id"].ToString();
                    string coverUrl = list["coverImgUrl"].ToString();
                    Console.WriteLine(coverUrl);
                    SongList songList = new SongList(name, id, coverUrl);
                    songLists.Add(songList);
                }
            }

        }
        #endregion


        #region 通过歌单id获取其中详细列表
        public static List<ListSong> getSongByList(string id)
        {
            HttpClient client = new HttpClient();
            client.DefaultRequestHeaders.Add("User-Agent", "Mozilla/5.0 (Windows NT 10.0; Win64; x64) AppleWebKit/537.36 (KHTML, like Gecko) Chrome/102.0.5005.63 Safari/537.36 Edg/102.0.1245.33");
            string url = "http://localhost:3000/playlist/detail?id=" + id+"&time=1";
            string response = client.GetStringAsync(url).Result;
            JToken json = JToken.Parse(response);
            JArray lists = (JArray)json["playlist"]["tracks"];
            List<ListSong> ListSongs = new List<ListSong>();
            foreach(var list in lists)
            {
                string name = list["name"].ToString();
                string Id = list["id"].ToString();
                string artists;
                try
                {
                    artists = list["ar"][0]["name"].ToString();
                }catch(Exception e) { artists = "未知歌手"; }
                string time = Until.formatLongToTimeStr(list["dt"].ToString());
                string coverImage = list["al"]["picUrl"].ToString();
                ListSong listSong = new ListSong(Id, name, artists, time, coverImage);
                ListSongs.Add(listSong);
            }
            return ListSongs;

        }
        #endregion


        #region 获取歌词
        public static string findLrcById(string id)
        {
            HttpClient client = new HttpClient();
            client.DefaultRequestHeaders.Add("User-Agent", "Mozilla/5.0 (Windows NT 10.0; Win64; x64) AppleWebKit/537.36 (KHTML, like Gecko) Chrome/102.0.5005.63 Safari/537.36 Edg/102.0.1245.33");
            string url = "http://localhost:3000/lyric?id=" + id;

            string response = client.GetStringAsync(url).Result;
            JToken json = JToken.Parse(response);
            string lrc = json["lrc"]["lyric"].ToString();
            //Console.WriteLine(lrc);
            return lrc;
        }
        #endregion


        #region 获取歌曲评论
        public static List<Comment> getComment(string id)
        {
            try
            {
                HttpClient client = new HttpClient();
                client.DefaultRequestHeaders.Add("User-Agent", "Mozilla/5.0 (Windows NT 10.0; Win64; x64) AppleWebKit/537.36 (KHTML, like Gecko) Chrome/102.0.5005.63 Safari/537.36 Edg/102.0.1245.33");
                string url = "http://localhost:3000/comment/music?id=" + id + "&limit=1";
                string response = client.GetStringAsync(url).Result;
                JToken json = JToken.Parse(response);
                JArray lists = (JArray)json["hotComments"];
                List<Comment> comments = new List<Comment>();
                foreach (var list in lists)
                {
                    string username = list["user"]["nickname"].ToString();
                    string avatarUrl = list["user"]["avatarUrl"].ToString();
                    string content = list["content"].ToString();
                    //string time = list["timerStr"].ToString();
                    Comment comment = new Comment(username, avatarUrl, content, " ");
                    comments.Add(comment);
                }
                return comments;
            }
            catch
            {
                return null;
            }

        }
        #endregion

    }
}
