﻿namespace Company.DataGenerators.Common
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using Contracts;

    public class RandomDataGenerator : IRandomDataGenerator
    {
        /// <summary>
        /// Represent all digits - 1234567890
        /// </summary>
        public const string Digits = "1234567890";

        /// <summary>
        /// Represent all small Latin letters - abcdefghijklmnopqrstuvwxyz
        /// </summary>
        public const string SmallLetters = "abcdefghijklmnopqrstuvwxyz";

        /// <summary>
        /// Represent all capital Latin letters - ABCDEFGHIJKLMNOPQRSTUVWXYZ
        /// </summary>
        public const string CapitalLetters = "ABCDEFGHIJKLMNOPQRSTUVWXYZ";

        /// <summary>
        /// Represent all capital and small Latin letters - abcdefghijklmnopqrstuvwxyzABCDEFGHIJKLMNOPQRSTUVWXYZ
        /// </summary>
        public const string AllLeters = "abcdefghijklmnopqrstuvwxyzABCDEFGHIJKLMNOPQRSTUVWXYZ";

        /// <summary>
        /// Represent all capital and small Latin letters and digits- abcdefghijklmnopqrstuvwxyzABCDEFGHIJKLMNOPQRSTUVWXYZ1234567890
        /// </summary>
        public const string AllLettersAndDigits = "abcdefghijklmnopqrstuvwxyzABCDEFGHIJKLMNOPQRSTUVWXYZ1234567890";

        private static RandomDataGenerator instance;

        private readonly Random random;

        private RandomDataGenerator()
        {
            this.random = new Random();
        }

        public static RandomDataGenerator Instance
        {
            get
            {
                if (instance == null)
                {
                    instance = new RandomDataGenerator();
                }

                return instance;
            }
        }

        public string GetRandomStringExact(int length, string charsToUse = AllLeters)
        {
            var result = new char[length];

            for (int i = 0; i < length; i++)
            {
                result[i] = charsToUse[this.random.Next(0, charsToUse.Length)];
            }

            return new string(result);
        }

        public string GetRandomString(int min, int max, string charsToUse = AllLeters)
        {
            return this.GetRandomStringExact(this.random.Next(min, max + 1), charsToUse);
        }

        public string GetRandomStringOrNull(int min, int max, int percent)
        {
            return this.GetChance(percent) ? null : this.GetRandomString(min, max);
        }

        public int GetRandomInt(int min, int max)
        {
            return this.random.Next(min, max + 1);
        }

        public double GetRandomDouble()
        {
            return this.random.NextDouble();
        }

        public DateTime GetRandomDate(DateTime startDate, DateTime endDate)
        {
            var range = endDate - startDate;

            var randTimeSpan = new TimeSpan((long)(this.random.NextDouble() * range.Ticks));

            return startDate + randTimeSpan;
        }


        public IList<string> GetUniqueStringsCollection(int minLength, int maxLength, int count)
        {
            var uniqueStrings = new HashSet<string>();

            while (uniqueStrings.Count != count)
            {
                uniqueStrings.Add(Instance.GetRandomString(minLength, maxLength));
            }

            return uniqueStrings.ToList();
        }

        public bool GetChance(int percent)
        {
            return this.random.Next(0, 101) <= percent;
        }
    }
}