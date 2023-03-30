namespace Game_library
{
    /// <summary>
    /// An object in the world, can be pickups or blockades
    /// </summary>
    public class WorldObject
    {
        /// <summary>
        /// The position where the world object lies
        /// </summary>
        public Position Pos { get; set; }
        /// <summary>
        /// The attack item object, in case the world object is a weapon pickup
        /// </summary>
        public AttackItem Weapon { get; set; }
        /// <summary>
        /// The defense item object, in case the world object is a defense pickup
        /// </summary>
        public DefenseItem Defense { get; set; }
        /// <summary>
        /// Name of the world object
        /// </summary>
        public string Name { get; set; }
        /// <summary>
        /// Bool deciding if the world object is something that can be picked up
        /// </summary>
        public bool Lootable { get; set; }
        /// <summary>
        /// Bool that dictates whether or not a world object can be removed or not
        /// </summary>
        public bool Removable { get; set; }
        /// <summary>
        /// Constructor for if the world object is not a pickup, but rather a form of blockade
        /// </summary>
        /// <param name="name">Name for the world object being created</param>
        /// <param name="position">The position for the world object in the world</param>
        /// <param name="removable">Bool that decides if the world object can be removed from the map</param>
        public WorldObject(string name, Position position, bool removable)
        {
            Name = name;
            Pos = position;
            Lootable = false;
            Removable = removable;
        }
        /// <summary>
        /// Constructor for if the world object is a pickup, more specifically an attack item pickup
        /// </summary>
        /// <param name="name">Name for the world object being created</param>
        /// <param name="position">The position for the world object in the world</param>
        /// <param name="weapon">The attack item the world object contains</param>
        public WorldObject(string name, Position position, AttackItem weapon)
        {
            Name = name;
            Pos = position;
            Weapon = weapon;
            Lootable = true;
            Removable = false;
        }
        /// <summary>
        /// Constructor for if the world object is a pickup, more specifically a defense item pickup
        /// </summary>
        /// <param name="name">Name for the world object being created</param>
        /// <param name="position">The position for the world object in the world</param>
        /// <param name="defense">The defense item the world object contains</param>
        public WorldObject(string name, Position position, DefenseItem defense)
        {
            Name = name;
            Pos = position;
            Defense = defense;
            Lootable = true;
            Removable = false;
        }
    }
}