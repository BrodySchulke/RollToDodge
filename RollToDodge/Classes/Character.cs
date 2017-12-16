//-----------------------------------------------------------------------
// <copyright file="Character.cs" company="Brody Schulke">
//     Brody Schulke
// </copyright>
//-----------------------------------------------------------------------
namespace RollToDodge.Classes
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using RollToDodge.Interfaces;

    /// <summary>
    /// Interaction logic for Character.cs
    /// Represents a Character that has attributes and is managed by a real-word player
    /// </summary>
    public class Character
    {
        // Equipped items currently can't store references to existing objects
        // due to the limitations of storing gamedata using JSON.NET.
        // In the future, this is something I would like to optimize to reduce overhead

        /// <summary>
        /// Represents the set of Armour equipped by the Character
        /// </summary>
        private Armour[] equippedArmour;

        /// <summary>
        /// Represents the set of Weapons equipped by the Character
        /// </summary>
        private Weapon[] equippedWeapons;

        /// <summary>
        /// Represents the entire inventory of the Character - a List of other sub-inventories
        /// which are instantiated by their specific types
        /// </summary>
        private List<List<IItem>> inventory;

        /// <summary>
        /// Initializes a new instance of the Character class
        /// </summary>
        public Character()
        {
            this.equippedArmour = new Armour[Enum.GetNames(typeof(EquippedArmourSlot)).Length];
            this.equippedWeapons = new Weapon[Enum.GetNames(typeof(EquippedWeaponSlot)).Length];
            this.inventory = new List<List<IItem>>(Enum.GetNames(typeof(ItemType)).Length);
            this.Attributes = new int[Enum.GetNames(typeof(CharacterAttribute)).Length];
            this.Armour = new List<Armour>();
            this.Food = new List<Food>();
            this.Weapons = new List<Weapon>();
        }

        /// <summary>
        /// Represents the various attributes that each character has
        /// </summary>
        public enum CharacterAttribute
        {
            /// <summary>
            /// Character agility
            /// </summary>
            Agility,

            /// <summary>
            /// Character Charisma
            /// </summary>
            Charisma,

            /// <summary>
            /// Character Intelligence
            /// </summary>
            Intelligence,

            /// <summary>
            /// Character Perception
            /// </summary>
            Perception,

            /// <summary>
            /// Character Strength
            /// </summary>
            Strength
        }

        /// <summary>
        /// Represents the slots where armour can be equipped
        /// </summary>
        public enum EquippedArmourSlot
        {
            /// <summary>
            /// Boots slot
            /// </summary>
            Boots,

            /// <summary>
            /// Helmet slot
            /// </summary>
            Helmet,

            /// <summary>
            /// Torso slot
            /// </summary>
            Torso,

            /// <summary>
            /// Legs slot
            /// </summary>
            Legs,

            /// <summary>
            /// Shield slot
            /// </summary>
            Shield
        }

        /// <summary>
        /// Represents the slots where weapons can be equipped
        /// </summary>
        public enum EquippedWeaponSlot
        {
            /// <summary>
            /// Ammo slot
            /// </summary>
            Ammo,

            /// <summary>
            /// Left arm slot
            /// </summary>
            LeftArm,

            /// <summary>
            /// Ranged slot
            /// </summary>
            Ranged,

            /// <summary>
            /// Right arm slot
            /// </summary>
            RightArm
        }

        /// <summary>
        /// Represents the types of items
        /// </summary>
        public enum ItemType
        {
            /// <summary>
            /// Armour item type
            /// </summary>
            Armour,

            /// <summary>
            /// Food item type
            /// </summary>
            Food,

            /// <summary>
            /// Weapon item type
            /// </summary>
            Weapons
        }

        /// <summary>
        /// Gets or sets the list of attributes
        /// Used for managing attribut points of a character
        /// </summary>
        public int[] Attributes { get; set; }

        /// <summary>
        /// Gets or sets the list of Armour that the character has 
        /// in their inventory
        /// </summary>
        public List<Armour> Armour { get; set; }

        /// <summary>
        /// Gets the carrying capacity of the character which is 
        /// based on their strength
        /// </summary>
        public int CarryCapacity
        {
            get
            {
                return this.Attributes[Convert.ToInt32(CharacterAttribute.Strength)] * 10;
            }
        }

        /// <summary>
        /// Gets the weight of items that the character is currently carrying
        /// </summary>
        public int CarryWeight
        {
            get
            {
                return Enumerable.Sum(this.Inventory.Select(list => list.Sum(item => item.Weight)));
            }
        }

        /// <summary>
        /// Gets or sets the character's current health
        /// </summary>
        public int CurrentHealth { get; set; }

        /// <summary>
        /// Gets or sets the experience points the character currently has
        /// </summary>
        public int Experience { get; set; }

        /// <summary>
        /// Gets the list of food that the character currently has
        /// in their inventory
        /// </summary>
        public List<Food> Food { get; }

        /// <summary>
        /// Gets or sets the amount of gold the character has
        /// </summary>
        public int Gold { get; set; }

        /// <summary>
        /// Gets or sets the character's current level
        /// </summary>
        public int Level { get; set; }

        /// <summary>
        /// Gets the list of weapons that the character currently has in
        /// their inventory
        /// </summary>
        public List<Weapon> Weapons { get; }

        /// <summary>
        /// Gets or sets the character's entire inventory
        /// </summary>
        public List<List<IItem>> Inventory
        {
            get
            {
                return this.inventory;
            }

            set
            {
                this.inventory = value;
            }
        }

        /// <summary>
        /// Gets or sets the name of the character
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// Gets or sets the list of negative attributes associated with 
        /// the character
        /// </summary>
        public List<string> NegativeAttributes { get; set; }

        /// <summary>
        /// Gets or sets the character's maximum health
        /// </summary>
        public int MaxHealth { get; set; }

        /// <summary>
        /// Gets or sets the list of specialized attributes associated with
        /// the character
        /// </summary>
        public List<string> SpecializedAttributes { get; set; }

        /// <summary>
        /// Merges all of the sub-inventories of specific item types into the 
        /// player's main inventory for display purposes
        /// </summary>
        public void MergeToInventory()
        {
            for (int i = 0; i < Enum.GetNames(typeof(ItemType)).Length; i++)
            {
                this.Inventory.Add(new List<IItem>());
            }

            this.Inventory[0].AddRange(this.Food);
            this.Inventory[1].AddRange(this.Weapons);
            this.Inventory[2].AddRange(this.Armour);
        }

        /// <summary>
        /// Informs JSON.Net not to serialize the inventory. Since it is a collection
        /// of interfaces, resolving object types is not possible now.
        /// </summary>
        /// <returns>Always false</returns>
        public bool ShouldSerializeInventory()
        {
            return false;
        }
    }
}
