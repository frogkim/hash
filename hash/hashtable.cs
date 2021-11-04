// Jong-Young Choi

//Make sure that each of your class methods is functional!
//You may add private members to HashTable, but do NOT change the public interface.
//
//Use the same algorithm for hashFunction that you submitted in Test Plan #3.
//Use the second constructor argument to determine the type of probing used: Implement quadratic probing if the value of "useLinearProbing" is false.

//Test your HashTable class against Test Plan #3. Does your code pass the tests?
//Make sure that your name appears in a comment at the top of each source file. Submit all source files, including the test code, after first compressing them into a single file using the Windows file compression utility (NOT a commercial utility); the file extension should be .zip.
using System;

namespace HashingLab
{
    class HashTable<T> // specifies a "generic" class with type parameter T. it is moer supposed general
    where T : IKeyed   // forces T to implement the Ikeyed interface
    {
        // Do not add data member - it's the same with global variable in C
        private T[] items;
        private bool linearProbing;
        private bool[] occupied;

        public HashTable(int theSize, bool useLinearProbing = false)//optional parameter useLinearProbing defaults to false
        {
            if(theSize < 0) throw (new Exception("The size of hastable must be positive."));

            // constructor's job is to initialize the instance variables
            // bracket!
            linearProbing = useLinearProbing;
            // if quadratic probing is used, we must satisfy Theorem Q.
            if(!linearProbing)
            {
                getNextGoodSizeForQuadraticProbing(ref theSize);
            }
            items = new T[theSize]; // default value, we don't know yet
            occupied = new bool[theSize]; // bool defaults to false, good!
        }

        private void getNextGoodSizeForQuadraticProbing(ref int theSize)
        {
            while(!satisfiesTheoremQ(theSize))
            {
                theSize++;
            }
        }
        private bool satisfiesTheoremQ(int theSize)
        {
            if( theSize == 1 || theSize == 2) return true;
            else if(isPrime(theSize) && theSize % 4 == 3) return true;
            else if(theSize % 2 == 0)
            {
                int half = theSize / 2;
                if(isPrime(half) && half % 4 == 3) return true;
            }
            return false;
        }
        private bool isPrime(int theSize)
        {
            int divider = 2;
            while(divider < theSize)
            {
                if(theSize % divider == 0) return false;
                divider++;
            }
            return true;
        }

        public void addItem(T theItem)
        {
            int keyValue = theItem.getKey();
            int homePosition = hashFunction(keyValue);
            // int m = items.Length; it is not C# style.
            for (int i = 0; i < items.Length; i++)
            {
                // compute the probe index d = p(e,i)
                // int index = probe(linearProbing, homePosition, i);
                int index;
                if (linearProbing)
                {
                    index = linearProbe(homePosition, i);
                }
                else
                {
                    index = quadraticProbe(homePosition, i);
                }
                
                if (!occupied[index])
                {
                    items[index] = theItem;
                    occupied[index] = true;
                    return;
                }
            }
            throw new Exception("Not enough capacity");
        }

        //private int probe(bool linear, int homePosition, int probeIndex)
        //{
        //    int index = -1;
        //    if(linear)
        //    {
        //        index = e + probeIndex;
        //    }
        //    else
        //    {
        // TODO: Check here again
        //        // (i + 1)/2 * (i + 1)/2 * (-1)^(i+1)  
        //        int sign = (int) Math.Pow(-1, probeIndex + 1);
        //        index = (probeIndex + 1) / 2;
        //        index = index * index * sign;
        //        index = homePosition + index;
        //    }
        //    index = index % items.Length;    
        //    return index;
        //}

        private int linearProbe(int homePosition, int probeIndex)
        {
            return (homePosition + probeIndex) % items.Length;

        }

        private int quadraticProbe(int homePosition, int probeIndex)
        {
            // TODO: Check here again
            int sign = (int)Math.Pow(-1, probeIndex + 1);
            int index = (probeIndex + 1) / 2;
            index = index * index * sign;
            index = homePosition + index;
            index = index % items.Length;
            return index;
        }


        public bool retrieveItem(ref T theItem)//theItem comes with its key fields filled, returns with all fields filled if found
        {
            // if we find theItem in items at index d, then
            // then we should fill in all fields of theItem using items[d]'s values.
            // like this: theItem = items[d];

            int k = theItem.getKey();
            int e = hashFunction(k);
            return false;
        }

        private int hashFunction(int keyValue)
        {
            if (keyValue < 0) throw new Exception("Key value must be at least greater than zero");
            // getKey method is implemented by user, not hashtable creater.
            // It is needed to be confirmed by hashtabel creator.

            int theNumber = keyValue, firstHalf = 0, secondHalf = 0;
            // Step 1 - 5: iterate 3 times
            for(int i = 0; i < 3; i++)
            {
                // Step 1
                splitNumber(theNumber, ref firstHalf, ref secondHalf);
                // Step 2
                if( firstHalf == 0 ) firstHalf = 17;
                if( secondHalf == 0 ) secondHalf = 17;
                // Step 3
                theNumber = firstHalf * secondHalf;
                // Step 4
                theNumber += 9;
                // Step 5
                // TODO: Check here again
                theNumber = theNumber % items.Length;
            }
            return theNumber;
        }
        private void splitNumber(int theNumber, ref int firstHalf, ref int secondHalf)
        {
            int digit = getDigit(theNumber);
            int firstDigit = digit / 2;
            int secondDigit = firstDigit;
            if( (digit / 2) > firstDigit)
            {
                secondDigit++;
            }
            int zeros = (int) Math.Pow(10, secondDigit);
            firstHalf = theNumber / zeros;
            secondHalf = theNumber - firstHalf * zeros;
        }

        private int getDigit(int theNumber)
        {
            int digit = 0;
            while( theNumber > 0 )
            {
                theNumber /= 10;
                digit++;
            }
            return digit;
        }
    }
}

interface IKeyed
{
    public int getKey();
}