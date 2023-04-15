using System;
using System.Xml.Linq;
using Game_library.Attacks;
using Game_library.Interfaces;

namespace Game_library
{
    /// <summary>
    /// A creature, is able to move around and interact with the world, can equip items and do combat
    /// </summary>
    public class Creature : ISubject
    {
        private List<IObserver> _observers = new List<IObserver>();
        private IStrategy _strategy;
        /// <summary>
        /// The position where the creature lies
        /// </summary>
        public IPosition Pos { get; set; }
        /// <summary>
        /// The weapon equipped for the creature, decides how much damage the creature can deal
        /// </summary>
        public AttackItem? Weapon { get; set; }
        /// <summary>
        /// The defensive item the creature has equipped, dictates how much flat damage can be resisted when damaged
        /// </summary>
        public DefenseItem? Defense { get; set; }
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
        public Creature(string name, int hitpoints, IPosition position, AttackItem? weapon, DefenseItem? defense)
        {
            _strategy = new StandardAttack();
            Name = name;
            Hitpoints = hitpoints;
            Pos = position;
            Weapon = weapon;
            Defense = defense;
        }
        /// <summary>
        /// Method for calculating however much damage the creature will dish out
        /// </summary>
        /// <returns>Returns the damage number, decided by the damage stat from the equipped weapon</returns>
        public (int, IStrategy) Hit()
        {
            if (Weapon == null)
            {
                return (3, _strategy);
            }
            else
            {
                return (Convert.ToInt32(_strategy.Attack(Weapon)), _strategy);
            }
        }
        /// <summary>
        /// Method for picking up and equipping a new defensive item
        /// </summary>
        /// <param name="defense">The new defensive item that is being looted</param>
        public void Loot(IEquipment equipment)
        {
            if (typeof(AttackItem).IsInstanceOfType(equipment))
            {
                Weapon = equipment as AttackItem;
            }
            else if (typeof(DefenseItem).IsInstanceOfType(equipment))
            {
                Defense = equipment as DefenseItem;
            }
        }
        /// <summary>
        /// Method for calculating the damage the creature will be receiving to its hitpoints, utilizes the equipped defensive to flatly reduce incoming damage
        /// </summary>
        /// <param name="damage">The incoming raw damage that will reduce the creatures hitpoints</param>
        public virtual void ReceiveHit(World world, (int damage, IStrategy strat) hitinfo)
        {
            int damage = hitinfo.damage;
            if (typeof(DoubleAttack).IsInstanceOfType(hitinfo.strat))
            {
                damage *= 2;
                if (Defense != null)
                {
                    damage -= Defense.Armor;
                }
            }
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
            if (Hitpoints < 0)
            {
                Hitpoints = 0;
            }
            Notify(world);
        }
        public void Attach(IObserver observer)
        {
            _observers.Add(observer);
        }
        public void Notify(World world)
        {
            foreach (var observer in _observers)
            {
                observer.Update(world, this);
            }
        }
        public void ChangeStrategy(IStrategy strategy)
        {
            _strategy = strategy;
        }
    }
}
