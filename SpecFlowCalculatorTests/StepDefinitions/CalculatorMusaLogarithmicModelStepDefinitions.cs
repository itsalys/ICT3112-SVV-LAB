using ICT3101_Calculator;
using NUnit.Framework;
using TechTalk.SpecFlow;

namespace SpecFlowCalculatorTests.StepDefinitions
{
    [Binding]
    public class CalculatorMusaLogarithmicModelStepDefinitions
    {
        private readonly CalculatorContext _context;
        private double _result;

        public CalculatorMusaLogarithmicModelStepDefinitions(CalculatorContext context)
        {
            _context = context;
        }

        [When(@"I have entered lambda_0 = (.*), th = (.*) , and u = (.*) into the calculator and press MusaLog failure intensity")]
        public void WhenIHaveEnteredLambdaThAndUIntoTheCalculatorAndPressFailureIntensity(double lambda_0, double th, double u)
        {
            _result = _context.Calculator.CalculateMusaLogFailureIntensity(lambda_0, th, u);
        }

        [Then(@"the MusaLog failure intensity result should be (.*)")]
        public void ThenTheMusaLogFailureIntensityResultShouldBe(double expectedFailureIntensity)
        {
            Assert.That(_result, Is.EqualTo(expectedFailureIntensity));
        }

        [When(@"I have entered lambda_0 = (.*), th = (.*), and t = (.*) into the calculator and press MusaLog expected failures")]
        public void WhenIHaveEnteredLambdaThAndTIntoTheCalculatorAndPressExpectedFailures(double lambda_0, double th, double t)
        {
            _result = _context.Calculator.CalculateMusaLogExpectedFailures(lambda_0, th, t);
        }

        [Then(@"the MusaLog expected failures result should be (.*)")]
        public void ThenTheExpectedFailuresResultShouldBe(double expectedFailures)
        {
            Assert.That(_result, Is.EqualTo(expectedFailures));
        }

        // [Then(@"the input for MusaLog failure intensity is invalid")]
        // public void ThenTheInputForFailureIntensityIsInvalid()
        // {
        //     Assert.That(_result, Is.EqualTo(-1)); // Assuming -1 indicates invalid input
        // }

        // [Then(@"the input for MusaLog expected failures is invalid")]
        // public void ThenTheInputForExpectedFailuresIsInvalid()
        // {
        //     Assert.That(_result, Is.EqualTo(-1)); // Assuming -1 indicates invalid input
        // }
    }
}
