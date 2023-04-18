using Game_library;
using Game_library.Attacks;
using Game_library.Observers;
using Game_library.Factories;
using System.Diagnostics;
using System.Xml.Linq;
using System.Reflection.Emit;
using System.IO;

#region Config
/*
World world = new World();
Console.WriteLine($"{worldConfigExample.Name} has the following x and y coordinates:");
Console.WriteLine($"{worldConfigExample.MaxX} is the max x coordinate");
Console.WriteLine($"{worldConfigExample.MaxY} is the max y coordinate");
Console.WriteLine("----------------");
*/
#endregion
World world = new World("ExampleWorld", 10, 10);

#region Creature creation
Creature goblin1 = new Creature(1, "Goblin", 7, new Position(5, 10), new AttackItem("Big Club", 4, 1), new DefenseItem("Leather", 2));
goblin1.Attach(new CreatureObserver());
world.CreatureList.Add(goblin1);

Creature goblin2 = new Creature(2, "Goblin", 7, new Position(6, 10), null, null);
goblin2.Attach(new CreatureObserver());
world.CreatureList.Add(goblin2);

Creature goblin3 = new Creature(3, "Goblin", 20, new Position(7, 10), null, new DefenseItem("Cloth", 1));
goblin3.Attach(new CreatureObserver());
world.CreatureList.Add(goblin3);
#endregion

Console.WriteLine("----------------");

#region Observer
Console.WriteLine("Current creatures in " + world.Name);
foreach (Creature creature in world.CreatureList)
{
    Console.WriteLine(creature.Name);
}
Console.WriteLine("");

goblin2.ReceiveHit(world, goblin1.Hit());
//demonstrates observer, seeing the goblin get to 0 hitpoints
goblin2.ReceiveHit(world, goblin1.Hit());

Console.WriteLine("");
Console.WriteLine("Current creatures in " + world.Name);
foreach (Creature creature in world.CreatureList)
{
    Console.WriteLine(creature.Name);
}
#endregion

Console.WriteLine("----------------");
goblin1.Loot(new AttackItem("Bigger Club", 7, 1));
Console.WriteLine("----------------");

#region Strategy
Console.WriteLine("Goblin with id of 3 has " + goblin3.Hitpoints + "HP");
Console.WriteLine("");

goblin3.ReceiveHit(world, goblin1.Hit()); //should be hit for 6 damage
Console.WriteLine("");

goblin1.ChangeStrategy(new DoubleAttack()); //Sets the attack type to double attack instand of standard attack
Console.WriteLine("");

goblin3.ReceiveHit(world, goblin1.Hit()); //should be hit for 8 damage
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
GhostCreature Phantom1 = new GhostCreature(4, "Phantom", 1, new Position(4, 9), new AttackItem("Lance", 4, 2), new DefenseItem("Spectral Armor", 3));
Phantom1.Attach(new CreatureObserver());
world.CreatureList.Add(Phantom1);

GhostCreature Phantom2 = new GhostCreature(5, "Phantom", 1, new Position(5, 9), null, null);
Phantom2.Attach(new CreatureObserver());
world.CreatureList.Add(Phantom2);

Phantom2.ReceiveHit(world, Phantom1.Hit());

Console.WriteLine("\nCurrent creatures in " + world.Name);
foreach (Creature creature in world.CreatureList)
{
    Console.WriteLine(creature.Name);
}
#endregion

/*
File.Create("Combat-Log.txt").Close();
File.Create("Combat-Log.xml").Close();

TraceSource _trace = new TraceSource("Creature");

_trace.Switch = new SourceSwitch("Creature" + "trace", SourceLevels.All.ToString());

_trace.Listeners.Add(new ConsoleTraceListener());
TraceListener txtLog = new TextWriterTraceListener("Combat-Log.txt");
_trace.Listeners.Add(txtLog);
TraceListener xmlLog = new XmlWriterTraceListener("Combat-Log.xml");
_trace.Listeners.Add(xmlLog);

_trace.TraceEvent(TraceEventType.Information, 1, "SPAWNED");

_trace.Close();
*/