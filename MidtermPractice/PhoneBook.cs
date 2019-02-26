using System;

namespace MidtermPractice
{
    public class PhoneBook
    {
        public PhoneBookData[] arr;
        public int Count;
        public int m = 11;
        public int c1 = 1;
        public int c2 = 3;

        private int i = 0;

        public PhoneBook()
        {
            arr = new PhoneBookData[m];
        }

        public void Insert(string name, int phoneNumber)
        {
            int hashCode = PreHash(name);
            int hashPosition = EncryptHash(hashCode);
            Console.WriteLine("Insert to position: "+hashPosition);
            arr[hashPosition] = new PhoneBookData {name = name,number = phoneNumber};
        }

        private int EncryptHash(int phoneNumber)
        {
            
            int result = (phoneNumber + c1 * i + c2 * i * i) % m;
            while (arr[result] != null)
            {
                i++;
                
                result = (phoneNumber + c1 * i + c2 * i * i) % m;
            }

            return result;
        }

        private int FindLastEncryptHash(int hashCode, string name)
        {
            int temporaryI = 0;
            int result = (hashCode + c1 * temporaryI + c2 * temporaryI * temporaryI) % m;
            while (arr[result] != null)
            {
                if (arr[result].name == name)
                {
                    return result;
                }
                else
                {
                    i++;
                    result = (hashCode + c1 * (i) + c2 * (i) * (i)) % m;
                }
            }
            throw new InvalidOperationException("didn't find the element");
        }

        public PhoneBookData Search(string name)
        {
            int hashCode = PreHash(name);
            int hashPosition = FindLastEncryptHash(hashCode,name);
            if (arr[hashPosition] != null)
            {
                return arr[hashPosition];
            }
            else
            {
                throw new InvalidOperationException("Can't find data");
            }
        }

        private int PreHash(string name)
        {
            int result = 0;
            for (int i = 0; i < name.Length; i++)
            {
                result += name[i] * (int)Math.Pow(10, i);
            }

            return result;
        }
    }

    public class PhoneBookData
    {
        public string name;
        public int number;
    }
}