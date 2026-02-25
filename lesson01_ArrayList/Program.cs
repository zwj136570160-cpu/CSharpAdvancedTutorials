using System.Collections;

namespace lesson01_ArrayList
{
    class Test
    {

    }
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("ArrayList");

            #region 练习题回顾
            //C#核心中，索引器的练习题
            //自定义一个整形数组类，该类中有一个整形数组变量
            //为它封装增删查改的方法
            #endregion

            #region 1.ArrayList的本质
            //ArrayList是一个C#为我们封装好的类
            //它的本质是一个object类型的数组
            //ArrayList类帮助我们实现了很多方法
            //比如数组的增删查改
            #endregion

            #region 2.申明
            //需要引用命名空间System.Collections
            ArrayList array = new ArrayList();
            #endregion

            #region 3.增删查改

            #region 增
            //Add
            array.Add(1);
            array.Add("123");
            array.Add(true);
            array.Add(new object());
            array.Add(new Test());
            array.Add(true);

            ArrayList array2 = new ArrayList();
            array2.Add(123);
            //范围增加（批量增加，把另一个list容器里面的内容加到后面）（AddRange）
            array.AddRange(array2);

            //插入（Insert）
            array.Insert(1, "123456");
            Console.WriteLine(array[1]);
            #endregion

            #region 删
            //移除指定元素，从头找，找到删(Remove)
            array.Remove(1);

            //移除指定位置的元素(RemoveAt)
            array.RemoveAt(2);
            //清空(Clear)
            //array.Clear();
            #endregion

            #region 查
            Console.WriteLine(array[0]);    //123

            //查看元素是否存在(Contains)
            if (array.Contains("123"))
            {
                Console.WriteLine("存在123");
            }

            //正向查找元素位置(IndexOf)
            //找到的返回值是位置，找不到，返回值是-1
            int index = array.IndexOf(true);
            Console.WriteLine(index);

            Console.WriteLine(array.IndexOf(false));

            //反向查找元素位置(LastIndexOf)
            index = array.LastIndexOf(true);
            Console.WriteLine(index);
            #endregion

            #region 改
            Console.WriteLine(array[0]);
            array[0] = "999";
            Console.WriteLine(array[0]);
            #endregion

            #endregion
            Console.WriteLine("-----------------------");

            #region 遍历
            //长度(Count)
            Console.WriteLine(array.Count);
            //容量(Capacity)
            Console.WriteLine(array.Capacity);
            for (int i = 0; i < array.Count; i++)
            {
                Console.WriteLine(array[i]);
            }
            Console.WriteLine("-----------------------");

            //迭代器遍历
            foreach (object item in array)
            {
                Console.WriteLine(item);
            }
            #endregion

            #region 4.装箱拆箱
            //ArrayList本质是一个自动扩容的object数组
            //由于万物之父来存储数据，自然存在装箱拆箱
            //当往其中进行值类型存储时就是在装箱，当将值类型对象取出来转换使用时，就存在拆箱
            //所以ArrayList尽量少用，之后会学习更好的数据容器

            int k = 1;
            //装箱
            array[0] = k;
            //拆箱
            k = (int)array[0];
            #endregion

        }
    }
}
