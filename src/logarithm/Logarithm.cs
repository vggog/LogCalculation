namespace LogarithmsLib
{
    public class Logarithm
    {
        public double number;
        public double baseLog;
        bool isNaturalLog;
        double result;

        public double Result
        { 
            get { return result; } 
        }

        public Logarithm(double baseLog, double number)
        {
            ValidateLogNumber(number);
            ValidateBaseLog(baseLog);

            this.number = number;
            this.baseLog = baseLog;
            isNaturalLog = false;

            LogarithmCalculation();
        }

        public Logarithm(double number)
        {
            ValidateLogNumber(number);

            this.number = number;
            baseLog = Math.E;
            isNaturalLog = true;

            LogarithmCalculation();
        }

        void ValidateLogNumber(double number)
        {
            if (number < 0)
            {
                throw new LogException("Число логарифма не может быть меньше нюля.");
            }
        }

        void ValidateBaseLog(double baseLog)
        {
            if (baseLog < 0 || baseLog == 1)
            {
                throw new LogException("Степень логарифма не может быть меньше нюля или быть равен 1.");
            }
        }

        void LogarithmCalculation()
        {
            if ( isNaturalLog )
            { 
                result = Math.Log(number);
            }
            else
            { 
                result = Math.Log(number, baseLog);
            }
        }

        public static double operator +(Logarithm log1, Logarithm log2)
        {
            return log1.result + log2.result;
        }

        public static double operator -(Logarithm log1, Logarithm log2)
        {
            return log1.result - log2.result;
        }

        public static double operator *(Logarithm log1, Logarithm log2)
        {
            return log1.result * log2.result;
        }

        public static double operator /(Logarithm log1, Logarithm log2)
        {
            return log1.result / log2.result;
        }

        public override string ToString()
        {
            return "log(" + ( isNaturalLog ? "e" : Convert.ToString(baseLog)) + ")(" + Convert.ToString(number) + ")";
        }
    }
}
