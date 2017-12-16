//-----------------------------------------------------------------------
// <copyright file="Weapon.cs" company="Brody Schulke">
//     Brody Schulke
// </copyright>
//-----------------------------------------------------------------------
namespace RollToDodge.Classes
{
    using System;
    using RollToDodge.Interfaces;

    /// <summary>
    /// Interaction logic for Weapon.cs
    /// Represents a weapon that can be equipped by a character and does damange
    /// </summary>
    public class Weapon : IItem
    {
        /// <summary>
        /// Weight field
        /// </summary>
        private int weight;

        /// <summary>
        /// weaponType field
        /// </summary>
        private string weaponType;

        /// <summary>
        /// Initializes a new instance of the Weapon class
        /// </summary>
        public Weapon()
        {
        }

        /// <summary>
        /// Enum representing the possible types of weapons used for controller Character equips
        /// </summary>
        public enum WeaponType
        {
            /// <summary>
            /// One-handed weapon type
            /// </summary>
            OneHanded,

            /// <summary>
            /// Two-handed weapon type
            /// </summary>
            TwoHanded,

            /// <summary>
            /// Ranged weapon type
            /// </summary>
            Ranged,

            /// <summary>
            /// Ammo weapon type (these can be throwable or used by ranged weapons)
            /// </summary>
            Ammo
        }

        /// <summary>
        /// Gets or sets the description of the weapon
        /// </summary>
        public string Description { get; set; }

        /// <summary>
        /// Gets or sets the weapon damage
        /// </summary>
        public int Damage { get; set; }

        /// <summary>
        /// Gets or sets the number of this weapon that the Character has
        /// </summary>
        public int Quantity { get; set; }

        /// <summary>
        /// Gets or sets the name of the weapon
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// Gets or sets the assigned weapon type while restricting values to those
        /// of the WeaponType enum
        /// </summary>
        public string WeaponTypeAssigned
        {
            get
            {
                return this.weaponType;
            }

            set
            {
                if (Array.IndexOf(Enum.GetNames(typeof(WeaponType)), value) < 0)
                {
                    return;
                }

                this.weaponType = value;
            }
        }

        /// <summary>
        /// Gets or sets the weight of the weapon which multiplies based on the Quantity property
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
