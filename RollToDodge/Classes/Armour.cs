//-----------------------------------------------------------------------
// <copyright file="Armour.cs" company="Brody Schulke">
//     Brody Schulke
// </copyright>
//-----------------------------------------------------------------------
namespace RollToDodge.Classes
{
    using System;
    using RollToDodge.Interfaces;

    /// <summary>
    /// Interaction logic for Armour.cs
    /// Represents the Armour item which can be equipped by a character and
    /// provides defense points.
    /// </summary>
    public class Armour : IItem
    {
        /// <summary>
        /// peice of the armour (where it can be equipped)
        /// </summary>
        private string armourPiece;

        /// <summary>
        /// Weight of the armour piece
        /// </summary>
        private int weight;

        /// <summary>
        /// Initializes a new instance of the Armour class
        /// </summary>
        public Armour()
        {
        }

        /// <summary>
        /// Gets or sets the armour piece while restricting values to
        /// those of the EquppedArmourSlot from the Player class
        /// </summary>
        public string ArmourPiece
        {
            get
            {
                return this.armourPiece;
            }

            set
            {
                if (Array.IndexOf(Enum.GetNames(typeof(Character.EquippedArmourSlot)), value) < 0)
                {
                    return;
                }

                this.armourPiece = value;
            }
        }

        /// <summary>
        /// Gets or sets the description of the armour
        /// </summary>
        public string Description { get; set; }

        /// <summary>
        /// Gets or sets the defense of the armour
        /// </summary>
        public int Defense { get; set; }

        /// <summary>
        /// Gets or sets the quantity of the armour that the character has
        /// in their inventory
        /// </summary>
        public int Quantity { get; set; }

        /// <summary>
        /// Gets or sets the name of the armour
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// Gets or sets the weight of the armour which is multiplied by
        /// the quantity
        /// </summary>
        public int Weight
        {
            get
            {
                return this.weight * this.Quantity;
            }

            set
            {
                this.weight = value;
            }
        }
    }
}
