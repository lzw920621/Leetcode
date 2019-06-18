using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _338_比特位计数
{
    /*
     给定一个非负整数 num。对于 0 ≤ i ≤ num 范围中的每个数字 i ，计算其二进制数中的 1 的数目并将它们作为数组返回。
    示例 1:
    输入: 2
    输出: [0,1,1]

    示例 2:    
    输入: 5
    输出: [0,1,1,2,1,2]
    */
    class Program
    {
        static void Main(string[] args)
        {
            int[] array = CountBits(5);
            foreach (var item in array)
            {
                Console.WriteLine(item);
            }
            Console.ReadKey();
        }

        

        public static int[] CountBits(int num)
        {
            int[] targetArray = new int[num+1];
            if (num==0)
            {
                targetArray[0] = 0;                
            }            
            else
            {
                targetArray[0] = 0;                
                for (int i = 1; i <=num; i++)
                {                    
                    //if(i%2 == 1)
                    if((i&1)==1)
                    {
                        targetArray[i] = 1 + targetArray[i >> 1];
                    }
                    else
                    {
                        targetArray[i]= targetArray[i >> 1];
                    }
                }
            }

            return targetArray;
        }
    }
}
