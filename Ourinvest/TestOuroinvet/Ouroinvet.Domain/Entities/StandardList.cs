using Ourinvest.Domain.Interfaces.IEntities;

namespace Ourinvest.Domain.Entities
{
    public class StandardList : IStandardList
    {
        public string[] ListContent { get; private set; }

        public StandardList() { }

        public string[] GetListContent(string listContent)
        {
            if (string.IsNullOrEmpty(listContent))
            {
                ListContent = new string[0];
            }
            else
            {
                ListContent = listContent.Trim().Replace(';', ',').Split(',');
            }

            return ListContent;
        }
    }
}