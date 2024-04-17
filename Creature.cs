using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mandatory_Assignment_in_Advanced_Software_Construction
{
    // Skabning klasse repræsenterer de væsner der befinder sig i spilverdenen.
    public class Creature
    {
        public string Name { get; set; }
        public int HitPoint { get; set; }
        public int MaxHitPoints { get; set; }  // Maximum health points the creature can have
        public int X { get; set; }
        public int Y { get; set; }
        public List<AttackItem> AttackItems { get; set; }
        public List<DefenceItem> DefenceItems { get; set; }
        public List<Consumable> Consumables { get; private set; }

        public Creature(string name, int hitPoint, int maxHitPoints, int x, int y)
        {
            Name = name;
            HitPoint = hitPoint;
            MaxHitPoints = maxHitPoints;
            X = x;
            Y = y;
            AttackItems = new List<AttackItem>();
            DefenceItems = new List<DefenceItem>();
            Consumables = new List<Consumable>();
        }

        // Hjælpefunktion til at bestemme om et mål er inden for rækkevidde af våbnet.
        public virtual bool IsInRange(Creature target, AttackItem weapon)
        {
            int distance = Math.Abs(X - target.X) + Math.Abs(Y - target.Y);
            return distance <= weapon.Range;
        }

        // Udføre et angreb med et valgt våben.
        public virtual void Hit(Creature target)
        {
            // Tjekker om skabningen har nogle våben udstyret
            if (AttackItems == null || AttackItems.Count == 0)
            {
                UnarmedHit(target);
            }
            else
            {
                // Vælger det våben med den højeste skade
                AttackItem weapon = AttackItems.OrderByDescending(w => w.HitPoint).FirstOrDefault();

                if (weapon != null && IsInRange(target, weapon))
                {
                    int damage = weapon.HitPoint;
                    target.ReceiveHit(damage);
                    Console.WriteLine($"{Name} angreb {target.Name} med {weapon.Name} for {damage} skade!");
                }
                else if (weapon != null)
                {
                    Console.WriteLine($"{Name} er for langt væk fra {target.Name} til at angribe med {weapon.Name}.");
                }
            }
        }
        protected virtual void UnarmedHit(Creature target)
        {
            // Antager en standard skade for ubevæbnede angreb
            int damage = 1;
            target.ReceiveHit(damage);
            Console.WriteLine($"{Name} angreb {target.Name} ubevæbnet for {damage} skade!");
        }

        // Modtage et angreb og anvende forsvar.
        public virtual void ReceiveHit(int hitPoints)
        {
            int totalDefense = DefenceItems.Sum(item => item.ReduceHitPoint);
            int damageTaken = Math.Max(hitPoints - totalDefense, 0); //linq

            HitPoint -= damageTaken;
            Console.WriteLine($"{Name} modtog {damageTaken} skade efter forsvar og har nu {HitPoint} hitpoints tilbage.");

            if (HitPoint <= 0)
                Die();
        }

        
        // Logik for at opsamle et objekt.
        public virtual void Loot(WorldObject worldObject)
        {
            if (worldObject is AttackItem attackItem && attackItem.Lootable)
            {
                AttackItems.Add(attackItem);
                Console.WriteLine($"{Name} har opsamlet et angrebsobjekt: {attackItem.Name}.");
            }
            else if (worldObject is DefenceItem defenceItem && defenceItem.Lootable)
            {
                DefenceItems.Add(defenceItem);
                Console.WriteLine($"{Name} har opsamlet et forsvarsobjekt: {defenceItem.Name}.");
            }
            else
            {
                Console.WriteLine($"{Name} kan ikke opsamle {worldObject.Name}.");
            }
        }

        // Logik for hvad der sker når skabningen dør.
        protected virtual void Die()
        {
            Console.WriteLine($"{Name} er død.");
            // Implementere logik for at fjerne skabningen fra verdenen her.
        }

        // En "template" metode der definerer skridtene i en kamp.
        
        public virtual void PerformAction(Creature target)
        {       

            ChooseAction(); // Vælg handling baseret på skabningens tilstand og tilgængelige genstande.
            Hit(target); // Udføre angreb eller anden handling.
            Logger.Log($"{Name} har udført en handling.");
        }

        // En virtuel metode der kan tilpasses i nedarvede klasser.
        protected virtual void ChooseAction() /// virtual = overrideable
        {
            // Vælg handling. Kan være mere kompleks i nedarvede klasser.
        }

        public virtual void LootAllCreature(Creature deadCreature)
        {
            if (deadCreature == null || deadCreature.HitPoint > 0)
            {
                Console.WriteLine("Intet at samle op eller skabningen er ikke død.");
                return;
            }

            AttackItems.AddRange(deadCreature.AttackItems); //linq
            DefenceItems.AddRange(deadCreature.DefenceItems);
            Console.WriteLine($"{Name} har samlet alle genstande fra {deadCreature.Name}.");
        }

        public virtual void LootSpecificCreature(Creature deadCreature, WorldObject item)
        {
            if (deadCreature == null || deadCreature.HitPoint > 0)
            {
                Console.WriteLine("Intet at samle op eller skabningen er ikke død.");
                return;
            }

            if (item is AttackItem attackItem && deadCreature.AttackItems.Contains(attackItem))
            {
                AttackItems.Add(attackItem);
                deadCreature.AttackItems.Remove(attackItem);
            }
            else if (item is DefenceItem defenceItem && deadCreature.DefenceItems.Contains(defenceItem))
            {
                DefenceItems.Add(defenceItem);
                deadCreature.DefenceItems.Remove(defenceItem);
            }

            Console.WriteLine($"{Name} har samlet {item.Name} fra {deadCreature.Name}.");
        }

        public virtual void LootAllChest(Chest chest)
        {
            if (chest == null || !chest.IsLootable)
            {
                Console.WriteLine("Intet at samle op eller kisten er ikke tilgængelig.");
                return;
            }

            AttackItems.AddRange(chest.AttackItems);
            DefenceItems.AddRange(chest.DefenceItems);
            Console.WriteLine($"{Name} har samlet alle genstande fra kisten.");
        }

        public virtual void LootSpecificChest(Chest chest, WorldObject item)
        {
            if (chest == null || !chest.IsLootable)
            {
                Console.WriteLine("Intet at samle op eller kisten er ikke tilgængelig.");
                return;
            }

            if (item is AttackItem attackItem && chest.AttackItems.Contains(attackItem))
            {
                AttackItems.Add(attackItem);
                chest.AttackItems.Remove(attackItem);
            }
            else if (item is DefenceItem defenceItem && chest.DefenceItems.Contains(defenceItem))
            {
                DefenceItems.Add(defenceItem);
                chest.DefenceItems.Remove(defenceItem);
            }

            Console.WriteLine($"{Name} har samlet {item.Name} fra kisten.");
        }

        public virtual void UseConsumable(Consumable consumable)
        {
            // Check if the consumable is valid and belongs to the creature's inventory
            if (consumable != null && Consumables.Contains(consumable) && !consumable.IsUsed)
            {
                if (consumable.Use(this)) // This will handle the restoration and set IsUsed to true
                {
                    Console.WriteLine($"{Name} has used {consumable.Name} and restored health.");
                    Consumables.Remove(consumable); // Remove the consumable after use
                }
                else
                {
                    Console.WriteLine($"{consumable.Name} cannot be used again or target is null.");
                }
            }
            else
            {
                Console.WriteLine($"Consumable is either not in the inventory or has already been used.");
            }
        }


        public virtual void RestoreHealth(int amount)
        {
            HitPoint += amount;
            if (HitPoint > MaxHitPoints)
            {
                HitPoint = MaxHitPoints; // Cap the HitPoint to MaxHitPoints
            }
            Console.WriteLine($"{Name} har nu {HitPoint}/{MaxHitPoints} HP.");
        }



    }
}
