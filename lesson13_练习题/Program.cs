namespace lesson13_练习题
{
    //有一个热水器，包含一个加热器，一个报警器，一个显示器
    //我们给热水器通上电，当水温超过95度时
    //1.报警器会开始发出语音，告诉你水的温度
    //2.显示器也会改变水温提示，提示水已经烧开了

    /// <summary>
    /// 热水器
    /// </summary>
    class WaterHeater
    {
        
    }

    /// <summary>
    /// 加热器
    /// </summary>
    class Heater
    {
        public int temp;
        public event Action<int> WaterTemperature;

        public void HeatUp()
        {
            int updateIndex = 0;

            while (true)
            {
                if (updateIndex % 9999999 == 0)
                {
                    //隔一段事件，会加一点任务
                    ++temp;
                    Console.WriteLine($"加热到{temp}度");
                    if (temp >= 100)
                    {
                        break;
                    }
                    //温度超过95度，就触发报警器和显示器显示信息
                    if (temp >= 95)
                    {
                        if (WaterTemperature != null)
                        {
                            WaterTemperature(temp);
                        }
                    }
                    updateIndex = 0;
                }
                ++updateIndex;
            }
        }
    }

    /// <summary>
    /// 报警器
    /// </summary>
    class Alarm
    {
        public void ShowInfo(int temp)
        {
            Console.WriteLine($"当前水温：{temp}度");
        }
    }

    /// <summary>
    /// 显示器
    /// </summary>
    class Display
    {
        public void ShowInfo(int temp)
        {
            Console.WriteLine($"当前水温：{temp}度");
        }
    }

    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("事件 练习题");

            Heater heater = new Heater();
            Alarm alarm = new Alarm();
            Display display = new Display();
            heater.WaterTemperature += alarm.ShowInfo;
            heater.WaterTemperature += display.ShowInfo;
            heater.HeatUp();
        }
    }
}
