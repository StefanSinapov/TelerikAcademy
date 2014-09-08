namespace Company.DataGenerators.Contracts
{
    using System.Collections.Generic;
    using Common;

    public interface IRandomDataGenerator
    {
        string GetRandomStringExact(int length, string charsToUse = RandomDataGenerator.AllLeters);

        string GetRandomString(int min, int max, string charsToUse = RandomDataGenerator.AllLeters);
        
        string GetRandomStringOrNull(int min, int max, int percent);
        
        int GetRandomInt(int min, int max);
        
        double GetRandomDouble();
        
        IList<string> GetUniqueStringsCollection(int minLength, int maxLength, int count);
        
        bool GetChance(int percent);
    }
}