using System;
using TestOurinvest.Ourinvest.View.ViewlModel;

namespace TestOurinvest
{
    class Program
    {
        static void Main(string[] args)
        {
            InitProgram();
        }

        private static void InitProgram()
        {
            Console.WriteLine("Digite 1 para lista ou 2 para expressão matemática (ou '0' para sair):");
            if (int.TryParse(Console.ReadLine(), out int typeExecution) && typeExecution != 0)
            {
                ExecuteOption(typeExecution);
            }
            else
            {
                Console.WriteLine("Encerrando o programa.");
            }
        }

        private static void ExecuteOption(int option)
        {
            switch (option)
            {
                case 1:
                    VMStandardList.RunListExecution();
                    break;
                case 2:
                    VMMathExpression.RunExpressionExecution();
                    break;
                default:
                    Console.WriteLine("Opção não reconhecida. Encerrando o programa.");
                    break;
            }
        }
    }
}