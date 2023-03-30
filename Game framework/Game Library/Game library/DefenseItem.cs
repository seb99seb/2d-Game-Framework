namespace Game_library
{
    public class DefenseItem
    {
        public string Name { get; set; }
        public int Armor { get; set; }
        public DefenseItem(string name, int armor)
        {
            Name = name;
            Armor = armor;
        }
    }
}
