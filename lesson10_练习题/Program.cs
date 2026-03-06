namespace lesson10_练习题
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("LinkedList 练习题");

            //使用Linkedlist，向其中加入10个随机整形变量
            //正向遍历一次打印出信息
            //反向遍历一次打印出信息

            LinkedList<int> linkedList = new LinkedList<int>();
            Random random = new Random();
            for (int i = 0; i < 10; i++)
            {
                linkedList.AddLast(random.Next(10));
            }
            //正向
            LinkedListNode<int> nowNode = linkedList.First;
            while (nowNode != null)
            {
                Console.WriteLine(nowNode.Value);
                nowNode = nowNode.Next;
            }
            Console.WriteLine("--------------------");
            //反向
            nowNode = linkedList.Last;
            while (nowNode != null)
            {
                Console.WriteLine(nowNode.Value);
                nowNode = nowNode.Previous;
            }
        }
    }
}
