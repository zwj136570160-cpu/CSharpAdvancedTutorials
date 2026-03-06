namespace lesson08_练习题
{
    internal class Program
    {
        //练习题1
        static string DetectInput(int inputKey)
        {
            string str = "";

            Dictionary<int, string> num = new Dictionary<int, string>();
            num.Add(0, "零");
            num.Add(1, "壹");
            num.Add(2, "贰");
            num.Add(3, "叁");
            num.Add(4, "肆");
            num.Add(5, "伍");
            num.Add(6, "陆");
            num.Add(7, "柒");
            num.Add(8, "捌");
            num.Add(9, "玖");

            //得百位
            int b = inputKey / 100;
            if (b != 0)
            {
                str += num[b];
            }
            //得十位数
            int s = inputKey % 100 / 10;
            if (s != 0 || str != "")
            {
                str += num[s];
            }
            //得个位数
            int g = inputKey % 10;
            str += num[g];
            return str;
        }

        static void Main(string[] args)
        {
            Console.WriteLine("Dictionary 练习题");

            #region 练习题1
            //0：壹，1：贰，2：叁，3：肆，4：伍，5：陆，6：柒，7：捌，8：玖，9：拾
            //使用字典存储0~9的数字对应的大写文字
            //提示用户输入一个不超过三位的数，提供一个方法，返回数的大写
            //例如：306，返回叁零陆

            try
            {
                Console.WriteLine("请输入一个不超过三位的数");
                Console.WriteLine(DetectInput(int.Parse(Console.ReadLine())));
            }
            catch
            {
                Console.WriteLine("请输入数字");
            }

            #endregion

            #region 练习题2
            //计算每个字母出现的次数“Welcome to Unity World！”，使用字典存储，最后遍历整个字典，不区分大小写

            string str = "Welcome to Unity World！";
            str = str.ToLower();
            Dictionary<char, int> keys = new Dictionary<char, int>();
            for (int i = 0; i < str.Length; i++)
            {
                if (keys.ContainsKey(str[i]))
                {
                    keys[str[i]] += 1;
                }
                else
                {
                    keys.Add(str[i], 1);
                }
            }

            foreach (char item in keys.Keys)
            {
                Console.WriteLine($"字母{item}出现了{keys[item]}次");
                Console.WriteLine(":");
            }
            #endregion
        }
    }
}
