using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Leetcode.Strings
{
    class Read_N_Characters_Given_Read4
    {
        public int Read4(char[] buf)
        {
            return 0;
        }

        private int buffPtr = 0; // buffer的index
        private int buffCnt = 0;//buff 的 size
        private char[] buff = new char[4]; //放到全局变量
        public int Read(char[] buf, int n)
        {
            int ptr = 0;
            while (ptr < n)
            {
                if (buffPtr == 0)
                {
                    buffCnt = Read4(buff);
                }
                if (buffCnt == 0) break;
                while (ptr < n && buffPtr < buffCnt)
                {
                    buf[ptr++] = buff[buffPtr++];
                }
                if (buffPtr >= buffCnt) buffPtr = 0;
            }
            return ptr;
        }
    }
}
