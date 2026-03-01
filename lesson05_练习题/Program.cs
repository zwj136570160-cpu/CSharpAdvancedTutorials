namespace lesson05_练习题
{
    //定义一个泛型方法，方法内判断该类型为何类型，并返回类型的名称与占有的字节数，如果是int，则返回“整形，4字节”
    //只考虑以下类型
    //int：整形
    //char：字符
    //float：单精度浮点数
    //string：字符串
    //如果是其它类型，则返回“其它类型”
    //（可以通过typeof(类型) == typeof(类型) 的方式进行类型判断）

    class Test
    {
        public string Type<T>(T t)
        {
            if (typeof(T) == typeof(int))
            {
                return $"整形,{sizeof(int)}字节";
            }
            else if (typeof(T) == typeof(char))
            {
                return $"字符,{sizeof(char)}字节";
            }
            else if(typeof(T) == typeof(float))
            {
                return $"浮点数,{sizeof(float)}字节";
            }
            else if (typeof(T) == typeof(string))
            {
                return $"字符串,?字节";
            }
            return "其他类型";
        }
    }
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("泛型 练习题");

            Test test = new Test();
            Console.WriteLine($"{test.Type<int>(10)}");
        }
    }
}
