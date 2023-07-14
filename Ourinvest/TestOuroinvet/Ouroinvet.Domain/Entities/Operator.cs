using Ourinvest.Domain.Interfaces.IEntities;

namespace Ourinvest.Domain.Entities
{
    public class Operator : IOperator
    {
        public char Oper { get; private set; }
        public double LeftOperand { get; private set; }
        public double RightOperand { get; private set; }

        public Operator(char oper, double leftOperand, double rightOperand)
        {
            Oper = oper;
            LeftOperand = leftOperand;
            RightOperand = rightOperand;
        }
    }
}