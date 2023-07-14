using System;
using Ourinvest.Domain.Interfaces.IEntities;

namespace Ourinvest.Domain.Entities
{
    public class OperatorEvaluator : IOperatorEvaluator
    {
        public double EvaluateOperator(IOperator oper)
        {
            return oper.Oper switch
            {
                '+' => oper.LeftOperand + oper.RightOperand,
                '-' => oper.LeftOperand - oper.RightOperand,
                '*' => oper.LeftOperand * oper.RightOperand,
                '/' => oper.LeftOperand / oper.RightOperand,
                _ => throw new InvalidOperationException("Operador inválido"),
            };
        }
        public bool IsOperator(char character)
        {
            return character == '+' || character == '-' || character == '*' || character == '/';
        }
        public int GetOperatorPrecedence(char character)
        {
            switch (character)
            {
                case '+':
                case '-':
                    return 1;
                case '*':
                case '/':
                    return 2;
                default:
                    return 0;
            }
        }
    }
}