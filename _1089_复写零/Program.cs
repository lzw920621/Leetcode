﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _1089_复写零
{
    /*
    给你一个长度固定的整数数组 arr，请你将该数组中出现的每个零都复写一遍，并将其余的元素向右平移。
    注意：请不要在超过该数组长度的位置写入元素。
    要求：请对输入的数组 就地 进行上述修改，不要从函数返回任何东西。
 
    示例 1：

    输入：[1,0,2,3,0,4,5,0]
    输出：null
    解释：调用函数后，输入的数组将被修改为：[1,0,0,2,3,0,0,4]

    示例 2：

    输入：[1,2,3]
    输出：null
    解释：调用函数后，输入的数组将被修改为：[1,2,3]

    提示：

        1 <= arr.length <= 10000
        0 <= arr[i] <= 9

    来源：力扣（LeetCode）
    链接：https://leetcode-cn.com/problems/duplicate-zeros
    著作权归领扣网络所有。商业转载请联系官方授权，非商业转载请注明出处。    
    */
    class Program
    {
        static void Main(string[] args)
        {
            int[] array = new int[] { 1, 0, 2, 3, 0, 4, 5, 0 };
            DuplicateZeros(array);
        }

        public static  void DuplicateZeros(int[] arr)
        {
            int numOfZero = 0;//零的个数
            for (int i = 0; i < arr.Length; i++)
            {
                if(arr[i]==0)
                {
                    numOfZero++;
                }
            }

            for (int i = arr.Length-1; i >=0; i--)
            {
                if(arr[i]==0)
                {
                    if (i + numOfZero <= arr.Length - 1)
                    {
                        arr[i + numOfZero] = 0;
                    }
                    if(i+numOfZero-1<=arr.Length-1)
                    {
                        arr[i + numOfZero - 1] = 0;
                    }
                    numOfZero--;                                        
                }
                else
                {
                    if( i + numOfZero <= arr.Length - 1 )
                    {
                        arr[i + numOfZero] = arr[i];
                    }                    
                }
            }
        }
    }
}
