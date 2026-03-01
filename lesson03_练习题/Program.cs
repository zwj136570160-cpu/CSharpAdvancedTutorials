using System.Collections;

namespace lesson03_练习题
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Queue 练习题");

            #region 练习题1
            //请简述队列的存储规则

            //先进先出
            #endregion

            #region 练习题2
            //使用队列存储消息，一次性存10条消息，每隔一段时间打印一条消息，控制台打印消息时要有明显停顿感

            Queue queue = new Queue();
            int[] array = new int[] { 1, 2, 3, 4, 5, 6, 7, 8, 10 };
            int index = 0;
            for (int i = 0; i < array.Length; i++)
            {
                queue.Enqueue(array[i]);
            }
            while (queue.Count > 0)
            {
                ++index;
                if (index == 99999999)
                {
                    object o = queue.Dequeue();
                    Console.WriteLine(o);
                    index = 0;
                }
            }
            #endregion
        }
    }
}
