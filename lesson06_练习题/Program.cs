using System.Collections;

namespace lesson06_练习题
{
    #region 练习题1
    //用泛型实现一个单例模式基类

    class Test<T> where T : new()
    {
        private static T instance = new T();
        public int value = 10;

        public static T Instance
        {
            get
            {
                return instance; 
            }
        }
    }

    class GameMgr : Test<GameMgr>
    {
        public int value;
    }
    #endregion

    #region 练习题2
    //利用泛型知识点，仿造ArrayList实现一个不确定数组类型的类，实现增删查改方法

    class ArrayList<T>
    {
        private T[] array;
        private int count;

        public ArrayList()
        {
            count = 0;
            //一开始的容量就是16
            array = new T[16];
        }

        //增
        public void Add(T value)
        {
            //是否需要扩容
            if (count >= Capacity)
            {
                //搬家
                T[] temp = new T[count * 2];
                for (int i = 0; i < Capacity; i++)
                {
                    temp[i] = array[i];
                }
                array = temp;
            }

            //不需要扩容，直接加
            array[count] = value;
            ++count;
        }

        //删
        public void Remove(T value)
        {
            //这个地方不是小于数组的容量，是小于具体存了几个值
            int index = -1;
            for (int i = 0; i < count; i++)
            {
                //不能使用“==”来判断，不是所有的类型都重载了运算符
                if (array[i].Equals(value))
                {
                    index = i;
                    break;
                }
            }
            //只要不等于-1，就证明找到了，那就去移除
            if (index != -1)
            {
                RemoveAt(index);
            }
        }

        //删
        public void RemoveAt(int index)
        {
            //判断索引是否合法
            if (index < 0 || index >= Count)
            {
                Console.WriteLine("索引不合法");
                return;
            }
            //后面往前放
            for (; index < count - 1; index++)
            {
                array[index] = array[index + 1];
            }
            //把一个数移除了，后面的往前放，那么最后一个要移除
            array[count - 1] = default(T);
            count--;
        }


        //索引器，查改
        public T this[int index]
        {
            get
            {
                if (index < 0 || index >= Count)
                {
                    Console.WriteLine("索引不合法");
                    return default(T);
                }
                return array[index]; 
            }
            set
            {
                if (index < 0 || index >= Count)
                {
                    Console.WriteLine("索引不合法");
                    return;
                }
                array[index] = value; 
            }
        }

        /// <summary>
        /// 获取容量
        /// </summary>
        public int Capacity
        {
            get
            {
                return array.Length;
            }
        }

        /// <summary>
        /// 得到具体存了几个值
        /// </summary>
        public int Count
        {
            get
            {
                return count; 
            }
        }
    }
    #endregion

    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("泛型约束 练习题");


            ArrayList<int> array = new ArrayList<int>();
            Console.WriteLine(array.Count);
            Console.WriteLine(array.Capacity);
            array.Add(1);
            array.Add(2);
            array.Add(3);
            Console.WriteLine(array.Count);
            Console.WriteLine(array.Capacity);

            Console.WriteLine(array[-5]);

            array.Remove(2);
            Console.WriteLine(array.Count);
        }
    }
}
