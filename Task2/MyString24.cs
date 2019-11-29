using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task2
{
    class MyString24
    {
        private char[] _myStr;
        public char this[int i]
        {
            get => _myStr[i];
            set
            {
                _myStr[i] = value;
            }
        }
        public MyString24(string input)
        {
            _myStr = input.ToCharArray();
        }
        public MyString24(char[] input)
        {
            _myStr = input;
        }
        public static explicit operator char[](MyString24 str) =>
            str.ToString().ToCharArray();
        public static explicit operator MyString24(string str) =>
            new MyString24(str.ToCharArray());
        public static explicit operator string(MyString24 str) =>
            str.ToString();
        public override string ToString() =>
            new string(_myStr);
        public int Length => _myStr.Length;
        public bool Equals(string input) =>
            Equals((MyString24)input);
        public bool Equals(MyString24 input)
        {
            if (input.Length != _myStr.Length)
                return false;
            for (int i = 0; i < input.Length; i++)
                if (_myStr[i] != input[i])
                    return false;
            return true;
        }
        public MyString24 Concatenation(string input) =>
            Concatenation((MyString24)input);
        public MyString24 Concatenation(MyString24 input)
        {
            char[] ch = new char[_myStr.Length + input.Length];
            for (int i = 0; i < ch.Length; i++)
            {
                if (i < _myStr.Length)
                    ch[i] = _myStr[i];
                else
                    ch[i] = input[i - _myStr.Length];
            }
            return new MyString24(ch);
        }
        public bool Contains(char input)
        {
            foreach (char ch in _myStr)
                if (ch == input)
                    return true;
            return false;
        }
        public bool Contains(string input)
        {
            if (_myStr.Length < input.Length)
                return false;
            for (int i = 0; i < _myStr.Length; i++)
            {
                if (_myStr.Length < input.Length + i)
                    return false;
                for (int j = 0; j < input.Length; j++)
                {
                    if (_myStr[i + j] != input[j])
                        break;
                    if (j + 1 == input.Length)
                        return true;
                }
            }
            return false;
        }
        public void MyStringDisplay(string subStr)
        {
            Console.WriteLine("Equals:");
            Console.WriteLine(Equals(subStr));
            Console.WriteLine("Concatenation:");
            Console.WriteLine(Concatenation(subStr));
            Console.WriteLine("Contains:");
            Console.WriteLine(Contains(subStr));
        }
    }
}
