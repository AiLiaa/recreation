using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using Newtonsoft.Json;

namespace recreation.Novel
{
    class bookshelf
    {
        //书架列表
        public List<fiction_json> bookshelf_json { get; set; }

        //读取txt文件并反序列化
        public void fiction_json_init() {
            string nextLine;
            StreamReader sR = new StreamReader(@"D:\ProgramData\sourecVS2019\recreation\Novel\bookshelf_json\a.txt", Encoding.UTF8);
            while ((nextLine = sR.ReadLine()) != null)
            {
                fiction_json fj = JsonConvert.DeserializeObject<fiction_json>(nextLine);
                bookshelf_json.Add(fj);
            }
        }

  
    }
}
