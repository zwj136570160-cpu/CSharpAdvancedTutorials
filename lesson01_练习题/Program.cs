using Microsoft.VisualBasic;
using System.Collections;

namespace lesson01_练习题
{
    #region 练习题2
    //创建一个背包管理类，使用ArrayList存储物品，实现购买物品，卖出物品，显示物品的功能。购买与卖出物品会导致金钱变化

    #region 方法1
    //class BagManagement
    //{
    //    public int money;
    //    private int itemPrice;
    //    public ArrayList bag;
    //    private int index;

    //    public BagManagement(int money, int itemPrice)
    //    {
    //        this.money = money;
    //        this.itemPrice = itemPrice;
    //        bag = new ArrayList();
    //        index = 0;
    //    }

    //    //存储物品
    //    public void Add(string item)
    //    {
    //        bag.Add(item);
    //        ++index;
    //    }

    //    //购买物品
    //    public void Buy()
    //    {
    //        Console.WriteLine($"你购买了一件物品，剩余资金：{money - itemPrice}");
    //    }

    //    //卖出物品
    //    public void Sell()
    //    {
    //        Console.WriteLine($"你出售了一件物品，目前资金余额为：{money + itemPrice}元");
    //    }

    //    //显示物品
    //    public void DisplayItems()
    //    {
    //        for (int i = 0; i < bag.Count; i++)
    //        {
    //            Console.WriteLine(bag[i]);
    //        }
    //    }
    //}
    #endregion

    #region 方法2
    class BagMgr
    {
        
        //背包中的物品
        private ArrayList items;
        //背包中的钱
        private int money;

        public BagMgr(int money)
        {
            this.money = money;
            items = new ArrayList();
        }

        //购买物品
        public void BuyItem(Item item)
        {
            if (item.num <= 0 || item.money < 0)
            {
                Console.WriteLine("请传入正确的物品信息");
                return;
            }

            if (this.money < item.money)
            {
                Console.WriteLine("买不起，钱不够");
                return;
            }
            this.money -= item.money * item.num;
            Console.WriteLine($"购买{item.name}{item.num}个花费{item.num * item.money}");
            Console.WriteLine($"剩余资金{this.money}");

            //如果想要叠加物品，可以在前面先判断是否有这个物品，然后加数量
            for (int i = 0; i < items.Count; i++)
            {
                if ((items[i] as Item).id == item.id)
                {
                    //叠加数量
                    (items[i] as Item).num += item.num;
                    return;
                }
            }
            items.Add(item);
        }

        public void SellItem(Item item)
        {
            for (int i = 0; i < items.Count; i++)
            {
                if ((items[i] as Item).id == item.id)
                {
                    //两种情况
                    int num = 0;
                    
                    if ((items[i] as Item).num == item.num)
                    {
                        //1.比我身上的少
                        num = item.num;
                    }
                    else
                    {
                        //2.大于等于我身上的东西数量
                        num = (items[i] as Item).num;

                        //卖完了，就从身上移除了
                        items.RemoveAt(i);
                    }
                    int sellMoney = (int)(num * (items[i] as Item).money * 0.8f);
                    this.money += sellMoney;
                    Console.WriteLine($"卖了{(items[i] as Item).name}{item.num}个，赚了{sellMoney}元");
                    Console.WriteLine($"目前拥有金额{this.money}元");

                    return;
                }
            }
        }

        public void SellItem(int id, int num = 1)
        {
            Item item = new Item(id ,num);
            SellItem(item);
            
        }

        public void ShowItem()
        {
            for (int i = 0; i < items.Count; i++)
            {
                Console.WriteLine($"有{(items[i] as Item).name}:{(items[i] as Item).num}个");
            }
            Console.WriteLine($"当前拥有{this.money}元");
        }
    }

    class Item
    {
        //物品的价格
        public int money;
        //物品的名称
        public string name;
        //物品的数量
        public int num;
        //物品唯一Id
        public int id;

        public Item(int id, int num)
        {
            this.id = id;
            this.num = num ;
        }

        public Item(int money, string name, int num, int id)
        {
            this.money = money;
            this.name = name;
            this.num = num;
            this.id = id;
        }
    }
    #endregion

    #endregion
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("ArrayList 练习题");

            #region 练习题1
            //请简述ArrayList和数组的区别

            //ArrayList是一个object类型的数组
            //1.ArrayList可以不用一开始就定长，单独使用数组是定长的
            //2.数组可以指定存储类型，ArrayList帮我们封装了方便的API来使用
            //3.数组的增删需要我们自己去实现，ArrayList帮我们封装了方便的API来使用
            //4.ArrayList使用时，可以存在装箱拆箱，数组使用时只要不是Object数组那就不存在这个问题
            //5.数组长度为Length，ArrayList长度为Count
            #endregion

            BagMgr bag = new BagMgr(99999);
            Item item1 = new Item(10, "红药", 5, 1);
            Item item2 = new Item(20, "蓝药", 5, 2);
            Item item3 = new Item(999, "屠龙刀", 1, 3);

            bag.BuyItem(item3);
            bag.BuyItem(item2);
            bag.BuyItem(item1);

            bag.SellItem(item3);
            bag.SellItem(2);
        }
    }
}
