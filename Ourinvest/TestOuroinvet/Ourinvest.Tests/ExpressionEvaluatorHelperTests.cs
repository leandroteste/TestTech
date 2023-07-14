using NUnit.Framework;
using Ourinvest.Domain.Helper;
using Ourinvest.Domain.Entities;
using Ourinvest.Domain.Interfaces.IHelper;
using Ourinvest.Domain.Interfaces.IEntities;

namespace Ourinvest.Tests
{
    [TestFixture]
    public class ExpressionEvaluatorHelperTests
    {
        private IOperatorEvaluator _operatorEvaluator;
        private IExpressionEvaluator _expressionEvaluator;

        [SetUp]
        public void Setup()
        {
            _operatorEvaluator = new OperatorEvaluator();
            _expressionEvaluator = new ExpressionEvaluatorHelper(_operatorEvaluator);
        }

        [Test]
        public void Evaluate_MultipleOperations_ReturnsCorrectResult()
        {
            string expression = "(2 + 3) * (4 - 1) / 2";
            double expected = 7.5;

            double result = _expressionEvaluator.Evaluate(expression);

            Assert.AreEqual(expected, result);
        }

        [Test]
        public void Evaluate_Exponentiation_ReturnsCorrectResult()
        {
            string expression = "2 ^ 3";
            double expected = 8.0;

            double result = _expressionEvaluator.Evaluate(expression);

            Assert.AreEqual(expected, result);
        }

        [Test]
        public void Evaluate_NestedExpressions_ReturnsCorrectResult()
        {
            string expression = "(2 + 3) * ((4 - 1) / 2)";
            double expected = 7.5;

            double result = _expressionEvaluator.Evaluate(expression);

            Assert.AreEqual(expected, result);
        }

        [Test]
        public void Evaluate_ComplexExpressionWithParentheses_ReturnsCorrectResult()
        {
            string expression = "((2 + 3) * (4 - 1)) / (2 + 2)";
            double expected = 3.75;

            double result = _expressionEvaluator.Evaluate(expression);

            Assert.AreEqual(expected, result);
        }
    }
}