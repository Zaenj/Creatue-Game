using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mandatory_Assignment_in_Advanced_Software_Construction
{
    // Defines configuration settings for different aspects of the game.
    public class GameSettings
    {
        public WorldSize? WorldSize { get; set; } // Optional configuration for world dimensions.
        public CreatureDefaults? CreatureDefaults { get; set; } // Optional default settings for creatures.
        public ItemSettings? ItemSettings { get; set; } // Optional settings for items within the game.
    }

    // Represents the dimensions of the game world.
    public class WorldSize
    {
        public int MaxX { get; set; } // Maximum X dimension of the world.
        public int MaxY { get; set; } // Maximum Y dimension of the world.
    }

    // Default settings for creature characteristics.
    public class CreatureDefaults
    {
        public int InitialHealth { get; set; } // The initial health of a creature.
        public int MaxHealth { get; set; } // The maximum health a creature can have.
        public double AttackCoefficient { get; set; } // Coefficient for calculating attack damage.
        public double DefenseCoefficient { get; set; } // Coefficient for calculating defense ability.
    }

    // Settings related to different types of items in the game.
    public class ItemSettings
    {
        public int MaxAttackItems { get; set; } // Maximum number of attack items allowed.
        public int MaxDefenseItems { get; set; } // Maximum number of defense items allowed.
        public int MaxConsumables { get; set; } // Maximum number of consumable items allowed.
        public InitialItemProbabilities InitialItemProbabilities { get; set; } // Probabilities for initially spawning items.
    }

    // Probabilities for each type of item to appear in the game.
    public class InitialItemProbabilities
    {
        public int AttackItemChance { get; set; } // Probability of finding an attack item.
        public int DefenseItemChance { get; set; } // Probability of finding a defense item.
        public int ConsumableChance { get; set; } // Probability of finding a consumable item.
    }
}
