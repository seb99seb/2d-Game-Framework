namespace Game_library
{
    public class AttackItem
    {
        public string Name { get; set; }
        public int Damage { get; set; }
        public int Range { get; set; }
        public AttackItem(string name, int damage, int range)
        {
            Name = name;
            Damage = damage;
            Range = range;
        }
    }
}
