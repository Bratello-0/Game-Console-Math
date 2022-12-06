using System;
using System.Linq;

namespace Game4
{ 
    partial class MathGame
    {
        private Example ExampleObj { get; set; }
        private int glasses = 0;
        private long result = 0;
        private int headPoint = 3;
        private const int maxHeadPoint = 3;
        private bool isGameOver = false;
        //private SettingsConfig Settings { get; set; }
        public NumberDigits NumDigits { get; private set; }
        public Difficulty LevelGame { get; private set; }
        public Operation TypeOperation { get; private set; }

        public int HeadPoint
        {
            get => headPoint;
            private set
            {
                if (Math.Abs(value) <= maxHeadPoint)
                {
                    headPoint = Math.Abs(value);
                    PrintHeadPoint();
                    if (headPoint == 0) GameOver();
                }
            }
        }
        public int Glasses
        {
            get => glasses;
            private set
            {
                glasses += ((int)LevelGame * (int)NumDigits) + 1 + (int)TypeOperation;
            }
        }

        public MathGame()
        {
            SetSettings();
        }

        private Difficulty StrToIntDLevel(string str)
        {
            if (str.Length == 0)
                return Difficulty.Easy;
            str = str.ToLower();
            switch (str[0])
            {
                case 'h':
                    return Difficulty.Hard;
                case 'n':
                    return Difficulty.Normal;
                case 'e':
                default:
                    return Difficulty.Easy;
            }
        }
        private NumberDigits StrToIntNDigits(string str)
        {
            if (str.Length == 0)
                return NumberDigits.OneDigits;
            switch (str[0])
            {
                case '3':
                    return NumberDigits.ThereeDigits;
                case '2':
                    return NumberDigits.TwoDigits;
                case '1':
                default:
                    return NumberDigits.OneDigits;
            }
        }
        private Operation StrToIntTOperation(string str)
        {
            if (str.Length == 0)
                return Operation.Addition;
            str = str.ToLower();
            switch (str[0])
            {
                case 'a':
                    return Operation.AllOperations;
                case '*':
                    return Operation.Multiplication;
                case '-':
                    return Operation.Subtraction;
                case '+':
                default:
                    return Operation.Addition;
            }
        }

        private void CheckResult()
        {
            if (ExampleObj.Result != this.result)
            {
                Console.WriteLine($"НЕ ПРАВИЛЬНО!!! ПОПРОБУЙ ЕЩЕ РАЗ\nПравильный ответ:{ExampleObj.Result}");
                HeadPoint--;
                return;
            }
            Console.WriteLine($"Правильно!!!");
            Glasses++;
        }

        private void GameOver()
        {
            Console.WriteLine($"Вы проиграли!!!(((\nКоличество очков: {Glasses}");
            isGameOver = !isGameOver;
        }

        private bool GiveAnswer(string AnswerUser)
        {
            AnswerUser = new string(AnswerUser.Select(s => s)
                .Where(s => s == '-' || (s >= '0' && s <= '9')).ToArray());
            if (AnswerUser.Any())
            {
                result = long.Parse(AnswerUser);
                return false;
            }
            Console.WriteLine("Некоректный ввод");
            return true;
        }

        private bool EnterSettings(string str) => (str.Any() && str == "def");

        private bool Choice(string text, ref string strSetting)
        {
            Console.Write(text);
            strSetting = Console.ReadLine();
            if (EnterSettings(strSetting)) { DefaultSetting(); return true; }
            return false;
        }

        public void Start()
        {
            ExampleObj = new Example(LevelGame, NumDigits, TypeOperation);
            PrintHelp();
            while (!isGameOver)
            {
                ShowExample();
                if (CheckingCommand()) { continue; }
                CheckResult();
                ExampleObj.Update(LevelGame, NumDigits, TypeOperation);
            }
        }
    }
}
