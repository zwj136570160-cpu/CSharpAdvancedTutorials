namespace lesson08_Dictionary
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Dictionary");

            #region 1.Dictionary的本质
            //可以将Dictionary理解为：拥有泛型的Hashtable
            //它也是基于键的哈希代码组织起来的键/值对
            //键值对类型从Hashtable的object变为了可以自己制定的泛型
            #endregion

            #region 2.申明
            //需要引用命名空间：System.Collections.Generic
            Dictionary<int,string> dictionary = new Dictionary<int,string>();
            #endregion

            #region 3.增删查改

            #region 增
            dictionary.Add(1, "123");
            dictionary.Add(2, "123");
            dictionary.Add(3, "123");
            #endregion

            #region 删
            //1.只能通过键去删除，删除不存在键，没反应
            dictionary.Remove(1);

            //2.清空
            dictionary.Clear();

            dictionary.Add(1,"123");
            dictionary.Add(2,"124");
            dictionary.Add(3,"125");
            #endregion

            #region 查
            //1.通过键查看值，找不到会报错
            Console.WriteLine(dictionary[2]);
            //Console.WriteLine(dictionary[4]);
            Console.WriteLine(dictionary[1]);

            //2.查看键是否存在
            //根据键检测
            if (dictionary.ContainsKey(1))
            {
                Console.WriteLine("存在键为1的键值对");
            }
            //根据值检测
            if (dictionary.ContainsValue("123"))
            {
                Console.WriteLine("存在值为123的键值对");
            }
            #endregion

            #region 改
            Console.WriteLine(dictionary[1]);
            dictionary[1] = "555";
            Console.WriteLine(dictionary[1]);
            #endregion

            #endregion

            #region 4.遍历
            Console.WriteLine("---------------------------");
            //长度
            Console.WriteLine(dictionary.Count);
            //1.遍历所有键
            foreach (var item in dictionary.Keys)
            {
                Console.WriteLine(item);
                Console.WriteLine(dictionary[item]);
            }
            //2.遍历所有值
            Console.WriteLine("---------------------------");
            foreach (string item in dictionary.Values)
            {
                Console.WriteLine(item);
            }
            //3.键值对一起遍历
            Console.WriteLine("---------------------------");
            foreach (KeyValuePair<int, string> item in dictionary)
            {
                Console.WriteLine($"键：{item.Key}，值：{item.Value}");
            }
            #endregion
        }
    }
}
