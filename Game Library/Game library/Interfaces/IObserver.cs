using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Game_library.Interfaces
{
    public interface IObserver
    {
        void Update(World world, ISubject subject);
    }
}
