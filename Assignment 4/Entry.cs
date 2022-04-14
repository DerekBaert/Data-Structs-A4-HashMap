using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assignment_4
{
    internal class Entry<K,V>
    {
        public K? Key { get; set; }
        public V? Value { get; set; }

        /// <summary>
        /// Initializes the class.
        /// </summary>
        /// <param name="key">Name of the key for the Entry.</param>
        /// <param name="value">Value of the Entry.</param>
        public Entry(K key, V value)
        {
            this.Key = key;
            this.Value = value;
        }
    }
}
