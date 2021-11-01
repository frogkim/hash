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
    class HashTable<T>
    where T : IKeyed
    {
        private T[] items;
        private bool linearProbing;
        private bool[] occupied;

        public HashTable(int theSize, bool useLinearProbing = false)//optional parameter useLinearProbing defaults to false
        {
            items = new T[theSize];
            linearProbing = useLinearProbing;
        }

        public void addItem(T theItem)
        {
            int index = hashFunction(theItem.getKey());
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

        public bool retrieveItem(ref T theItem)//theItem comes with its key fields filled, returns with all fields filled if found
        {
            return false;
        }

        private int hashFunction(int keyValue)
        {
            return 0;
        }
    }
}

interface IKeyed
{
    int getKey();
}