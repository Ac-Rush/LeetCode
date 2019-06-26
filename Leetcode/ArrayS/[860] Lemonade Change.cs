using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Leetcode.ArrayS
{
    class _860__Lemonade_Change
    {
        public bool LemonadeChange(int[] bills)
        {
            int[] rest = new int[3]; //5 ,10 ,20
            foreach (var bill in bills)
            {
                switch (bill)
                {
                    case 5:
                        {
                            rest[0]++;
                            break;
                        }
                    case 10:
                        {
                            rest[1]++;
                            if (rest[0] <= 0)
                            {
                                return false;
                            }
                            rest[0]--;
                            break;
                        }
                    case 20:
                        {
                            //   rest[2]++;
                            if (rest[1] > 0 && rest[0] > 0)
                            {
                                rest[1]--;
                                rest[0]--;
                            }
                            else if (rest[0] >= 3)
                            {
                                rest[0] -= 3;
                            }
                            else
                            {
                                return false;
                            }

                            break;
                        }
                    default: break;
                }
            }
            return true;
        }



        public bool LemonadeChange2(int[] bills)
        {
            int five = 0, ten = 0;
            foreach (int i in bills)
            {
                if (i == 5) five++;
                else if (i == 10) { five--; ten++; }
                else if (ten > 0) { ten--; five--; }
                else five -= 3;
                if (five < 0) return false;
            }
            return true;
        }
    }
}
