// Jong-Young Choi
using System;

namespace HashingLab
{
    class HashTable<T> 
    where T : IKeyed   
    {
        // Do not add data member - it's the same with global variable in C
        private T[] items;
        private bool linearProbing;
        private bool[] occupied;

        public HashTable(int theSize, bool useLinearProbing = false)
        {
            if (theSize < 0) throw (new Exception("The size of hastable must be positive."));

            linearProbing = useLinearProbing;
            if (!linearProbing)
            {
                getNextGoodSizeForQuadraticProbing(ref theSize);
            }
            items = new T[theSize]; // default value, we don't know yet
            occupied = new bool[theSize]; // bool defaults to false, good!
        }

        private void getNextGoodSizeForQuadraticProbing(ref int theSize)
        {
            while (!satisfiesTheoremQ(theSize))
            {
                theSize++;
            }
        }
        private bool satisfiesTheoremQ(int theSize)
        {
            if (theSize == 1 || theSize == 2) return true;
            else if (isPrime(theSize) && theSize % 4 == 3) return true;
            else if (theSize % 2 == 0)
            {
                int half = theSize / 2;
                if (isPrime(half) && half % 4 == 3) return true;
            }
            return false;
        }
        private bool isPrime(int theSize)
        {
            int divider = 2;
            while (divider < theSize)
            {
                if (theSize % divider == 0) return false;
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
                int index = probe(homePosition, i);
                if (!occupied[index])
                {
                    items[index] = theItem;
                    occupied[index] = true;
                    return;
                }
            }
            throw new Exception("Not enough capacity");
        }

        private int probe(int homePosition, int probeIndex)
        {
            int index;
            if (linearProbing)
            {
                index = linearProbe(homePosition, probeIndex);
                return index;
            }
            index = quadraticProbe(homePosition, probeIndex);
            return index;
        }
        // The reason to make linearProbe method
        // linearProbe method is just one line.
        // However, linearProbe method should be managed equal level as qudaraticProbe method.
        // Eventhough linearProbe method is one line, creating this method is more consistent code style.
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
            while (index < 0)
            {
                index += items.Length;
            }
            index = index % items.Length;
            return index;
        }
        public bool retrieveItem(ref T theItem)
        {
            int keyValue = theItem.getKey();
            int homePosition = hashFunction(keyValue);
            // How about below style?
            // int homePosition = hashFunction(theItem.getKey());
            for (int i = 0; i < items.Length; i++)
            {
                // compute the probe index d = p(e,i)
                int index = probe(homePosition, i);
                //      if the array cell at index d is empty, then return false;
                if (!occupied[index]) return false;
                //      if the array cell at index d is occupied by an object y with the same key value
                //          as x, then copy all data from y into x and return true;
                if (items[index].getKey() == keyValue)
                {
                    theItem = items[index];
                    return true; // Is it right place for return true?
                }
            }
            return false;
        }

        private int hashFunction(int keyValue)
        {
            if (keyValue < 0) throw new Exception("Key value must be at least greater than zero");
            // The reason to put throw here
            // getKey method is implemented by user, not hashtable creator.
            // Therefore, it should be checked.

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
                theNumber = theNumber % items.Length;
            }
            return theNumber;
        }

        private void splitNumber(int theNumber, ref int firstHalf, ref int secondHalf)
        {
            int digit = getDigit(theNumber);
            int firstDigit = digit / 2;
            int secondDigit = firstDigit;
            //(in case the number of digits is odd, group the greater number of digits into the second half)
            if ( (digit / 2) > firstDigit)
            {
                secondDigit++;
            }
            int zeros = (int) Math.Pow(10, secondDigit);
            if(zeros == 0)
            {
                firstHalf = 0;
            }
            else
            {
                firstHalf = theNumber / zeros;
            }
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