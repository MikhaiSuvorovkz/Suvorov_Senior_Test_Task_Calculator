using System;

namespace Game.Core.Entities
{
    public class Calculator : ICalculator
    {
        public string Calculate(string inputExpression)
        {
            if (string.IsNullOrWhiteSpace(inputExpression) || !IsValidExpression(inputExpression))
            {
                throw new ArgumentException("Expression is not valid.");
            }

            
            int result = Evaluate(inputExpression);
            
            return result.ToString();
        }

        private bool IsValidExpression(string input)
        {
            // Проверяем, что выражение состоит только из чисел и знаков '+'
            string[] parts = input.Split('+');
            foreach (string part in parts)
            {
                if (!int.TryParse(part, out int number) || IsNegative(number))
                {
                    return false;
                }
            }

            // Условие корректности выполнено
            return true;
        }

        private static bool IsNegative(int number)
        {
            return number < 0;
        }

        private int Evaluate(string input)
        {
            // Выполнение сложения
            string[] parts = input.Split('+');
            int sum = 0;
            
            foreach (string part in parts)
            {
                sum += int.Parse(part);
            }

            return sum;
        }
    }
}