using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;
namespace Practice
{

    public class Player
    {
    
        //Default constructor for Player object
        public Player()
        {
            
            Attributes = new int[Enum.GetNames(typeof(CharacterAttributes)).Length];
            Food = new List<Food>();
            Weapons = new List<Weapon>();
            CurrentHealth = 0;
            MaxHealth = 0;
            Name = "";
        }

        //Represents the various attributes that each player has
        public enum CharacterAttributes
        {
            Agility,
            Charisma,
            Intelligence,
            Perception,
            Strength
        }

        //Represents the slots for equipping armor
        public enum EquippedArmorSlots
        {
            Boots,
            Helmet,
            Torso,
            Legs,
            Shield
        }

        //Represents the slots for equipping weapons
        public enum EquippedWeaponSlots
        {
            Ammo,
            LeftArm,
            Ranged,
            RightArm
        }

        public enum ItemTypes
        {
            Armor,
            Food,
            Money,
            Weapons
        }

        //Holds values associated with each attriute
        public int[] Attributes { get; set; }

        //Gets or sets the Carry Capacity of the Player in pounds
        public int CarryCapacity
        {
            get
            {
                return this.Attributes[Convert.ToInt32(Player.CharacterAttributes.Strength)] * 10;
            }
        }

        //Represents the current weight being carried by the Player in pounds
        public int CarryWeight
        {
            get
            {
                return Inventory.Sum(x => x.Weight);
            }
        }

        //Represents the player's current health
        public int CurrentHealth { get; set; }

        //Gets the Food the Player currently has
        public List<Food> Food { get; }

        public List<Weapon> Weapons { get; }

        public List<IItem> Inventory
        {
            get
            {
                Inventory = new List<IItem>();
                Inventory.AddRange(Food);
                Inventory.AddRange(Weapons);
                return Inventory;
            }
            set
            {
                Inventory = value;
            }
        }

        //Player's fictional Name
        public string Name { get; set; }

        //Player's maximum health
        public int MaxHealth { get; set; }

        public bool ShouldSerializeInventory()
        {
            return false;
        }

        //Returns a string representation of the Player
        public override string ToString()
        {
            string res = String.Format(@"Name: {0} 
Attributes: {1}
Food: {2}"
            , this.Name, string.Join(",",this.Attributes), String.Join(",",Food.Select(x => x.Name)));
            return res;

        }
    }
}
