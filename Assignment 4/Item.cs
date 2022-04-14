using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assignment_4 
{    
    public class Item : IComparable<Item>
    {
        public string Name { get; set; }
        public int GoldPieces { get; set; }
        public double Weight { get; set; }

        /// <summary>
        /// Initializes the item object.
        /// </summary>
        /// <param name="Name">Name of the item.</param>
        /// <param name="GoldPieces">Gold pieces for the item.</param>
        /// <param name="Weight">Weight of the item.</param>
        public Item(string Name, int GoldPieces, double Weight)
        {
            this.Name = Name;
            this.GoldPieces = GoldPieces;
            this.Weight = Weight;
        }

        /// <summary>
        /// Determines whether two item instances are equal.
        /// </summary>
        /// <param name="obj">Object to compare to current object.</param>
        /// <returns>True if equal, false if not.</returns>
        public override bool Equals(object? obj)
        {
            Item item = obj as Item;
            if (item == null)
            {
                return false;
            }
            else
            {                
                return (this.Name.Equals(item.Name) && this.GoldPieces == item.GoldPieces && this.Weight == item.Weight);
            }
        }

        /// <summary>
        /// Compares the name of two items and determines if they are equal.
        /// </summary>
        /// <param name="other">Item to compare to current Item.</param>
        /// <returns>Integer that indicates whether this instance precedes, follows, or appears in the same position in the sort order as the given string.</returns>
        public int CompareTo(Item other)
        {
            return this.Name.CompareTo(other.Name);
        }

        /// <summary>
        /// Returns string representation of the item object.
        /// </summary>
        /// <returns>String representation of the item object.</returns>
        public override string ToString()
        {
            return $"{this.Name} is worth {this.GoldPieces}gp and weighs {this.Weight}kg";
        }
    }
}
