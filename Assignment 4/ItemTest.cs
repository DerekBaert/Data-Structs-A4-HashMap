using Assignment_4;
using NUnit.Framework;
using System;

namespace Assignment_4
{
    [TestFixture]
    public class ItemTest
    {
        /// <summary>
        /// Test the Item constructor to make sure it sets the properties properly.
        /// </summary>
        [Test]
        public static void ItemConstructorTest()
        {
            string name = "Awesome Item";
            int value = 100;
            double weight = 5.0;

            Item item = new Item(name, value, weight);

            Assert.AreEqual(name, item.Name);
            Assert.AreEqual(value, item.GoldPieces);
            Assert.AreEqual(weight, item.Weight);
        }

        /// <summary>
        /// Test that the ToString returns the expected string.
        /// </summary>
        [Test]
        public static void ToStringTest()
        {
            string expectedResult = "Awesome Item is worth 100gp and weighs 5kg";

            object item = new Item("Awesome Item", 100, 5.0);

            Assert.AreEqual(expectedResult, item.ToString());
        }

        /// <summary>
        /// Test CompareTo using the same object. Also ensures Item impliments IComparable with Items
        /// </summary>
        [Test]
        public static void CompareToSameObjectTest()
        {
            int expectedResult = 0;
            Item item = new Item("Item", 10, 5.0);
            IComparable<Item> comparableItem = new Item("Item", 10, 5.0);

            Assert.AreEqual(expectedResult, comparableItem.CompareTo(item));
        }

        /// <summary>
        /// Test CompareTo on two Items with the same name.
        /// </summary>
        [Test]
        public static void CompareToSameNameTest()
        {
            int expectedResult = 0;
            Item item1 = new Item("Item", 10, 5.0);
            Item item2 = new Item("Item", 10, 5.0);

            Assert.AreEqual(expectedResult, item1.CompareTo(item2));

        }

        /// <summary>
        /// Test CompareTo with a item with a name that comes aphabetically before the instance.
        /// </summary>
        [Test]
        public static void CompareToAphabeticallyBeforeNameTest()
        {
            Item item1 = new Item("B", 10, 5.0);
            Item item2 = new Item("A", 10, 5.0);

            Assert.IsTrue(item1.CompareTo(item2) > 0);
        }

        /// <summary>
        /// Test CompareTo with a Item with a name that comes aphabetically after the instance.
        /// </summary>
        [Test]
        public static void CompareToAphabeticallyAfterNameTest()
        {
            Item item1 = new Item("A", 10, 5.0);
            Item item2 = new Item("B", 10, 5.0);

            Assert.IsTrue(item1.CompareTo(item2) < 0);
        }


        /// <summary>
        /// Test that Equals returns true when the same object is checked against itself.
        /// </summary>
        [Test]
        public static void EqualsSameObjectTest()
        {
            Item item = new Item("Item", 10, 5.0);
            object objItem = item;
            Assert.IsTrue(objItem.Equals(objItem));
        }

        /// <summary>
        /// Test that Equals returns false when a null object is passed in.
        /// </summary>
        [Test]
        public static void EqualsNullObjectTest()
        {
            Item item = new Item("Item", 10, 5.0);
            object objItem = item;

            Assert.IsFalse(objItem.Equals(null));
        }

        /// <summary>
        /// Test that Equals returns false when a non Item object is passed in.
        /// </summary>
        [Test]
        public static void EqualsNonItemObjectTest()
        {
            Item item = new Item("Item", 10, 5.0);
            object objItem = item;

            Assert.IsFalse(objItem.Equals("Not an item"));
        }

        /// <summary>
        /// Test that Equals returns true when a Item with a matching name/gold/weight is compared.
        /// </summary>
        [Test]
        public static void EqualsDifferentObjectsWithMatchingNameTest()
        {
            Item item1 = new Item("Item", 10, 5.0);
            Item item2 = new Item("Item", 10, 5.0);
            object objItem = item1;
            object objItem2 = item2;

            Assert.IsTrue(objItem.Equals(objItem2));
        }

        /// <summary>
        /// Test that Equals returns false when a Item with a mismatching name is compared.
        /// </summary>
        [Test]
        public static void EqualsMisMatchedObjects_name_values_differ_Test()
        {
            Item item1 = new Item("Item", 10, 5.0);
            Item item2 = new Item("Item2", 10, 5.0);
            object objItem = item1;
            object objItem2 = item2;

            Assert.IsFalse(objItem.Equals(objItem2));
        }

        /// <summary>
        /// Test that Equals returns false when a Item with a mismatching gold value is compared.
        /// </summary>
        [Test]
        public static void EqualsMisMatchedObject_gold_values_differ_Test()
        {
            Item item1 = new Item("Item", 10, 5.0);
            Item item2 = new Item("Item", 11, 5.0);
            object objItem = item1;
            object objItem2 = item2;

            Assert.IsFalse(objItem.Equals(objItem2));
        }


        /// <summary>
        /// Test that Equals returns false when a Item with a mismatching weight is compared.
        /// </summary>
        [Test]
        public static void EqualsMisMatchedObject_weight_values_differ_Test()
        {
            Item item1 = new Item("Item", 10, 5.0);
            Item item2 = new Item("Item", 10, 4.0);
            object objItem = item1;
            object objItem2 = item2;

            Assert.IsFalse(objItem.Equals(objItem2));
        }
    }
}