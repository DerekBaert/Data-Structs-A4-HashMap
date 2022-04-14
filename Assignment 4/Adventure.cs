using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace Assignment_4
{
    internal class Adventure
    {
        private HashMap<StringKey, Item> map;

        /// <summary>
        /// Reads a list of items from a file and adds them to the HashMap.
        /// </summary>
        /// <param name="path">File path of item list.</param>
        /// <exception cref="ArgumentNullException">Thrown if the file path is null.</exception>
        /// <exception cref="ArgumentException">Thrown if file does not exist.</exception>
        public Adventure(string path)
        {
            if(path == null)
            {
                throw new ArgumentNullException("path");
            }
            map = new HashMap<StringKey, Item>();
            try
            {
                using (StreamReader sr = new StreamReader(path))
                {
                    string line;
                    // Read and display lines from the file until the end of
                    // the file is reached.
                    while ((line = sr.ReadLine()) != null)
                    {
                        string[] data = line.Split(',');
                        for (int i = 0; i < data.Length; i++)
                        {
                            data[i] = data[i].Trim(' ');
                        }
                        Item item = new Item(data[0], int.Parse(data[1]), double.Parse(data[2]));

                        map.Put(new StringKey(data[0]), item);
                    }
                }
            }
            catch (System.IO.FileNotFoundException)
            {
                throw new ArgumentException();
            }

        }

        /// <summary>
        /// Returns the HashMap
        /// </summary>
        /// <returns>HashMap of items</returns>
        public HashMap<StringKey, Item> GetMap()
        {
            return map;
        }

        /// <summary>
        /// Prints all items with a gold value of more than 0 in alphabetical order.
        /// </summary>
        /// <returns>Alphabetical list of all items with a gold value more than 0.</returns>
        public string PrintLootMap()
        {
            SortedDictionary<string, Item> itemList = new SortedDictionary<string, Item>();
            string print = "";
            IEnumerator<Item> items = map.Values();
            while(items.MoveNext())
            {
                if(items.Current.GoldPieces > 0)
                {
                    itemList.Add(items.Current.Name, items.Current);
                }
            }
            foreach(KeyValuePair<string, Item> entry in itemList)
            {
                print += entry.Value.ToString() + "\n";
            }
            return print;
        }
    }
}
