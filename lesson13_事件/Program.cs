namespace lesson13_事件
{
    #region 1.事件是什么
    //事件是基于委托的存在
    //事件是委托的安全包裹
    //让委托的使用更具有安全性
    //事件是一种特殊的变量类型
    #endregion

    #region 2.事件的使用
    //申明语法：
    //访问修饰符 event 委托类型 事件名称;
    //事件的使用：
    //1.事件是作为成员变量存在于类中
    //2.委托怎么用，事件就怎么用
    //事件相对于委托的区别：
    //1.不能在类外部赋值
    //2.不能在类外部调用
    //注意：
    //它智能作为成员存在于类和接口以及结构体中

    class Test
    {
        //委托成员变量 用于存储函数的
        public Action myFun;
        //事件成员变量 用于存储函数的
        public event Action myEvent;

        public Test()
        {
            //事件的使用和委托一样 只是有些细微的区别
            myFun = TestFun;
            myFun += TestFun;
            myFun -= TestFun;
            myFun();
            myFun.Invoke();
            myFun = null;

            myEvent = TestFun;
            myEvent += TestFun;
            myEvent -= TestFun;
            myEvent();
            myEvent.Invoke();
            myEvent = null;
        }

        public void DoEvent()
        {
            if (myEvent != null)
            {
                myEvent();
            }
        }

        public void TestFun()
        {
            Console.WriteLine("123");
        }
    }
    #endregion

    #region 3.为什么有事件
    //1.防止外部随意置空委托
    //2.防止外部随意调用委托
    //3.事件相当于对委托进行了一次封装，让其更加安全
    #endregion

    internal class Program
    {
        static void Testfun()
        {

        }

        static void Main(string[] args)
        {
            Console.WriteLine("事件");

            Test test = new Test();

            //委托可以在外部赋值
            test.myFun = null;
            test.myFun = Testfun;
            //事件不能在外部赋值
            test.myEvent = null;
            test.myEvent = Testfun;
            //虽然不能直接赋值，但是可以通过+=和-=的方式来添加和删除事件
            test.myEvent += Testfun;
            test.myEvent -= Testfun;

            //委托是可以在外部调用的
            test.myFun();
            test.myFun.Invoke();

            //事件不能在外部调用
            test.myEvent();
            //只能在类的内部去封装调用
            test.DoEvent();

            Action a = Testfun;
            //事件是不能作为临时变量在函数使用的
            //event Action ae = Testfun;
    }
        //总结：
        //事件和委托的区别
        //事件和委托的使用基本一样
        //事件就是特殊的委托
        //主要区别：
        //1.事件不能在外部使用赋值=符号，只能使用+ - 委托，哪里都能用
        //2.事件不能在外部执行，委托哪里都可以执行
        //3.事件不能作为函数中的临时变量，委托可以
    }
}
