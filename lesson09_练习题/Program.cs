namespace lesson09_练习题
{
    #region 练习题3
    //请尝试自己实现一个双向链表
    //并提供以下方法和属性
    //数据的个数，头节点，尾节点
    //增加数据到链表最后
    //删除指定位置节点

    /// <summary>
    /// 双向链表节点
    /// </summary>
    /// <typeparam name="T"></typeparam>
    class DoublyLinkedListNode<T>
    {
        /// <summary>
        /// 数据
        /// </summary>
        public T data;
        /// <summary>
        /// 上一个节点
        /// </summary>
        public DoublyLinkedListNode<T> previous;
        /// <summary>
        /// 下一个节点
        /// </summary>
        public DoublyLinkedListNode<T> next;

        public DoublyLinkedListNode(T data)
        {
            this.data = data;
        }
    }

    /// <summary>
    /// 双向链表类
    /// </summary>
    /// <typeparam name="T"></typeparam>
    class DoublyLinkedList<T>
    {
        /// <summary>
        /// 头节点
        /// </summary>
        private DoublyLinkedListNode<T> head;
        /// <summary>
        /// 尾节点
        /// </summary>
        private DoublyLinkedListNode<T> last;
        /// <summary>
        /// 数据个数
        /// </summary>
        private int count = 0;

        public int Count
        {
            get
            {
                return count; 
            }
        }
        public DoublyLinkedListNode<T> Head
        {
            get
            {
                return head;
            }
        }
        public DoublyLinkedListNode<T> Last
        {
            get
            {
                return last;
            }
        }

        /// <summary>
        /// 增加节点
        /// </summary>
        /// <param name="data"></param>
        public void Add(T data)
        {
            DoublyLinkedListNode<T> newNode = new DoublyLinkedListNode<T>(data);

            if (head == null)
            {
                head = newNode;
                last = newNode;
            }
            else
            {
                //添加到尾节点
                last.next = newNode;
                //尾节点添加的节点，记录自己的上一个节点
                newNode.previous = last;
                last = newNode;
            }
            //加了一个节点
            ++count;
        }

        /// <summary>
        /// 删除节点
        /// </summary>
        /// <param name="data"></param>
        public void Remove(int index)
        {
            //首先判断是否越界
            if (index >= count || index < 0)
            {
                Console.WriteLine($"只有{count}个节点，请输入合法位置");
                return;
            }
            int tempCount = 0;
            DoublyLinkedListNode<T> tempNode = head;
            while (true)
            {
                //找到对应位置的节点，然后移除即可
                if (tempCount == index)
                {
                    //当前要移除的节点的上一个节点，指向自己的下一个节点
                    if (tempNode.previous != null)
                    {
                        tempNode.previous.next = tempNode.next;
                    }
                    if (tempNode.next != null)
                    {
                        tempNode.next.previous = tempNode.previous;
                    }
                    //如果是头节点，那需要改变头节点的指向
                    if (index == 0)
                    {
                        //如果头节点被移除，那头节点就变成了头节点的下一个节点
                        head = tempNode.next;
                    }
                    else if (index == count - 1)
                    {
                        //如果尾节点被移除了，那尾节点就变成了尾节点的上一个节点
                        last = last.previous;
                    }
                    --count;
                    break;
                }
                //每次循环完过后，要让当前临时节点等于下一个节点
                tempNode = tempNode.next;
                ++tempCount;
            }
        }
    }
    #endregion

    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("顺序存储和链式存储 练习题");
            Console.SetWindowSize(100, 50);
            Console.SetBufferSize(100, 50);

            #region 练习题1
            //请说出常用的数据结构有哪些

            //数组、栈、队列、链表、树、图、堆、散列表
            #endregion

            #region 练习题2
            //请描述顺序存储和链式存储的区别

            //顺序存储：用一组地址连续的存储单元依次存储线性表的各个数据元素
            //链式存储：用一组任意的存储单元存储线性表中的各个数据元素
            #endregion

            //练习题3
            DoublyLinkedList<int> link = new DoublyLinkedList<int>();
            link.Add(1);
            link.Add(2);
            link.Add(3);
            link.Add(4);
            //正向遍历
            DoublyLinkedListNode<int> node = link.Head;
            while (node != null)
            {
                Console.WriteLine(node.data);
                node = node.next;
            }
            //反向遍历
            node = link.Last;
            while (node != null)
            {
                Console.WriteLine(node.data);
                node = node.previous;
            }
            Console.WriteLine("----------------------");
            link.Remove(0);
            node = link.Head;
            while (node != null)
            {
                Console.WriteLine(node.data);
                node = node.next;
            }
            node = link.Last;
            while (node != null)
            {
                Console.WriteLine(node.data);
                node = node.previous;
            }
            Console.WriteLine("----------------------");
            link.Remove(1);
            //正向遍历
            node = link.Head;
            while (node != null)
            {
                Console.WriteLine(node.data);
                node = node.next;
            }
            //反向遍历
            node = link.Last;
            while (node != null)
            {
                Console.WriteLine(node.data);
                node = node.previous;
            }
            Console.WriteLine("----------------------");
            link.Remove(1);
            //正向遍历
            node = link.Head;
            while (node != null)
            {
                Console.WriteLine(node.data);
                node = node.next;
            }
            //反向遍历
            node = link.Last;
            while (node != null)
            {
                Console.WriteLine(node.data);
                node = node.previous;
            }
            Console.WriteLine("----------------------");
            link.Remove(1);
        }
    }
}
