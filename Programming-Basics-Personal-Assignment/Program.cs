using System.Numerics;
using System.Runtime.InteropServices;

namespace Programming_Basics_Personal_Assignment
{
    internal class Program
    {
        private static Character player;
        private static ItemInfo item1;
        private static ItemInfo item2;


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
            item1 = new ItemInfo("무쇠 갑옷", "무쇠로 만들어진 튼튼한 갑옷입니다.", 0, 10, 0);
            item2 = new ItemInfo("낡은 검", "쉽게 볼 수 있는 낡은 검입니다.", 2, 0, 0);
        }        
        static void DisplayGameIntro()
        {
            Console.Clear();

            Console.WriteLine("스파르타 마을에 오신 여러분 환영합니다.");
            Console.WriteLine("이곳에서 전전으로 들어가기 전 활동을 할 수 있습니다.");
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
            Console.WriteLine($"Lv.{player.Level}");
            Console.WriteLine($"{player.Name}({player.Job})");
            Console.WriteLine($"공격력 : {player.Atk}");
            Console.WriteLine($"방어력 : {player.Def}");
            Console.WriteLine($"체력 : {player.Hp}");
            Console.WriteLine($"Gold : {player.Gold} G");
            Console.WriteLine();
            Console.WriteLine("0. 나가기");

            if (item1.ItemName == "[E] 무쇠 갑옷" && item2.ItemName != "[E] 낡은 검")
            {
                Console.Clear();

                Console.WriteLine("상태보기");
                Console.WriteLine("캐릭터의 정보를 표시합니다.");
                Console.WriteLine();
                Console.WriteLine($"Lv.{player.Level}");
                Console.WriteLine($"{player.Name}({player.Job})");
                Console.WriteLine($"공격력 : {player.Atk}");
                Console.WriteLine($"방어력 : {player.Def} +({item1.ItemDef + item2.ItemDef})");
                Console.WriteLine($"체력 : {player.Hp}");
                Console.WriteLine($"Gold : {player.Gold} G");
                Console.WriteLine();
                Console.WriteLine("0. 나가기");
            }
            else if (item2.ItemName == "[E] 낡은 검" && item1.ItemName != "[E] 무쇠 갑옷")
            {
                Console.Clear();

                Console.WriteLine("상태보기");
                Console.WriteLine("캐릭터의 정보를 표시합니다.");
                Console.WriteLine();
                Console.WriteLine($"Lv.{player.Level}");
                Console.WriteLine($"{player.Name}({player.Job})");
                Console.WriteLine($"공격력 : {player.Atk} +({item1.ItemAtk + item2.ItemAtk})");
                Console.WriteLine($"방어력 : {player.Def}");
                Console.WriteLine($"체력 : {player.Hp}");
                Console.WriteLine($"Gold : {player.Gold} G");
                Console.WriteLine();
                Console.WriteLine("0. 나가기");
            }
            else if (item1.ItemName == "[E] 무쇠 갑옷" && item2.ItemName == "[E] 낡은 검")
            {
                Console.Clear();

                Console.WriteLine("상태보기");
                Console.WriteLine("캐릭터의 정보를 표시합니다.");
                Console.WriteLine();
                Console.WriteLine($"Lv.{player.Level}");
                Console.WriteLine($"{player.Name}({player.Job})");
                Console.WriteLine($"공격력 : {player.Atk} +({item1.ItemAtk + item2.ItemAtk})");
                Console.WriteLine($"방어력 : {player.Def} +({item1.ItemDef + item2.ItemDef})");
                Console.WriteLine($"체력 : {player.Hp}");
                Console.WriteLine($"Gold : {player.Gold} G");
                Console.WriteLine();
                Console.WriteLine("0. 나가기");
            }
            int input = CheckValidInput(0, 0);

            switch (input)
            {
                case 0:
                    DisplayGameIntro();
                    break;
            }
        }

        
        static void DisplayInventory()
        {
            Console.Clear();

            Console.WriteLine("인벤토리");
            Console.WriteLine("보유 중인 아이템을 관리할 수 있습니다.");
            Console.WriteLine();
            Console.WriteLine("[아이템 목록]");
            Console.WriteLine($"- {item1.ItemName}    " + $" | 방어력 +{item1.ItemDef} | {item1.ItemDescription}");
            Console.WriteLine($"- {item2.ItemName}    " + $" | 공격력 +{item2.ItemAtk} | {item2.ItemDescription}");
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
            Console.WriteLine($"- 1 {item1.ItemName}    " + $" | 방어력 +{item1.ItemDef} | {item1.ItemDescription}");
            Console.WriteLine($"- 2 {item2.ItemName}    " + $" | 공격력 +{item2.ItemAtk} | {item2.ItemDescription}");
            Console.WriteLine();
            Console.WriteLine("0. 나가기");
            Console.WriteLine();
            Console.WriteLine("장착할 아이템 번호를 입력해주세요.");
            Console.WriteLine("이미 장착하고 있을 경우 해제합니다.");

            int input = CheckValidInput(0, 2);
            switch (input)
            {                
                case 0:
                    DisplayInventory();
                    break;
                case 1:
                    // 1번 아이템 선택하면 캐릭터 인포에 능력치를 플러스해주고 아이템 이름 앞에 [E]를 붙였다가 떼기                   
                    if (item1.ItemName == "무쇠 갑옷")
                    {
                        item1.ItemName = "[E] 무쇠 갑옷";
                        
                        player.Atk += item1.ItemAtk;
                        player.Def += item1.ItemDef;
                        player.Hp += item1.ItemHp;                       
                    }
                    else
                    {
                        item1.ItemName = "무쇠 갑옷";

                        player.Atk -= item1.ItemAtk;
                        player.Def -= item1.ItemDef;
                        player.Hp -= item1.ItemHp;
                    }                    
                    EquipItemManagement();
                    break;
                case 2:
                    if (item2.ItemName == "낡은 검")
                    {
                        item2.ItemName = "[E] 낡은 검";

                        player.Atk += item2.ItemAtk;
                        player.Def += item2.ItemDef;
                        player.Hp += item2.ItemHp;
                    }
                    else
                    {
                        item2.ItemName = "낡은 검";

                        player.Atk -= item2.ItemAtk;
                        player.Def -= item2.ItemDef;
                        player.Hp -= item2.ItemHp;
                    }
                    EquipItemManagement();
                    break;
            }
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
        public int ItemAtk { get; set; }
        public int ItemDef { get; set; }
        public int ItemHp { get; set; }        

        public ItemInfo(string itemname, string itemdes, int itematk, int itemdef, int itemhp)
        {
            ItemName = itemname;
            ItemDescription = itemdes;
            ItemAtk = itematk;
            ItemDef = itemdef;
            ItemHp = itemhp;            
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