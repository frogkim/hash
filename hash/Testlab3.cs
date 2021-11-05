// Jong-Young Choi
using System;
using System.IO;

namespace HashingLab
{
    class Testlab3
    {
        static readonly bool LinearProbing = true;
        static readonly bool QuadraticProbing = false;

        public static void Main(string[] args)
        {
            var logFile = new FileInfo("log.txt");
            string s;
            s = "Hello, log!";
            logFile.AppendText(logFile.LastWriteTime.ToString() + s);



            int capacity = 11;
            HashTable<Person> t = new HashTable<Person>(capacity, LinearProbing);

            //(c)stores a Person object p with name John Doe, age 20, SSN "000000001", repeatedly, a total of 11 times;
            Person p = new Person("John Doe", "000000001", 20);
           for(int i=0; i<11; i++)
            {
                t.addItem(p);
            }
            //(d)attempts to store the Person John Doe again;
            try
            {
                t.addItem(p);
            // } catch (IndexOutOfRangeException e)
            }
            catch(Exception e)
            {
                // Console.WriteLine("Adding Person object p is failed because of full capacity.");
                Console.WriteLine("Oops! we got the following exeptions:" + e);
            }
            
            //(e)creates a new Person object x with SSN "000000001" but no name or age, and calls retrieveItem to get this Person.
            // Person x = new Person("", "000000001", 0);
            Person x = new Person("000000001");
            if (t.retrieveItem(ref x))
            {
                Console.WriteLine("Success to retrieve x");
            }
            else
            {
                Console.WriteLine("Fail to retrieve x");
            }
            //5. Write C# code that

            //(a) creates a HashTable t with the capacity to store 11 Person objects using quadratic probing
            //  (note that the actual size stored internally may differ: see exercise 4(b) above);
            
            t = new HashTable<Person>(capacity, QuadraticProbing);
            //(b)stores the Person p from Question #2(c) above, repeatedly, until the hash table is full.
            for (int i = 0; i < capacity; i++)
            {
                t.addItem(p);
            }
            
            // not required testlab.
            // try 4(d) with quadratic
            // 11 is a good number as a size for quadratic probing.
            // hashtable's size will be 11 and this try will throw exception
            try
            {
                t.addItem(p);
                // } catch (IndexOutOfRangeException e)
            }
            catch (Exception e)
            {
                // Console.WriteLine("Adding Person object p is failed because of full capacity.");
                Console.WriteLine("Oops! we got the following exeptions:" + e);
            }
            // Is it possible to make a Person object with zero SSN?
            p = new Person("000000000");
            Console.WriteLine("Making zero SSN person object done.");

            // Is it possible to add to HashTable with zero SSN person?
            t = new HashTable<Person>(capacity, LinearProbing);
            t.addItem(p);
            Console.WriteLine("Adding zero SSN person to Linear Probing Hash table done.");

            t = new HashTable<Person>(capacity, QuadraticProbing);
            t.addItem(p);
            Console.WriteLine("Adding zero SSN person to Quadratic Probing Hash table done.");

        }
    }
}
