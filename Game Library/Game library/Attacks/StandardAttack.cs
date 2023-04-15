using Game_library.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace Game_library.Attacks
{
    public class StandardAttack : IStrategy
    {
        public object Attack(object data)
        {
            AttackItem attackitem = data as AttackItem;
            return attackitem.Damage/*, "single"*/;
        }
    }
}
