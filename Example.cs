namespace Game4
{
    partial class MathGame
    {
        partial class Example
        {
            public DigitExample DExample { get; private set; }
            public long Result { get; private set; }

            public Example 
                (Difficulty level, NumberDigits number, Operation operation)
            {
                CreateDigit(level, number, operation);
                Result = DExample.GetSum(DExample._result);
            }
            public void Update
                (Difficulty level, NumberDigits number, Operation operation)
            {
                DExample = null;
                CreateDigit(level, number, operation);
                Result = DExample.GetSum(DExample._result);
            }

            private int GetRandValue(Difficulty level)
            {
                switch (level)
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
                (Difficulty level, NumberDigits number, Operation operation)
            {
                int value = GetRandValue(level);
                while (value >= 0)
                {
                    if (DExample == null)
                        DExample = new DigitExample(number);
                    else
                        DExample = new DigitExample(DExample, operation, number);
                    value--;
                }
            }
            public override string ToString()
            {
                return DExample.ToString();
            }
        }
    }
}
