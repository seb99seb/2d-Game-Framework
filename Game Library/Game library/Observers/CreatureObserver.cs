using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Game_library.Interfaces;

namespace Game_library.Observers
{
    public class CreatureObserver : IObserver
    {
        public void Update(World world, ISubject subject)
        {
            Creature creature = subject as Creature;
            if (creature.Hitpoints == 0)
            {
                //Console.WriteLine($"{creature.Name} has been slayed");
                world.CreatureList.Remove(creature);
            }
        }
    }
}