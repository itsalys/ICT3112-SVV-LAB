Feature: UsingCalculatorFactorial
    In order to understand factorial calculations
    As a math enthusiast
    I want to correctly calculate factorials for different numbers

@Factorials
Scenario: Calculate the factorial of a normal number
    Given I have a calculator
    When I have entered 5 into the calculator and press factorial
    Then the factorial result should be 120

@Factorials
Scenario: Calculate the factorial of zero
    Given I have a calculator
    When I have entered 0 into the calculator and press factorial
    Then the factorial result should be 1
