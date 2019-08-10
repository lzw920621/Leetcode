using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _59_螺旋矩阵II
{
    /*
    给定一个正整数 n，生成一个包含 1 到 n2 所有元素，且元素按顺时针顺序螺旋排列的正方形矩阵。

    示例:

    输入: 3
    输出:
    [
     [ 1, 2, 3 ],
     [ 8, 9, 4 ],
     [ 7, 6, 5 ]
    ]

    来源：力扣（LeetCode）
    链接：https://leetcode-cn.com/problems/spiral-matrix-ii
    著作权归领扣网络所有。商业转载请联系官方授权，非商业转载请注明出处。
    */
    class Program
    {
        static void Main(string[] args)
        {
            int[][] array = GenerateMatrix(5);
        }

        public static int[][] GenerateMatrix(int n)
        {
            int[][] array = new int[n][];
            bool[][] tempArray = new bool[n][];//辅助数组 记录已经遍历过的元素
            for (int r = 0; r < n; r++)
            {
                tempArray[r] = new bool[n];
                array[r] = new int[n];
            }
            Direction direction = Direction.Right;
            int count = n * n;
            int tempCount = 0;
            int i = 0, j = 0;//当前元素的索引[i][j]

            while (tempCount < count)
            {
                switch (direction)
                {
                    case Direction.Right://向右遍历
                        for (int k = j; k < n; k++)//遍历第i行的元素
                        {
                            if (tempArray[i][k] == true)//该元素已经遍历过
                            {
                                //改变方向 向下遍历
                                direction = Direction.Down;
                                i++;
                                break;
                            }
                            else //该元素没有被遍历过
                            {
                                j = k;                                
                                tempCount++;
                                array[i][j] = tempCount;
                                if (tempCount == count) return array;//已遍历完所有的元素 返回结果
                                tempArray[i][j] = true;//该元素已经遍历过
                            }
                        }
                        break;
                    case Direction.Down://向下遍历
                        for (int k = i; k < n; k++)//遍历第j列
                        {
                            if (tempArray[k][j] == true)
                            {
                                //改变方向 向左遍历
                                direction = Direction.Left;
                                j--;
                                break;
                            }
                            else
                            {
                                i = k;
                                tempCount++;
                                array[i][j] = tempCount;
                                if (tempCount == count) return array;
                                tempArray[i][j] = true;
                            }
                        }

                        break;
                    case Direction.Left://向左遍历
                        for (int k = j; k >= 0; k--)
                        {
                            if (tempArray[i][k] == true)
                            {
                                //改变方向 向上遍历
                                direction = Direction.Up;
                                i--;
                                break;
                            }
                            else
                            {
                                j = k;
                                tempCount++;
                                array[i][j] = tempCount;
                                if (tempCount == count) return array;
                                tempArray[i][j] = true;
                            }
                        }
                        break;
                    case Direction.Up:
                        for (int k = i; k >= 0; k--)
                        {
                            if (tempArray[k][j] == true)
                            {
                                //改变方向 向右遍历
                                direction = Direction.Right;
                                j++;
                                break;
                            }
                            else
                            {
                                i = k;
                                tempCount++;
                                array[i][j] = tempCount;
                                if (tempCount == count) return array;
                                tempArray[i][j] = true;
                            }
                        }
                        break;
                }
            }

            return array;
        }
        enum Direction
        {
            Up,
            Down,
            Left,
            Right
        }
    }
}
