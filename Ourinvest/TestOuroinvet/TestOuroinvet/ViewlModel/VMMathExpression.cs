using System;
using Ourinvest.Domain.Helper;
using Ourinvest.Domain.Entities;
using Ourinvest.Domain.Interfaces.IHelper;
using Ourinvest.Domain.Interfaces.IEntities;

namespace TestOurinvest.Ourinvest.View.ViewlModel
{
    public static class VMMathExpression
    {
        private static readonly IOperatorEvaluator operatorEvaluator = new OperatorEvaluator();
        private static readonly IExpressionEvaluator expressionEvaluator = new ExpressionEvaluatorHelper(operatorEvaluator);
        public static void RunExpressionExecution()
        {
            bool running = true;
            while (running)
            {
                Console.WriteLine("Digite a expressão matemática (ou 'q' para sair):");
                string expression = Console.ReadLine();

                if (expression.ToLower() == "q")
                {
                    running = false;
                    continue;
                }

                try
                {
                    double result = expressionEvaluator.Evaluate(expression);
                    Console.WriteLine("Resultado: " + result);
                }
                catch (Exception ex)
                {
                    Console.WriteLine("Ocorreu um erro ao avaliar a expressão: " + ex.Message);
                }
            }

            Console.WriteLine("Encerrando o programa.");
        }
    }
}