using ICT3101_Calculator;
using NUnit.Framework;
using TechTalk.SpecFlow;

namespace SpecFlowCalculatorTests.StepDefinitions
{
    [Binding]
    public class CalculatorQualityMetricsStepDefinitions
    {
        private readonly CalculatorContext _context;
        private double _result;

        public CalculatorQualityMetricsStepDefinitions(CalculatorContext context)
        {
            _context = context;
        }

        [When(@"I have entered (.*) lines of code and (.*) defects into the calculator and press defect density")]
        public void WhenIHaveEnteredLinesOfCodeAndDefectsIntoTheCalculatorAndPressDefectDensity(int linesOfCode, int defects)
        {
            _result = _context.Calculator.CalculateDefectDensity(linesOfCode, defects);
        }

        [Then(@"the defect density result should be (.*) defects per line of code")]
        public void ThenTheDefectDensityResultShouldBe(double expectedDefectDensity)
        {
            Assert.That(_result, Is.EqualTo(expectedDefectDensity));
        }

        [When(@"I have entered (.*) for the SSI \(previous release\), (.*) for the CSI \(current version\), (.*) for the deleted code and (.*) for the changed code into the calculator and press total SSI")]
        public void WhenIHaveEnteredForTheFirstReleaseAndForTheSecondReleaseIntoTheCalculatorAndPressTotalSSI(int SSI, int CSI, int delCode, int changeCode)
        {
            _result = _context.Calculator.CalculateTotalSSI(SSI, CSI, delCode, changeCode);
        }

        [Then(@"the total SSI result should be (.*)")]
        public void ThenTheTotalSSIResultShouldBe(int expectedTotalSSI)
        {
            Assert.That(_result, Is.EqualTo(expectedTotalSSI));
        }

        // [Then(@"the input for defect density is invalid")]
        // public void ThenTheInputForDefectDensityIsInvalid()
        // {
        //     Assert.That(_result, Is.EqualTo(-1)); // Assuming -1 indicates invalid input
        // }

        // [Then(@"the input for total SSI is invalid")]
        // public void ThenTheInputForTotalSSIIsInvalid()
        // {
        //     Assert.That(_result, Is.EqualTo(-1)); // Assuming -1 indicates invalid input
        // }
    }
}
