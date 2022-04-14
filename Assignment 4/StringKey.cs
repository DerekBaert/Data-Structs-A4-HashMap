using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assignment_4
{
    public class StringKey : IComparable<StringKey>
    {
        public string KeyName { get; set; }

        /// <summary>
        /// Initializes the KeyName object.
        /// </summary>
        /// <param name="KeyName">Name of the Key</param>
        public StringKey(string KeyName)
        {
            this.KeyName = KeyName;
        }

        /// <summary>
        /// Determines whether two StringKey instances are equal.
        /// </summary>
        /// <param name="obj">Object to compare to current object.</param>
        /// <returns>True if equal, false if not.</returns>
        public override bool Equals(object? obj)
        {
            StringKey key = obj as StringKey;
            if (key == null)
            {
                return false;
            }
            else
            {
                return this.KeyName.Equals(key.KeyName);
            }
        }

        /// <summary>
        /// Compares the name of two StringKeys and determines if they are equal.
        /// </summary>
        /// <param name="other">Item to compare to current Item.</param>
        /// <returns>Integer that indicates whether this instance precedes, follows, or appears in the same position in the sort order as the given string.</returns>
        public int CompareTo(StringKey other)
        {
            return this.KeyName.CompareTo(other.KeyName);
        }

        /// <summary>
        /// Returns a string representation of the object.
        /// </summary>
        /// <returns>String representation of the object.</returns>
        public override string ToString()
        {
            return $"KeyName: {this.KeyName} HashCode: {this.GetHashCode()}";
        }

        /// <summary>
        /// Returns a hashcode calculated based on the KeyName.
        /// </summary>
        /// <returns>Hashcode calculated based on KeyName.</returns>
        public override int GetHashCode()
        {
            int code = 0;
            int i = 0;

            foreach (char c in this.KeyName)
            {
                int ascii = (int)c; 
                int pow = HashPow(31, i);
                code += ascii * pow;
                i++;
            }
            return Math.Abs(code);
        }

        /// <summary>
        /// Exponent function for the GetHashCode class
        /// </summary>
        /// <param name="x">The base number.</param>
        /// <param name="y">The exponent.</param>
        /// <returns>Result of the calculation.</returns>
        private int HashPow(int x, int y)
        {
            int result = 1;
            for (int i = 1; i <= y; i++)
            {
                result = result * x;
            }
            return result;
        }        
    }
}
