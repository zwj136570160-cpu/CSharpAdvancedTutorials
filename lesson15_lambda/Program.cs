namespace lesson15_lambda
{
    internal class Program
    {
        #region 4.闭包
        //内层的函数可以引用包含在它外层的函数的变量
        //即使外层函数的执行已经终止
        //注意：
        //该变量提供的值并非变量创建的值，而是在父函数范围内的最终值

        class Test
        {
            public event Action action;

            public Test()
            {
                int value = 10;
                //这里就形成了闭包，因为当构造函数执行完毕后，其中申明的临时变量value的声明周期被改变了
                action = () =>
                {
                    Console.WriteLine(value);
                };

                for (int i = 0; i < 10; i++)
                {
                    //此index 非彼index
                    int index = i;
                    action += () =>
                    {
                        Console.WriteLine(index);
                    };
                }
            }

            public void DoSomthing()
            {
                action();
            }
        }
        #endregion

        static void Main(string[] args)
        {
            Console.WriteLine("lambda");

            #region 1.什么是lambda表达式
            //可以将lambda表达式理解为匿名函数的简写
            //它除了写法不同外，使用上和匿名函数一摸一样都是和委托或者事件配合使用的
            #endregion

            #region 2.lambad表达式语法
            //匿名函数
            //delegate (参数列表)
            //{
            //    函数逻辑
            //}

            //lambda表达式
            //(参数列表) => 
            //{
            //    函数体
            //}
            #endregion

            #region 3.使用
            //1.无参无返回值
            Action a = () =>
            {
                Console.WriteLine("无参无返回值的lambda表达式");
            };
            a();

            //2.有参
            Action<int> a2 = (int vlaue) =>
            {
                Console.WriteLine($"有参数的lmbda表达式{vlaue}");
            };
            a2(100);

            //3.甚至参数类型都可以省略，参数类型和委托或事件容器一致
            Action<int> a3 = (value) =>
            {
                Console.WriteLine($"省略参数类型的写法{200}");
            };
            a3(200);
            //4.返回值
            Func<string, int> a4 = (value) =>
            {
                Console.WriteLine($"有返回值的lambda表达式{value}");
                return 1;
            };
            Console.WriteLine(a4("123123"));

            //其他传参使用等和匿名函数一样
            //缺点也是和匿名函数一样的
            #endregion

            #region 4.闭包
            Test t = new Test();
            t.DoSomthing();
            #endregion
        }
        //总结：
        //匿名函数的特殊写法就是lambda表达式
        //固定写法：
        //（参数列表）=>
        //{
        //    函数体
        //}
        //参数列表可以直接省略参数类型
        //主要在委托传递和存储时，为了方便可以直接使用匿名函数或者lambda表达式
        //缺点：无法指定移除
    }
}
