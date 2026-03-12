namespace lesson14_练习题
{
    internal class Program
    {
        static Func<int, int> Test(int a)
        {
            //这种写法会改变i的生命周期
            return delegate (int b)
            {
                return a * b;
            };
        }

        static void Main(string[] args)
        {
            Console.WriteLine("匿名函数 练习题");

            //写一个函数传入一个整数，返回一个函数
            //之后执行这个匿名函数时传入一个整数和之前那个函数传入的数相乘
            //返回结果

            Console.WriteLine(Test(1)(2));
        }
    }
}
