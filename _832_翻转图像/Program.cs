using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _832_翻转图像
{
    /*
    给定一个二进制矩阵 A，我们想先水平翻转图像，然后反转图像并返回结果。

    水平翻转图片就是将图片的每一行都进行翻转，即逆序。例如，水平翻转 [1, 1, 0] 的结果是 [0, 1, 1]。

    反转图片的意思是图片中的 0 全部被 1 替换， 1 全部被 0 替换。例如，反转 [0, 1, 1] 的结果是 [1, 0, 0]。

    示例 1:

    输入: [[1,1,0],[1,0,1],[0,0,0]]
    输出: [[1,0,0],[0,1,0],[1,1,1]]
    解释: 首先翻转每一行: [[0,1,1],[1,0,1],[0,0,0]]；
         然后反转图片: [[1,0,0],[0,1,0],[1,1,1]]

    示例 2:

    输入: [[1,1,0,0],[1,0,0,1],[0,1,1,1],[1,0,1,0]]
    输出: [[1,1,0,0],[0,1,1,0],[0,0,0,1],[1,0,1,0]]
    解释: 首先翻转每一行: [[0,0,1,1],[1,0,0,1],[1,1,1,0],[0,1,0,1]]；
         然后反转图片: [[1,1,0,0],[0,1,1,0],[0,0,0,1],[1,0,1,0]]

    说明:

        1 <= A.length = A[0].length <= 20
        0 <= A[i][j] <= 1

    来源：力扣（LeetCode）
    链接：https://leetcode-cn.com/problems/flipping-an-image
    著作权归领扣网络所有。商业转载请联系官方授权，非商业转载请注明出处。
    
    
    */
    class Program
    {
        static void Main(string[] args)
        {
            int[][] array = new int[4][];
            array[0] = new int[] { 1, 1, 0, 0 };
            array[1] = new int[] { 1, 0, 0, 1 };
            array[2] = new int[] { 0, 1, 1, 1 };
            array[3] = new int[] { 1, 0, 1, 0 };
            int[][] newArray = FlipAndInvertImage(array);
        }

        public static int[][] FlipAndInvertImage(int[][] A)
        {
            int temp;
            for (int i = 0; i < A.GetLength(0); i++)
            {
                for (int j = 0; j < A[i].Length / 2; j++)
                {
                    temp = A[i][j];
                    A[i][j] = A[i][A[i].Length - 1 - j] ^ 1;
                    A[i][A[i].Length - 1 - j] = temp ^ 1;
                }
                if ((A.Length&1)==1)//长度奇数
                {                    
                    A[i][A[i].Length / 2] = A[i][A[i].Length / 2] ^ 1;
                }                
            }
            return A;
        }
    }
}
