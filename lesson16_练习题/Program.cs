namespace lesson16_练习题
{
    #region 练习题1
    //写一个怪物类，创建10个怪物将其添加到List中
    //对List列表进行排序，根据用户输入数字进行排序
    //1、攻击排序
    //2、防御排序
    //3、血量排序
    //4、反转

    /// <summary>
    /// 怪物类
    /// </summary>
    class Monster
    {
        public string name;
        public int atk;
        public int def;
        public int hp;

        public Monster(string name, int atk, int def, int hp)
        {
            this.name = name;
            this.atk = atk;
            this.def = def;
            this.hp = hp;
        }

        public string Print()
        {
            return $"{name}，攻击：{atk}，防御：{def}，血量：{hp}";
        }
    }

    #endregion

    #region 练习题2
    //写一个物品类（类型，名字，品质），创建10个物品
    //添加到List中
    //同时使用类型、品质、名字进行比较
    //排序的权重是：类型>品质>名字长度

    class Item
    {
        public int type;
        public string name;
        public int quality;

        public Item(int type, string name, int quality)
        {
            this.type = type;
            this.name = name;
            this.quality = quality;
        }

        public override string ToString()
        {
            return $"类型：{type}，名字：{name}，品质：{quality}";
        }
    }
    #endregion

    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("List排序 练习题");

            #region 练习题1
            Console.WriteLine("----------------练习题1----------------");
            //添加10个怪物到List中
            List<Monster> monsters = new List<Monster>();
            Random r = new Random();
            for (int i = 1; i <= 10; i++)
            {
                monsters.Add(new Monster($"怪物{i}", r.Next(20), r.Next(20), r.Next(1, 20)));
            }
            Console.WriteLine("===怪物初始列表===");
            for (int i = 0; i < monsters.Count; i++)
            {
                Console.WriteLine(monsters[i].Print());
            }

            Console.WriteLine("请选择排序方式：");
            Console.WriteLine("1:攻击排序");
            Console.WriteLine("2:防御排序");
            Console.WriteLine("3:血量排序");
            Console.WriteLine("4:反转");
            int input = int.Parse(Console.ReadLine());
            try
            {
                switch (input)
                {
                    case 1:
                        monsters.Sort((a, b) =>
                        {
                            return a.atk > b.atk ? 1 : -1;
                        });
                        Console.WriteLine("===按攻击排序后===");
                        for (int i = 0; i < monsters.Count; i++)
                        {
                            Console.WriteLine(monsters[i].Print());
                        }
                        break;
                    case 2:
                        monsters.Sort((a,b) =>
                        {
                            return a.def > b.def ? 1 : -1;
                        });
                        Console.WriteLine("===按防御排序后===");
                        for (int i = 0; i < monsters.Count; i++)
                        {
                            Console.WriteLine(monsters[i].Print());
                        }
                        break;
                    case 3:
                        monsters.Sort((a, b) =>
                        {
                            return a.hp > b.hp ? 1 : -1;
                        });
                        Console.WriteLine("===按血量排序后===");
                        for (int i = 0; i < monsters.Count; i++)
                        {
                            Console.WriteLine(monsters[i].Print());
                        }
                        break;
                    case 4:
                        //反转API
                        monsters.Reverse();
                        Console.WriteLine("===反转后===");
                        for (int i = 0; i < monsters.Count; i++)
                        {
                            Console.WriteLine(monsters[i].Print());
                        }
                        break;
                }
            }
            catch 
            {
                Console.WriteLine("输入无效，请输入数字");
            }
            #endregion

            #region 练习题2
            Console.WriteLine("----------------练习题2----------------");
            List<Item> items = new List<Item>();
            Random random = new Random();
            for (int i = 0; i < 10; i++)
            {
                items.Add(new Item(random.Next(1, 6), $"Item{random.Next(1, 201)}", random.Next(1, 6)));
                Console.WriteLine(items[i]);
            }
            Console.WriteLine("===排序后===");
            items.Sort((a, b) =>
            {
                //类型不同，按类型比
                if (a.type != b.type)
                {
                    return a.type > b.type ? -1 : 1;
                }
                //按品质比
                else if (a.quality != b.quality)
                {
                    return a.quality > b.quality ? -1 : 1;
                }
                //否则名字长度比
                else
                {
                    return a.name.Length > b.name.Length ? -1 : 1;
                }
            });
            for (int i = 0; i < 10; i++)
            {
                items.Add(new Item(random.Next(1, 6), $"Item{random.Next(1, 201)}", random.Next(1, 6)));
                Console.WriteLine(items[i]);
            }
            #endregion

            #region 练习题3
            //请尝试利用List排序方式对Dictionary中的内容排序
            //提示：得到Dictionary的所有键值对信息存入List中
            Console.WriteLine("----------------练习题3----------------");
            Dictionary<int, string> dict = new Dictionary<int, string>();
            dict.Add(3, "王五");
            dict.Add(2, "李四");
            dict.Add(1, "张三");
            dict.Add(5, "钱七");
            dict.Add(4, "赵六");
            //得到Dictionary的所有键值对信息存入List中
            List<KeyValuePair<int, string>> keyValuePairs = new List<KeyValuePair<int, string>>();
            foreach (KeyValuePair<int, string> item in dict)
            {
                keyValuePairs.Add(item);
            }
            //对List进行排序
            keyValuePairs.Sort((a,b) =>
            {
                return a.Key > b.Key ? 1 : -1;
            });
            for (int i = 0; i < keyValuePairs.Count; i++)
            {
                Console.WriteLine($"{keyValuePairs[i].Key}:{keyValuePairs[i].Value}");
            }
            #endregion
        }
    }
}
