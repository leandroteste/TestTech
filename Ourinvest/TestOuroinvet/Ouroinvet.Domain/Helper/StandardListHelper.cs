using System.Collections.Generic;
using Ourinvest.Domain.Interfaces.IHelper;
using Ourinvest.Domain.Interfaces.IEntities;

namespace Ourinvest.Domain.Helper
{
    public class StandardListHelper : IStandardListHelper
    {
        private readonly IStandardList _standardList;

        public StandardListHelper(IStandardList standardList)
        {
            _standardList = standardList;
        }

        public (string MostCommonItem, int MaxCount) SearchForTheItemThatRepeatsTheMost(string listContent)
        {
            Dictionary<string, int> itemCounts = new Dictionary<string, int>();

            int maxCount = 0;
            string mostCommonItem = "";

            foreach (string item in _standardList.GetListContent(listContent))
            {
                if (itemCounts.ContainsKey(item))
                {
                    itemCounts[item]++;
                }
                else
                {
                    itemCounts[item] = 1;
                }

                if (itemCounts[item] > maxCount)
                {
                    mostCommonItem = item;
                    maxCount = itemCounts[item];
                }
            }

            return (mostCommonItem, maxCount);
        }
    }
}