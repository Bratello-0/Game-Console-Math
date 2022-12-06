using System;

namespace Game4
{
    partial class MathGame
    {
        partial class Example
        {
            public class DigitExample
            {
                public DigitExample Next { get; private set; }
                public Operation OperationSymbol { get; private set; }
                public readonly long _result;

                public DigitExample
                    (DigitExample next, Operation operation, NumberDigits numberMaxSize)
                {
                    OperationSymbol = GetOperation(operation);
                    _result = GetNumber(numberMaxSize);
                    this.Next = next;
                }

                public DigitExample(NumberDigits numberMaxSize)
                {
                    OperationSymbol = Operation.NullOperations;
                    _result = GetNumber(numberMaxSize);
                }

                private int GetNumber(NumberDigits numberMaxSize) => 0.RandomNumber((int)Math.Pow(10, (int)numberMaxSize));

                public long GetSum(long result)
                {
                    if (OperationSymbol == Operation.NullOperations)
                        return result;
                    switch (OperationSymbol)
                    {
                        case Operation.Multiplication:
                            return Next.GetSum(result * Next._result);
                        case Operation.Addition:
                            return Next.GetSum(Next._result) + result;
                        case Operation.Subtraction:
                            return Next.GetSum(-Next._result) + result;
                        default: throw new NotImplementedException();
                    }
                }

                private Operation GetOperation(Operation operation)
                {
                    int temp;
                    switch (operation)
                    {
                        case Operation.AllOperations:
                            temp = 3.RandomNumber();
                            if (temp == 0)
                                return Operation.Addition;
                            if (temp == 1)
                                return Operation.Subtraction;
                            return Operation.Multiplication;
                        default:
                            return operation;
                    }
                }

                private char GetOperation() => OperationSymbol switch
                {
                    Operation.Addition => '+',
                    Operation.Subtraction => '-',
                    _ => '*',
                };

                public override string ToString()
                {
                    if (Next == null)
                        return _result.ToString();
                    return (_result.ToString() + GetOperation() + Next.ToString());
                }
            }
        }
    }
}
