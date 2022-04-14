using Assignment_4;
using NUnit.Framework;
using System;

namespace Assignment_4
{
    [TestFixture]
    public class StringKeyTest
    {
        /// <summary>
        /// Tests the StringKey constructor.
        /// </summary>
        [Test]
        public static void StringKeyConstructorTest()
        {
            string name = "Name";
            StringKey stringKey = new StringKey(name);

            Assert.AreEqual(stringKey.KeyName, name);
        }

        /// <summary>
        /// Test CompareTo using the same object. Ensures StringKey impliments IComparable<StringKey>
        /// </summary>
        [Test]
        public static void CompareToSameObjectTest()
        {
            int expectedResult = 0;
            StringKey stringKey = new StringKey("Name");
            IComparable<StringKey> comparableStringKey = stringKey;

            Assert.AreEqual(expectedResult, comparableStringKey.CompareTo(stringKey));
        }

        /// <summary>
        /// Test CompareTo on two StringKeys with the same name.
        /// </summary>
        [Test]
        public static void CompareToSameNameTest()
        {
            int expectedResult = 0;
            StringKey stringKey1 = new StringKey("A");
            StringKey stringKey2 = new StringKey("A");

            Assert.AreEqual(expectedResult, stringKey1.CompareTo(stringKey2));

        }

        /// <summary>
        /// Test CompareTo with a stringKey with a name that comes aphabetically before the instance.
        /// </summary>
        [Test]
        public static void CompareToAphabeticallyBeforeNameTest()
        {
            StringKey stringKey1 = new StringKey("B");
            StringKey stringKey2 = new StringKey("A");

            Assert.IsTrue(stringKey1.CompareTo(stringKey2) > 0);
        }

        /// <summary>
        /// Test CompareTo with a StringKey with a name that comes aphabetically after the instance.
        /// </summary>
        [Test]
        public static void CompareToAphabeticallyAfterNameTest()
        {
            StringKey stringKey1 = new StringKey("A");
            StringKey stringKey2 = new StringKey("B");

            Assert.IsTrue(stringKey1.CompareTo(stringKey2) < 0);
        }


        /// <summary>
        /// Test that the GetHashCode method returns differnt values for words with 
        /// same letters in different orders. Ensures overwrite of Object's HashCode method.
        /// </summary>
        [Test]
        public static void GetHashCodeVarietyTest()
        {
            StringKey stringKey1 = new StringKey("stop");
            StringKey stringKey2 = new StringKey("pots");
            object objStrKey1 = stringKey1;
            object objStrKey2 = stringKey2;

            Assert.AreNotEqual(objStrKey1.GetHashCode(), objStrKey2.GetHashCode());
        }


        /// <summary>
        /// Test that the GetHashCode method returns positive values for large words.
        /// </summary>
        [Test]
        public static void GetHashCode_is_not_negative_Test()
        {
            StringKey stringKey1 = new StringKey("A REALLY BIG STRING SHOULD NOT OVERFLOW TO NEGATIVE! ALWAYS ABSOLUTE VALUE YOUR HASHCODE!");

            object objStrKey1 = stringKey1;
            Assert.GreaterOrEqual(objStrKey1.GetHashCode(), 0);
        }

        /// <summary>
        /// Test that GetHashCode returns 0 on an empty name.
        /// </summary>
        [Test]
        public static void GetHashCodeEmptyNameTest()
        {
            int expectedResult = 0;
            StringKey stringKey = new StringKey("");
            object objStrKey1 = stringKey;
            Assert.AreEqual(expectedResult, objStrKey1.GetHashCode());
        }

        /// <summary>
        /// Test that Equals returns true when the same object is checked against itself.
        /// </summary>
        [Test]
        public static void EqualsSameObjectTest()
        {
            StringKey stringKey = new StringKey("A");
            object objStrKey1 = stringKey;

            Assert.IsTrue(objStrKey1.Equals(objStrKey1));
        }

        /// <summary>
        /// Test that Equals returns false when a null object is passed in.
        /// </summary>
        [Test]
        public static void EqualsNullObjectTest()
        {
            StringKey stringKey = new StringKey("A");
            object objStrKey1 = stringKey;

            Assert.IsFalse(objStrKey1.Equals(null));
        }

        /// <summary>
        /// Test that Equals returns false when a non StringKey object is passed in.
        /// </summary>
        [Test]
        public static void EqualsNonStringKeyObjectTest()
        {
            StringKey stringKey = new StringKey("A");
            object objStrKey1 = stringKey;

            Assert.IsFalse(objStrKey1.Equals("Not a string key"));
        }

        /// <summary>
        /// Test that Equals returns true when a StringKey with a matching name is compared.
        /// </summary>
        [Test]
        public static void EqualsDifferentObjectsWithMatchingNameTest()
        {
            StringKey stringKey1 = new StringKey("A");
            StringKey stringKey2 = new StringKey("A");
            object objStrKey1 = stringKey1;
            object objStrKey2 = stringKey2;

            Assert.IsTrue(objStrKey1.Equals(objStrKey2));
        }

        /// <summary>
        /// Test that Equals returns false when a StringKey with a mismatching name is compared.
        /// </summary>
        [Test]
        public static void EqualsMisMatchedObjectsTest()
        {
            StringKey stringKey1 = new StringKey("A");
            StringKey stringKey2 = new StringKey("B");
            object objStrKey1 = stringKey1;
            object objStrKey2 = stringKey2;

            Assert.IsFalse(objStrKey1.Equals(objStrKey2));
        }

        /// <summary>
        /// Test GetHashCode to ensure it returns expected result.
        /// </summary>
        [Test]
        public static void GetHashCodeTest()
        {
            int expectedResult = 3446974;
            StringKey stringKey = new StringKey("stop");
            object objStrKey1 = stringKey;

            // NOTE: this may differ from your tests, you may ignore this test!
            Assert.AreEqual(expectedResult, objStrKey1.GetHashCode());
        }

        /// <summary>
        /// Test that ToString returns the expected string.
        /// </summary>
        [Test]
        public static void ToStringTest()
        {
            string expectedString = "KeyName: stop HashCode: 3446974";
            StringKey stringKey = new StringKey("stop");
            object objStrKey1 = stringKey;

            // NOTE: this may differ from your tests, you may ignore this test with instructor approval!
            // THIS IS A GOOD IDEA FOR TESTING HOWEVER, YOU *SHOULD* DO IT ANYWAY.
            Assert.AreEqual(expectedString, objStrKey1.ToString());
        }

    }
}