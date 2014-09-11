﻿using System;

namespace WcfServiceCalculator.Console
{
    public class ServiceCalculator : IServiceCalculator
    {
        public int Calculate(int firstValue, int secondValue, 
            CalculationOperation operationType)
        {
            switch (operationType)
            {
                case CalculationOperation.Add:
                    return firstValue + secondValue;
                case CalculationOperation.Substract:
                    return firstValue - secondValue;
                case CalculationOperation.Multiply:
                    return firstValue * secondValue;
                case CalculationOperation.Divide:
                    return firstValue / secondValue;
                default:
                    throw new ArgumentException("Invalid operation");
            }
        }
    }
}
