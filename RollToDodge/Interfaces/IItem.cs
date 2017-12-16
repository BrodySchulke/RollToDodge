//-----------------------------------------------------------------------
// <copyright file="IItem.cs" company="Brody Schulke">
//     Brody Schulke
// </copyright>
//-----------------------------------------------------------------------
namespace RollToDodge.Interfaces
{
    /// <summary>
    /// Interface used by item types
    /// </summary>
    public interface IItem
    {
        /// <summary>
        /// Gets or sets the description of the item
        /// </summary>
        string Description { get; set; }

        /// <summary>
        /// Gets or sets the quantity of the item
        /// </summary>
        int Quantity { get; set; }

        /// <summary>
        /// Gets or sets the ame of the item
        /// </summary>
        string Name { get; set; }

        /// <summary>
        /// Gets or sets the weight of the item
        /// </summary>
        int Weight { get; set; }
    }
}
