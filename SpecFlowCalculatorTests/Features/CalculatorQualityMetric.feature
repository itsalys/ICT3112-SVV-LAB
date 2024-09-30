# User Story 1: Quality Metric Calculations for Defect Density and SSI

# As a system quality engineer,
# I want to calculate defect density and the total number of Shipped Source Instructions (SSI) for successive releases starting from the second release,
# So that I can assess code quality and track codebase changes over time.

Feature: UsingCalculatorQualityMetrics
    In order to assess code quality and track codebase changes over time
    As a system quality engineer
    I want to calculate defect density and the total number of Shipped Source Instructions (SSI)

@QualityMetrics
Scenario: Calculating Defect Density
    Given I have a calculator
    When I have entered 1000 lines of code and 50 defects into the calculator and press defect density
    Then the defect density result should be 0.05 defects per line of code

@QualityMetrics
Scenario: Calculating SSI for Successive Releases
    Given I have a calculator
    When I have entered 50 for the SSI (previous release), 20 for the CSI (current version), 2 for the deleted code and 2 for the changed code into the calculator and press total SSI
    Then the total SSI result should be 66

