using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net.Http;
using System.Net.Http.Headers;
using Newtonsoft.Json;

namespace recreation.Novel
{
    class HttpUtils
    {
        //发送get请求
        public static  async Task<string> Get(string url)
        {
            var client = new HttpClient();
   
            //在 accept 标头值中，我们告诉 JSON 是可接受的响应类型。
            client.DefaultRequestHeaders.Accept.Add( new MediaTypeWithQualityHeaderValue("application/json"));

            //生成一个Get请求并异步读取内容。
            HttpResponseMessage response = await client.GetAsync(url);
            var resp = await response.Content.ReadAsStringAsync();

            return resp;
         
        }

        //根据fictionid返回小说具体信息
        public static async Task<Data> findnovel(string fictionid) {

            string url = "https://api.pingcc.cn/fictionChapter/search/" + fictionid;

            string getJson = await HttpUtils.Get(url);

            Root2 rt2 = JsonConvert.DeserializeObject<Root2>(getJson);

            return rt2.data;
           
         
        }

        //根据chapterId返回章节内容
        public static async Task<chapContent> find_chap_cont(string chapterId)
        {

            string url = "https://api.pingcc.cn/fictionContent/search/" + chapterId;

            string getJson = await HttpUtils.Get(url);

           /* Console.WriteLine(getJson);*/

            chapContent chapCont = JsonConvert.DeserializeObject<chapContent>(getJson);

            return chapCont;


        }

    }
}
