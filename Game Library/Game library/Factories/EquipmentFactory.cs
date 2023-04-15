using Game_library.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Game_library.Factories
{
    public class EquipmentFactory
    {
        public static IEquipment GetEquipment(string type, string name, int value, int range = 0)
        {
            IEquipment equipmentType = null;
            if (type.ToLower().Equals("attack"))
            {
                equipmentType = new AttackItem(name, value, range);
            }
            else if (type.ToLower().Equals("defense"))
            {
                equipmentType = new DefenseItem(name, value);
            }
            return equipmentType;
        }
    }
}
