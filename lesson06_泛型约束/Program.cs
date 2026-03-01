namespace lesson06_泛型约束
{
    #region 知识回顾
    //泛型类
    class TestClass<T, U>
    {
        public T t;
        public U u;

        public U TestFun(T t)
        {
            return default(U);
        }

        //泛型函数
        public V TestFun<K, V>(K k)
        {
            return default(V);
        }
    }
    #endregion

    #region 1.什么是泛型约束
    //让泛型类型有一定限制
    //关键字：where
    //泛型约束一共有六种
    //1.值类型                                       where 泛型字母：struct
    //2.引用类型                                     where 泛型字母：class
    //3.存在无参公共构造函数                          where 泛型字母：new()
    //4.某个类本身或者其派生类                        where 泛型字母：类名
    //5.某个接口的派生类型                            where 泛型字母：接口名
    //6.另一个泛型类型本身或者派生类型                 where 泛型字母：另一个泛型字母

    //where 泛型字母:(约束的类型)
    #endregion

    #region 2.各泛型的约束讲解

    #region 值类型
    class Test<T> where T : struct
    {
        public T value;
        public void TestFun<K>(K v) where K : struct
        {

        }
    }
    #endregion

    #region 引用类型约束
    class Test2<T> where T:class
    {
        public T value;

        public void TestFun<K>(K k) where K:class
        {

        }
    }
    #endregion

    #region 公共无参构造约束

    class Test3<T> where T:new()
    {
        public T Value;

        public void TestFun<K>(K k) where K : new()
        {

        }
    }

    class Test1
    {

    }

    class Test2
    {
        public Test2(int a)
        {

        }
    }
    #endregion

    #region 类约束

    class Test4<T> where T : Test1
    {
        public T Value;

        public void TestFun<K>(K k) where K : Test1
        {

        }
    }

    class Test3:Test1
    {

    }
    #endregion

    #region 接口约束
    interface IFly
    {

    }

    interface IMove: IFly
    {

    }

    class Test4:IFly
    {

    }

    class Test5<T> where T : IFly
    {
        public T Value;

        public void TestFun<K>(K k) where K : IFly
        {

        }
    }
    #endregion

    #region 另一个泛型约束
    class Test6<T,U> where T : U
    {
        public T Value;

        public void TestFun<K,V>(K k) where K : V
        {

        }
    }
    #endregion

    #endregion

    #region 3.约束的组合使用

    //new()需要写在最后
    class Test7<T> where T:class,new()
    {

    }
    #endregion

    #region 4.多个泛型有约束
    class Test8<T,K> where T:class,new() where K : new()
    {

    }

    #endregion

    #region 总结
    //泛型约束：让类型有一定限制
    //class
    //struct
    //new()
    //类名
    //接口名
    //另一个泛型字母

    //注意：
    //1.可以组合使用
    //2.多个泛型约束，用where链接即可
    #endregion
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("泛型约束");

            Test<int> t1 = new Test<int>();
            t1.TestFun<float>(1.3f);
            //Test<object> t1 = new Test<object>();

            Test2<Random> t2 = new Test2<Random>();
            t2.value = new Random();
            t2.TestFun<object>(new object());

            Test3<Test1> t3 = new Test3<Test1>();

            Test4<Test3> t4 = new Test4<Test3>();

            Test5<IMove> t5 = new Test5<IMove>();
            //t5.Value = new Test4();

            Test6<Test4, IFly> t6 = new Test6<Test4, IFly>();
        }
    }
}
