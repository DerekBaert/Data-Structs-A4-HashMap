using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assignment_4
{
    internal class HashMap<K, V> : IMap<K, V>
    {
        public int Size { get; set; }        

        public Entry<K, V>[] Table { get; set; }

        private int Placeholders { get; set; }

        private int DEFAULT_CAPACITY { get; set; }

        private double DEFAULT_LOADFACTOR { get; set; }

        private int threshold; 

        /// <summary>
        /// Initializes HashMap to default parameters.
        /// </summary>
        public HashMap()
        {
            this.DEFAULT_CAPACITY = 11;
            this.DEFAULT_LOADFACTOR = .75;
            this.Table = new Entry<K, V>[this.DEFAULT_CAPACITY];
            this.Size = 0;
            this.threshold = (int)Math.Floor(DEFAULT_CAPACITY * DEFAULT_LOADFACTOR);
        }

        /// <summary>
        /// Initializes HashMap with given capacity.
        /// </summary>
        /// <param name="initialCapacity">Capacity for HashMap</param>
        /// <exception cref="ArgumentException">Thrown if argument is null.</exception>
        public HashMap(int initialCapacity)
        {
            if(initialCapacity <= 0)
            {
                throw new ArgumentException();
            }
            this.DEFAULT_CAPACITY = initialCapacity;
            this.DEFAULT_LOADFACTOR = .75;
            this.Table = new Entry<K, V>[this.DEFAULT_CAPACITY];
            this.threshold = (int)Math.Floor(DEFAULT_CAPACITY * DEFAULT_LOADFACTOR);
            this.Size = 0;
        }

        /// <summary>
        /// Initializes HashMap with given capacity and load factor.
        /// </summary>
        /// <param name="initialCapacity">Capacity for HashMap</param>
        /// <param name="loadFactor">Loadfactor for HashMap</param>
        /// <exception cref="ArgumentException">Thrown if argument is null.</exception>
        public HashMap(int initialCapacity, double loadFactor)
        {
            if (initialCapacity <= 0 || loadFactor <= 0)
            {
                throw new ArgumentException();
            }
            this.DEFAULT_CAPACITY = initialCapacity;
            this.DEFAULT_LOADFACTOR = loadFactor;
            this.Table = new Entry<K, V>[this.DEFAULT_CAPACITY];
            this.threshold = (int)Math.Floor(DEFAULT_CAPACITY * DEFAULT_LOADFACTOR);
            this.Size = 0;
        }

        /// <summary>
        /// Returns boolean indicating if HashMap is empty.
        /// </summary>
        /// <returns>True if HashMap is empty, false if not.</returns>
        public bool IsEmpty()
        {
            return this.Size == 0;
        }

        /// <summary>
        /// Resets HashMap to default parameters.
        /// </summary>
        public void Clear()
        {
            this.DEFAULT_CAPACITY = 11;
            this.DEFAULT_LOADFACTOR = .75;
            this.Size = 0;
            this.Table = new Entry<K, V>[this.DEFAULT_CAPACITY];
            this.threshold = (int)Math.Floor(DEFAULT_CAPACITY * DEFAULT_LOADFACTOR);
        }

        /// <summary>
        /// Finds matching bucket for given key, or next available bucket if key is not in map.
        /// </summary>
        /// <param name="key">Key to find bucket for.</param>
        /// <returns>Index of bucket</returns>
        public int GetMatchingOrNextAvailableBucket(K key)
        {
            int bucket = FindStartingBucket(key);

            while (this.Table[bucket] != null)
            {
                if (this.Table[bucket].Key.Equals(key))
                {
                    return bucket;
                }

                if (bucket < Table.Length - 1)
                {
                    bucket++;
                }
                else
                {
                    bucket = 0;
                }
            }
            return bucket;
        }

        /// <summary>
        /// Finds value of given key
        /// </summary>
        /// <param name="key">Key to find entry for.</param>
        /// <returns>Value of Entry with matching key.</returns>
        public V? Get(K key)
        {
            int index = GetMatchingOrNextAvailableBucket(key);
            if (Table[index] != null)
            {
                return Table[index].Value;
            }
            else
            {
                return default;
            }            
        }

        /// <summary>
        /// Adds the given pair to the table.
        /// </summary>
        /// <param name="key">Key of the entry</param>
        /// <param name="value">Value of the entry</param>
        /// <returns>Null if new entry is added, old value if new value if key already exists.</returns>
        /// <exception cref="ArgumentException">Thrown if argument is null.</exception>
        public V? Put(K key, V value)
        {
            if(key == null || value == null)
            {
                throw new ArgumentNullException();
            }
            int index = GetMatchingOrNextAvailableBucket(key);
            if(Table[index] != null)
            {
                if (Table[index].Key.Equals(key))
                {
                    V old = Table[index].Value;
                    Table[index].Value = value;
                    return old;
                }
            }
            if ((this.Size + this.Placeholders + 1) >= this.threshold)
            {
                ReHash();
                index = GetMatchingOrNextAvailableBucket(key);
                Table[index] = new Entry<K, V>(key, value);
                this.Size += 1;
                return default;
            }
            else
            {
                Table[index] = new Entry<K, V>(key, value);
                this.Size += 1;
                return default;
            }
            
        }

        /// <summary>
        /// Removes value from Entry matching given key.
        /// </summary>
        /// <param name="key">Key to find entry for.</param>
        /// <returns>Removed value.</returns>
        /// <exception cref="ArgumentException">Thrown if argument is null.</exception>
        public V? Remove(K key)
        {
            if(key == null)
            {
                throw new ArgumentNullException();
            }
            int index = GetMatchingOrNextAvailableBucket(key);
            if(Table[index] != null)
            {
                V old = Table[index].Value;
                Table[index].Value = default;
                this.Placeholders++;
                this.Size--;
                return old;
            }
            else
            {
                return default;
            }

        }

        /// <summary>
        /// Calculates size of new array.
        /// </summary>
        /// <returns>Size for new array.</returns>
        private int ReSize()
        {
            int newSize = Table.Length * 2 + 1;
            
            while(!checkPrime(newSize))
            {
                newSize += 2;
            }
            return newSize;
        }

        /// <summary>
        /// Creates new array and reinserts entries.
        /// </summary>
        public void ReHash()
        {
            Entry<K, V>[] oldTable = Table;
            this.Table = new Entry<K, V>[ReSize()];
            this.threshold = (int)(this.Table.Length * this.DEFAULT_LOADFACTOR);
            this.Size = 0;
            foreach (Entry<K, V> entry in oldTable)
            {
               if(entry != null && entry.Value != null)
               {
                    Put(entry.Key, entry.Value);
               }
               
            }
        }

        /// <summary>
        /// Returns all values in HashMap.
        /// </summary>
        /// <returns>Returns all values in HashMap.</returns>
        public IEnumerator<V> Values()
        {
            IEnumerator<Entry<K, V>> enumerator = Table.ToList().GetEnumerator();
            List<V> values = new List<V>();
            while (enumerator.MoveNext())
            {
                if(enumerator.Current != null && enumerator.Current.Value != null)
                {
                    values.Add(enumerator.Current.Value);
                }                
            }
            return values.GetEnumerator();
        }

        /// <summary>
        /// Returns all keys in HashMap.
        /// </summary>
        /// <returns>Returns all keys in HashMap.</returns>
        public IEnumerator<K> Keys()
        {
            IEnumerator<Entry<K, V>> enumerator = Table.ToList().GetEnumerator();
            List<K> keys = new List<K>();
            while (enumerator.MoveNext())
            {
                if (enumerator.Current != null && enumerator.Current.Value != null)
                {
                    keys.Add(enumerator.Current.Key);
                }
            }
            return keys.GetEnumerator();
        }

        /// <summary>
        /// Finds bucket matching hash code calculations.
        /// </summary>
        /// <param name="key">Key to find bucket for</param>
        /// <returns>Index matching key</returns>
        private int FindStartingBucket(K key)
        {
            return key.GetHashCode() % Table.Length;
        }

        /// <summary>
        /// Checks if a given number is prime or not.
        /// </summary>
        /// <param name="num">Number to check</param>
        /// <returns>True if prime, false if not.</returns>
        private bool checkPrime(int num)
        {
            int square = (int)Math.Round(Math.Sqrt((double)num));
            bool prime = true;
            for (int i = 3; i <= square; i++)
            {
                if (num % i == 0)
                {
                    prime = false;
                }
            }
            return prime;
        }
    }
}
