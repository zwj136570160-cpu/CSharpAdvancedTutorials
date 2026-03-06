namespace lesson09_顺序存储和链式存储
{
    #region 5.自己实现一个最简单的单项链表

    /// <summary>
    /// 单量链表节点
    /// </summary>
    /// <typeparam name="T"></typeparam>
    class LinkedNode<T>
    {


        public T value;
        //存储下一个元素是谁，相当于钩子
        public LinkedNode<T> nextNode;

        public LinkedNode(T value)
        {
            this.value = value; 
        }
    }

    /// <summary>
    /// 单项链表类，管理节点、管理、添加等等
    /// </summary>
    /// <typeparam name="T"></typeparam>
    class LindedList<T>
    {
        public LinkedNode<T> head;
        public LinkedNode<T> last;

        public void Add(T value)
        {
            //添加节点，必然是new一个新的节点
            LinkedNode<T> node = new LinkedNode<T>(value);
            if (head == null)
            {
                head = node;
                last = node;
            }
            else
            {
                last.nextNode = node;
                last = node;
            }
        }

        public void Remove(T value)
        {
            if (head == null)
            {
                return;
            }
            if (head.value.Equals(value))
            {
                head = head.nextNode;
                //如果头节点被移除了，发现头节点变空，证明只有一个节点，那尾也要清空
                if (head == null)
                {
                    last = null;
                }
                return;
            }
            LinkedNode<T> node = head;
            while (node.nextNode != null)
            {
                if (node.nextNode.value.Equals(value))
                {
                    node.nextNode = node.nextNode.nextNode;
                    break;
                }
            }
        }
    }
    #endregion

    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("顺序存储和链式存储");

            #region 1.数据结构
            //数据结构是计算机存储、组织数据的方式（规则）
            //数据结构是指相互之间存在一种或多种特定关系的数据元素的集合
            //比如自定义的一个类也可以称为数据结构，自己定义的数据组合规则

            //不要把数据结构想的太复杂
            //简单点理解，就是人定义的存储数据和表示数据之间关系的规则而已

            //常用的数据结构
            //数组、栈、队列、链表、树、图、堆、散列表
            #endregion

            #region 2.线性表
            //线性表是一种数据结构，是有n个具有相同特性的数据元素的有限序列
            //比如数组、ArrayList、Stack、Queue、链表等等
            #endregion

            //顺序存储和链式存储，是数据结构中

            #region 3.顺序存储
            //数据、Stack、Queue、List、ArrayList —— 顺序存储
            //只是数据、Stack、Queue的组织规则不同而已
            //顺序存储：
            //用一组地址连续的存储单元依次存储线性表的各个数据元素
            #endregion

            #region 4.链式存储
            //单项链表、双向链表、循环链表 —— 链式存储
            //链式存储（链接存储）：
            //用一组任意的存储单元存储线性表种的各个数据元素
            #endregion

            //5.自己实现一个最简单的单项链表
            LinkedNode<int> node = new LinkedNode<int>(1);
            LinkedNode<int> node2 = new LinkedNode<int>(2);
            node.nextNode = node2;
            node2.nextNode = new LinkedNode<int>(3);
            node2.nextNode.nextNode = new LinkedNode<int>(4);

            LindedList<int> link = new LindedList<int>();
            link.Add(1);
            link.Add(2);
            link.Add(3);
            link.Add(4);
            LinkedNode<int> node3 = link.head;
            while (node3 != null)
            {
                Console.WriteLine(node3.value);
                node3 = node3.nextNode;
            }
            link.Remove(2);
            node3 = link.head;
            while (node3 != null)
            {
                Console.WriteLine(node3.value);
                node3 = node3.nextNode;
            }
            link.Remove(1);
            node3 = link.head;
            while (node3 != null)
            {
                Console.WriteLine(node3.value);
                node3 = node3.nextNode;
            }

            #region 6.顺序存储和链式存储的优缺点
            //从增删查改的角度去思考
            //增：链式存储 计算上 优于顺序存储 （中间插入时链式不用像顺序一样去移动位置）
            //删：链式存储 计算上 优于顺序存储 （中间删除时链式不用像顺序一样去移动位置）
            //查：顺序存储 使用上 优于链式存储 （数组可以直接通过下标得到元素，链式需要遍历）
            //改：顺序存储 使用上 优于链式存储 （数组可以直接通过下标得到元素，链式需要遍历）
            #endregion
        }
    }
}
