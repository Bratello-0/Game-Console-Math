using MathGameConsole.Enum;

namespace MathGameConsole.Src.GameLogic
{
    public partial class MathGame
    {
        //обработчик команд
        private bool CheckingCommand()
        {
            string strLine;
            do
            {
                Console.Write(">>");
                strLine = Console.ReadLine();
                if (strLine.Length == 0)
                {
                    Console.WriteLine("Некоректный ввод");
                    return true;
                }

                if (strLine[0] == '\\')
                {
                    if (strLine == "\\help") { PrintHelp(); return true; }
                    if (strLine == "\\headpoint") { PrintHeadPoint(); return true; }
                    if (strLine == "\\restart") { Restart(); return true; }
                    if (strLine == "\\score") { PrintScore(); return true; }
                    if (strLine == "\\clear") { ClearConsole(); return true; }
                    if (strLine == "\\example") { ShowExample(); return true; }
                    if (strLine == "\\HESOYAM") { WinExample(); return true; }
                    if (strLine == "\\settings")
                    {
                        Console.Write("set \\ get\n-");
                        strLine = Console.ReadLine();
                        if (strLine.Any() && strLine == "set") { SetSettings(); return true; }
                        PrintSettings(); return true;
                    }
                }
            } while (GiveAnswer(strLine));
            return false;
        }

        //команды 
        private void DefaultSetting()
        {
            Console.WriteLine("Настройки по умолчанию");
            difficulty = Difficulty.Normal;
            NumberDigits = NumberDigits.OneDigits;
            TypeOperation = Operation.AllOperations;
        }
        private void ShowExample() => Console.WriteLine("Пример:" + ExampleObj);
        private void PrintScore() => Console.WriteLine("Количество очков: " + Score);
        private void SetSettings()
        {
            string strSetting = "";
            while (true)
            {
                Console.Clear();
                if (Choice("Выбери уровень сложности \nHard\\Normal\\Easy\n-",
                        ref strSetting))
                    break;
                difficulty = StringToDifficulty(strSetting);

                if (Choice("Выбери кол-во символов в числе \n1\\2\\3\n-",
                        ref strSetting))
                    break;
                NumberDigits = StringToNumberDigits(strSetting);

                if (Choice("Выбери тип примера \n+|-\\*\\All\n-",
                        ref strSetting))
                    break;
                TypeOperation = StringToOperation(strSetting);

                PrintSettings();
                Console.Write($"Согласны с выбранными настройками?\nyes\\no\n-");
                strSetting = Console.ReadLine();

                if (!strSetting.Any()) break;
                if (strSetting.ToLower().First() != 'n') break;
            }
            Console.Clear();
        }

        public void PrintSettings()
        {
            Console.WriteLine($"Выбрана сложность: {difficulty}");
            Console.WriteLine($"Выбрано кол-во символов в числе: {(int)NumberDigits}");
            Console.WriteLine($"Выбран тип примера: {TypeOperation}");
        }

        private void WinExample()
        {
            headPoint = 3;
            Console.WriteLine($"Правильно!!!");
            Console.WriteLine($"Ответ:" + ExampleObj.Result);
            Score++;
            ExampleObj.Update(difficulty, NumberDigits, TypeOperation);
        }

        public static void PrintHelp()
        {
            Console.WriteLine("Необходимо решить пример\nВвод только из натуральных чисел и 1 знака \'-\'");
            Console.WriteLine("Список доступных команд:" +
                "\\help, \\score, \\settings, \\headpoint, " +
                "\\restart, \\clear");
        }

        private void Restart()
        {
            headPoint = maxHeadPoint;
            SetSettings();
            ExampleObj.Update(difficulty, NumberDigits, TypeOperation);
        }
        public void PrintHeadPoint() => Console.WriteLine($"Осталось жизней: {headPoint}");
        private static void ClearConsole() => Console.Clear();
    }
}
