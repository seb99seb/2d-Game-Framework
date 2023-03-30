namespace Game_library
{
    /// <summary>
    /// An equipable offensive item, that dictates the wearers capability to do damage, both damage and range wise
    /// </summary>
    public class AttackItem
    {
        /// <summary>
        /// Name of the attack item
        /// </summary>
        public string Name { get; set; }
        /// <summary>
        /// The damage stat, is a deciding factor in damage calcuation
        /// </summary>
        public int Damage { get; set; }
        /// <summary>
        /// Range stat, dictates how far away from their target the weapon can hit
        /// </summary>
        public int Range { get; set; }
        /// <summary>
        /// Constructor setting the properties for name, damage and range
        /// </summary>
        /// <param name="name">Given name for the attack item</param>
        /// <param name="damage">Damage stat the attack item will have</param>
        /// <param name="range">The range the weapon will be capable of using</param>
        public AttackItem(string name, int damage, int range)
        {
            Name = name;
            Damage = damage;
            Range = range;
        }
    }
}
