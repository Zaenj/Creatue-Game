using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mandatory_Assignment_in_Advanced_Software_Construction
{
    // Verdensobjekt klasse som kan interageres med i spillet.
    public class WorldObject
    {
        public string Name { get; private set; }
        public bool Lootable { get; private set; }
        public bool Removable { get; private set; }

        protected WorldObject(string name, bool lootable, bool removable)
        {
            Name = name;
            Lootable = lootable;
            Removable = removable;
        }


    }
}
