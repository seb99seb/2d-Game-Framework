namespace Game_library
{
    /// <summary>
    /// A creature, is able to move around and interact with the world, can equip items and do combat
    /// </summary>
    public class Creature
    {
        /// <summary>
        /// The weapon equipped for the creature, decides how much damage the creature can deal
        /// </summary>
        public AttackItem Weapon { get; set; }
        /// <summary>
        /// The defensive item the creature has equipped, dictates how much flat damage can be resisted when damaged
        /// </summary>
        public DefenseItem Defense { get; set; }
        /// <summary>
        /// The name of a given creature
        /// </summary>
        public string Name { get; set; }
        /// <summary>
        /// The life the creature has remaining
        /// </summary>
        public int Hitpoints { get; set; }
        /// <summary>
        /// Constructor for a single creature, with name and hitpoints being parameters that has to be given, and weapon and defense optional
        /// </summary>
        /// <param name="name">The deciding name for a creature</param>
        /// <param name="hitpoints">Starting life for a creature</param>
        /// <param name="weapon">The starting weapon the creature will be utilizing</param>
        /// <param name="defense">The starting defense the creature will have equipped</param>
        public Creature(string name, int hitpoints, AttackItem? weapon, DefenseItem? defense)
        {
            Name = name;
            Hitpoints = hitpoints;
            if (Weapon != null)
            {
                Weapon = weapon;
            }
            else
            {
                Weapon = null;
            }
            if (Defense != null)
            {
                Defense = defense;
            }
            else
            {
                Defense = null;
            }
        }
        /// <summary>
        /// Method for calculating however much damage the creature will dish out
        /// </summary>
        /// <returns>Returns the damage number, decided by the damage stat from the equipped weapon</returns>
        public int Hit()
        {
            if (Weapon == null)
            {
                return 3;
            }
            else
            {
                return Weapon.Damage;
            }
        }
        /// <summary>
        /// Method for picking up and equipping a new defensive item
        /// </summary>
        /// <param name="defense">The new defensive item that is being looted</param>
        public void Loot(DefenseItem defense)
        {
            Defense = defense;
        }
        /// <summary>
        /// Method for picking up and equipping a new offensive item
        /// </summary>
        /// <param name="weapon">The new offensive item that is being looted</param>
        public void Loot(AttackItem weapon)
        {
            Weapon = weapon;
        }
        /// <summary>
        /// Method for calculating the damage the creature will be receiving to its hitpoints, utilizes the equipped defensive to flatly reduce incoming damage
        /// </summary>
        /// <param name="damage">The incoming raw damage that will reduce the creatures hitpoints</param>
        public void ReceiveHit(int damage)
        {
            if (Defense != null)
            {
                damage -= Defense.Armor;
                if (damage < 0)
                {
                    damage = 0;
                }
                Hitpoints -= damage;
            }
            else
            {
                Hitpoints -= damage;
            }
        }
    }
}
