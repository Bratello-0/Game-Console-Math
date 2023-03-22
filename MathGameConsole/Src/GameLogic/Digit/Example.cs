using MathGameConsole.Enum;
using MathGameConsole.Src.Extension;

namespace MathGameConsole.Src.MathGame.Digit
{
    partial class Example
    {
        public DigitExample DExample { get; private set; }
        public long Result { get; private set; }

        public Example
            (Difficulty difficulty, NumberDigits numberDigits, Operation operation)
        {
            CreateDigit(difficulty, numberDigits, operation);
            Result = DExample.GetSum(DExample._result);
        }
        public void Update
            (Difficulty difficulty, NumberDigits numberDigits, Operation operation)
        {
            DExample = null;
            CreateDigit(difficulty, numberDigits, operation);
            Result = DExample.GetSum(DExample._result);
        }

        private int GetRandValue(Difficulty difficulty)
        {
            switch (difficulty)
            {
                case Difficulty.Hard:
                    return 0.RandomNumber(5) + 6;
                case Difficulty.Normal:
                    return 0.RandomNumber(3) + 3;
                case Difficulty.Easy:
                default:
                    return 0.RandomNumber(2) + 1;
            }
        }

        private void CreateDigit
            (Difficulty difficulty, NumberDigits numberDigits, Operation operation)
        {
            int value = GetRandValue(difficulty);
            while (value >= 0)
            {
                if (DExample == null)
                    DExample = new DigitExample(numberDigits);
                else
                    DExample = new DigitExample(DExample, operation, numberDigits);
                value--;
            }
        }
        public override string ToString()
        {
            return DExample.ToString();
        }
    }
}
