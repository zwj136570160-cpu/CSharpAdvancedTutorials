using System.Collections;

namespace lesson02_Stack
{
    class Test
    {
        
    }
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Stack");

            #region 1.Stack的本质
            //Stack是一个C#为我们封装好的类
            //它的本质也是一个object[]数组，只是封装了特殊的存储规则

            //Stack是栈存储容器，栈是一种先进后出的数据结构
            //栈是先进后出
            #endregion

            #region 2.申明
            //需要引用命名空间System.Collections
            Stack stack = new Stack();
            #endregion

            #region 3.增取查改

            #region 增(Push)
            //压栈
            stack.Push(1);
            stack.Push("123");
            stack.Push(true);
            stack.Push(1.2f);
            stack.Push(new Test());
            #endregion

            #region 取
            //栈中不存在删除的概念
            //只要取的概念
            //弹栈
            object v = stack.Pop();
            Console.WriteLine(v);   //lesson02_Stack.Test

            v = stack.Pop();
            Console.WriteLine(v);   //1.2
            #endregion

            #region 查
            //1.栈无法查看指定位置的元素
            //只能查看栈顶的内容
            v = stack.Peek();
            Console.WriteLine(v);   //true

            v = stack.Peek();
            Console.WriteLine(v);   //true

            //2.查看元素是否存在于栈中
            if (stack.Contains("123"))
            {
                Console.WriteLine("存在123");
            }
            #endregion

            #region 改
            //栈无法改变其中的元素，只能（压）和弹（取）
            //实在要改，只能清空
            stack.Clear();
            stack.Push("1");
            stack.Push("2");
            stack.Push("味精");
            #endregion

            #endregion

            #region 4.遍历
            //1.长度
            Console.WriteLine(stack.Count);

            //2.用foreach遍历
            //而且遍历出来的顺序，也是从栈顶到栈底
            foreach (object item in stack)
            {
                Console.WriteLine(item);
            }

            //3.还有一种遍历方式
            //将栈转换为object数组
            //遍历出来的顺序，也是从栈顶到栈底
            object[] array = stack.ToArray();
            for (int i = 0; i < array.Length; i++)
            {
                Console.WriteLine(array[i]);
            }

            //4.循环弹栈
            while (stack.Count > 0)
            {
                Console.WriteLine(stack.Pop());
            }
            Console.WriteLine(stack.Count);
            #endregion

            #region 5.装箱拆箱
            //由于万物之父来存储数据，自然存在装箱拆箱
            //当往其中进行值类型存储时就是在装箱
            //当将值类型对象取出来转换使用时，就存在拆箱
            #endregion
        }
    }
}
