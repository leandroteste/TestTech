namespace Ourinvest.Domain.Interfaces.IEntities
{
    public interface IOperator
    {
        char Oper { get; }
        double LeftOperand { get; }
        double RightOperand { get; }
    }
}