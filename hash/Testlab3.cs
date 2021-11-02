// Jong-Young Choi

//This assignment concerns a HashTable generic class written to fulfill the requirements for Lab #3.
//In particular, the hash function is given in Question #1 below. In each of the tests below, work out the expected results manually and show your work.

//1. Let h be a hash function defined by iterating the following five steps 3 times:
//(i)split the input equally into two halves using folding
//      (in case the number of digits is odd, group the greater number of digits into the second half);
//(ii) if either half is 0, then replace it with 17;
//(iii) multiply the two halves together;
//(iv) add the number 9;
//(v) mod out by the table size.

//For example: to compute h(56000) with m = 10, we proceed as follows:
//(i)split into 56 and 000;
//(ii)replace 000 with 17;
//(iii)multiply 56 by 17 to get 952;
//(iv)add 9 to get 961;
//(v)mod out by 10 to get 1.

//Loop back to get
//(i) 0 and 1;
//(ii)17 and 1;
//(iii)17;
//(iv)26;
//(v)6.
//
//Loop back once more to get
//(i) 0 and 6;
//(ii)17 and 6;
//(iii)102;
//(iv)111;
//(v)1.So h(56000) = 1.

//(a)Compute BY HAND the value h(1), with m = 11.
//(b) Compute BY HAND the value h(34), with m = 15.


//2. Write C# code that

//(a) creates a class called Person which implements the IKeyed interface.
//  A Person should have a name and SSN (which are strings), and an age;
//  the "getKey" method of Person should return the numeric value of the SSN;
//(b)creates a HashTable t with the capacity to store 11 values of type Person using linear probing;
//(c)stores a Person object p with name John Doe, age 20, SSN "000000001", repeatedly, a total of 11 times;
//(d)attempts to store the Person John Doe again;
//(e)creates a new Person object x with SSN "000000001" but no name or age, and calls retrieveItem to get this Person.

//3. (a) Manually compute the state of the hash table after each call to addItem for the code you wrote in exercise #2 above.
//          Make a list of all the indexes in the order in which the items will be stored.
//(b) What should happen when the code from exercise 2(d) is run ?
//(c) What should x look like after the code from exercise 2(e) is run ?

//4. (a) Is 11 a good value for the size of a hash table using quadratic probing? Why or why not?
//(b) If your answer to part (a) above was No, then what should the HashTable set the actual size to be when the user tells it to use size 11?
//(c),(d)Repeat exercises 4(a),(b)with 11 replaced by 15.

//5. Write C# code that

//(a) creates a HashTable t with the capacity to store 11 Person objects using quadratic probing
//  (note that the actual size stored internally may differ: see exercise 4(b) above);
//(b)stores the Person p from Question #2(c) above, repeatedly, until the hash table is full.

//6. Manually compute the state of the hash table after each call to addItem for the code you wrote in Exercise 5 above.
//  Make a list of all the indexes in the order in which the items will be stored.

using System;

namespace HashingLab
{

    class Testlab3
    {
        static readonly bool LinearProbing = true;
        static readonly bool QuadraticProbing = false;

        public static void Main(string[] args)
        {
            Person p = new Person("Pat Smith", "123123123", 18);
            // int k = p.getKey();

            /*
            IKeyed kp = p;
            int k = kp.getKey();

             */

            //(b)creates a HashTable t with the capacity to store 11 values of type Person using linear probing;
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

            // 3.
            // p.getKey() will




            //5. Write C# code that

            //(a) creates a HashTable t with the capacity to store 11 Person objects using quadratic probing
            //  (note that the actual size stored internally may differ: see exercise 4(b) above);
            t = new HashTable<Person>(capacity, QuadraticProbing);
            //(b)stores the Person p from Question #2(c) above, repeatedly, until the hash table is full.
            for (int i = 0; i < capacity; i++)
            {
                t.addItem(p);
            }

        }
    }
}
