namespace lesson18_练习题
{
    //控制台中有一个■
    //它会如贪食蛇一样自动移动
    //请开启一个多线程来检测输入，控制它的转向

    enum E_MoveDir
    {
        Up,
        Down,
        Right,
        Left,
    }

    struct SetPosition
    {
        public int x;
        public int y;
    }

    class Icon
    {
        public E_MoveDir dir;
        public SetPosition setPosition;

        public Icon(E_MoveDir dir, SetPosition setPosition)
        {
            setPosition.x = 0;
            setPosition.y = 1;
            this.dir = dir;
        }

        public void Move()
        {
            switch (dir)
            {
                case E_MoveDir.Up:
                    setPosition.y--;
                    break;
                case E_MoveDir.Down:
                    setPosition.y++;
                    break;
                case E_MoveDir.Right:
                    setPosition.x += 2;
                    break;
                case E_MoveDir.Left:
                    setPosition.x -= 2;
                    break;
            }
        }

        public void Draw()
        {
            Console.SetCursorPosition(setPosition.x, setPosition.y);
            Console.Write("■");
        }

        public void Clear()
        {
            Console.SetCursorPosition(setPosition.x, setPosition.y);
            Console.Write("  ");
        }

        public void ChangeDir(E_MoveDir newDir)
        {
            this.dir = newDir;
        }
    }

    internal class Program
    {
        static void NewThreadLogic()
        {
            while (true)
            {
                switch(Console.ReadKey(true).Key)
                {
                    case ConsoleKey.W:
                        icon.ChangeDir(E_MoveDir.Up);
                        break;
                    case ConsoleKey.A:
                        icon.ChangeDir(E_MoveDir.Left);
                        break;
                    case ConsoleKey.S:
                        icon.ChangeDir(E_MoveDir.Down);
                        break;
                    case ConsoleKey.D:
                        icon.ChangeDir(E_MoveDir.Right);
                        break;
                }
            }
        }

        static Icon icon;

        static void Main(string[] args)
        {
            Console.WriteLine("多线程 练习题");

            Console.CursorVisible = false;

            SetPosition setPosition = new SetPosition();
            setPosition.x = 0;
            setPosition.y = 1;
            icon = new Icon(E_MoveDir.Right);
            //开启多线程
            Thread t = new Thread(NewThreadLogic);
            t.Start();
            icon.Draw();
            while (true)
            {
                Thread.Sleep(50);
                icon.Clear();
                icon.Move();
                icon.Draw();
            }
        }
    }
}
