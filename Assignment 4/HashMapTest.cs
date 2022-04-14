using NUnit.Framework;
using System;
using System.Collections;
using Assignment_4;

namespace Assignment_4
{
    [TestFixture]
    public class HashMapTest
    {
        #region Helper methods
        private static int RetrieveKeyIndex(StringKey key, Entry<StringKey, Item>[] table)
        {
            // PLEASE NOTE: this method is used for testing and may not be a valid way for students
            // to search their tables in the actual solution. Remember you need to handle collisions
            // and your look up should NOT be Big-O of N algorithm, unlike the below loop.
            for (int i = 0; i < table.Length; i++)
            {
                if (table[i] != null && table[i].Key.Equals(key))
                {
                    return i;
                }
            }
            return -1; // dummy value of -1 returned when no match found
        }

        private static int RetrieveValueIndex(Item item, Entry<StringKey, Item>[] table)
        {
            // PLEASE NOTE: this method is used for testing and may not be a valid way for students
            // to search their tables in the actual solution. Remember you need to handle collisions
            // and your look up should NOT be Big-O of N algorithm, unlike the below loop.
            for (int i = 0; i < table.Length; i++)
            {
                if (table[i] != null && table[i].Value.Equals(item))
                {
                    return i;
                }
            }
            return -1; // dummy value of -1 returned when no match found
        }
        #endregion

        #region Constructor Tests
        /// <summary>
        /// Test the HashMap NoArg constructor to make sure it sets the properties properly.
        /// </summary>
        [Test]
        public static void HashMapNoArgConstructorTest()
        {
            HashMap<StringKey, Item> newHashMap = new HashMap<StringKey, Item>();

            Assert.AreNotEqual(null, newHashMap);
            Assert.AreEqual(newHashMap.Table.Length, 11);
            Assert.AreEqual(newHashMap.Size, 0);

        }

        /// <summary>
        /// Test the HashMap OneArg constructor to make sure it creates an object.
        /// </summary>
        [Test]
        public static void HashMapOneArgConstructorTest()
        {
            HashMap<StringKey, Item> newHashMap = new HashMap<StringKey, Item>(5);

            Assert.AreNotEqual(null, newHashMap);
            Assert.AreEqual(newHashMap.Table.Length, 5);
            Assert.AreEqual(newHashMap.Size, 0);
        }

        /// <summary>
        /// Test the HashMap TwoArg Constructor to make sure it creates an object.
        /// </summary>
        [Test]
        public static void HashMapTwoArgConstructorTest()
        {
            HashMap<StringKey, Item> newHashMap = new HashMap<StringKey, Item>(7, 0.3);

            Assert.AreNotEqual(null, newHashMap);
            Assert.AreEqual(newHashMap.Table.Length, 7);
            Assert.AreEqual(newHashMap.Size, 0);
        }

        /// <summary>
        /// Test that the one arg constructor throws an exception if you pass in a zero size for initial capacity.
        /// </summary>
        [Test]
        public static void HashMapOneArgConstructorZeroTest()
        {
            Assert.Throws<ArgumentException>(() => new HashMap<StringKey, Item>(0));
        }

        /// <summary>
        /// Test that the one arg constructor throws an exception if you pass in a negative size for initial capacity.
        /// </summary>
        [Test]
        public static void HashMapOneArgConstructorNegativeTest()
        {
            Assert.Throws<ArgumentException>(() => new HashMap<StringKey, Item>(-1));
        }

        /// <summary>
        /// Test that the two arg constructor throws an exception if you pass in zero size for initial capacity.
        /// </summary>
        [Test]
        public static void HashMapTwoArgConstructorZeroSizeTest()
        {
            Assert.Throws<ArgumentException>(() => new HashMap<StringKey, Item>(0, 0.75));
        }

        /// <summary>
        /// Test that the two arg constructor throws an exception if you pass in a negative size for initial capacity.
        /// </summary>
        [Test]
        public static void HashMapTwoArgConstructorNegativeSizeTest()
        {
            Assert.Throws<ArgumentException>(() => new HashMap<StringKey, Item>(-1, 0.75));
        }

        /// <summary>
        /// Test that the two arg constructor throws an exception if you pass in a negative value for threshold.
        /// </summary>
        [Test]
        public static void HashMapTwoArgConstructorNegativeThresholdTest()
        {
            Assert.Throws<ArgumentException>(() => new HashMap<StringKey, Item>(1, -1));
        }

        /// <summary>
        /// Test that the two arg constructor throws an exception if you pass in value greater than 1 for initial capacity.
        /// </summary>
        [Test]
        public static void HashMapTwoArgConstructorTooLargeThresholdTest()
        {
            Assert.Throws<ArgumentException>(() => new HashMap<StringKey, Item>(0, 2));
        }
        #endregion

        #region Put Test
        /// <summary>
        /// Test that put throws an exception when called with a null key value.
        /// </summary>
        [Test]
        public static void Put_Throws_Exception_With_Null_Key_Test()
        {
            HashMap<StringKey, Item> hashMap = new HashMap<StringKey, Item>();
            StringKey key = new StringKey("item");
            Item item = new Item("item", 1, 1.0);

            Assert.Throws<ArgumentNullException>(() => hashMap.Put(null, item));
        }

        /// <summary>
        /// Test that put throws an exception when called with a null value.
        /// </summary>
        [Test]
        public static void Put_Throws_Exception_With_Null_Value_Test()
        {
            HashMap<StringKey, Item> hashMap = new HashMap<StringKey, Item>();
            StringKey key = new StringKey("item");
            Item item = new Item("item", 1, 1.0);

            Assert.Throws<ArgumentNullException>(() => hashMap.Put(key, null));
        }

        /// <summary>
        /// Test that Put returns null when there is no collsion (not an update).
        /// </summary>
        [Test]
        public static void Put_Returns_Null_when_a_new_insert_Test()
        {
            HashMap<StringKey, Item> hashMap = new HashMap<StringKey, Item>();
            StringKey key = new StringKey("item");
            Item item = new Item("item", 1, 1.0);

            Assert.AreEqual(null, hashMap.Put(key, item));
        }

        /// <summary>
        /// Test that Put increases the size of the hash.
        /// </summary>
        [Test]
        public static void Put_increases_size_Test()
        {
            HashMap<StringKey, Item> hashMap = new HashMap<StringKey, Item>();
            string Name = "item";
            StringKey key = new StringKey(Name);
            Item item = new Item("item", 1, 1.0);
            hashMap.Put(key, item);

            Assert.AreEqual(1, hashMap.Size);
        }

        /// <summary>
        /// Test that put adds the passed in Value to the hash.
        /// </summary>
        [Test]
        public static void Put_Adds_Value_To_Hash_Test()
        {
            HashMap<StringKey, Item> hashMap = new HashMap<StringKey, Item>();
            StringKey key = new StringKey("item");
            Item item = new Item("item", 1, 1.0);
            hashMap.Put(key, item);

            Entry<StringKey, Item>[] table = hashMap.Table;

            int bucket = key.GetHashCode() % table.Length;

            Assert.AreEqual(item, table[bucket].Value);
        }


        /// <summary>
        /// Test Put returns the replaced value when there is an Update.
        /// </summary>
        [Test]
        public static void Put_Returns_Replaced_Value_On_Update_Test()
        {
            HashMap<StringKey, Item> hashMap = new HashMap<StringKey, Item>();
            StringKey key = new StringKey("item");
            Item item01 = new Item("item", 1, 1.0);
            Item item02 = new Item("item", 2, 2.0);
            hashMap.Put(key, item01);

            Assert.AreEqual(item01, hashMap.Put(key, item02));
        }

        /// <summary>
        /// Test Put overwrites the value at the key when there is an Update.
        /// </summary>
        [Test]
        public static void Put_Overwrites_Value_At_Key_On_Update_Test()
        {
            HashMap<StringKey, Item> hashMap = new HashMap<StringKey, Item>();
            StringKey key = new StringKey("item");
            Item originalItem = new Item("item", 1, 1.0);
            Item newItem = new Item("item", 2, 2.0);
            hashMap.Put(key, originalItem);
            Item oldValue = hashMap.Put(key, newItem);

            Entry<StringKey, Item>[] table = hashMap.Table;

            int bucket = key.GetHashCode() % table.Length;

            Assert.AreEqual(newItem, table[bucket].Value);

            // doing a thourough check that the OLD value is no longer in the map anywhere
            bool isFound = false;
            for (int i = 0; i < table.Length; i++)
            {
                if (table[i] != null && table[i].Value.Equals(oldValue) && table[i].Key.Equals(key))
                {
                    isFound = true;
                }
            }

            Assert.IsFalse(isFound);
        }

        /// <summary>
        /// Test Put dosn't increase size when there is an Update (not an insert)
        /// </summary>
        [Test]
        public static void Put_Does_Not_Increase_Size_On_Update_Test()
        {
            HashMap<StringKey, Item> hashMap = new HashMap<StringKey, Item>();
            StringKey key = new StringKey("item");
            Item item01 = new Item("item", 1, 1.0);
            Item item02 = new Item("item", 2, 2.0);

            hashMap.Put(key, item01);

            Assert.AreEqual(1, hashMap.Size);

            hashMap.Put(key, item02);

            Assert.AreEqual(1, hashMap.Size);
        }

        /// <summary>
        /// Test Put uses linear probing on collisions Test
        /// </summary>
        [Test]
        public static void Put_uses_linear_probing_on_collisions_Test()
        {
            HashMap<StringKey, Item> hashMap = new HashMap<StringKey, Item>();
            Entry<StringKey, Item>[] table = hashMap.Table;

            Item item1Value = new Item("Purse", 10, 1);
            StringKey item1Key = new StringKey(item1Value.Name);

            Item item2Value = new Item("Helmet", 3, 2.5);
            StringKey item2Key = new StringKey(item2Value.Name);

            hashMap.Put(item1Key, item1Value);

            int bucket1 = item1Key.GetHashCode() % table.Length;
            int bucket2 = item2Key.GetHashCode() % table.Length;

            // check to see if there is a collision
            Assert.AreEqual(bucket1, bucket2);

            // causes a collision, test for linear probing here!
            hashMap.Put(item2Key, item2Value);

            // The second item is in the next available index
            Assert.AreEqual(item2Value, table[((bucket1 + 1) % table.Length)].Value);
        }

        /// <summary>
        /// Test constructors for an increase in the table resize at 75% of 11
        /// </summary>
        [Test]
        public static void Put_increases_table_size_on_default_constructor_at_75_percent_of_11_Test()
        {
            double loadFactor = 0.75; // default
            int capacity = 11; // default;

            HashMap<StringKey, Item> hashMap = new HashMap<StringKey, Item>();
            int threshold = (int)(capacity * loadFactor);
            int i = 0;
            for (i = 0; i < threshold - 1; i++)
            {
                hashMap.Put(new StringKey("item" + i), new Item("item" + i, i, 0.0 + i));
            }

            // just before the threshold, the table should still be the same
            Assert.AreEqual(capacity, hashMap.Table.Length);
            Assert.AreEqual(threshold - 1, hashMap.Size);

            hashMap.Put(new StringKey("item" + i), new Item("item" + i, i, 0.0 + i));

            // the next prime after 11 is 11*2 = 22... and 22+1 is 23!
            Assert.AreEqual(23, hashMap.Table.Length);
            Assert.AreEqual(threshold, hashMap.Size);
        }

        /// <summary>
        /// Test constructors for an increase in the table resize at 75% of 5
        /// </summary>
        [Test]
        public static void Put_increases_table_size_on_custom_size_constructor_at_75_percent_Test()
        {
            double loadFactor = 0.75; // default
            int capacity = 5; // default;

            HashMap<StringKey, Item> hashMap = new HashMap<StringKey, Item>(capacity);
            int threshold = (int)(capacity * loadFactor);
            int i = 0;
            for (i = 0; i < threshold - 1; i++)
            {
                hashMap.Put(new StringKey("item" + i), new Item("item" + i, i, 0.0 + i));
            }

            // just before the threshold, the table should still be the same
            Assert.AreEqual(capacity, hashMap.Table.Length);
            Assert.AreEqual(threshold - 1, hashMap.Size);

            hashMap.Put(new StringKey("item" + i), new Item("item" + i, i, 0.0 + i));

            // the next prime after 5 is 5*2 = 10... and 10+1 is 1!
            Assert.AreEqual(11, hashMap.Table.Length);
            Assert.AreEqual(threshold, hashMap.Size);
        }

        /// <summary>
        /// Test constructors for an increase in the table resize at 50% of 7
        /// </summary>
        [Test]
        public static void Put_increases_table_size_on_custom_capacity_with_a_custom_loadfactor_Test()
        {
            double loadFactor = 0.5; // default
            int capacity = 7; // default;

            HashMap<StringKey, Item> hashMap = new HashMap<StringKey, Item>(capacity, loadFactor);
            int threshold = (int)(capacity * loadFactor);
            int i = 0;
            for (i = 0; i < threshold - 1; i++)
            {
                hashMap.Put(new StringKey("item" + i), new Item("item" + i, i, 0.0 + i));
            }

            // just before the threshold, the table should still be the same
            Assert.AreEqual(capacity, hashMap.Table.Length);
            Assert.AreEqual(threshold - 1, hashMap.Size);

            hashMap.Put(new StringKey("item" + i), new Item("item" + i, i, 0.0 + i));

            // the next prime after 7 is 7*2 = 14... and 14+1 is 15.. that's not prime, so 15+2 is 17!
            Assert.AreEqual(17, hashMap.Table.Length);
            Assert.AreEqual(threshold, hashMap.Size);
        }
        #endregion

        #region IsEmpty Test
        /// <summary>
        /// Test that IsEmpty returns true on an empty hash map.
        /// </summary>
        [Test]
        public static void HashMapIsEmptyReturnsTrueTest()
        {
            HashMap<StringKey, Item> hashMap = new HashMap<StringKey, Item>();

            Assert.IsTrue(hashMap.IsEmpty());
        }

        /// <summary>
        /// Test that IsEmpty returns false on a hash map with contents.
        /// </summary>
        [Test]
        public static void HashMapIsEmptyReturnsFalseTest()
        {
            HashMap<StringKey, Item> hashMap = new HashMap<StringKey, Item>();
            hashMap.Put(new StringKey("item"), new Item("item", 1, 1.0));

            Assert.IsFalse(hashMap.IsEmpty());
        }
        #endregion

        #region Clear Test
        /// <summary>
        /// Test that Clear removes items from the HashMap.
        /// </summary>
        [Test]
        public static void ClearEmptiesTableTest()
        {
            HashMap<StringKey, Item> hashMap = new HashMap<StringKey, Item>();
            StringKey key = new StringKey("item");
            hashMap.Put(key, new Item("item", 1, 1.0));

            // make sure to actually clear the hashmap before testing... :|
            hashMap.Clear();

            Assert.AreEqual(null, hashMap.Get(key));
            Assert.IsTrue(hashMap.IsEmpty());
            Assert.AreEqual(0, hashMap.Size);
        }
        #endregion

        #region GetMatchingOrNextAvailableBucket Tests

        /// <summary>
        /// Test GetMatchingOrNextAvailableBucket returns the index that matches the key passed in.
        /// </summary>
        [Test]
        public static void GetMatchingOrNextAvailableBucket_Retuns_index_of_key_Test()
        {
            HashMap<StringKey, Item> hashMap = new HashMap<StringKey, Item>();
            StringKey key = new StringKey("New Item");
            Item item = new Item("New Item", 1, 1.0);
            hashMap.Put(key, item);

            int index = RetrieveKeyIndex(key, hashMap.Table);

            Assert.AreEqual(index, hashMap.GetMatchingOrNextAvailableBucket(key));
        }

        /// <summary>
        /// Test GetMatchingOrNextAvailableBucket returns the next avalable index value when collisions occurs with a key
        /// </summary>
        [Test]
        public static void GetMatchingOrNextAvailableBucket_Retuns_next_index_when_collision_occurs_Test()
        {
            HashMap<StringKey, Item> hashMap = new HashMap<StringKey, Item>();
            StringKey key = new StringKey("New Item");
            StringKey collisionKey = new StringKey("item_COLLSION");
            Item item = new Item("New Item", 1, 1.0);

            hashMap.Put(key, item);

            int index = RetrieveKeyIndex(key, hashMap.Table);

            // we overwrite the spot that item originally hashes to...
            hashMap.Table[index] = new Entry<StringKey, Item>(collisionKey, item);

            // test to see if putting the colliding item back retrieves index + 1
            Assert.AreEqual(index + 1, hashMap.GetMatchingOrNextAvailableBucket(key));
        }

        /// <summary>
        /// Test GetMatchingOrNextAvailableBucket returns the index value on entries that can only be found through collisions
        /// </summary>
        [Test]
        public static void GetMatchingOrNextAvailableBucket_Retuns_index_on_collision_entry_Test()
        {
            HashMap<StringKey, Item> hashMap = new HashMap<StringKey, Item>();
            StringKey key = new StringKey("New Item");
            StringKey collisionKey = new StringKey("item_COLLSION");
            Item item = new Item("New Item", 1, 1.0);

            hashMap.Put(key, item);

            int firstIndex = RetrieveKeyIndex(key, hashMap.Table);
            hashMap.Table[firstIndex] = new Entry<StringKey, Item>(collisionKey, item);

            hashMap.Put(key, item); // should collide with the first entry and find the next available spot.

            // get the new index of "Item"
            int secondIndex = RetrieveKeyIndex(key, hashMap.Table);

            Assert.AreEqual(secondIndex, hashMap.GetMatchingOrNextAvailableBucket(key));
            Assert.AreNotEqual(secondIndex, firstIndex);
        }

        /// <summary>
        /// Test GetMatchingOrNextAvailableBucket returns the 0 index value when collisions on last bucket occurs with a key
        /// </summary>
        [Test]
        public static void GetMatchingOrNextAvailableBucket_Retuns_0_index_when_collision_on_last_bucket_occurs_Test()
        {
            HashMap<StringKey, Item> hashMap = new HashMap<StringKey, Item>();
            StringKey key = new StringKey("item");
            StringKey collisionKey = new StringKey("item_COLLSION");
            Item item = new Item("item", 1, 1.0);

            hashMap.Put(key, item);

            int index = RetrieveKeyIndex(key, hashMap.Table);

            // test that this item was the last item in the array.
            // this SHOULD work if the same hash in StringKey is made as your instructor.
            Assert.AreEqual(hashMap.Table.Length - 1, index);

            // we overwrite the spot that item originally hashes to...
            hashMap.Table[index] = new Entry<StringKey, Item>(collisionKey, item);

            // test to see if the next bucket is index 0 during a collision
            Assert.AreEqual(0, hashMap.GetMatchingOrNextAvailableBucket(key));
        }


        /// <summary>
        /// Test GetMatchingOrNextAvailableBucket returns the 0 index value when collisions on last bucket occurs with a key
        /// Test that after putting in a new entry that collides with the last index and ends up on 0, still returns 0 during look up!
        /// </summary>
        [Test]
        public static void GetMatchingOrNextAvailableBucket_Retuns_0_when_entry_inserted_to_index_0_during_collision_on_last_index_Test()
        {
            HashMap<StringKey, Item> hashMap = new HashMap<StringKey, Item>();
            StringKey key = new StringKey("item");
            StringKey collisionKey = new StringKey("item_COLLSION");
            Item item = new Item("item", 1, 1.0);

            hashMap.Put(key, item);

            int index = RetrieveKeyIndex(key, hashMap.Table);

            // test that this item was the last item in the array.
            // this SHOULD work if the same hash in StringKey is made as your instructor.
            Assert.AreEqual(hashMap.Table.Length - 1, index);

            // we overwrite the spot that item originally hashes to...
            hashMap.Table[index] = new Entry<StringKey, Item>(collisionKey, item);

            hashMap.Put(key, item);

            // test to see if the bucket returned is index 0 after colliding with the last index and being placed at 0
            Assert.AreEqual(0, hashMap.GetMatchingOrNextAvailableBucket(key));
        }

        #endregion


        #region Get Tests
        /// <summary>
        /// Test Get returns the value that matches the key passed in.
        /// </summary>
        [Test]
        public static void Get_Retuns_Value_of_key_Test()
        {
            HashMap<StringKey, Item> hashMap = new HashMap<StringKey, Item>();
            StringKey key = new StringKey("item");
            Item item = new Item("item", 1, 1.0);
            hashMap.Put(key, item);

            Assert.AreEqual(item, hashMap.Get(key));
            Assert.AreEqual(1, hashMap.Size); // size should remain 1
        }

        /// <summary>
        /// Test Get returns null if the key doesn't exist in the hash.
        /// </summary>
        [Test]
        public static void Get_Retuns_Null_on_key_missing_from_hash_Test()
        {
            HashMap<StringKey, Item> hashMap = new HashMap<StringKey, Item>();
            StringKey key = new StringKey("item");
            Item item = new Item("item", 1, 1.0);

            Assert.AreEqual(null, hashMap.Get(key));
        }



        /// <summary>
        /// Test Get uses linear probing on put collisions Test
        /// </summary>
        [Test]
        public static void Get_uses_linear_probing_on_collisions_Test()
        {
            HashMap<StringKey, Item> hashMap = new HashMap<StringKey, Item>();
            Entry<StringKey, Item>[] table = hashMap.Table;

            Item item1Value = new Item("Purse", 10, 1);
            StringKey item1Key = new StringKey(item1Value.Name);

            Item item2Value = new Item("Helmet", 3, 2.5);
            StringKey item2Key = new StringKey(item2Value.Name);

            hashMap.Put(item1Key, item1Value);

            int bucket1 = item1Key.GetHashCode() % table.Length;
            int bucket2 = item2Key.GetHashCode() % table.Length;

            // check to see if there is a collision
            Assert.AreEqual(bucket1, bucket2);

            // causes a collision, test for linear probing here!
            hashMap.Put(item2Key, item2Value);

            // The second item is in the next available index
            Assert.AreEqual(item2Value, table[((bucket1 + 1) % table.Length)].Value);



            //Test GET HERE

        }

        #endregion

        #region Remove Tests
        /// <summary>
        /// Test Remove decreases the size of the HashMap.
        /// </summary>
        [Test]
        public static void Remove_Decreases_Size_Test()
        {
            HashMap<StringKey, Item> hashMap = new HashMap<StringKey, Item>();
            StringKey key = new StringKey("item");
            Item item = new Item("item", 1, 1.0);
            hashMap.Put(key, item);
            Assert.AreEqual(1, hashMap.Size);
            hashMap.Remove(key);
            Assert.AreEqual(0, hashMap.Size);
        }

        /// <summary>
        /// Test Remove removes the key from the HashMap.
        /// </summary>
        [Test]
        public static void Remove_Removes_Key_From_Hash_Test()
        {
            HashMap<StringKey, Item> hashMap = new HashMap<StringKey, Item>();
            StringKey key = new StringKey("item");
            Item item = new Item("item", 1, 1.0);
            hashMap.Put(key, item);
            hashMap.Remove(key);

            Assert.AreEqual(null, hashMap.Get(key));
        }

        /// <summary>
        /// Test Remove returns the removed value from the HashMap.
        /// </summary>
        [Test]
        public static void Remove_Returns_Removed_Value_Test()
        {
            HashMap<StringKey, Item> hashMap = new HashMap<StringKey, Item>();
            StringKey key = new StringKey("item");
            Item item = new Item("item", 1, 1.0);
            hashMap.Put(key, item);
            Item returnedItem = hashMap.Remove(key);

            Assert.AreEqual(item, returnedItem);
        }

        /// <summary>
        /// Test Remove returns null when removing a value that doesn't exist in the HashMap.
        /// </summary>
        [Test]
        public static void Remove_Returns_null_or_default_Value_when_no_match_exists_Test()
        {
            HashMap<StringKey, Item> hashMap = new HashMap<StringKey, Item>();
            StringKey key = new StringKey("item");

            // try to remove a value that doesn't exist:
            Item returnedItem = hashMap.Remove(key);

            Assert.IsTrue(returnedItem == null || default(Item) == returnedItem);
        }

        /// <summary>
        /// Test that remove throws an exception when called with a null key value.
        /// </summary>
        [Test]
        public static void Remove_Throws_Exception_With_Null_Key_Test()
        {
            HashMap<StringKey, Item> hashMap = new HashMap<StringKey, Item>();

            Assert.Throws<ArgumentNullException>(() => hashMap.Remove(null));
        }

        /// <summary>
        /// Test that remove keeps a placeholder in the table
        /// </summary>
        [Test]
        public static void Remove_keeps_a_key_placeholder_Test()
        {
            HashMap<StringKey, Item> hashMap = new HashMap<StringKey, Item>();
            StringKey key = new StringKey("item");
            Item item = new Item("item", 1, 1.0);
            hashMap.Put(key, item);
            Item returnedItem = hashMap.Remove(key);

            Entry<StringKey, Item>[] table = hashMap.Table;
            int bucket = key.GetHashCode() % table.Length;

            // a placeholder will have an Entry with a null for the value, but the key is stil the same as the removed
            Assert.AreEqual(table[bucket].Key, key);
            Assert.AreEqual(table[bucket].Value, null);
        }

        /// <summary>
        /// Removes cause placeholders to remain in the table, test to ensure that
        /// a resize still occurs even when items are removed
        /// </summary>
        [Test]
        public static void Remove_placeholders_count_towards_resize_Test()
        {
            double loadFactor = 0.5; // default
            int capacity = 7; // default;

            HashMap<StringKey, Item> hashMap = new HashMap<StringKey, Item>(capacity, loadFactor);
            int threshold = (int)(capacity * loadFactor);
            int i = 0;
            for (i = 0; i < threshold - 1; i++)
            {
                hashMap.Put(new StringKey("item" + i), new Item("item" + i, i, 0.0 + i));
            }

            // just before the threshold, the table should still be the same
            Assert.AreEqual(capacity, hashMap.Table.Length);
            Assert.AreEqual(threshold - 1, hashMap.Size);

            hashMap.Remove(new StringKey("item1"));
            Assert.AreEqual(threshold - 2, hashMap.Size);

            hashMap.Put(new StringKey("item" + i), new Item("item" + i, i, 0.0 + i));

            // the next prime after 7 is 7*2 = 14... and 14+1 is 15.. that's not prime, so 15+2 is 17; which is prime!
            Assert.AreEqual(17, hashMap.Table.Length);
            Assert.AreEqual(threshold - 1, hashMap.Size);
        }




        /// <summary>
        /// Test Remove uses linear probing on put collisions Test
        /// </summary>
        [Test]
        public static void Remove_uses_linear_probing_on_collisions_Test()
        {
            HashMap<StringKey, Item> hashMap = new HashMap<StringKey, Item>();
            Entry<StringKey, Item>[] table = hashMap.Table;

            Item item1Value = new Item("Purse", 10, 1);
            StringKey item1Key = new StringKey(item1Value.Name);

            Item item2Value = new Item("Helmet", 3, 2.5);
            StringKey item2Key = new StringKey(item2Value.Name);

            hashMap.Put(item1Key, item1Value);

            int bucket1 = item1Key.GetHashCode() % table.Length;
            int bucket2 = item2Key.GetHashCode() % table.Length;

            // check to see if there is a collision
            Assert.AreEqual(bucket1, bucket2);

            // causes a collision, test for linear probing here!
            hashMap.Put(item2Key, item2Value);

            // The second item is in the next available index
            Assert.AreEqual(item2Value, table[((bucket1 + 1) % table.Length)].Value);



            //Test Remove HERE

        }

        #endregion

        #region Keys()
        /// <summary>
        /// Keys returns an IEnumerator of all the keys in the hashmap.
        /// </summary>
        [Test]
        public static void Keys_returns_list_of_keys_Test()
        {
            HashMap<StringKey, Item> hashMap = new HashMap<StringKey, Item>();

            for (int i = 0; i < 15; i++)
            {
                hashMap.Put(new StringKey("item" + i), new Item("item" + i, i, 0.0 + i));
            }

            // get the keys for the map
            IEnumerator keys = hashMap.Keys();
            int count = 0;
            while (keys.MoveNext())
            {
                StringKey currentKey = (StringKey)keys.Current;
                // look up each item in the hashmap, using the keys, they should all be there!
                Item currItem = hashMap.Get(currentKey);
                Assert.IsNotNull(currItem);
                count++;
            }

            Assert.AreEqual(hashMap.Size, count);
        }
        #endregion


        #region Values()
        /// <summary>
        /// Values returns an IEnumerator of all the Values in the hashmap.
        /// </summary>
        [Test]
        public static void Values_returns_list_of_Values_Test()
        {
            HashMap<StringKey, Item> hashMap = new HashMap<StringKey, Item>();

            for (int i = 0; i < 15; i++)
            {
                hashMap.Put(new StringKey("item" + i), new Item("item" + i, i, 0.0 + i));
            }

            Entry<StringKey, Item>[] table = hashMap.Table;

            // get the keys for the map
            IEnumerator values = hashMap.Values();
            int count = 0;

            // loop through the values of the hashmap values
            while (values.MoveNext())
            {
                Item currValue = (Item)values.Current;

                StringKey currKey = new StringKey(currValue.Name);

                Item matchValue = hashMap.Get(currKey);

                // The returned value should be the value we looked up with get, based on the same key name
                Assert.AreEqual(matchValue, currValue);

                count++;
            }

            // The count of the values should be the same as the puts into the table earlier in the test.
            Assert.AreEqual(hashMap.Size, count);
        }
        #endregion
    }
}
