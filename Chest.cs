using System;
using System.Collections.Generic;

namespace Mandatory_Assignment_in_Advanced_Software_Construction
{
    // Defines a Chest class which contains various types of game items.
    public class Chest
    {
        // Lists to store various types of items within the chest.
        public List<AttackItem> AttackItems { get; set; }
        public List<DefenceItem> DefenceItems { get; set; }
        public List<Consumable> Consumables { get; set; }
        public bool IsLootable { get; set; } // Indicates whether the chest can be looted.

        // Constructor initializes the lists and sets the chest to be lootable by default.
        public Chest()
        {
            AttackItems = new List<AttackItem>();
            DefenceItems = new List<DefenceItem>();
            Consumables = new List<Consumable>();
            IsLootable = true; // Assuming chests are always lootable by default.
            InitializeContents(); // Populate the chest with items.
        }

        // Initializes the contents of the chest with random items.
        private void InitializeContents()
        {
            Logger.Log("Skaber chestobjekt"); // Logging chest creation.

            Random rnd = new Random();

            // Randomly decide the count of each type of item (for simplicity, 0-2 of each)
            int attackItemCount = rnd.Next(0, 3);
            int defenceItemCount = rnd.Next(0, 3);
            int consumableCount = rnd.Next(0, 3);

            // Populate the chest with attack items.
            for (int i = 0; i < attackItemCount; i++)
            {
                AttackItems.Add(GameObjectFactory.CreateAttackItem($"Sword{i + 1}", 10 * (i + 1), 1));
            }

            // Populate the chest with defence items.
            for (int i = 0; i < defenceItemCount; i++)
            {
                DefenceItems.Add(GameObjectFactory.CreateDefenceItem($"Shield{i + 1}", 5 * (i + 1)));
            }

            // Populate the chest with consumables.
            for (int i = 0; i < consumableCount; i++)
            {
                Consumables.Add(GameObjectFactory.CreateConsumable($"Health Potion{i + 1}", 20 * (i + 1)));
            }
        }

        // Checks if the chest is empty (i.e., has no items).
        public bool IsEmpty()
        {
            return !AttackItems.Any() && !DefenceItems.Any() && !Consumables.Any();
        }
    }
}
