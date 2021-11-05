// Modified by Jong-Young Choi

using System;

namespace HashingLab
{
    class Person : IKeyed
    {
        private string name;
        private string SSN;
        private int age;

        public Person(string theName, string theSSN, int theAge)
        {
            name = theName;
            SSN = theSSN;
            age = theAge;
        }

        public Person(string theSSN)
        {
            SSN = theSSN;
        }
        public int getKey()
        {
            // return Int32.Parse(SSN);
            return int.Parse(SSN);
        }
    }
}
