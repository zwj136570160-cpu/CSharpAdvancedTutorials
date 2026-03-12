namespace lesson16_List排序
{
    class Item : IComparable<Item>
    {
        public int money;

        public Item(int money)
        {
            this.money = money; 
        }

        public int CompareTo(Item? other)
        {
            //返回值的含义
            //小于0：
            //放在传入对象前面
            //等于0：
            //位置不变
            //大于0：
            //放在传入对象后面

            //可以简单理解，传入对象的位置就是0
            //如果你的返回值为负数，那就放在它的左边
            //如果你的返回值为正数，那就放在它的右边

            if (this.money > other.money)
            {
                return 1;
            }
            else
            {
                return -1;
            }

            return 0;
        }
    }

    class ShopItem
    {
        public int id;

        public ShopItem(int id)
        {
            this.id = id;
        }
    }

    internal class Program
    {
        static int SortShopItem(ShopItem a, ShopItem b)
        {
            //传入的两个对象为列表中的两个对象
            //进行两两比较，用左边的和右边的条件比较
            //返回值规则和之前一样，0做标准，负数在左（前），正数在右（后）
            if (a.id > b.id)
            {
                return 1;
            }
            else
            {
                return -1;
            }
        }

        static void Main(string[] args)
        {
            Console.WriteLine("list排序");

            #region 1.List自带排序方法
            List<int> list = new List<int>();
            list.Add(3);
            list.Add(2);
            list.Add(6);
            list.Add(1);
            list.Add(4);
            list.Add(5);
            for (int i = 0; i < list.Count; i++)
            {
                Console.WriteLine(list[i]);
            }
            Console.WriteLine("---------------------");
            //list提供了排序方法(Sort)
            list.Sort();
            for (int i = 0; i < list.Count; i++)
            {
                Console.WriteLine(list[i]);
            }
            Console.WriteLine("---------------------");
            //ArrayList也提供了排序方法(Sort)
            #endregion

            #region 2.自定义类的排序
            List<Item> list2 = new List<Item>();
            list2.Add(new Item(6));
            list2.Add(new Item(1));
            list2.Add(new Item(3));
            list2.Add(new Item(5));
            list2.Add(new Item(2));
            list2.Add(new Item(4));
            list2.Sort();
            for (int i = 0; i < list2.Count; i++)
            {
                Console.WriteLine(list2[i].money);
            }
            Console.WriteLine("---------------------");
            #endregion

            #region 3.通过委托函数进行排序
            List<ShopItem> shopItems = new List<ShopItem>();
            shopItems.Add(new ShopItem(1));
            shopItems.Add(new ShopItem(5));
            shopItems.Add(new ShopItem(6));
            shopItems.Add(new ShopItem(2));
            shopItems.Add(new ShopItem(4));
            shopItems.Add(new ShopItem(3));

            //方式1:委托函数
            //shopItems.Sort(SortShopItem);

            //方式2:匿名函数
            //shopItems.Sort(delegate(ShopItem a, ShopItem b)
            //{
            //       if (a.id > b.id)
            //    {
            //        return 1;
            //    }
            //    else
            //    {
            //        return -1;
            //    }
            //});

            //方式3:lambda表达式配合三目运算符的完美呈现
            shopItems.Sort((a, b) =>
            {
                return a.id > b.id ? -1 : 1;
            });
            for (int i = 0; i < shopItems.Count; i++)
            {
                Console.WriteLine(shopItems[i].id);
            }
            #endregion
        }

        //总结:
        //1.如果是系统自带的类型，直接调用Sort方法即可
        //如果是自定义的类，想要排序有两种方式
        //1.继承接口:IComparable
        //2.在Sort中传入委托函数
    }
}
