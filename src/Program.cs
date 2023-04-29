using LogarithmsLib;

namespace Logarithms.src
{
    class Program
    {
        static void Main()
        {
            Console.WriteLine("Приветствую Вас в калькуляторе логарифмов.");
            Console.WriteLine("Калькулятор может складывать, вычитать, умножать и делить логарифмы.");
            Console.WriteLine("А также возводить в степень и выполнять переход от одного основания к другому.");
            Console.WriteLine("Пример ввода:");
            Console.WriteLine("Сложение:                   log(основание)(число) + log(основание)(число)");
            Console.WriteLine("Вычитание:                  log(основание)(число) - log(основание)(число)");
            Console.WriteLine("Умножение:                  log(основание)(число) * log(основание)(число)");
            Console.WriteLine("Деление:                    log(основание)(число) / log(основание)(число)");
            Console.WriteLine("Переход к новому основанию: new log(основание)(число) log(основание)(число)");
            Console.WriteLine("Логарифм с основанием e - ln(число)");
            Console.WriteLine("Логарифм с основанием 10 - lg(число)");
            Console.WriteLine("Для выхода из калькулятора введите \"exit\"");

            ParseExpression parse;

            while (true)
            {
                Console.WriteLine();
                Console.Write("Введиете выражение: ");
                string expression = Console.ReadLine();

                if (expression == "")
                {
                    continue;
                }
                else if (expression == "exit")
                {
                    break;
                }

                try
                {
                    parse = new ParseExpression(expression);
                }
                catch (LogException logarithmExp)
                {
                    Console.WriteLine(logarithmExp);
                    continue;
                }
                catch (ExpressionException expressionExp)
                {
                    Console.WriteLine(expressionExp);
                    continue;
                }

                string stringExpression;
                CalculateExpression expressionResult = new(parse.log1, parse.log2, parse.expressionOperator);
                if (parse.expressionOperator == "new")
                {
                    stringExpression = expression + " = " + expressionResult.newLog;
                }
                else
                {
                    stringExpression = expression + " = " + expressionResult.calculationResult;
                }
                Console.WriteLine(stringExpression);
            }
        }
    }
}
