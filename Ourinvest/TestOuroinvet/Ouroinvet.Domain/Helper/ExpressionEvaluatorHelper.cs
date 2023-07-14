using System;
using System.Text;
using Ourinvest.Domain.Entities;
using System.Collections.Generic;
using Ourinvest.Domain.Interfaces.IHelper;
using Ourinvest.Domain.Interfaces.IEntities;

namespace Ourinvest.Domain.Helper
{
    public class ExpressionEvaluatorHelper : IExpressionEvaluator
    {
        private readonly IOperatorEvaluator _operatorEvaluator;

        public ExpressionEvaluatorHelper(IOperatorEvaluator operatorEvaluator)
        {
            _operatorEvaluator = operatorEvaluator;
        }

        public double Evaluate(string expression)
        {
            expression = expression.Replace(" ", "");
            return EvaluateExpression(expression);
        }
        private double EvaluateExpression(string expression)
        {
            Stack<double> operandStack = new Stack<double>();
            Stack<char> operatorStack = new Stack<char>();

            for (int i = 0; i < expression.Length; i++)
            {
                char currentChar = expression[i];

                if (currentChar == '(')
                {
                    operatorStack.Push(currentChar);
                }
                else if (currentChar == ')')
                {
                    while (operatorStack.Count > 0 && operatorStack.Peek() != '(')
                    {
                        EvaluateTopOperator(operandStack, operatorStack);
                    }

                    if (operatorStack.Count == 0 || operatorStack.Peek() != '(')
                    {
                        throw new InvalidOperationException("Expressão inválida: parênteses não correspondentes");
                    }

                    operatorStack.Pop();
                }
                else if (_operatorEvaluator.IsOperator(currentChar))
                {
                    while (operatorStack.Count > 0 && operatorStack.Peek() != '(' && _operatorEvaluator.GetOperatorPrecedence(operatorStack.Peek()) >= _operatorEvaluator.GetOperatorPrecedence(currentChar))
                    {
                        EvaluateTopOperator(operandStack, operatorStack);
                    }

                    operatorStack.Push(currentChar);
                }
                else if (char.IsDigit(currentChar))
                {
                    StringBuilder operandBuilder = new StringBuilder();
                    operandBuilder.Append(currentChar);

                    while (i + 1 < expression.Length && (char.IsDigit(expression[i + 1]) || expression[i + 1] == '.'))
                    {
                        operandBuilder.Append(expression[i + 1]);
                        i++;
                    }

                    if (!double.TryParse(operandBuilder.ToString(), out double operand))
                    {
                        throw new InvalidOperationException("Expressão inválida: número inválido");
                    }

                    operandStack.Push(operand);
                }
                else if (currentChar == '^')
                {
                    operatorStack.Push(currentChar);
                }
                else
                {
                    throw new InvalidOperationException($"Expressão inválida: caractere inválido ({currentChar})");
                }
            }

            while (operatorStack.Count > 0)
            {
                EvaluateTopOperator(operandStack, operatorStack);
            }

            if (operandStack.Count != 1 || operatorStack.Count != 0)
            {
                throw new InvalidOperationException("Expressão inválida: operadores e operandos não correspondentes");
            }

            return operandStack.Pop();
        }

        private void EvaluateTopOperator(Stack<double> operandStack, Stack<char> operatorStack)
        {
            char topOperator = operatorStack.Pop();

            if (topOperator == '^')
            {
                double exponent = operandStack.Pop();
                double baseNumber = operandStack.Pop();
                double result = Math.Pow(baseNumber, exponent);
                operandStack.Push(result);
            }
            else
            {
                double rightOperand = operandStack.Pop();
                double leftOperand = operandStack.Pop();
                double result = _operatorEvaluator.EvaluateOperator(new Operator(topOperator, leftOperand, rightOperand));
                operandStack.Push(result);
            }
        }
    }
}