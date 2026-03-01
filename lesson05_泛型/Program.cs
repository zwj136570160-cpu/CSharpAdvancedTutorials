namespace lesson05_泛型
{
    #region 1.泛型是什么
    //泛型实现了类型参数化，达到代码重用目的
    //通过类型参数化来实现同一份代码上操作多种类型

    //泛型相当于类型占位符
    //定义类或方法时使用替代符代表变量类型
    //当真正使用类或者方法时在具体指定类型
    #endregion

    #region 2.泛型分类
    //泛型类喝泛型接口
    //基本语法
    //class 类名<泛型占位字母>
    //interface 接口名<泛型占位字母>

    //泛型函数
    //基本语法：函数名<翻新占位字母>(参数列表)

    //注意：泛型占位字母可以有多个，用逗号分开
    #endregion

    #region 3.泛型类和接口
    //泛型类
    class TestClass<T>
    {
        public T Value;
    }

    //多占位字母泛型类
    class TestClass2<T1,T2,K,M,L,Key,Value>
    {
        public T1 value1;
        public T2 value2;
        public K value3;
        public M value4;
        public L value5;
        public Key value6;
        public Value value7;
    }

    //泛型接口
    interface TestInterface<T>
    {
        T Value { get; set; }
    }

    //泛型类继承接口
    class Test : TestInterface<int>
    {
        public int Value { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
    }

    #endregion

    #region 4.泛型方法
    //1.普通类中的泛型方法
    class Test2
    {
        public void TestFun<T>(T value)
        {
            Console.WriteLine(value);
        }

        public void TestFun<T>()
        {
            //用泛型类型在里面做一些逻辑处理
            T t = default(T);   //获取类型的默认值
        }

        public T TestFun<T>(string v)
        {
            return default(T);
        }

        public void TestFun<T,K,M>(T t, K k, M m)
        {

        }
    }

    //2.泛型类中的泛型方法
    class Test2<T>
    {
        public T Value;

        public void TestFun<K>(K k)
        {
            Console.WriteLine(k);
        }

        //这个不叫泛型方法，因为T是泛型类申明的时候，就指定了，在使用这个函数的时候，我们不能再去动态的变化
        public void TestFun(T t)
        {

        }
    }
    #endregion

    #region 5.泛型的作用
    //1.不同类型对象的相同逻辑处理就可以选择泛型
    //2.使用泛型可以一定成都避免装箱拆箱

    class ArrayList<T>
    {
        private T[] array;

        public void Add(T value)
        {

        }

        public void Remove(T value)
        {

        }
    }
    #endregion

    #region 总结
    //1.申明泛型时，它只是一个类型的占位符
    //2.泛型真正起作用的时候，是在使用它的时候
    //3.泛型占位字母可以有n个用逗号分开
    //4.泛型占位字母一般是大写字母
    //5.不确定泛型类型时，获取默认值，可以使用default(占位字符)
    //6.看到<>包裹的字母，那肯定是泛型
    #endregion

    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("泛型");

            TestClass<int> t = new TestClass<int>();
            t.Value = 10;
            Console.WriteLine(t.Value);

            TestClass<string> t2 = new TestClass<string>();
            t2.Value = "123123";
            Console.WriteLine(t2.Value);

            TestClass2<int, string, float, double, TestClass<int>, uint, short> t3 = new TestClass2<int, string, float, double, TestClass<int>, uint, short>();

            Test2 tt = new Test2();
            tt.TestFun<string>("123123456");

            Test2<int> tt2 = new Test2<int>();
            tt2.TestFun(10);
            tt2.TestFun<string>("123");
            tt2.TestFun<float>(1.4f);
            tt2.TestFun(20);
        }
    }
}
