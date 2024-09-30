using System;
using System.Linq;

namespace ICT3101_Calculator
{
    public class Calculator
    {
        public Calculator() { }

public double DoOperation(double num1, double num2, double num3, double num4, string op)
{
    double result = double.NaN; // Default value
    
    switch (op)
    {
        case "a": // Add
            result = Add(num1, num2);
            break;
        case "s": // Subtract
            result = Subtract(num1, num2);
            break;
        case "m": // Multiply
            result = Multiply(num1, num2);
            break;
        case "d": // Divide
            result = Divide(num1, num2);
            break;
        case "f": // Factorial
            result = Factorial(num1);
            break;
        case "t": // Area of Triangle
            result = AreaOfTriangle(num1, num2);
            break;
        case "c": // Area of Circle
            result = AreaOfCircle(num1);
            break;
        case "u": // Unknown Function A
            result = UnknownFunctionA((int)num1, (int)num2);
            break;
        case "b": // Unknown Function B
            result = UnknownFunctionB((int)num1, (int)num2);
            break;
        case "1": // Mean Time Between Failures (MTBF)
            result = CalculateMTBF(num1, num2);
            break;
        case "2": // Availability
            result = CalculateAvailability(num1, num2);
            break;
        case "3": // Defect Density
            result = CalculateFailureIntensity(num1, num2, num3);
            break;
        case "4": // Total SSI
            result = CalculateExpectedFailures(num1, num2, num3);
            break;
        case "5": // Musa Log Failure Intensity
            result = CalculateMusaLogFailureIntensity(num1, num2, num3);
            break;
        case "6": // Musa Log Expected Failures
            result = CalculateMusaLogExpectedFailures(num1, num2, num3);
            break;
        case "7": // Defect Density
            result = CalculateDefectDensity(num1, num2);
            break;
        case "8": // Total SSI
            result = CalculateTotalSSI(num1, num2, num3, num4);
            break;
        default:
            throw new ArgumentException("Invalid operation");
    }
    return result;
}


        public double Add(double num1, double num2)
        {
           // see if both numbers in String only contains 0 and 1s (binary)
           // convert num1 and num2 into string           
           string num1String = num1.ToString("F0");
           string num2String = num2.ToString("F0");
           // check if num1 and num2 are binary           
           if (num1String.All(c => c == '0' || c == '1') && num2String.All(c => c == '0' ||  c == '1'))
           {               
                return Convert.ToInt32( (num1String + num2String), 2);
           }
           return (num1 + num2);       
        }
//         {

//             return num1+num2;

// // LAB 2 - Task 9
//             string val3 = num1.ToString() + num2.ToString();
//             return Convert.ToInt32(val3, 2);
//         }

        public double Subtract(double num1, double num2)
        {
            return num1 - num2;
        }

        public double Multiply(double num1, double num2)
        {
            return num1 * num2;
        }

        public double Divide(double num1, double num2)
        {        
            // if (num1 == 0 || num2 == 0)
            // {
            //     throw new ArgumentException("Cannot divide or divide by zero.");
            // }

            // LAB 2 - Task 9
                if (num1 == 0 && num2 == 0) return 1;
                if (num2 == 0) return double.PositiveInfinity; 

            return num1 / num2;
        }

        // Task 15
        public double Factorial(double num)
        {
            if (num < 0)
            {
                throw new ArgumentException("Factorial is not defined for negative numbers.");
            }

            if (num % 1 != 0)
            {
                throw new ArgumentException("Factorial is not defined for decimal numbers.");
            }

            if (num == 0 || num == 1)
            {
                return 1;
            }

            double result = 1;
            for (int i = 2; i <= num; i++)
            {
                result *= i;
            }
            return result;
        }
    
        // Task 16 - Area of Triangle
        public double AreaOfTriangle(double height, double baseLength)
        {
            if (height <= 0 || baseLength <= 0)
            {
                throw new ArgumentException("Height and base length must be positive numbers.");
            }

            return (height * baseLength) / 2;
        }

        // Task 16 - Area of Circle
        public double AreaOfCircle(double radius)
        {
            if (radius <= 0)
            {
                throw new ArgumentException("Radius must be a positive number.");
            }

            return Math.PI * Math.Pow(radius, 2);
        }

        // Task 17 - UnknownFunctionA
        public double UnknownFunctionA(int num1, int num2)
        {
            if (num1 < 0 || num2 < 0)
            {
                throw new ArgumentException("Negative inputs are not allowed");
            }

            return Factorial(num1) / Factorial(Subtract(num1, num2));
        }


            // Task 17 - UnknownFunctionB
        public double UnknownFunctionB(int num1, int num2)
        {
            if (num1 < 0 || num2 < 0)
            {
                throw new ArgumentException("Negative inputs are not allowed");
            }

            return Factorial(num1) / Multiply(Factorial(num2), Factorial(Subtract(num1, num2)));
        }

        // LAB 2 - Task 17 - Availability

        public double CalculateMTBF(double mttf, double mttr)
        {
            if (mttf < 0 || mttr < 0)
            {
                return -1;  
            }
            return mttf + mttr;
        }

        public double CalculateAvailability(double mttf, double mttr)
        {
            if (mttf < 0 || mttr < 0)
            {
                return -1;  
            }
            double mtbf = CalculateMTBF(mttf, mttr);
            return mttf / mtbf;
        }

        // LAB 2 - Task 18 - Reliability

        public double CalculateFailureIntensity(double lambda_0, double u, double v_0)
        {
            double result = lambda_0 * (1 - (u / v_0));
            return Math.Round(result, 0);  
        }

        public double CalculateExpectedFailures(double lambda_0, double t, double v_0)
        {
            double result = v_0 * (1 - Math.Exp(-(lambda_0 / v_0)*t));
            return Math.Round(result, 0);  
        }

        // LAB 2.3

        public double CalculateDefectDensity(double linesOfCode, double defects)
        {
            if (linesOfCode <= 0 || defects < 0)
            {
                return -1;  
            }
            return defects / linesOfCode;
        }

        public double CalculateTotalSSI(double SSI, double CSI, double delCode, double changeCode)
        {
            if (SSI < 0 || CSI < 0 || delCode < 0 || changeCode < 0)
            {
                return -1;  
            }
            double result = SSI + CSI - delCode - changeCode;
            return Math.Round(result, 0);
        }

        public double CalculateMusaLogFailureIntensity(double lambda_0, double th, double u)
        {
            double result = lambda_0 * Math.Exp(-th * u);
            return Math.Round(result, 0);  
        }
        

        public double CalculateMusaLogExpectedFailures(double lambda_0, double th, double t)
        {
            double result = (1 / th) * Math.Log((lambda_0 * th * t) + 1);
            return Math.Round(result, 0);  
        }

    }   

}