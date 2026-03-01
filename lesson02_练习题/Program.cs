using System.Collections;

namespace lesson02_练习题
{
    internal class Program
    {
        #region 练习题2
        //写一个方法计算任意一个数的二进制数
        //使用站结构方式存储，之后打印出来

        static void Calc(int num)
        {
            Console.Write($"{num}的二进制是：");
            Stack calc = new Stack();
            while (true)
            {
                calc.Push(num % 2);
                num /= 2;
                if (num == 1)
                {
                    calc.Push(num % 2);
                    break;
                }
            }
            foreach (object item in calc)
            {
                Console.Write(item);
            }
        }
        #endregion

        static void Main(string[] args)
        {
            Console.WriteLine("Stack 练习题");

            #region 练习题1
            //请简述栈的存储规则
            //1.栈是C#封装好的类，本质上是一个封装了特殊规则的object数组
            //2.Stack是栈存储容器，是先进后出的数据结构
            #endregion

            Calc(10);
            
        }
    }
}
