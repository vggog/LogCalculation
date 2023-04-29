namespace Logarithms.src
{
    public class ExpressionException : Exception
    {
        public ExpressionException(string message)
        : base(message)
        { }
    }

    public class ExpressionCalculateException : Exception
    {
        public ExpressionCalculateException(string message)
        : base(message)
        { }
    }
}
