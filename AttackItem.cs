using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mandatory_Assignment_in_Advanced_Software_Construction
{
    // AttackItem class that inherits from WorldObject, used to perform attacks.
    public class AttackItem : WorldObject, IAttack
    {
        // Properties for HitPoint and Range with private setters to encapsulate the class fields.
        public int HitPoint { get; private set; }
        public int Range { get; private set; }

        // Constructor that initializes the AttackItem along with base class properties.
        public AttackItem(string name, int hitPoint, int range)
            : base(name, true, true) // Calls the base class constructor with parameters.
        {
            HitPoint = hitPoint; // Assigns the hitPoint parameter to the HitPoint property.
            Range = range;       // Assigns the range parameter to the Range property.
        }

        // Method to perform an attack on a target creature.
        public void Attack(Creature target)
        {
            // Checks if the target is not null before performing an attack.
            if (target != null)
            {
                // Logs the attack action.
                Logger.Log($"{Name} angriber {target.Name}");
                // Calls the ReceiveHit method on the target creature with HitPoint as damage.
                target.ReceiveHit(HitPoint);
            }
        }
    }
}
