namespace lesson15_练习题
{
    internal class Program
    {
        //有一个函数，会返回一个委托函数，这个委托函数中只有一句打印代码
        //之后执行返回的委托函数时，可以打印出1~10
        static Action Test()
        {
            Action action = null;

            for (int i = 1; i < 11; i++)
            {
                int index = i;
                action += () =>
                {
                    Console.WriteLine(index);
                };
            }

            return action;
        }

        static void Main(string[] args)
        {
            Console.WriteLine("lambda 练习题");

            Test()();
        }
    }
}
