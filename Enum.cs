namespace Game4
{
    public enum Operation : int
    {
        Addition = 1,
        Subtraction = 2,
        Multiplication = 3,
        AllOperations = 4,
        NullOperations = 0,
    }
    public enum Difficulty : int
    {
        Hard = 3,
        Normal = 2,
        Easy = 1
    }
    public enum NumberDigits : int
    {
        OneDigits = 1,
        TwoDigits = 2,
        ThereeDigits = 3
    }
    partial class MathGame
    {
        //public class SettingsConfig
        //{
        //    public NumberDigits NumDigits { get; private set; }
        //    public Difficulty DifficultyLevel { get; private set; }
        //    public Operation TypeOperation { get; private set; }

        //    public void StrToIntDLevel(this string str)
        //    {
        //        if (str.Length == 0)
        //            DifficultyLevel =  Difficulty.Easy;
        //        str = str.ToLower();
        //        switch (str[0])
        //        {
        //            case 'h':
        //                return Difficulty.Hard;
        //            case 'n':
        //                return Difficulty.Normal;
        //            case 'e':
        //            default:
        //                return Difficulty.Easy;
        //        }
        //    }
        //    public static NumberDigits StrToIntNDigits(string str)
        //    {
        //        if (str.Length == 0)
        //            return NumberDigits.OneDigits;
        //        switch (str[0])
        //        {
        //            case '3':
        //                return NumberDigits.ThereeDigits;
        //            case '2':
        //                return NumberDigits.TwoDigits;
        //            case '1':
        //            default:
        //                return NumberDigits.OneDigits;
        //        }
        //    }
        //    public Operation StrToIntTOperation(string str)
        //    {
        //        if (str.Length == 0)
        //            return Operation.Addition;
        //        str = str.ToLower();
        //        switch (str[0])
        //        {
        //            case 'a':
        //                return Operation.AllOperations;
        //            case '*':
        //                return Operation.Multiplication;
        //            case '-':
        //                return Operation.Subtraction;
        //            case '+':
        //            default:
        //                return Operation.Addition;
        //        }
        //    }
        //}
    }
}
