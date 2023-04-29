using LogarithmsLib;


namespace Logarithms.src
{
    class CalculateExpression
    {
        public double calculationResult;
        public Logarithm newLog;

        public CalculateExpression(Logarithm log1, Logarithm log2, string expressionOperator)
        {
            if (expressionOperator == "+")
                calculationResult = log1 + log2;

            else if (expressionOperator == "-")
                calculationResult = log1 - log2;

            else if (expressionOperator == "*")
                calculationResult = log1 * log2;

            else if (expressionOperator == "/")
                calculationResult = log1 / log2;

            else if (expressionOperator == "new")
            {
                if (log1.baseLog == log2.baseLog)
                    newLog = new Logarithm(log2.number, log1.number);
                else
                    throw new ExpressionCalculateException("Нельзя перейти к новому основанию");
            }

            else
                calculationResult = log1.Result;
        }
    }
}
