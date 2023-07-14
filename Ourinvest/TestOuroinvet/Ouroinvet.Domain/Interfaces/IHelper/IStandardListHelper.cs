namespace Ourinvest.Domain.Interfaces.IHelper
{
    public interface IStandardListHelper
    {
        (string MostCommonItem, int MaxCount) SearchForTheItemThatRepeatsTheMost(string listContent);
    }
}