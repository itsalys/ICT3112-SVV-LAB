# User Story 2: Musa Logarithmic Model for Failure Intensity and Expected Failures

# As a system quality engineer,
# I want to calculate the failure intensity an the number of expected failures of the system using the Musa Logarithmic model,
# So that I can predict the system’s reliability over time.

Feature: UsingCalculatorMusaLogarithmicModel
    In order to predict system reliability over time
    As a system quality engineer
    I want to calculate failure intensity and the number of expected failures using the Musa Logarithmic model

@MusaLogarithmicModel
Scenario: Calculating Failure Intensity
    Given I have a calculator
    When I have entered lambda_0 = 10, th = 0.02 , and u = 50 into the calculator and press MusaLog failure intensity
    Then the MusaLog failure intensity result should be 4

@MusaLogarithmicModel
Scenario: Calculating Expected Failures
    Given I have a calculator
    When I have entered lambda_0 = 10, th = 0.02, and t = 10 into the calculator and press MusaLog expected failures
    Then the MusaLog expected failures result should be 55