using System.Diagnostics;

namespace lesson12_练习题
{
    #region 练习题1
    //一家三口，妈妈做饭，爸爸妈妈和孩子都要吃饭
    //用委托模拟做饭——>开饭——>吃饭的过程

    public delegate void MealAction();
    class EatingProcess
    {
        /// <summary>
        /// 做饭
        /// </summary>
        public void Cook()
        {
            Console.WriteLine("妈妈正在做饭");
        }

        /// <summary>
        /// 开饭
        /// </summary>
        public MealAction MealReady;

        /// <summary>
        /// 爸爸吃饭
        /// </summary>
        public void DadEating()
        {
            Console.WriteLine("爸爸开始吃饭啦！");
        }

        /// <summary>
        /// 妈妈吃饭
        /// </summary>
        public void MomEating()
        {
            Console.WriteLine("妈妈开始吃饭啦！");
        }

        /// <summary>
        /// 孩子吃饭
        /// </summary>
        public void ChildEating()
        {
            Console.WriteLine("孩子开始吃饭啦！");
        }

        public void StartEatingProcess()
        {
            //妈妈做饭
            Cook();
            //饭做好了，通知所有人吃饭
            Console.WriteLine("饭做好了！开饭了！");
            if (MealReady != null)
            {
                MealReady();
            }
        }
    }
    #endregion

    #region 练习题2
    //怪物死亡后，玩家要加10块钱，界面要更新数据，成就要累加怪物击杀数，请用委托来模拟实现这些功能，只用写核心逻辑表现这个过程，不用写的太复杂

    class Monster
    {
        //当怪物死亡时，把自己作为参数传出去
        public Action<Monster> deadDoSomthing;
        //怪物成员变量 特征 价值多少钱
        public int money = 10;

        public void Dead()
        {
            if (deadDoSomthing != null)
            {
                deadDoSomthing(this);
            }
            //一般情况下，委托关联的函数 有加就有减（或者直接清空）
            deadDoSomthing = null;
        }
    }

    class Player
    {
        private int myMoney = 0;

        public void MonsterDeadDoSomthing(Monster monster)
        {
            myMoney += monster.money;
            Console.WriteLine($"现在有{myMoney}元钱");
        }
    }

    class Panel
    {
        private int nowShowMoney = 0;

        public void MonsterDeadDo(Monster monster)
        {
            nowShowMoney += monster.money;
            Console.WriteLine($"当前面板显示{nowShowMoney}元");
        }
    }

    class Cj
    {
        private int nowKillMonsterNum = 0;

        public void MonsterDeadDo(Monster monster)
        {
            nowKillMonsterNum += 1;
            Console.WriteLine($"当前击杀了{nowKillMonsterNum}怪物");
        }
    }
    #endregion

    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("委托 练习题");

            #region 练习题1
            EatingProcess family = new EatingProcess();
            family.MealReady += family.DadEating;
            family.MealReady += family.MomEating;
            family.MealReady += family.ChildEating;
            family.StartEatingProcess();
            #endregion

            #region 练习题2
            Monster monster = new Monster();
            Player player = new Player();
            Panel panel = new Panel();
            Cj cj = new Cj();

            monster.deadDoSomthing += player.MonsterDeadDoSomthing;
            monster.deadDoSomthing += panel.MonsterDeadDo;
            monster.deadDoSomthing += cj.MonsterDeadDo;
            monster.Dead();
            #endregion



        }
    }
}
