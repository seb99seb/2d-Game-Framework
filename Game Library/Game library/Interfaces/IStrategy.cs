using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Game_library.Interfaces
{
    public interface IStrategy
    {
        object Attack(object data);
    }
}