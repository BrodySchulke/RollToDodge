//-----------------------------------------------------------------------
// <copyright file="Food.cs" company="Brody Schulke">
//     Brody Schulke
// </copyright>
//-----------------------------------------------------------------------
namespace RollToDodge.Classes
{
    using RollToDodge.Interfaces;

    /// <summary>
    /// Interaction logic for Food.cs
    /// Represents a food item that is consumable by a character
    /// </summary>
    public class Food : IItem
    {
        /// <summary>
        /// Weight of the food item
        /// </summary>
        private int weight;

        /// <summary>
        /// Initializes a new instance of the Food class
        /// </summary>
        public Food()
        {
        }

        /// <summary>
        /// Gets or sets the description of the food
        /// </summary>
        public string Description { get; set; }

        /// <summary>
        /// Gets or sets the health healed by the food upon consumption
        /// </summary>
        public int HealthHealed { get; set; }

        /// <summary>
        /// Gets or sets the quantity of the food that the character has
        /// </summary>
        public int Quantity { get; set; }

        /// <summary>
        /// Gets or sets the name of the food
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// Gets or sets the weight of the food which is multiplied by the quantity that the 
        /// character has
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
