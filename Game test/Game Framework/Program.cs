using Game_library;
using Game_library.Attacks;
using Game_library.Observers;
using Game_library.Factories;

World world = new World(10, 10);

#region Creature creation
Creature goblin1 = new Creature("Goblin", 7, new Position(5, 10), new AttackItem("Big Club", 4, 1), new DefenseItem("Leather", 2));
goblin1.Attach(new CreatureObserver());
world.CreatureList.Add(goblin1);

Creature goblin2 = new Creature("Goblin", 7, new Position(6, 10), null, null);
goblin2.Attach(new CreatureObserver());
world.CreatureList.Add(goblin2);

Creature goblin3 = new Creature("Goblin", 20, new Position(7, 10), null, new DefenseItem("Cloth", 1));
goblin3.Attach(new CreatureObserver());
world.CreatureList.Add(goblin3);
#endregion

#region Observer
Console.WriteLine("Current creatures in the world");
foreach (Creature creature in world.CreatureList)
{
    Console.WriteLine(creature.Name);
}
Console.WriteLine("");

goblin2.ReceiveHit(world, goblin1.Hit());
//demonstrates observer, seeing the goblin get to 0 hitpoints
goblin2.ReceiveHit(world, goblin1.Hit());

Console.WriteLine("");
Console.WriteLine("Current creatures in the world");
foreach (Creature creature in world.CreatureList)
{
    Console.WriteLine(creature.Name);
}
#endregion

Console.WriteLine("----------------");
goblin1.Loot(new AttackItem("Bigger Club", 7, 1));

#region Strategy
Console.WriteLine(goblin3.Hitpoints);

goblin3.ReceiveHit(world, goblin1.Hit()); //should be hit for 6 damage
Console.WriteLine(goblin3.Hitpoints); //should be at 14 hitpoints

goblin1.ChangeStrategy(new DoubleAttack()); //Sets the attack type to double attack instand of standard attack
goblin3.ReceiveHit(world, goblin1.Hit()); //should be hit for 8 damage
Console.WriteLine(goblin3.Hitpoints); //should be at 6 hitpoints
#endregion

Console.WriteLine("----------------");

#region Factory
Console.WriteLine($"{goblin1.Weapon.Damage} Damage");
Console.WriteLine($"{goblin1.Defense.Armor} Defense");

goblin1.Loot(EquipmentFactory.GetEquipment("defense", "Iron Armor", 4, 1));
goblin1.Loot(EquipmentFactory.GetEquipment("attack", "Biggest Club", 10));

Console.WriteLine($"{goblin1.Weapon.Damage} Damage");
Console.WriteLine($"{goblin1.Defense.Armor} Defense");
#endregion

Console.WriteLine("----------------");

#region LINQ
string creatureToBeSearched = "goblin";
var enemyList = world.FindEnemy(creatureToBeSearched);

Console.WriteLine($"There are {enemyList.Count} {creatureToBeSearched}(s) with coordinates:");
foreach (var creature in enemyList)
{
    Console.WriteLine($"{creature.Pos.X} {creature.Pos.Y}");
}

Console.WriteLine("");

creatureToBeSearched = "Boar";
enemyList = world.FindEnemy(creatureToBeSearched);

Console.WriteLine($"There are {enemyList.Count} {creatureToBeSearched}(s) with coordinates:");
foreach (var creature in enemyList)
{
    Console.WriteLine($"{creature.Pos.X} {creature.Pos.Y}");
}
#endregion

Console.WriteLine("----------------");

#region Liskov Substitution
GhostCreature Phantom1 = new GhostCreature("Phantom", 1, new Position(4, 9), new AttackItem("Lance", 4, 2), new DefenseItem("Spectral Armor", 3));
Phantom1.Attach(new CreatureObserver());
world.CreatureList.Add(Phantom1);

GhostCreature Phantom2 = new GhostCreature("Phantom", 1, new Position(5, 9), null, null);
Phantom2.Attach(new CreatureObserver());
world.CreatureList.Add(Phantom2);

Phantom2.ReceiveHit(world, Phantom1.Hit());
#endregion

Console.WriteLine("----------------");

#region Config
World worldConfigExample = new World();
Console.WriteLine($"{worldConfigExample.MaxX} is the max X coordinate");
Console.WriteLine($"{worldConfigExample.MaxY} is the max Y coordinate");
#endregion