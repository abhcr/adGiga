using System;
using System.Collections.Generic;
using System.Text;
using System.IO;
using System.Security.Cryptography;

namespace SoftwareLocker
{
    static class Encryption
    {
        static public string InverseByBase(string st, int MoveBase)
        {
            StringBuilder SB = new StringBuilder();
            //st = ConvertToLetterDigit(st);
            int c;
            for (int i = 0; i < st.Length; i += MoveBase)
            {
                if (i + MoveBase > st.Length - 1)
                    c = st.Length - i;
                else
                    c = MoveBase;
                SB.Append(InverseString(st.Substring(i, c)));
            }
            return SB.ToString();
        }

        static public string InverseString(string st)
        {
            StringBuilder SB = new StringBuilder();
            for (int i = st.Length - 1; i >= 0; i--)
            {
                SB.Append(st[i]);
            }
            return SB.ToString();
        }

        static public string ConvertToLetterDigit(string st)
        {
            StringBuilder SB = new StringBuilder();
            foreach (char ch in st)
            {
                if (char.IsLetterOrDigit(ch) == false)
                    SB.Append(Convert.ToInt16(ch).ToString());
                else
                    SB.Append(ch);
            }
            return SB.ToString();
        }

        /// <summary>
        /// moving all characters in string insert then into new index
        /// </summary>
        /// <param name="st">string to moving characters</param>
        /// <returns>moved characters string</returns>
        static public string Boring(string st)
        {
            int NewPlace;
            char ch;
            for (int i = 0; i < st.Length; i++)
            {
                NewPlace = i * Convert.ToUInt16(st[i]);
                NewPlace = NewPlace % st.Length;
                ch = st[i];
                st = st.Remove(i,1);
                st = st.Insert(NewPlace, ch.ToString());
            }
            return st;
        }

        static public string MakePassword(string st, string Identifier)
        {
            if (Identifier.Length != 5)
                throw new ArgumentException("Identifier must be 5 character length");
            int[] num = new int[5];
            num[0] = Convert.ToInt32(Identifier[0].ToString(), 16);
            num[1] = Convert.ToInt32(Identifier[1].ToString(), 16);
            num[2] = Convert.ToInt32(Identifier[2].ToString(), 16);
            num[3] = Convert.ToInt32(Identifier[3].ToString(), 16);
            num[4] = Convert.ToInt32(Identifier[4].ToString(), 16);
            st = Boring(st);
            st = InverseByBase(st, num[0]);
            st = InverseByBase(st, num[1]);
            st = InverseByBase(st, num[2]);
            st = InverseByBase(st, num[3]);
            st = InverseByBase(st, num[4]);
            StringBuilder SB = new StringBuilder();
            foreach (char ch in st)
            {
                SB.Append(ChangeChar(ch, num));
            }
            return SB.ToString();
        }

        static private char ChangeChar(char ch, int[] EnCode)
        { 
            ch = char.ToUpper(ch);
            if (ch >= 'A' && ch <= 'H')
                return Convert.ToChar(Convert.ToInt16(ch) + 2 * EnCode[0]);
            else if (ch >= 'I' && ch <= 'P')
                return Convert.ToChar(Convert.ToInt16(ch) - EnCode[2]);
            else if (ch >= 'Q' && ch <= 'Z')
                return Convert.ToChar(Convert.ToInt16(ch) - EnCode[1]);
            else if (ch >= '0' && ch <= '4')
                return Convert.ToChar(Convert.ToInt16(ch) + 5);
            else if (ch >= '5' && ch <= '9')
                return Convert.ToChar(Convert.ToInt16(ch) - 5);
            else
                return '0';
        }
    }
}
