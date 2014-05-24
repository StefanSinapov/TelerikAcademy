namespace CodeRefactoring
{
    using System;
    using System.Linq;

    public class Print
    {
        public void PrintStatistics(double[] arr, int lenghtOfArrat)
        {
            double maxValue = double.MinValue;
            for (int i = 0; i < lenghtOfArrat; i++)
            {
                if (arr[i] > maxValue)
                {
                    maxValue = arr[i];
                }
            }

            this.PrintMax(maxValue);

            double minValue = double.MaxValue;
            for (int i = 0; i < lenghtOfArrat; i++)
            {
                if (arr[i] < minValue)
                {
                    minValue = arr[i];
                }
            }

            this.PrintMin(minValue);

            double sumOfArray = 0;
            for (int i = 0; i < lenghtOfArrat; i++)
            {
                sumOfArray += arr[i];
            }

            double average = sumOfArray / lenghtOfArrat;
            this.PrintAvg(average);
        }

        public void PrintAvg(double average)
        {
            throw new NotImplementedException();
        }

        public void PrintMin(double min)
        {
            throw new NotImplementedException();
        }

        public void PrintMax(double max)
        {
            throw new NotImplementedException();
        }
    }
}
