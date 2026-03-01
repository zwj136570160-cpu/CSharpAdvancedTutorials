using System.Collections;

namespace lesson04_练习题
{
    /// <summary>
    /// 怪物管理器，因为一般管理器都是唯一的，所以做成一个单例模式的对象
    /// </summary>
    class MonsterMgr
    {
        private int monsterId = 0;

        private static MonsterMgr instance = new MonsterMgr();

        private Hashtable monsterTable = new Hashtable();

        private MonsterMgr()
        {

        }

        public static MonsterMgr Instance
        {
            get
            {
                return instance; 
            }
        }

        public void AddMonster()
        {
            Monster monster = new Monster(monsterId);
            Console.WriteLine($"创建了ID为：{monsterId}的怪物");
            ++monsterId;

            monsterTable.Add(monster.id, monster);
        }

        public void RemoveMonster(int monsterId)
        {
            if (monsterTable.ContainsKey(monsterId))
            {
                (monsterTable[monsterId] as Monster).Dead();
                monsterTable.Remove(monsterId);
            }
        }
    }

    class Monster
    {
        public int id;

        public Monster(int id)
        {
            this.id = id;
        }

        public void Dead()
        {
            Console.WriteLine($"怪物{id}死亡");
        }
    }
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hashtable 练习题");

            #region 练习题1
            //请描述Hashtable的存储规则

            //1.一个键对应一个值
            //2.类型是object
            //3.一个键值对形式存储的容器
            #endregion

            #region 练习题2
            //制作一个怪物管理器，提供创建怪物，移除怪物的方法。每个怪物都有自己的唯一ID

            MonsterMgr.Instance.AddMonster();
            MonsterMgr.Instance.AddMonster();
            MonsterMgr.Instance.AddMonster();
            MonsterMgr.Instance.AddMonster();
            MonsterMgr.Instance.AddMonster();

            MonsterMgr.Instance.RemoveMonster(0);
            MonsterMgr.Instance.RemoveMonster(2);
            MonsterMgr.Instance.RemoveMonster(4);
            #endregion
        }
    }
}
