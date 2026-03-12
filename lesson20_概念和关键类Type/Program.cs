using System.Reflection;

namespace lesson20_概念和关键类Type
{
    #region 知识点回顾
    //编译器是一种翻译程序
    //它用于将源语言程序翻译为目标语言程序

    //源语言程序：某种程序设计语言写的，比如C#、C、C++、Java等语言写的程序
    //目标语言程序：二进制数表示的伪机器代码写的程序
    #endregion

    #region 1.什么是程序集
    //程序集是经由编译器编译得到的，供进一步编译执行的那个中间产物
    //在Windows系统中，它一般表现为后缀为.dll（库文件）或者是.exe（可执行文件）的格式

    //大白话：
    //程序集就是我们写的一个代码集合，我们现在写的所有代码最终都会被编译器翻译为一个程序集供别人使用
    //比如一个代码文件（dll）或者一个可执行文件（exe）
    #endregion

    #region 2.元数据
    //元数据就是用来描述数据的数据
    //这个概念不仅仅用于程序上，在别的领域也有元数据

    //大白话：
    //程序中的类，类中的函数、变量等等信息就是程序的元数据
    //有关程序以及类型的数据被称为元数据，他们保存在程序集中
    #endregion

    #region 3.反射的概念
    //程序正在运行时，可以查看其他程序集或者自身的元数据
    //一个运行的程序查看本身或者其他程序的元数据的行为就叫做反射

    //大白话：
    //在程序运行时，通过反射可以得到其他程序集或者自己程序集代码的各种信息
    //类、函数、变量、对象等等，实例化他们，执行他们，操作他们
    #endregion

    #region 4.反射的作用
    //因为反射可以在程序编译后获得信息，所以它提高了程序的拓展性和灵活性
    //1.程序运行时得到所有元数据，包括元数据的特性
    //2.程序运行时，实例化对象，操作对象
    //3.程序运行时创建新对象，用这些对象执行任务
    #endregion

    class Test
    {
        private int i = 1;
        public int j = 0;
        public string str = "123";

        public Test()
        {

        }

        public Test(int i)
        {
            this.i = i;
        }

        public Test(int i,string str) : this(i)
        {
            this.str = str;
        }

        public void Speak()
        {
            Console.WriteLine(i);
        }
    }

    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("概念和关键类Type");

            #region 5.语法相关

            #region Type
            //Type(类的信息类)
            //它是反射功能的基础
            //它是访问元数据的主要方式
            //使用Type的成员获取有关类型声明的信息
            //有关类型的成员（如构造函数、方法、字段、属性和类的事件）

            #region 获取Type
            //1.万物之父object中的GetType()可以获取对象的Type
            int a = 42;
            Type type = a.GetType();
            Console.WriteLine(type);    //输出：System.Int32
            //2.通过typeof关键字传入类名，也可得到对象的Type
            Type type2 = typeof(Test);
            Console.WriteLine(type2);   //输出：lesson20_概念和关键类Type.Test
            //3.通过类的名字也可以获取类型
            //注意：类名必须包含命名空间
            Type type3 = Type.GetType("System.Int32");
            Console.WriteLine(type3);   //输出：System.Int32

            #endregion

            #region 得到类的程序集信息
            //可以通过Type得到类所在的程序集信息
            Console.WriteLine(type.Assembly);   //输出：System.Private.CoreLib.dll
            #endregion

            #region 获取类中的所有公共成员
            //首先得到Type
            Type t = typeof(Test);
            //然后得到所有公共成员
            //需要引用命名空间System.Reflection
            MemberInfo[] infos = t.GetMembers();
            for (int i = 0; i < infos.Length; i++)
            {
                Console.WriteLine(infos[i]);    //输出：public Int32 j
                                                //输出：public System.String str
                                                //输出：public Void Speak()
            }
            #endregion

            #region 获取类的公共构造函数并调用
            //1.获取所有构造函数
            ConstructorInfo[] ctors = t.GetConstructors();
            for (int i = 0; i < ctors.Length; i++)
            {
                Console.WriteLine(ctors[i]);    //输出：public Void .ctor()
                                                //输出：public Void .ctor(Int32)
                                                //输出：public Void .ctor(Int32, System.String)
            }

            //2.获取其中一个构造函数并执行
            //得构造函数传入Type数组，数组中内容按顺序是参数类型
            //2.1.得到无参构造
            ConstructorInfo info = t.GetConstructor(new Type[0]);
            //执行无参构造,无参构造没有参数，传null
            Test obj = info.Invoke(null) as Test;
            Console.WriteLine(obj.j);   //输出：0
            //2.2.得到一个参数的构造
            ConstructorInfo info2 = t.GetConstructor(new Type[] { typeof(int) });
            obj = info2.Invoke(new object[] {2}) as Test;
            Console.WriteLine(obj.str); //输出：123

            ConstructorInfo info3 = t.GetConstructor(new Type[] { typeof(int), typeof(string) });
            obj = info3.Invoke(new object[] {4, "4444"}) as Test;
            Console.WriteLine(obj.str);   //输出：4444
            #endregion

            #region 获取类的公共成员变量
            //1.得到所有成员变量
            FieldInfo[] fieldInfos = t.GetFields();
            for (int i = 0; i < fieldInfos.Length; i++)
            {
                Console.WriteLine(fieldInfos[i]);   //输出：public Int32 j
                                                    //输出：public System.String str
            }
            //2.得到指定名称的公共成员变量
            FieldInfo infoJ = t.GetField("j");
            Console.WriteLine(infoJ);   //输出：public Int32 j

            //3.通过反射获取和设置对象的值
            Test test = new Test();
            test.j = 99;
            test.str = "2222";
            //3.1.通过反射，获取对象的某个变量的值
            Console.WriteLine(infoJ.GetValue(test));
            //3.2.通过反射，设置对象的某个变量的值
            infoJ.SetValue(test, 100);
            Console.WriteLine(infoJ.GetValue(test));    //输出：100
            #endregion

            #region 获取类的公共成员方法
            //通过Type得到类中的GetMethod方法，得到类中的公共成员方法
            //MethodInfo是方法的反射信息
            Type strType = typeof(string);
            //1.如果存在方法重载，用Type数组表示参数类型
            MethodInfo[] methods = strType.GetMethods();
            for (int i = 0; i < methods.Length; i++)
            {
                Console.WriteLine(methods[i]);  //输出：public System.String Substring(Int32, Int32)
                                                //输出：public System.String Substring(Int32)
            }
            MethodInfo subStr = strType.GetMethod("Substring",
                new Type[] { typeof(int), typeof(int) });
           
            //2.调用该方法
            //注意：如果是静态方法，Invoke中第一个参数传null即可
            string str = "Hello，World!";
            object resule = subStr.Invoke(str, new object[] { 7, 5 });
            Console.WriteLine(resule);  //输出：orld!
            #endregion

            #region 其他
            //Type;
            //得枚举
            //GetEnumNames()得到枚举的名字
            //GetEnumValues()得到枚举的值

            //得事件
            //GetEvent()得到事件信息
            //GetEvents()得到所有事件信息

            //得接口
            //GetInterface()得到接口信息
            //GetInterfaces()得到所有接口信息

            //得属性
            //GetProperty()得到属性信息
            //GetProperties()得到所有属性信息
            //等等

            #endregion

            #endregion

            #region Assembly
            //程序集类
            //主要用来加载其他程序集，加载后才能用Type来使用其他程序集中的信息
            //如果想要使用不是自己程序集中的内容，需要先加载程序集
            //比如dll文件（库文件）
            //简单的把库文件看成一种代码仓库，它提供给使用者一些可以直接拿来用的变量、函数或类

            //三种加载程序集的函数
            //一般用来记载在同一文件下的其他程序集
            //Assembly asembly2 = Assembly.Load("程序集名字");

            //一般用来加载不在同一文件下的其他程序集
            //Assembly asembly = Assembly.LoadFrom("包含程序集清单的文件的名称或路径");
            //Assembly asembly3 = Assembly.LoadFile("要加载的文件的完全限定路径");

            //1.先加载一个指定程序集
            Assembly assembly = Assembly.LoadFrom("E:\\C#课程\\C#进阶\\Csharp进阶教学\\lesson18_练习题\\bin\\Debug\\net10.0\\lesson18_练习题.dll");
            Type[] types = assembly.GetTypes();
            for (int i = 0; i < types.Length; i++)
            {
                Console.WriteLine(types[i]);    
            }
            //2.再加载程序集中的一个类对象，之后才能使用反射
            Type icon = assembly.GetType("lesson18_练习题.Icon");
            MemberInfo[] members = icon.GetMembers();
            for (int i = 0; i < members.Length; i++)
            {
                Console.WriteLine(members[i]);
            }
            //通过反射实例化对象
            //得到结构体Type
            Type structType = assembly.GetType("lesson18_练习题.SetPosition");
            Object SetPositionObj = Activator.CreateInstance(structType);
            FieldInfo x = structType.GetField("x");
            FieldInfo y = structType.GetField("y");
            x.SetValue(SetPositionObj, 0);
            y.SetValue(SetPositionObj, 1);
            //首先得到枚举Type来得到可以传入的参数
            Type moveDir = assembly.GetType("lesson18_练习题.E_MoveDir");
            FieldInfo right = moveDir.GetField("Right");

            //直接实例化对象
            object iconObj = Activator.CreateInstance(icon, right.GetValue(null), SetPositionObj);
            //得到对象中的方法，通过反射
            MethodInfo move = icon.GetMethod("Move");
            MethodInfo draw = icon.GetMethod("Draw");
            MethodInfo clear = icon.GetMethod("Clear");

            Console.Clear();
            while (true)
            {
                Thread.Sleep(50);
                clear.Invoke(iconObj, null);
                move.Invoke(iconObj, null);
                draw.Invoke(iconObj, null);
            }

            //3.类库工程创建
            //新建项目——>新建类库
            #endregion

            #region Activator
            //用于快速实例化对象的类
            //用于将Type对象快捷实例化为对象
            //先得到Type
            //然后快速实例化对象

            Type testType = typeof(Test);
            //1.无参构造
            Activator.CreateInstance(testType);
            Test testObj = Activator.CreateInstance(testType) as Test;
            Console.WriteLine(testObj.str); //输出：123
            //2.有参构造
            testObj = Activator.CreateInstance(testType, 99) as Test;
            Console.WriteLine(testObj.j);   //输出：0

            testObj = Activator.CreateInstance(testType, 55, "111222") as Test;
            Console.WriteLine(testObj.j);   //输出：0
            #endregion

            #endregion
        }
        //总结
        //反射
        //在程序运行时，通过反射可以得到其他程序集或者自己程序集代码的各种信息
        //类、函数、变量、对象等等，实例化他们，执行他们，操作他们

        //关键类
        //Type
        //Assembly
        //Activator

        //对于我们的意义
        //在初中级阶段，基本不会使用反射
        //所以目前对于大家来说，了解反射可以做什么就行
        //很长时间内都不会用到反射相关知识点

        //为什么要学反射
        //为了之后学习Unity引擎的基本工作原理做铺垫
        //Unity引擎的基本工作机制，就是建立在反射的基础上
    }
}
