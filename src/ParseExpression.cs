using LogarithmsLib;

namespace Logarithms.src
{
    class ParseExpression
    {
        readonly string expression;
        public string? expressionOperator;
        public Logarithm? log1;
        public Logarithm? log2;

        public ParseExpression(string exp)
        {
            expression = exp;

            for (int i = 0; i < expression.Length; i++)
            {
                char expressionChar = expression[i];

                if (expressionChar == 'l')
                {
                    if (log1 is null)
                        log1 = ParseLog(i);
                    else
                        log2 = ParseLog(i);
                }
                else if (IsExpressionOperator(i))
                {
                    ParseOperator(expressionChar);
                }
                else if (expressionChar == ' ')
                { }
                else
                {
                    throw new ExpressionException("Неверный ввод выражения.");
                }

                i = FindChapterIndex(i, ' ');
            }
        }

        Logarithm ParseLog(int i)
        {
            if (IsValidLogStr(i))
            {
                double baseLog = ParseNum(i + 4);
                i = FindChapterIndex(i + 4, ')');

                double number = ParseNum(i + 2);
                return new Logarithm(baseLog, number);
            }
            else if (IsValidLnStr(i))
            {
                return new Logarithm(ParseNum(i + 3));
            }
            else if (IsValidLgStr(i))
            {
                return new Logarithm(10, ParseNum(i + 3));
            }

            throw new ExpressionException("Неверный ввод логарифма.");
        }

        int FindChapterIndex(int i, char targetCharIndex)
        {
            while (i < expression.Length - 1 && expression[++i] != targetCharIndex)
            { }
            return i;
        }

        bool IsValidLogStr(int i)
        {
            /*
             * Valid log str is lok like: log(
             */
            return expression[i] == 'l' && expression[i + 1] == 'o' && expression[i + 2] == 'g' && expression[i + 3] == '(';
        }

        bool IsValidLnStr(int i)
        {
            /*
             * Valid ln str is lok like: ln(
             */
            return expression[i] == 'l' && expression[i + 1] == 'n' && expression[i + 2] == '(';
        }

        bool IsValidLgStr(int i)
        {
            /*
             * Valid lg str is loke like: lg(
             */
            return expression[i] == 'l' && expression[i + 1] == 'g' && expression[i + 2] == '(';
        }

        double ParseNum(int i)
        {
            string num = "";
            for (int j = i; expression[j] != ')'; j++)
            {
                num += expression[j];
            }

            if (num == "e")
            {
                return Math.E;
            }
            else if (num == "pi")
            {
                return Math.PI;
            }

            try
            {
                return Convert.ToDouble(num);
            }
            catch (FormatException)
            {
                throw new ExpressionException("В степенях и числах логарифма должны стоять числа.");
            }
        }

        bool IsExpressionOperator(int i)
        {
            /*
             * Math expression operators is:  +  -  *  /  new
             */
            char[] operators = { '+', '-', '*', '/' };
            return operators.Contains(expression[i]) || expression[i] == 'n' && expression[i + 1] == 'e' && expression[i + 2] == 'w';
        }

        void ParseOperator(char expressionChar)
        {
            if (expressionOperator is not null)
                throw new ExpressionException("В выражении не может быть более одного оператора.");
            else if (expressionChar == 'n')
                expressionOperator = "new";
            else
                expressionOperator = Convert.ToString(expressionChar);
        }
    }
}
