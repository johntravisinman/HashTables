using System;

namespace HashingExamples
{
    // The entry that will be stored in the hash tables
    public class HashEntry
    {
        // private field for data in hash entry
        private int data;
        // public property to access the data in the hash entry
        public int Data
        {
            get { return data; }
            set { data = value; }
        }
        // The next hash entry
        public HashEntry next;
        // Constructor
        public HashEntry(int data)
        {
            this.data = data;
            next = null;
        }
        // Default Constructor
        public HashEntry()
        {
            data = 0;
            next = null;
        }
    }
    // Hash table using chaining
    public class HashChain
    {
        // The hash table (just an array of hash entries)
        private HashEntry[] hashTable;
        private int size;
        // Constructor
        public HashChain(int size)
        {
            // create an empty hashTable
            hashTable = new HashEntry[size];
            for(int i = 0; i < size; i++)
            {
                hashTable[i] = null;
            }
            // set the size field
            this.size = size;
        }
        // Populate the hash table with the given values
        public void Populate(int[] values, int numberOfValues)
        {
            int key;
            for(int i = 0; i < numberOfValues; i++)
            {
                // Simple hash on the value to get the key
                // key = value % tableSize
                key = values[i] % size;
                // No collision
                if (hashTable[key] == null)
                {
                    // Store the new entry
                    hashTable[key] = new HashEntry(values[i]);
                }
                // Collision. So chain
                else
                {
                    HashEntry tempEntry = hashTable[key];
                    // Loop through the chain until the end
                    while (tempEntry.next != null)
                    {
                        tempEntry = tempEntry.next;
                    }
                    // Store the new entry
                    tempEntry.next = new HashEntry(values[i]);
                }

            }
        }

        // Print the hash table
        public void Print()
        {
            Console.WriteLine("Key\tValue");
            for(int i = 0; i < size; i++)
            {
                // Empty
                if(hashTable[i] == null)
                {
                    Console.WriteLine(i + "\tnull");
                }
                // Non-Empty
                else
                {
                    // Get the first chained entry
                    HashEntry nextEntry = hashTable[i].next;
                    Console.Write(i + "\t" + hashTable[i].Data);
                    while(nextEntry != null)
                    {
                        Console.Write(" -> " + nextEntry.Data);
                    }
                }
                Console.WriteLine("");
            }
        }
    }
    class Program
    {
        static void Main(string[] args)
        {
            // Array of random ints
            int[] randArray = GetArrayOfRandomInts(100, 100000);

        }

        static int[] GetArrayOfRandomInts(int size, int range)
        {
            // Pseudo-random number generator
            Random rand = new Random();
            int[] arr = new int[size];
            for(int i = 0; i < size; i++)
            {
                arr[i] = rand.Next(range);
            }
            return arr;
        }
    }
}
