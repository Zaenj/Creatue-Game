using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mandatory_Assignment_in_Advanced_Software_Construction
{
    public class World
    {
        public int MaxX { get; set; }
        public int MaxY { get; set; }
        public List<Creature> Creatures { get; set; }
        public List<WorldObject> WorldObjects { get; set; }
        public List<Chest> Chests { get; set; }  

        public World(int maxX, int maxY)
        {
            MaxX = maxX;
            MaxY = maxY;
            Creatures = new List<Creature>();
            WorldObjects = new List<WorldObject>();
            Chests = new List<Chest>(); 
        }

        public void AddCreature(Creature creature)
        {
            if (creature.X <= MaxX && creature.Y <= MaxY)
                Creatures.Add(creature);
        }

        public void AddWorldObject(WorldObject worldObject)
        {
            WorldObjects.Add(worldObject);
        }

   
        public void AddChest(Chest chest)
        {
            if (Chests != null)
                Chests.Add(chest);
        }

        public void Initialize()
        {
            // bruger GameObjectFactory til at tilføje startobjekter og skabninger til verdenen
            AddCreature(GameObjectFactory.CreateCreature("Orc", 100, 100, 5, 5));
            AddCreature(GameObjectFactory.CreateCreature("Elf", 80, 80, 5, 5));
            AddWorldObject(GameObjectFactory.CreateAttackItem("Sword", 20, 2));
            AddWorldObject(GameObjectFactory.CreateDefenceItem("Shield", 5));
            AddWorldObject(GameObjectFactory.CreateAttackItem("Fist", 2, 1));

            // tilføj en Chest med random indhold til verden
            Chest treasureChest = GameObjectFactory.CreateChest();
            AddChest(treasureChest);
        }
    }
}
