using MathGameConsole.Enum;
using MathGameConsole.Src.MathGame.Digit;

namespace MathGameConsole.Src.GameLogic
{
    public partial class MathGame
    {
        private Example ExampleObj { get; set; }
        private int score = 0;
        private long result = 0;
        private int headPoint = 3;
        private const int maxHeadPoint = 3;
        private bool isGameOver = false;

        public NumberDigits NumberDigits { get; private set; }
        public Difficulty difficulty { get; private set; }
        public Operation TypeOperation { get; private set; }

        public MathGame()
        {
            SetSettings();
        }

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
        public int Score
        {
            get => score;
            private set
            {
                score += (int)difficulty * (int)NumberDigits + 1 + (int)TypeOperation;
            }
        }

        private Difficulty StringToDifficulty(string stringDifficulty)
        {
            if (stringDifficulty.Length == 0)
                return Difficulty.Easy;
            stringDifficulty = stringDifficulty.ToLower();
            switch (stringDifficulty[0])
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
        private NumberDigits StringToNumberDigits(string stringNumberDigit)
        {
            if (stringNumberDigit.Length == 0) { return NumberDigits.OneDigits; }
            switch (stringNumberDigit[0])
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
        private Operation StringToOperation(string stringOperation)
        {
            if (stringOperation.Length == 0) { return Operation.Addition; }
            stringOperation = stringOperation.ToLower();
            switch (stringOperation[0])
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
            if (ExampleObj.Result != result)
            {
                Console.WriteLine($"Не правильно!!!\nПравильный ответ:{ExampleObj.Result}");
                HeadPoint--;
                return;
            }
            Console.WriteLine($"Правильно!!!");
            Score++;
        }

        private void GameOver()
        {
            Console.WriteLine($"Вы проиграли!!!(((\nКоличество очков: {Score}");
            isGameOver = !isGameOver;
        }

        private bool GiveAnswer(string AnswerUser)
        {
            AnswerUser = new string(AnswerUser.Select(s => s)
                .Where(s => s == '-' || s >= '0' && s <= '9').ToArray());
            if (AnswerUser.Any())
            {
                result = long.Parse(AnswerUser);
                return false;
            }
            Console.WriteLine("Некоректный ввод");
            return true;
        }

        private bool IsDeffoutSettings(string answer) => answer.Any() && answer == "def";

        private bool Choice(string text, ref string setting)
        {
            Console.Write(text);
            setting = Console.ReadLine();
            if (IsDeffoutSettings(setting)) { DefaultSetting(); return true; }
            return false;
        }

        public void Start()
        {
            ExampleObj = new Example(difficulty, NumberDigits, TypeOperation);
            PrintHelp();
            while (!isGameOver)
            {
                ShowExample();
                if (CheckingCommand()) { continue; }
                CheckResult();
                ExampleObj.Update(difficulty, NumberDigits, TypeOperation);
            }
        }
    }
}
