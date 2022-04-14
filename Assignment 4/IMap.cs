using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assignment_4
{
    internal interface IMap<K, V>
    {
        public int Size { get; set; }
        public bool IsEmpty();
        public void Clear();
        public V Get(K key);
        public V Put(K key, V value);
        public V Remove(K key);
        public IEnumerator<K> Keys();
        public IEnumerator<V> Values();
    }
}
