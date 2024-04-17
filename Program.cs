using Mandatory_Assignment_in_Advanced_Software_Construction;

class Program
{
    static void Main()
    {
        string configPath = "C:\\Users\\ZaenJav\\Desktop\\Mandatory Assignment in Advanced Software Construction\\gameConfig.json"; // Adjust path as necessary
        GameConfig config = GameConfig.Load(configPath);

        if (config != null)
        {
            Console.WriteLine($"World Dimensions: {config.WorldMaxX}x{config.WorldMaxY}");
            foreach (var creature in config.Creatures)
            {
                Console.WriteLine($"Creature: {creature.Name}, HP: {creature.MaxHealth}, Location: ({creature.StartingX}, {creature.StartingY})");
            }

            foreach (var item in config.ChestItems)
            {
                Console.WriteLine($"Item: {item.Name}, Type: {item.Type}, Quantity: {item.Quantity}");
            }
        }
        else
        {
            Console.WriteLine("Configuration could not be loaded.");
        }

        // Creating creatures for simulation
        Creature creature1 = GameObjectFactory.CreateCreature("Warrior", 100, 150, 1, 1); //instansiering af objekt
        Creature creature2 = GameObjectFactory.CreateCreature("Mage", 80, 100, 1, 2);  // Adjusted position to be in range

        // Adding attack items to creatures for the fight
        creature1.AttackItems.Add(GameObjectFactory.CreateAttackItem("Sword", 25, 1));
        creature2.AttackItems.Add(GameObjectFactory.CreateAttackItem("Staff", 20, 1));

        // Fight simulation with a loop until one dies
        Console.WriteLine($"Starting the fight between {creature1.Name} and {creature2.Name}.");
        while (creature1.HitPoint > 0 && creature2.HitPoint > 0)
        {
            // Move towards each other if out of range
            if (!creature1.IsInRange(creature2, creature1.AttackItems.First()) && creature1.X < creature2.X)
            {
                creature1.X++;
            }
            else if (!creature2.IsInRange(creature1, creature2.AttackItems.First()) && creature2.X > creature1.X)
            {
                creature2.X--;
            }

            creature1.Hit(creature2); // Creature 1 attacks Creature 2
            if (creature2.HitPoint > 0)
            {
                creature2.Hit(creature1); // Creature 2 retaliates if still alive
            }
        }

        Console.WriteLine($"Fight ended. {creature1.Name} HP: {creature1.HitPoint}, {creature2.Name} HP: {creature2.HitPoint}");

        // Check and announce the winner
        if (creature1.HitPoint <= 0 && creature2.HitPoint > 0)
        {
            Console.WriteLine($"{creature2.Name} is the winner!");
        }
        else if (creature2.HitPoint <= 0 && creature1.HitPoint > 0)
        {
            Console.WriteLine($"{creature1.Name} is the winner!");
        }
        else
        {
            Console.WriteLine("Both creatures have fallen!");
        }

       
    }
}
