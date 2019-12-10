using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _478_在圆内随机生成点
{
    /*
        给定圆的半径和圆心的 x、y 坐标，写一个在圆中产生均匀随机点的函数 randPoint 。

    说明:

        输入值和输出值都将是浮点数。
        圆的半径和圆心的 x、y 坐标将作为参数传递给类的构造函数。
        圆周上的点也认为是在圆中。
        randPoint 返回一个包含随机点的x坐标和y坐标的大小为2的数组。

    示例 1：

    输入: 
    ["Solution","randPoint","randPoint","randPoint"]
    [[1,0,0],[],[],[]]
    输出: [null,[-0.72939,-0.65505],[-0.78502,-0.28626],[-0.83119,-0.19803]]

    示例 2：

    输入: 
    ["Solution","randPoint","randPoint","randPoint"]
    [[10,5,-7.5],[],[],[]]
    输出: [null,[11.52438,-8.33273],[2.46992,-16.21705],[11.13430,-12.42337]]

    输入语法说明：

    输入是两个列表：调用成员函数名和调用的参数。Solution 的构造函数有三个参数，圆的半径、圆心的 x 坐标、圆心的 y 坐标。randPoint 没有参数。输入参数是一个列表，即使参数为空，也会输入一个 [] 空列表。

    来源：力扣（LeetCode）
    链接：https://leetcode-cn.com/problems/generate-random-point-in-a-circle
    著作权归领扣网络所有。商业转载请联系官方授权，非商业转载请注明出处。


    */
    class Program
    {
        static void Main(string[] args)
        {
        }
    }

    public class Solution
    {
        double x_center, y_center, radius;
        Random rd = new Random();
        double r2 ;
        public Solution(double radius, double x_center, double y_center)
        {
            this.x_center = x_center;
            this.y_center = y_center;
            this.radius = radius;
            r2 = radius * radius;
        }

        public double[] RandPoint()
        {
            
            int parityX = rd.Next(0, 2);//X奇偶
            int parityY = rd.Next(0, 2);//Y奇偶
            double tempX=0, tempY=0;

            while (true)
            {
                tempX = rd.NextDouble() * radius;
                tempY = rd.NextDouble() * radius;
                if (tempX * tempX + tempY * tempY <= r2)
                {
                    break;
                }
            }
            
            if(parityX == 0 )
            {
                if(parityY==0)
                {
                    return new double[] { x_center + tempX, y_center + tempY };
                }
                else
                {
                    return new double[] { x_center + tempX, y_center - tempY };
                }
            }
            else 
            {
                if(parityY==0)
                {
                    return new double[] { x_center - tempX, y_center + tempY };
                }
                else
                {
                    return new double[] { x_center - tempX, y_center - tempY };
                }                
            }            
        }
    }
}
