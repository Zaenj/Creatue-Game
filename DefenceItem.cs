using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mandatory_Assignment_in_Advanced_Software_Construction
{
    /// <summary>
    /// Represents a defense item that can reduce the damage taken by a creature.
    /// Inherits from <see cref="WorldObject"/>.
    /// </summary>
    public class DefenceItem : WorldObject
    {
        /// <summary>
        /// Gets the amount of hit points this defense item can reduce.
        /// </summary>
        public int ReduceHitPoint { get; private set; }

        /// <summary>
        /// Initializes a new instance of the <see cref="DefenceItem"/> class.
        /// </summary>
        /// <param name="name">The name of the defense item.</param>
        /// <param name="reduceHitPoint">The hit points reduced by the item.</param>
        public DefenceItem(string name, int reduceHitPoint)
            : base(name, true, true)
        {
            ReduceHitPoint = reduceHitPoint;
        }
    }
}
