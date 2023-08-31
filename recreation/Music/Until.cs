using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace recreation.Music
{
    class Until
    {
        public static string formatLongToTimeStr(string s)
        {
            int l = int.Parse(s);
            int hour = 0;
            int minute = 0;
            int second = 0;
            second = l / 1000;

            if (second > 60)
            {
                minute = second / 60;
                second = second % 60;
            }
            if (minute > 60)
            {
                hour = minute / 60;
                minute = minute % 60;
            }
            return (minute.ToString() + "分钟"
                + second.ToString() + "秒");
        }
    }
}
