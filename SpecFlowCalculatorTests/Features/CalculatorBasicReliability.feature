Feature: UsingCalculatorBasicReliability
    In order to calculate the Basic Musa model's failures/intensities
    As a Software Quality Metric enthusiast
    I want to use my calculator to do this

@Reliability
Scenario: Calculating failure intensity
    Given I have a calculator
    When I have entered lambda_0 = 10, u = 50, and v_0 = 100 into the calculator and press failure intensity
    Then the failure intensity result should be 5

@Reliability
Scenario: Calculating expected number of failures
    Given I have a calculator
    When I have entered lambda_0 = 10, t = 10, and v_0 = 100 into the calculator and press expected failures
    Then the expected failures result should be 63
