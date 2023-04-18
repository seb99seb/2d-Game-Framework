using Game_library.Attacks;
using Game_library.Interfaces;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;
using static System.Net.Mime.MediaTypeNames;

namespace Game_library
{
    public class GhostCreature : Creature
    {
        public GhostCreature(int id, string name, int hitpoints, IPosition position, AttackItem? weapon, DefenseItem? defense) : base(id, name, hitpoints, position, weapon, defense) { }
        public override void ReceiveHit(World world, (int damage, IStrategy strat) hitinfo)
        {
            int tempDefStat;
            if (Defense == null)
            {
                tempDefStat = 0;
            }
            else
            {
                tempDefStat = Defense.Armor;
            }
            int hits = 0;
            if (typeof(DoubleAttack).IsInstanceOfType(hitinfo.strat))
            {
                for (int i = 0; i < 2; i++)
                {
                    hits += RNG(tempDefStat, hitinfo.damage);
                }
            }
            else
            {
                hits += RNG(tempDefStat, hitinfo.damage);
            }
            TraceListener txtLog = new TextWriterTraceListener("Combat-Log.txt");
            _trace.Listeners.Add(txtLog);
            TraceListener xmlLog = new XmlWriterTraceListener("Combat-Log.xml");
            _trace.Listeners.Add(xmlLog);
            _trace.TraceEvent(TraceEventType.Information, Id, $"Creature {Id} \"{Name}\" takes {hits} damage");
            _trace.Close();
            Hitpoints -= hits;
            if (Hitpoints < 0)
            {
                Hitpoints = 0;
            }
            Notify(world);
        }
        public int RNG(int tempDefStat, int damage)
        {
            Random rnd = new Random();
            if (tempDefStat < damage)
            {
                if (rnd.Next(1, 5) != 1)
                {
                    //Console.WriteLine("Succes on 75% roll");
                    return 1;
                }
            }
            else if (tempDefStat > damage)
            {
                if (rnd.Next(1, 5) == 1)
                {
                    //Console.WriteLine("Succes on 50% roll");
                    return 1;
                }
            }
            else
            {
                if (rnd.Next(1, 3) == 1)
                {
                    //Console.WriteLine("Succes on 25% roll");
                    return 1;
                }
            }
            return 0;
        }
    }
}
