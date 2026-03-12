namespace lesson17_练习题
{
    //协变
    delegate T TestOut<out T>();
    //逆变
    delegate void TestIn<in T>(T t);

    class Father
    {

    }

    class Son : Father
    {

    }

    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("协变逆变 练习题");

            #region 练习题1
            //请描述协变逆变有什么作用
            //用out修饰的泛型符号只能作为返回值，不能作为参数
            //用in修饰的泛型符号只能作为参数，不能作为返回值
            //协变：用父类委托类型装载子类委托类型
            //逆变：用子类委托类型装载父类委托类型
            #endregion

            #region 练习题2
            //通过代码说明协变和逆变的作用
            //协变：用父类委托类型装载子类委托类型
            TestOut<Father> father = () =>
            {
                return new Son();
            };
            TestOut<Father> f = father;
            //逆变：用子类委托类型装载父类委托类型
            TestIn<Father> son = (value) =>
            {

            };
            TestIn<Son> s = son;
            #endregion
        }
    }
}
