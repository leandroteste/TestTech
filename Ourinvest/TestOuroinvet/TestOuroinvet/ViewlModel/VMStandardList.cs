using System;
using Ourinvest.Domain.Helper;
using Ourinvest.Domain.Entities;

namespace TestOurinvest.Ourinvest.View.ViewlModel
{
    public static class VMStandardList
    {
        private static readonly StandardListHelper _standardListHelper = new StandardListHelper(new StandardList());

        public static void RunListExecution()
        {
            bool running = true;
            while (running)
            {
                Console.WriteLine("Digite a lista separada por vírgulas (ou 'q' para sair):");
                string input = Console.ReadLine();

                if (input.ToLower() == "q")
                {
                    running = false;
                    continue;
                }

                (string MostCommonItem, int MaxCount) = _standardListHelper.SearchForTheItemThatRepeatsTheMost(input);

                Console.WriteLine();
                Console.WriteLine($"Item mais comum: {MostCommonItem}");
                Console.WriteLine($"Contagem máxima: {MaxCount}");
                Console.WriteLine();
            }

            Console.WriteLine("Encerrando o programa.");
        }
    }
}