using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _739_每日温度
{
    /*
    根据每日 气温 列表，请重新生成一个列表，对应位置的输入是你需要再等待多久温度才会升高超过该日的天数。如果之后都不会升高，请在该位置用 0 来代替。

    例如，给定一个列表 temperatures = [73, 74, 75, 71, 69, 72, 76, 73]，你的输出应该是 [1, 1, 4, 2, 1, 1, 0, 0]。

    提示：气温 列表长度的范围是 [1, 30000]。每个气温的值的均为华氏度，都是在 [30, 100] 范围内的整数。

    来源：力扣（LeetCode）
    链接：https://leetcode-cn.com/problems/daily-temperatures
    著作权归领扣网络所有。商业转载请联系官方授权，非商业转载请注明出处。
    */
    class Program
    {
        static void Main(string[] args)
        {
            int[] array = DailyTemperatures(new int[] { 73, 74, 75, 71, 69, 72, 76, 73 });
        }

        public static int[] DailyTemperatures(int[] T)
        {
            int[] array = new int[T.Length];
            Stack<int> stack = new Stack<int>();
            for (int i = T.Length-1; i >=0; i--)
            {
                while(stack.Count>0 && T[stack.Peek()]<=T[i])
                {
                    stack.Pop();
                }
                if(stack.Count>0)
                {
                    array[i] = stack.Peek();
                }
                else
                {
                    array[i] = i;
                }
                stack.Push(i);
            }
            for (int i = 0; i < T.Length; i++)
            {
                array[i] = array[i] - i;
            }
            return array;
        }
    }
}
