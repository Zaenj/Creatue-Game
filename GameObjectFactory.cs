using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace Mandatory_Assignment_in_Advanced_Software_Construction
{
    // Indfører en Factory klasse til at oprette spilobjekter.
    public static class GameObjectFactory
    {
        // Metode til at oprette en skabning.
        public static Creature CreateCreature(string name, int hitPoint, int maxHitPoints, int x, int y)
        {
            Logger.Log($"Skaber skabning: {name}");
            return new Creature(name, hitPoint, maxHitPoints, x, y);
        }

        // Metode til at oprette et angrebsobjekt.
        public static AttackItem CreateAttackItem(string name, int hitPoint, int range)
        {
            Logger.Log($"Skaber angrebsobjekt: {name}");
            return new AttackItem(name, hitPoint, range);
        }

        // Metode til at oprette et forsvarsobjekt.
        public static DefenceItem CreateDefenceItem(string name, int reduceHitPoint)
        {
            Logger.Log($"Skaber forsvarsobjekt: {name}");
            return new DefenceItem(name, reduceHitPoint);
        }

        //Metode til at oprette chest objekt
        public static Chest CreateChest()
        {
            Chest chest = new Chest();
            // Assume Chest constructor handles randomizing contents
            return chest;
        }

        // Method to create a Consumable item
        public static Consumable CreateConsumable(string name, int healthRestore)
        {
            Logger.Log($"Skaber Consumable");
            return new Consumable(name, healthRestore);
        }



    }
}
