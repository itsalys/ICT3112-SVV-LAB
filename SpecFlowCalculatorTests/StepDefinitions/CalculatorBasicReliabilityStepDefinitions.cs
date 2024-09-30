using ICT3101_Calculator;
using NUnit.Framework;
using TechTalk.SpecFlow;

namespace SpecFlowCalculatorTests.StepDefinitions
{
    [Binding]
    public class CalculatorBasicReliabilityStepDefinitions
    {
        private readonly CalculatorContext _context;
        private double _result;

        public CalculatorBasicReliabilityStepDefinitions(CalculatorContext context)
        {
            _context = context;
        }

        [When(@"I have entered lambda_0 = (.*), u = (.*), and v_0 = (.*) into the calculator and press failure intensity")]
        public void WhenIHaveEnteredLambdaMuAndVIntoTheCalculatorAndPressFailureIntensity(double lambda_0, double u, double v_0)
        {
            _result = _context.Calculator.CalculateFailureIntensity(lambda_0, u, v_0);
        }

        [Then(@"the failure intensity result should be (.*)")]
        public void ThenTheFailureIntensityResultShouldBe(double expectedValue)
        {
            Assert.That(_result, Is.EqualTo(expectedValue));
        }

        [When(@"I have entered lambda_0 = (.*), t = (.*), and v_0 = (.*) into the calculator and press expected failures")]
        public void WhenIHaveEnteredLambdaTauAndVIntoTheCalculatorAndPressExpectedFailures(double lambda_0, double t, double v_0)
        {
            _result = _context.Calculator.CalculateExpectedFailures(lambda_0, t, v_0);
        }

        [Then(@"the expected failures result should be (.*)")]
        public void ThenTheExpectedFailuresResultShouldBe(double expectedValue)
        {
            Assert.That(Math.Round(_result, 3), Is.EqualTo(expectedValue));  // Rounded to 3 decimal places
        }
    }
}
