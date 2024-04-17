using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mandatory_Assignment_in_Advanced_Software_Construction
{
    // Represents a consumable item in the game that can restore health to a Creature.
    public class Consumable
    {
        // Name of the consumable item.
        public string Name { get; private set; }
        // Amount of health restored by using this consumable.
        public int HealthRestore { get; private set; }
        // Flag to track whether the consumable has been used.
        public bool IsUsed { get; private set; }

        // Constructor initializes the consumable with a name and health restoration value.
        public Consumable(string name, int healthRestore)
        {
            Name = name;
            HealthRestore = healthRestore;
            IsUsed = false;
        }

        // Use the consumable on a target Creature, restoring health and marking it as used.
        public bool Use(Creature target)
        {
            if (!IsUsed && target != null) // Ensures the consumable is not used and the target is not null.
            {
                target.RestoreHealth(HealthRestore); // Restore health to the target.
                IsUsed = true; // Mark the consumable as used.
                Console.WriteLine($"{Name} blev brugt på {target.Name}, genopretter {HealthRestore} HP.");
                return true;
            }
            else
            {
                Console.WriteLine($"{Name} kan ikke bruges igen eller mål er null.");
                return false;
            }
        }
    }
}
