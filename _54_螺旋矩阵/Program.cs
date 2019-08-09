using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _54_螺旋矩阵
{
    /*
    给定一个包含 m x n 个元素的矩阵（m 行, n 列），请按照顺时针螺旋顺序，返回矩阵中的所有元素。

    示例 1:

    输入:
    [
     [ 1, 2, 3 ],
     [ 4, 5, 6 ],
     [ 7, 8, 9 ]
    ]
    输出: [1,2,3,6,9,8,7,4,5]

    示例 2:

    输入:
    [
      [1, 2, 3, 4],
      [5, 6, 7, 8],
      [9,10,11,12]
    ]
    输出: [1,2,3,4,8,12,11,10,9,5,6,7]

    来源：力扣（LeetCode）
    链接：https://leetcode-cn.com/problems/spiral-matrix
    著作权归领扣网络所有。商业转载请联系官方授权，非商业转载请注明出处。

    */
    class Program
    {
        static void Main(string[] args)
        {
        }
        public static IList<int> SpiralOrder(int[][] matrix)
        {
            IList<int> list = new List<int>();
            if (matrix == null || matrix.Length < 1) return list;
            int count = matrix.Count() * matrix[0].Count();//总的元素个数
            bool[][] tempArray = new bool[matrix.Length][];//辅助数组 记录已经遍历过的元素
            for (int r = 0; r < matrix.Length; r++)
            {
                tempArray[r] = new bool[matrix[r].Length];
            }

            Direction direction = Direction.Right;
            int tempCount = 0;
            int i = 0, j = 0;//当前元素的索引[i][j]
            while(tempCount<count)
            {
                switch(direction)
                {
                    case Direction.Right://向右遍历
                        for (int k = j; k < matrix[i].Length; k++)//遍历第i行的元素
                        {
                            if(tempArray[i][k]==true)//该元素已经遍历过
                            {
                                //改变方向 向下遍历
                                direction = Direction.Down;
                                i++;
                                break;
                            }
                            else //该元素没有被遍历过
                            {
                                j = k;
                                list.Add(matrix[i][j]);
                                tempCount++;
                                if (tempCount == count) return list;//已遍历完所有的元素 返回结果
                                tempArray[i][j] = true;//该元素已经遍历过
                            }
                        }
                        break;
                    case Direction.Down://向下遍历
                        for (int k = i; k < matrix.Length; k++)//遍历第j列
                        {
                            if(tempArray[k][j]==true)
                            {
                                //改变方向 向左遍历
                                direction = Direction.Left;
                                j--;
                                break;
                            }
                            else
                            {
                                i = k;
                                list.Add(matrix[i][j]);
                                tempCount++;
                                if (tempCount == count) return list;
                                tempArray[i][j] = true;
                            }
                        }

                        break;
                    case Direction.Left://向左遍历
                        for (int k = j ; k >=0; k--)
                        {
                            if(tempArray[i][k]==true)
                            {
                                //改变方向 向上遍历
                                direction = Direction.Up;
                                i--;
                                break;
                            }
                            else
                            {
                                j = k;
                                list.Add(matrix[i][j]);
                                tempCount++;
                                if (tempCount == count) return list;
                                tempArray[i][j] = true;
                            }
                        }
                        break;
                    case Direction.Up:
                        for (int k = i ; k >=0; k--)
                        {
                            if(tempArray[k][j]==true)
                            {
                                //改变方向 向右遍历
                                direction = Direction.Right;
                                j++;
                                break;
                            }
                            else
                            {
                                i = k;
                                list.Add(matrix[i][j]);
                                tempCount++;
                                if (tempCount == count) return list;
                                tempArray[i][j] = true;
                            }
                        }

                        break;
                }
            }
            return list;
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
