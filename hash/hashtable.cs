// Jong-Young Choi

//Make sure that each of your class methods is functional!
//You may add private members to HashTable, but do NOT change the public interface.
//
//Use the same algorithm for hashFunction that you submitted in Test Plan #3.
//Use the second constructor argument to determine the type of probing used: Implement quadratic probing if the value of "useLinearProbing" is false.

//Test your HashTable class against Test Plan #3. Does your code pass the tests?
//Make sure that your name appears in a comment at the top of each source file. Submit all source files, including the test code, after first compressing them into a single file using the Windows file compression utility (NOT a commercial utility); the file extension should be .zip.

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
            while(!satisfiedTheoremQ(theSize))
            {
                theSize++;
            }
        }
        private bool satisfiesTheoremQ(int theSize)
        {
            return false; // FIX ME!
        }


        public void addItem(T theItem)
        {
            // Remember, type T can be ANY type (that implements IKeyed)!
            // Keep your code general!
            // compute the home position e of theItem
            // home position of Item is
            int k = theItem.getKey();
            int e = hashFunction(k);
            for(int i=0; i<theSize; i++)
            {
                if (!occupied[index])
                {
                    items[index] = theItem;
                    occupied[index] = true;
                }
                else
                {
                    if(linearProbing)
                    {

                    }
                    else
                    {

                    }
                }
            } 
        }

        public bool retrieveItem(ref T theItem)//theItem comes with its key fields filled, returns with all fields filled if found
        {
            return false;
        }

        private int hashFunction(int keyValue)
        {
            // we need to splite keyValue into tow "havles", longer half is right.
            int digit = 0;
            int tmp = keyValue;
            while( tmp > 0 )
            {
                tmp = tmp / 10;
                digit++;
            }

            string keyString = keyValue.ToString();
            int len = keyString.Length;
            string digits7through9 = keyString.Substring(7, 2);
            // now it's time to write the real code...!





            return 0; // replace this! Implement the hash function from Test Plan 3
        }
    }
}

interface IKeyed
{
    public int getKey();
}