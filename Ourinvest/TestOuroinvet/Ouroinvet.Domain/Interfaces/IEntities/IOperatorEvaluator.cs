using Ourinvest.Domain.Entities;

namespace Ourinvest.Domain.Interfaces.IEntities
{
    public interface IOperatorEvaluator
    {
        double EvaluateOperator(IOperator oper);
        bool IsOperator(char character);
        int GetOperatorPrecedence(char character);
    }
}