using NUnit.Framework;
using Ourinvest.Domain.Helper;
using Ourinvest.Domain.Entities;

namespace Ourinvest.Tests
{
    [TestFixture]
    public class StandardListHelperTests
    {
        private StandardListHelper _standardListHelper;

        [SetUp]
        public void Setup()
        {
            // Configuração inicial para cada teste
            StandardList standardList = new StandardList();
            _standardListHelper = new StandardListHelper(standardList);
        }

        [Test]
        public void SearchForTheItemThatRepeatsTheMost_ShouldFindMostCommonItem()
        {
            // Arrange
            string listContent = "apple,banana,banana,orange,apple,banana";

            // Act
            (string mostCommonItem, int maxCount) = _standardListHelper.SearchForTheItemThatRepeatsTheMost(listContent);

            // Assert
            Assert.AreEqual("banana", mostCommonItem);
            Assert.AreEqual(3, maxCount);
        }

        [Test]
        public void SearchForTheItemThatRepeatsTheMost_ShouldHandleEmptyList()
        {
            // Arrange
            string listContent = "";

            // Act
            (string mostCommonItem, int maxCount) = _standardListHelper.SearchForTheItemThatRepeatsTheMost(listContent);

            // Assert
            Assert.AreEqual("", mostCommonItem);
            Assert.AreEqual(0, maxCount);
        }

        [Test]
        public void SearchForTheItemThatRepeatsTheMost_ShouldHandleSingleItem()
        {
            // Arrange
            string listContent = "apple";

            // Act
            (string mostCommonItem, int maxCount) = _standardListHelper.SearchForTheItemThatRepeatsTheMost(listContent);

            // Assert
            Assert.AreEqual("apple", mostCommonItem);
            Assert.AreEqual(1, maxCount);
        }
    }
}