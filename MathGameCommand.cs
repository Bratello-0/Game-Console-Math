using System;
using System.Linq;


namespace Game4
{
    partial class MathGame
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
                    if (strLine == "\\glasses") { PrintGlasses(); return true; }
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
            LevelGame = Difficulty.Normal;
            NumDigits = NumberDigits.OneDigits;
            TypeOperation = Operation.AllOperations;
        }
        private void ShowExample() => Console.WriteLine("Пример:"+ExampleObj);
        private void PrintGlasses() => Console.WriteLine("Количество очков: " + Glasses);
        private void SetSettings()
        {
            string strSetting = "";
            while (true)
            {
                Console.Clear();
                if (Choice("Выбери уровень сложности \nHard\\Normal\\Easy\n-",
                        ref strSetting))
                    break;
                LevelGame = StrToIntDLevel(strSetting);

                if (Choice("Выбери кол-во символов в числе \n1\\2\\3\n-",
                        ref strSetting))
                    break;
                NumDigits = StrToIntNDigits(strSetting);

                if (Choice("Выбери тип примера \n+|-\\*\\All\n-",
                        ref strSetting))
                    break;
                TypeOperation = StrToIntTOperation(strSetting);

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
            Console.WriteLine(@$"Выбрана сложность: {LevelGame}");
            Console.WriteLine($"Выбрано кол-во символов в числе: {(int)NumDigits}");
            Console.WriteLine($"Выбран тип примера: {TypeOperation}");
        }

        private void WinExample() 
        {
            headPoint = 3;
            Console.WriteLine($"Правильно!!!");
            Console.WriteLine($"Ответ:"+ ExampleObj.Result);
            Glasses++;
            ExampleObj.Update(LevelGame, NumDigits, TypeOperation);
        }

        public void PrintHelp()
        {
            Console.WriteLine("Необходимо решить пример\nВвод только из натуральных чисел и 1 знака \'-\'");
            Console.WriteLine("Список доступных команд:" +
                "\\help, \\glasses, \\settings, \\headpoint, " +
                "\\restart, \\clear");
        }

        private void Restart()
        {
            headPoint = maxHeadPoint;
            SetSettings();
            ExampleObj.Update(LevelGame, NumDigits, TypeOperation);
        }
        public void PrintHeadPoint() => Console.WriteLine($"Осталось жизней: {headPoint}");
        private void ClearConsole() => Console.Clear();
    }
}
