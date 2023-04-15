using Game_library.Interfaces;

namespace Game_library
{
    /// <summary>
    /// An equipable defensive item, that dictates the wearers capability to resist damage
    /// </summary>
    public class DefenseItem : IEquipment
    {
        /// <summary>
        /// Name of the defense item
        /// </summary>
        public string Name { get; set; }
        /// <summary>
        /// The defense stat, is a deciding factor in damage calcuation
        /// </summary>
        public int Armor { get; set; }
        /// <summary>
        /// Constructor setting the properties for name, damage and range
        /// </summary>
        /// <param name="name">Given name for the defensive item</param>
        /// <param name="armor">Defensive stat the attack item will have</param>
        public DefenseItem(string name, int armor)
        {
            Name = name;
            Armor = armor;
        }
    }
}
