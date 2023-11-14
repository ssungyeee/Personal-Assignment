namespace Fix_Script
{
    internal class Program
    {
        private static Character player;
        // private static ItemInfo item1;
        // private static ItemInfo item2;
        private static ItemInfo[] items;


        static void Main(string[] args)
        {
            GameDataSetting();
            DisplayGameIntro();
        }

        static void GameDataSetting()
        {
            // 캐릭터 정보 세팅
            player = new Character("Chad", "전사", 1, 10, 5, 100, 1500);

            // 아이템 정보 세팅
            // item1 = new ItemInfo("무쇠 갑옷", "무쇠로 만들어진 튼튼한 갑옷입니다.", 0, 10, 0);
            // item2 = new ItemInfo("낡은 검", "쉽게 볼 수 있는 낡은 검입니다.", 2, 0, 0);

            items = new ItemInfo[10];
            AddItem(new ItemInfo("무쇠 갑옷", "무쇠로 만든 갑옷", 0, 0, 5, 0));
            AddItem(new ItemInfo("낡은 검", "대장간 구석에 있던 검", 1, 2, 0, 0));
            AddItem(new ItemInfo("생명의 돌", "왠지 들고 있으면 튼튼해지는 기분이 드는 돌", 2, 0, 0, 8));
        }

        static void AddItem(ItemInfo Item)
        {
            if (ItemInfo.ItemCnt == 10)
            {
                return;                
            }
            items[ItemInfo.ItemCnt] = Item;
            ItemInfo.ItemCnt++;
        }

        static void DisplayGameIntro()
        {
            Console.Clear();

            Console.WriteLine("스파르타 마을에 오신 여러분 환영합니다.");
            Console.WriteLine("이곳에서 던전으로 들어가기 전 활동을 할 수 있습니다.");
            Console.WriteLine();
            Console.WriteLine("1. 상태보기");
            Console.WriteLine("2. 인벤토리");
            Console.WriteLine();
            Console.WriteLine("원하시는 행동을 입력해주세요.");

            int input = CheckValidInput(1, 2);
            switch (input)
            {
                case 1:
                    DisplayMyInfo();
                    break;

                case 2:
                    DisplayInventory();
                    break;
            }
        }
        static void DisplayMyInfo()
        {
            Console.Clear();

            Console.WriteLine("상태보기");
            Console.WriteLine("캐릭터의 정보를 표시합니다.");
            Console.WriteLine();
            Console.WriteLine("Lv. " + player.Level.ToString("00"));
            Console.WriteLine($"{player.Name}({player.Job})");

            int bonusAtk = getSumBonusAtk();
            Console.Write("공격력 : " + (player.Atk + bonusAtk).ToString());
            Console.WriteLine(bonusAtk > 0 ? string.Format(" (+{0})", bonusAtk) : "");

            int bonusDef = getSumBonusDef();
            Console.Write("방어력 : " + (player.Def + bonusDef).ToString());
            Console.WriteLine(bonusDef > 0 ? string.Format(" (+{0})", bonusDef) : "");

            int bonusHp = getSumBonusHp();
            Console.Write("Hp : " + (player.Hp + bonusHp).ToString());
            Console.WriteLine(bonusHp > 0 ? string.Format(" (+{0})", bonusHp) : "");

            Console.WriteLine($"Gold : {player.Gold} G");
            Console.WriteLine();
            Console.WriteLine("0. 나가기");

            //if (item1.ItemName == "[E] 무쇠 갑옷" && item2.ItemName != "[E] 낡은 검")
            //{
            //    Console.Clear();

            //    Console.WriteLine("상태보기");
            //    Console.WriteLine("캐릭터의 정보를 표시합니다.");
            //    Console.WriteLine();
            //    Console.WriteLine($"Lv.{player.Level}");
            //    Console.WriteLine($"{player.Name}({player.Job})");
            //    Console.WriteLine($"공격력 : {player.Atk}");
            //    Console.WriteLine($"방어력 : {player.Def} +({item1.ItemDef + item2.ItemDef})");
            //    Console.WriteLine($"체력 : {player.Hp}");
            //    Console.WriteLine($"Gold : {player.Gold} G");
            //    Console.WriteLine();
            //    Console.WriteLine("0. 나가기");
            //}
            //else if (item2.ItemName == "[E] 낡은 검" && item1.ItemName != "[E] 무쇠 갑옷")
            //{
            //    Console.Clear();

            //    Console.WriteLine("상태보기");
            //    Console.WriteLine("캐릭터의 정보를 표시합니다.");
            //    Console.WriteLine();
            //    Console.WriteLine($"Lv.{player.Level}");
            //    Console.WriteLine($"{player.Name}({player.Job})");
            //    Console.WriteLine($"공격력 : {player.Atk} +({item1.ItemAtk + item2.ItemAtk})");
            //    Console.WriteLine($"방어력 : {player.Def}");
            //    Console.WriteLine($"체력 : {player.Hp}");
            //    Console.WriteLine($"Gold : {player.Gold} G");
            //    Console.WriteLine();
            //    Console.WriteLine("0. 나가기");
            //}
            //else if (item1.ItemName == "[E] 무쇠 갑옷" && item2.ItemName == "[E] 낡은 검")
            //{
            //    Console.Clear();

            //    Console.WriteLine("상태보기");
            //    Console.WriteLine("캐릭터의 정보를 표시합니다.");
            //    Console.WriteLine();
            //    Console.WriteLine($"Lv.{player.Level}");
            //    Console.WriteLine($"{player.Name}({player.Job})");
            //    Console.WriteLine($"공격력 : {player.Atk} +({item1.ItemAtk + item2.ItemAtk})");
            //    Console.WriteLine($"방어력 : {player.Def} +({item1.ItemDef + item2.ItemDef})");
            //    Console.WriteLine($"체력 : {player.Hp}");
            //    Console.WriteLine($"Gold : {player.Gold} G");
            //    Console.WriteLine();
            //    Console.WriteLine("0. 나가기");
            //}
            int input = CheckValidInput(0, 0);

            switch (input)
            {
                case 0:
                    DisplayGameIntro();
                    break;
            }
        }
        private static int getSumBonusAtk()
        {
            int sum = 0;
            for (int i = 0; i < ItemInfo.ItemCnt; i++)
            {
                if (items[i].IsEquiped)
                {
                    sum += items[i].ItemAtk;
                }
            }
            return sum;
        }
        private static int getSumBonusDef()
        {
            int sum = 0;
            for (int i = 0; i < ItemInfo.ItemCnt; i++)
            {
                if (items[i].IsEquiped)
                {
                    sum += items[i].ItemDef;
                }                    
            }
            return sum;
        }
        private static int getSumBonusHp()
        {
            int sum = 0;
            for (int i = 0; i < ItemInfo.ItemCnt; i++)
            {
                if (items[i].IsEquiped)
                {
                    sum += items[i].ItemHp;
                }
            }
            return sum;
        }


        static void DisplayInventory()
        {
            Console.Clear();

            Console.WriteLine("인벤토리");
            Console.WriteLine("보유 중인 아이템을 관리할 수 있습니다.");
            Console.WriteLine();
            Console.WriteLine("[아이템 목록]");
            //Console.WriteLine($"- {item1.ItemName}    " + $" | 방어력 +{item1.ItemDef} | {item1.ItemDescription}");
            //Console.WriteLine($"- {item2.ItemName}    " + $" | 공격력 +{item2.ItemAtk} | {item2.ItemDescription}");
            for (int i = 0; i < ItemInfo.ItemCnt; i++)
            {
                items[i].PrintItemDes();
            }            
            Console.WriteLine();
            Console.WriteLine("1. 장착 관리");
            Console.WriteLine("0. 나가기");
            Console.WriteLine();
            Console.WriteLine("원하시는 행동을 입력해주세요");

            int input = CheckValidInput(0, 1);
            switch (input)
            {
                case 0:
                    DisplayGameIntro();
                    break;
                case 1:
                    EquipItemManagement();
                    break;
            }
        }

        
        static void EquipItemManagement()
        {
            Console.Clear();

            Console.WriteLine("인벤토리 - 장착 관리");
            Console.WriteLine("아이템을 장착하거나 해제합니다");
            Console.WriteLine();
            Console.WriteLine("[아이템 목록]");
            //Console.WriteLine($"- 1 {item1.ItemName}    " + $" | 방어력 +{item1.ItemDef} | {item1.ItemDescription}");
            //Console.WriteLine($"- 2 {item2.ItemName}    " + $" | 공격력 +{item2.ItemAtk} | {item2.ItemDescription}");
            for (int i = 0; i < ItemInfo.ItemCnt; i++)
            {
                items[i].PrintItemDes(true, i + 1);
            }
            Console.WriteLine();
            Console.WriteLine("0. 나가기");
            Console.WriteLine();
            Console.WriteLine("장착할 아이템 번호를 입력해주세요.");
            Console.WriteLine("이미 장착하고 있을 경우 해제합니다.");

            int input = CheckValidInput(0, ItemInfo.ItemCnt);

            switch (input)
            {
                case 0:
                    DisplayInventory();
                    break;
                default:
                    ToggleEquipStatus(input - 1); // items[]가 배열이라 0부터 시작하기 때문
                    EquipItemManagement();
                    break;
                // case 1:
                    // 1번 아이템 선택하면 캐릭터 인포에 능력치를 플러스해주고 아이템 이름 앞에 [E]를 붙였다가 떼기                   
                    //if (item1.ItemName == "무쇠 갑옷")
                    //{
                    //    item1.ItemName = "[E] 무쇠 갑옷";

                    //    player.Atk += item1.ItemAtk;
                    //    player.Def += item1.ItemDef;
                    //    player.Hp += item1.ItemHp;
                    //}
                    //else
                    //{
                    //    item1.ItemName = "무쇠 갑옷";
                    //    player.Atk -= item1.ItemAtk;

                    //    player.Def -= item1.ItemDef;
                    //    player.Hp -= item1.ItemHp;
                    //}
                    //EquipItemManagement();
                    // break;
                // case 2:
                    //if (item2.ItemName == "낡은 검")
                    //{
                    //    item2.ItemName = "[E] 낡은 검";

                    //    player.Atk += item2.ItemAtk;
                    //    player.Def += item2.ItemDef;
                    //    player.Hp += item2.ItemHp;
                    //}
                    //else
                    //{
                    //    item2.ItemName = "낡은 검";

                    //    player.Atk -= item2.ItemAtk;
                    //    player.Def -= item2.ItemDef;
                    //    player.Hp -= item2.ItemHp;
                    //}
                    //EquipItemManagement();
                    //break;
            }
        }
        static void ToggleEquipStatus(int idx)
        {
            items[idx].IsEquiped = !items[idx].IsEquiped;
        }


        static int CheckValidInput(int min, int max)
        {
            while (true)
            {
                string input = Console.ReadLine();

                bool parseSuccess = int.TryParse(input, out var ret);
                if (parseSuccess)
                {
                    if (ret >= min && ret <= max)
                        return ret;
                }

                Console.WriteLine("잘못된 입력입니다.");
            }
        }
    }

    public class ItemInfo
    {
        public string ItemName { get; set; }
        public string ItemDescription { get; }
        public int Type { get; }
        public int ItemAtk { get; set; }
        public int ItemDef { get; set; }
        public int ItemHp { get; set; }

        public static int ItemCnt = 0;

        public bool IsEquiped {  get; set; }

        public ItemInfo(string itemname, string itemdes, int type, int itematk, int itemdef, int itemhp, bool isEquiped = false)
        {
            ItemName = itemname;
            ItemDescription = itemdes;
            Type = type;
            ItemAtk = itematk;
            ItemDef = itemdef;
            ItemHp = itemhp;
            IsEquiped = isEquiped;
        }

        public void PrintItemDes(bool withNumber = false, int idx = 0)
        {
            Console.Write("- ");

            if (withNumber)
            {
                Console.Write("{0} ", idx);
            }

            if (IsEquiped)
            {
                Console.Write("[E]");
                Console.Write(PadRightForMixedText(ItemName, 9));
            }
            else
            {
                Console.Write(PadRightForMixedText(ItemName, 12));
            }

            Console.Write(" | ");

            if (ItemAtk != 0)
            {
                Console.Write($"Atk {(ItemAtk >= 0 ? "+" : "")}{ItemAtk} ");
            }

            if (ItemDef != 0)
            {
                Console.Write($"Def {(ItemDef >= 0 ? "+" : "")}{ItemDef} ");
            }

            if (ItemHp != 0)
            {
                Console.Write($"Hp  {(ItemHp >= 0 ? "+" : "")}{ItemHp} ");
            }

            Console.Write(" | ");

            Console.WriteLine(ItemDescription);
        }
        public static int GetPrintableLength(string str)
        {
            int length = 0;
            foreach (char c in str)
            {
                if (char.GetUnicodeCategory(c) == System.Globalization.UnicodeCategory.OtherLetter)
                {
                    length += 2; // 한글과 같은 넓은 문자에 대해 길이를 2로 취급
                }
                else
                {
                    length += 1; // 나머지 문자에 대해 길이를 1로 취급
                }
            }

            return length;
        }

        public static string PadRightForMixedText(string str, int totalLength)
        {
            int currentLength = GetPrintableLength(str);
            int padding = totalLength - currentLength;
            return str.PadRight(str.Length + padding);
        }
    }



    public class Character
    {
        public string Name { get; }
        public string Job { get; }
        public int Level { get; }
        public int Atk { get; set; }
        public int Def { get; set; }
        public int Hp { get; set; }
        public int Gold { get; }

        public Character(string name, string job, int level, int atk, int def, int hp, int gold)
        {
            Name = name;
            Job = job;
            Level = level;
            Atk = atk;
            Def = def;
            Hp = hp;
            Gold = gold;
        }
    }
}