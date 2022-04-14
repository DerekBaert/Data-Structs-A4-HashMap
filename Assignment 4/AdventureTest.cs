using Assignment_4;
using NUnit.Framework;
using System;

namespace Assignment_4
{
    [TestFixture]
    public class AdventureTest
    {
        private static string itemList = AppDomain.CurrentDomain.BaseDirectory + "ItemData.txt";

        #region Constructor Tests
        /// <summary>
        /// Test Adventure constructor parameter throws exception when null.
        /// </summary>
        [Test]
        public static void Adventure_Constructor_null_parameters_throws_exception_Test()
        {
            Assert.Throws<ArgumentNullException>(() => new Adventure(null));
        }

        /// <summary>
        /// Test Adventure constructor parameter throws exception when file doesn't exist
        /// </summary>
        [Test]
        public static void Adventure_Constructor_invalid_file_throws_exception_Test()
        {
            Assert.Throws<ArgumentException>(() => new Adventure("NOT A REAL FILE.TXT"));
        }

        /// <summary>
        /// Test the Adventure constructor to make sure it sets the properties properly.
        /// Reads in the example file, which has 22 items.
        /// </summary>
        [Test]
        public static void Adventure_Constructor_Test()
        {
            Adventure adventure = new Adventure(itemList);

            Assert.AreNotEqual(null, adventure);
            Assert.AreNotEqual(null, adventure.GetMap());
            Assert.AreEqual(22, adventure.GetMap().Size); // NOTE: you need access to the internal Hash Map for this to work!
        }
        #endregion

        #region PrintLootMap()
        /// <summary>
        /// Ensure that when using PrintLootMap that only items with more than 0GP are printed.
        /// Also ensure that the items are sorted alphabetically!
        /// </summary>
        [Test]
        public static void PrintLootMap()
        {
            string expectedResult = "Armor is worth 250gp and weighs 35kg\nArrow is worth 2gp and weighs 0.1kg\nAxe is worth 250gp and weighs 3.5kg\nBackpack is worth 20gp and weighs 0.4kg\nBelt is worth 60gp and weighs 0.09kg\nBow is worth 100gp and weighs 1.5kg\nChest is worth 50gp and weighs 15kg\nCrossbow is worth 350gp and weighs 9kg\nDagger is worth 95gp and weighs 0.6kg\nDiamond is worth 5000gp and weighs 0.01kg\nHelmet is worth 35gp and weighs 1.1kg\nLantern is worth 45gp and weighs 2kg\nPurse is worth 5gp and weighs 0.2kg\nQuiver is worth 60gp and weighs 0.3kg\nRing is worth 395gp and weighs 0.05kg\nScroll is worth 10gp and weighs 0.02kg\nStaff is worth 45gp and weighs 1kg\nSword is worth 300gp and weighs 2kg\nTorch is worth 15gp and weighs 1kg\n";
            Adventure adventure = new Adventure(itemList);

            Assert.AreEqual(expectedResult, adventure.PrintLootMap());
        }
        #endregion

    }
}
