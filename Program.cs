using System;

namespace HashingExamples
{
    class Program
    {
        static void Main(string[] args)
        {
            // Sizes for both the sample data and the table itself. (eventually user input)
            const int TableSize = 100;
            const int DataSize = 1000;
            
            // Array of random ints. This will be sample data for all hash tables
            int[] arrayOfRandomInts = GetArrayOfRandomInts(DataSize, 100000);
            
            // Create an empty chaining hash table
            ChainingHashTable chainingHashTable = new ChainingHashTable(TableSize);
            chainingHashTable.Populate(arrayOfRandomInts);
            chainingHashTable.Print();
        }

        static int[] GetArrayOfRandomInts(int size, int range)
        {
            // Pseudo-random number generator
            Random rand = new Random();
            int[] arr = new int[size];
            for (int i = 0; i < size; i++)
            {
                arr[i] = rand.Next(range);
            }
            return arr;
        }
    }
}
