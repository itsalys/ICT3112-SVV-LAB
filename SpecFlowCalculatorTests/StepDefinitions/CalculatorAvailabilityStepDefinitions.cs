using ICT3101_Calculator;
using NUnit.Framework;
using TechTalk.SpecFlow;

namespace SpecFlowCalculatorTests.StepDefinitions
{
    [Binding]
    public class CalculatorAvailabilityStepDefinitions
    {
        private readonly CalculatorContext _context;
        private double _result;

        public CalculatorAvailabilityStepDefinitions(CalculatorContext context)
        {
            _context = context;
        }

        [When(@"I have entered (.*) and (.*) into the calculator and press MTBF")]
        public void WhenIHaveEnteredAndIntoTheCalculatorAndPressMTBF(double mttf, double mttr)
        {
            _result = _context.Calculator.CalculateMTBF(mttf, mttr);
        }

        [Then(@"the MTBF result should be (.*)")]
        public void ThenTheMTBFResultShouldBe(double expectedMTBF)
        {
            Assert.That(_result, Is.EqualTo(expectedMTBF));
        }

        [Then(@"the input for MTBF is invalid")]
        public void ThenTheMTBFResultShouldBeInvalid()
        {
            Assert.That(_result, Is.EqualTo(-1));
        }

        [When(@"I have entered (.*) and (.*) into the calculator and press Availability")]
        public void WhenIHaveEnteredAndIntoTheCalculatorAndPressAvailability(double mttf, double mttr)
        {
            _result = _context.Calculator.CalculateAvailability(mttf, mttr);
        }

        [Then(@"the availability result should be (.*)")]
        public void ThenTheAvailabilityResultShouldBe(double expectedAvailability)
        {
            Assert.That(Math.Round(_result, 3), Is.EqualTo(expectedAvailability));  // Rounding to 3 decimal places
        }

        [Then(@"the input for availability is invalid")]
        public void ThenTheAvailabilityResultShouldBeInvalid()
        {
            Assert.That(Math.Round(_result, 3), Is.EqualTo(-1));
        }
    }
}
