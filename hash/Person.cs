
using System;

namespace HashingLab
{
    //(a) creates a class called Person which implements the IKeyed interface.
    //  A Person should have a name and SSN (which are strings), and an age;
    //  the "getKey" method of Person should return the numeric value of the SSN;
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
        /*
         * 
         *         public Person(string inputSSN)
                {
                    Init("", inputSSN, 0);
                }

                public Person(string inputName, string inputSSN, int inputAge)
                {
                    Init(inputName,inputSSN,inputAge);
                }

                private void Init(string inputName, string inputSSN, int inputAge)
                {
                    name = inputName;
                    SSN = inputSSN;
                    age = inputAge;
                }

         */

        public int getKey()
        {
            // return Int32.Parse(SSN);
            return int.Parse(SSN);
        }


        /*
                int IKeyed.getKey() // useful if Person has multiple "getKey" methods,
                    //e.g. if Person implements more than one interface with getKey.
                {
                    return int.Parse(SSN);
                } // this way, p.getKey() is ILLEGAL if p is declared as a Person!
         */


    }
}
