using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Leetcode.Strings
{
    class String_Compression
    {
        /// <summary>
        ///  超赞
        /// </summary>
        /// <param name="chars"></param>
        /// <returns></returns>
        public int Compress(char[] chars)
        {
            int anchor = 0, write = 0;
            for (int read = 0; read < chars.Length; read++)
            {
                if (read + 1 == chars.Length || chars[read + 1] != chars[read])  //如何复用代码 处理边界
                {
                    chars[write++] = chars[anchor];
                    if (read > anchor)
                    {
                        foreach (char c in ("" + (read - anchor + 1)))  // 如何记录长度
                        {
                            chars[write++] = c;
                        }
                    }
                    anchor = read + 1;
                }
            }
            return write;
        }
    }
}
